using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TeplicaBack.Models
{
    public class ControllerModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public float Price { get; set; }

        public string? UserLogin { get; set; }
        [Required]
        public string ControllerType { get; set; }
        public ControllerModel(float price, string controllerType)
        {
            Id = Guid.NewGuid();
            Price = price;
            ControllerType = controllerType;
        }
    }
}
