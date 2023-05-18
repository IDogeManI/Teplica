namespace TeplicaBack.Models.TeplicaControllers
{
    public class TemperatureController : Controller
    {
        public TemperatureController(Guid id, string userLogin, string controllerType) : base(id, userLogin, controllerType)
        {
        }
        public int PingTimeInSeconds { get; set; }
        public float TemperatureToStartHeat { get; set; }
        public float TemperatureToEndHeat { get; set; }
        public float TemperatureToStartCold { get; set; }
        public float TemperatureToEndCold { get; set; }
        public float CriticalHighTemperature { get; set; }
        public float CriticalLowTemperature { get; set; }

        public override void ChangeProperties(string[] properties)
        {
            PingTimeInSeconds = int.Parse(properties[1]);
            TemperatureToStartHeat = float.Parse(properties[2]);
            TemperatureToEndHeat = float.Parse(properties[3]);
            TemperatureToStartCold = float.Parse(properties[4]);
            TemperatureToEndCold = float.Parse(properties[5]);
            CriticalHighTemperature = float.Parse(properties[6]);
            CriticalLowTemperature = float.Parse(properties[7]);
        }

        public override List<string> GetProperties()
        {
            List<string> properties = new List<string>();
            properties.Add(PingTimeInSeconds.ToString());
            properties.Add(TemperatureToStartHeat.ToString());
            properties.Add(TemperatureToEndHeat.ToString());
            properties.Add(TemperatureToStartCold.ToString());
            properties.Add(TemperatureToEndCold.ToString());
            properties.Add(CriticalHighTemperature.ToString());
            properties.Add(CriticalLowTemperature.ToString());
            return properties;
        }

        public override string Ping(string value)
        {
            SetValue(float.Parse(value));
            return "PingTimeInSeconds=" + PingTimeInSeconds+ "&TemperatureToStartHeat="+ TemperatureToStartHeat
                + "&TemperatureToEndHeat=" + TemperatureToEndHeat + "&TemperatureToStartCold=" + TemperatureToStartCold
                + "&TemperatureToEndCold=" + TemperatureToEndCold + "&CriticalHighTemperature=" + CriticalHighTemperature
                + "&CriticalLowTemperature=" + CriticalLowTemperature;
        }
    }
}
