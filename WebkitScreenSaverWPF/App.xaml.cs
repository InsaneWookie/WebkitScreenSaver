using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WebkitScreenSaverWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //TODO: show a setting dialog to select the url if one isnt supplied on the command line
            string url = "google.com";
            if (e.Args.Length > 0)
            {
                url = e.Args[0];
            }

            new MainWindow(url).ShowDialog();

            this.Shutdown();
        }
    }
}
