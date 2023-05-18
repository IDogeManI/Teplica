using TeplicaBack.Models.TeplicaControllers;

namespace TeplicaBack.Models
{
    public class HomeIndexModel
    {
        public List<ControllerModel> ControllerModels { get; set; } = new();
        public List<Controller> Controllers { get; set; } = new();
    }
}
