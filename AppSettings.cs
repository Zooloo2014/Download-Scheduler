using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDM
{
    abstract public class AppSettings
    {
        protected bool dirty;


        protected string defaultDirectory;
        public string DefaultDirectory
        {
            get
            {
                return defaultDirectory;
            }
            set
            {
                defaultDirectory = value;
                dirty = true;
            }
        }


        public AppSettings()
        {
        }


        ~AppSettings()
        {
            if (dirty)
                Save();
        }

        
        public void Load()
        {
            Read();
            dirty = false;
        }


        protected abstract void Read();


        public void Save()
        {
            Write();
            dirty = false;
        }

        
        protected abstract void Write();
    }
}
