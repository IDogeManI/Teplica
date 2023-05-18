using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace TeplicaBack.Models.TeplicaControllers
{
    public abstract class Controller
    {
        public Guid Id { get; set; }
        public string UserLogin { get; set; }
        public int Group { get; set; } = 0;
        public string ControllerType { get; set; }
        public float CurrentValue { get; set; }
        private bool isPinged = false;
        private object locker = new object();
        private int WorkTime { get; set; } = 0;
        public List<(float, int)> AllValuesWithTime { get; set; } = new();

        public Controller(Guid id, string userLogin, string controllerType)
        {
            AllValuesWithTime.Add((10, 0));
            AllValuesWithTime.Add((12130, 1));
            AllValuesWithTime.Add((14440, 2));
            AllValuesWithTime.Add((150, 30));
            AllValuesWithTime.Add((160, 40));
            AllValuesWithTime.Add((1320, 50));
            AllValuesWithTime.Add((1120, 60));
            AllValuesWithTime.Add((170, 70));
            AllValuesWithTime.Add((120, 80));
            Id = id;
            UserLogin = userLogin;
            ControllerType = controllerType;
        }
        private async void WorkTimer()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    lock (locker)
                    {
                        WorkTime++;
                    }
                }
            });
        }
        protected void SetValue(float value)
        {
            if (!isPinged)
            {
                WorkTimer();
                isPinged = true;
            }
            CurrentValue = value;
            lock (locker)
            {
                AllValuesWithTime.Add((CurrentValue, WorkTime));
            }
        }
        public abstract void ChangeProperties(string[] properties);
        public abstract string Ping(string value);
        public abstract List<string> GetProperties();
    }
}
