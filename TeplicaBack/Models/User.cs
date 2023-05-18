

using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TeplicaBack.Models.TeplicaControllers;

namespace TeplicaBack.Models
{
    public class User
    {
        [Key]
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }

        public List<ControllerModel> Controllers { get; set; }

        public User(string login,string password) 
        { 
            Login = login;
            Password = password;
            Controllers = new List<ControllerModel>();
        }

    }
}
