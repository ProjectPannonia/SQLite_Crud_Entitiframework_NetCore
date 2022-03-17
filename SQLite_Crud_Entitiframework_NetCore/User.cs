using System.ComponentModel.DataAnnotations;

namespace SQLite_Crud_Entitiframework_NetCore
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}