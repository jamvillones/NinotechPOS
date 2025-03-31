using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;

[RunInstaller(true)]
public class MyInstaller : Installer
{

    //public override void Commit(System.Collections.IDictionary savedState)
    //{
    //    base.Commit(savedState);

    //    try
    //    {
    //        //System.Diagnostics.Process.Start(System.IO.Path.GetDirectoryName(this.Context.Parameters["AssemblyPath"]) + @"\NinotechPOS.exe");
    //        Process.Start(Context.Parameters["assemblypath"] + "NinotechPOS.exe");
    //    }
    //    catch (Exception ex)
    //    {
    //        // Log the error or show a message if needed
    //        System.Windows.Forms.MessageBox.Show("Error launching application: " + ex.Message);
    //    }
    //}

    //public override void Install(IDictionary stateSaver)
    //{
    //    base.Install(stateSaver);

    //    try
    //    {
    //        // Get the target installation directory
    //        string targetDir = Context.Parameters["targetdir"];

    //        if (!string.IsNullOrEmpty(targetDir) && Directory.Exists(targetDir))
    //        {
    //            string exePath = Path.Combine(targetDir, "NinotechPOS.exe");

    //            if (File.Exists(exePath))
    //            {
    //                Process.Start(exePath);
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine("Error launching application: " + ex.Message);
    //    }
    //}

    public override void Commit(System.Collections.IDictionary savedState)
    {
        base.Commit(savedState);

        try
        {
            // Get the target installation directory
            string targetDir = "C:\\Program Files\\Niñotech\\Niñotech POS\\";

            if (!string.IsNullOrEmpty(targetDir) && Directory.Exists(targetDir))
            {
                string exePath = Path.Combine(targetDir, "NinotechPOS.exe");

                if (File.Exists(exePath))
                {
                    Process.Start(exePath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error launching application: " + ex.Message);
        }
    }
}
