using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Окружение
    /// </summary>
    public class Environtment
    {
        Device device = new Device();

        /// <summary>
        /// Устройство
        /// </summary>
        public Device Device
        {
            get => device;
            set => device = value;
        }

        Application application = new Application();

        /// <summary>
        /// Браузер
        /// </summary>
        public Application Application
        {
            get => application;
            set => application = value;
        }

        Browser browser = new Browser();

        /// <summary>
        /// Браузер
        /// </summary>
        public Browser Browser
        {
            get => browser;
            set => browser = value;
        }

        public override string ToString()
        {
            string result = $"Приложение: \"{Application.Name}\" с версией \"{Application.Version}\" \n" +
                $"Устройство: \"{Device.Name}\" с операционной системой \"{Device.OperationSystem}\"";

            if (Browser.Use)
            {
                result += $"\nБраузер: \"{Browser.Name}\" с версией \"{Browser.Version}\"";
            }
            return result;
        }
    }
}
