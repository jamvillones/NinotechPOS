using Newtonsoft.Json;
using System.Windows.Forms;

namespace POS.Misc
{
    public class WindowConfiguration
    {
        public static WindowConfiguration Instance { get; set; }
        public FormWindowState WindowState { get; set; }


        public static void Initialize()
        {
            var settings = Properties.Settings.Default;

            Instance = JsonConvert.DeserializeObject<WindowConfiguration>(settings.WindowConfiguration) ?? new WindowConfiguration();
        }
    }
}
