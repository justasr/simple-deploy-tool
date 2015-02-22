using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using senukaiDeployTool.Interface;
using System.IO;


namespace senukaiDeployTool
{
    class FileDeployActioner : IFileActioner
    {
        public string source_path;
        public string live_path;

        public FileDeployActioner(string source_path, string live_path)
        {
            this.source_path = source_path;
            this.live_path = live_path;
        }

        public bool actionWithFile(String sPath)
        {
            String sLivePath = sPath.Replace(source_path, live_path);
            File.Copy(sPath, sLivePath, true);
       
            return true;
        }

        public bool actionWithDirectory(String sPath)
        {
            String sLivePath = sPath.Replace(source_path, live_path);

            //Jei Live egzistuoja kuriam backup'a
            if (!Directory.Exists(sLivePath))
                Directory.CreateDirectory(sLivePath);

            return true;
        }

    }
}
