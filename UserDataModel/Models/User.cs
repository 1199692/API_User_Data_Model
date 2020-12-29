using System;
using System.ComponentModel.DataAnnotations;

//Data Model for table "Users"
namespace UserDataModel.Models
{
    public class User
    {
        [Key]
        //<Summary>Unique user identifier</Summary>
        public int Id { get; set; }
        
        public int Version { get; set; }

        [MaxLength(50, ErrorMessage ="Name can be 50 characters long")]
        public string Name { get; set; }
    }
}

//Data Model for table "Units"
namespace UnitDataModel.Models
{
    public class Unit
    {
        [Key]
        ///<Summary>Unique unit identifier</Summary>
        public int Id { get; set; }

        public int Version { get; set; }

        [MaxLength(60, ErrorMessage = "Name can be 60 characters long")]
        public string Name { get; set; }
    }
}

//Data Model for table "Roles"
namespace RoleDataModel.Models
{
    public class Role
    {
        [Key]
        ///<Summary>Unique Role identifier</Summary>
        public int Id { get; set; }

        public int Version { get; set; }

        [MaxLength(50, ErrorMessage = "Name can be 50 characters long")]
        public string Name { get; set; }
    }

}

//Data Model for table User Role "URoles" 
namespace URoleDataModel.Models
{
    public class URole
    {
        [Key]
        ///<Summary>Unique User Role identifier</Summary>
        public int Id { get; set; }

        [Required]
        public int Version { get; set; }

        public int UserId { get; set; }

        public int UnitId { get; set; }

        public int RoleId { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }
    }

}