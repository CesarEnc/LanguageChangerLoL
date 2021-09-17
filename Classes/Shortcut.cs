using System;
using IWshRuntimeLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LanguageChangerLoL.Classes
{
    public class Shortcut
    {
        public string LeaguePath { get; set; }
        public string Language { get; set; }

        public string Path = null;

        public Shortcut(string leaguePath, string language)
        {
            LeaguePath = leaguePath;
            Language = language;
        }

        public void Create()
        {

            WshShell wsh = new WshShell();
            Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $@"\LoLIn{Language}.lnk";
            IWshRuntimeLibrary.IWshShortcut shortcut = wsh.CreateShortcut(Path) as IWshRuntimeLibrary.IWshShortcut;
            
            shortcut.TargetPath = LeaguePath;
            shortcut.Arguments = $"--locale={Language}";
            shortcut.Description = "Mordekaiser Numero UNO";
            try
            {
                shortcut.Save();
            }
            catch (Exception)
            {

                throw new Exception("Shortcut couldn't be created.");
            }
        }
        public void Run()
        {
            if(Path!= null)
            {
                Process.Start(new ProcessStartInfo(Path) { UseShellExecute = true });
            }
            else
            {
                throw new Exception("This shortcut has not been created.");
            }
        }
        public void Delete()
        {
            if(Path != null)
            {
                System.IO.File.Delete(Path);
            }
            else
            {
                throw new Exception("This shortcut has not been created.");
            }
        }
    }
}
