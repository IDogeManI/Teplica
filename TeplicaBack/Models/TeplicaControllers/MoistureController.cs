namespace TeplicaBack.Models.TeplicaControllers
{
    public class MoistureController : Controller
    {
        public MoistureController(Guid id, string userLogin, string controllerType) : base(id, userLogin, controllerType)
        {
        }
        public float NeededMoisture { get; set; }

        public override void ChangeProperties(string[] properties)
        {
            NeededMoisture = float.Parse(properties[1]);
        }

        public override List<string> GetProperties()
        {
            List<string> properties = new List<string>();
            properties.Add(NeededMoisture.ToString());
            return properties;
        }

        public override string Ping(string value)
        {
            SetValue(float.Parse(value));
            return "NeededMoisture=" + NeededMoisture;
        }
    }
}
