namespace TeplicaBack.Models.TeplicaControllers
{
    public class IlluminationController : Controller
    {
        public IlluminationController(Guid id, string userLogin, string controllerType) : base(id, userLogin, controllerType)
        {
        }
        public int TimeOfDayInSeconds { get; set; }

        public override void ChangeProperties(string[] properties)
        {
            TimeOfDayInSeconds = int.Parse(properties[1]);
        }

        public override List<string> GetProperties()
        {
            List<string> properties = new List<string>();
            properties.Add(TimeOfDayInSeconds.ToString());
            return properties;
        }

        public override string Ping(string value)
        {
            SetValue(float.Parse(value));
            return "TimeOfDayInSeconds=" + TimeOfDayInSeconds;
        }
    }
}
