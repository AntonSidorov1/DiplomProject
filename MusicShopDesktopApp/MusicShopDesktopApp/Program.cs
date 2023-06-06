using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicShopDesktopApp
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = assembly.GetName();
            Helper.Environtment.Application.Name = assemblyName.Name;
            Helper.Environtment.Application.Version = assemblyName.Version.ToString(4);

            OperatingSystem operatingSystem = Environment.OSVersion;
            PlatformID platformID = operatingSystem.Platform;

            Helper.Environtment.Device.OperationSystem = platformID.ToString() + " " + operatingSystem.Version.ToString(4);
            Helper.Environtment.Device.Name = Environment.MachineName;

            Helper.Environtment.Browser.Use = false;


            try
            {
                Helper.OpenEnvirontmentSession();
            }
            catch
            {

            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ProductsForm());
        }
    }
}
