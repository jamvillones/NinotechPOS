using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;

[RunInstaller(true)]
public class MyInstaller : Installer
{

    public override void Commit(System.Collections.IDictionary savedState)
    {
        base.Commit(savedState);

        try
        {
            // Get the full path of the installed application
            string appPath = Context.Parameters["assemblypath"];

            // Start the application
            Process.Start(appPath);
        }
        catch (Exception ex)
        {
            // Log the error or show a message if needed
            System.Windows.Forms.MessageBox.Show("Error launching application: " + ex.Message);
        }

    }
}
