using TeplicaBack.Models.TeplicaControllers;

namespace TeplicaBack.Models
{
    public class IndexModel
    {
        public List<Controller> userControllers { get; set; } = null!;
        public List<ControllerModel> buyableModels { get; set; } = null!;
    }
}
