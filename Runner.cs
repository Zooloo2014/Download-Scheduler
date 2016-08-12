using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace NDM
{
    abstract public class Runner
    {
        public abstract void Start();


        protected double progress;
        public double Progress 
        {
            get
            {
                return progress;
            }
            protected set
            {
                progress = value;
            }
        }

        
        private string downloadDir;
        public string DownloadDir
        {
            get
            {
                if (downloadDir.EndsWith(@"\"))
                    return downloadDir.Substring(0, downloadDir.Length - 1);
                else
                    return downloadDir;
            }
            set
            {
                if (value == String.Empty)
                    downloadDir = value;
                else
                    if (value.EndsWith(@"\"))
                        downloadDir = value;
                    else
                        downloadDir = value + @"\";
            }
        }


        protected void RenameFile(string oldName, string newName)
        {
            if (File.Exists(newName))
                File.Delete(newName);

            File.Move(oldName, newName);
        }


        protected void DeleteFile(string name)
        {
            if (File.Exists(name))
                File.Delete(name);
        }
    }
}
