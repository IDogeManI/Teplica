using System.Reflection;

namespace TeplicaBack.Models.TeplicaControllers
{
    public class ControllerFactory
    {
        public ControllerFactory()
        {

        }

        public Controller? GetController(ControllerModel controllerModel)
        {
            var a = Assembly.GetExecutingAssembly().GetTypes().Where(x => (x.FullName ?? "")
                .Contains("TeplicaBack.Models.TeplicaControllers"))
                .FirstOrDefault(x => x.Name == controllerModel.ControllerType + "Controller");
            if (a == null)
                return null;
            return (Controller?)Activator.CreateInstance(a, controllerModel.Id, controllerModel.UserLogin, controllerModel.ControllerType);
        }
    }
}
