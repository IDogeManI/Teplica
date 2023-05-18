using TeplicaBack.Models;
using TeplicaBack.Models.TeplicaControllers;

namespace TeplicaBack.Logic
{
    public class ControllersService
    {
        public List<Controller> ControllerList { get; set; } = new();
        public ControllerFactory ControllerFactory { get; set; } = new();
        public ControllersService() { }

        public Controller? AddAndGetController(ControllerModel controller)
        {
            AddController(controller);
            return FindControllerById(controller.Id);
        }
        public List<Controller> AddAndGetAllControllers(IEnumerable<ControllerModel> controllers)
        {
            List<Controller> tmp = new List<Controller>();
            foreach (var controller in controllers)
            {
                AddController(controller);
                var a = FindControllerById(controller.Id);
                if (a == null)
                    continue;
                tmp.Add(a);
            }
            return tmp;
        }
        public void Regroup(Guid id, int group)
        {
            var tmp = FindControllerById(id);
            if (tmp == null)
                return;
            tmp.Group = group;
        }
        public void ChangeProperties(string[] properties)
        {
            var tmp = FindControllerById(Guid.Parse(properties[0]));
            if (tmp == null)
                return;
            tmp.ChangeProperties(properties);
        }
        public Controller? FindControllerById(Guid id)
            => ControllerList.FirstOrDefault(x => x.Id == id);
        public bool AddController(Controller controller)
        {
            foreach (var item in ControllerList)
                if (item.Id == controller.Id)
                    return false;

            ControllerList.Add(controller);
            return true;
        }
        public bool AddController(ControllerModel controller)
        {
            var tmp = GetController(controller);
            if (tmp == null)
                return false;
            return AddController(tmp);
        }
        public string Ping(Guid id, string value)
        {
            var tmp = FindControllerById(id);
            if (tmp == null)
                return "";
            return tmp.Ping(value);
        }
        private Controller? GetController(ControllerModel controller)
            => ControllerFactory.GetController(controller);
    }
}
