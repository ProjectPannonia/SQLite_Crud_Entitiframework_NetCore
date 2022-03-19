using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace SQLite_Crud_Entitiframework_NetCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<User> DatabaseUsers { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Create()
        {
            using(DataContext context = new DataContext())
            {
                var name = NameTextBox.Text;
                var address = AddressTextBox.Text;

                if(name != null && address != null)
                {
                    context.Users.Add(new User() { Name = name, Address = address });
                    context.SaveChanges();
                }
                
            }
        }
        public void Read()
        {
            using (DataContext context = new DataContext())
            {
                DatabaseUsers = context.Users.ToList();
                ItemList.ItemsSource = DatabaseUsers;
            }
        }
        public void Update()
        {
           using(DataContext context = new DataContext())
           {
                User selectedUser = ItemList.SelectedItem as User;

                var name = NameTextBox.Text;
                var address = AddressTextBox.Text;

                if(name != null && address != null)
                {
                    User user = context.Users.Find(selectedUser.Id);
                    
                    user.Name = name;
                    user.Address = address;

                    context.SaveChanges();
                }
           }
        }
        public void Delete()
        {
            using (DataContext context = new DataContext())
            {
                User selectedUser = ItemList.SelectedItem as User;

                if(selectedUser != null)
                {
                    User user = context.Users.Single(x => x.Id == selectedUser.Id);

                    context.Remove(user);
                    context.SaveChanges();
                }
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Create();
            Read();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Update();
            Read();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delete();
            Read();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ItemList.Items.Clear();
        }
    }
}
