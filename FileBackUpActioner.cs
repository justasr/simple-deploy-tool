using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using senukaiDeployTool.Interface;
using System.IO;

namespace senukaiDeployTool
{
    class FileBackupActioner : IFileActioner
    {
        public string source_path;
        public string live_path;
        public string backup_path;

        public FileBackupActioner(string source_path, string live_path, string backup_path)
        {
            this.source_path = source_path;
            this.live_path = live_path;
            this.backup_path = this.genBackupPath(backup_path);
        }

        public bool actionWithFile( String sPath )
        {
            String sLivePath = sPath.Replace(source_path, live_path);
            String sBackupPath = sPath.Replace(source_path, backup_path);

            //Jei Live egzistuoja kuriam backup'a
            if (File.Exists(sLivePath))
                File.Copy(sLivePath, sBackupPath,true);
            

            return true;
        }

        public bool actionWithDirectory(String sPath)
        {
            String sLivePath = sPath.Replace(source_path, live_path);
            String sBackupPath = sPath.Replace(source_path, backup_path);

            //Jei Live egzistuoja kuriam backup'a
            if (Directory.Exists(sLivePath))
                Directory.CreateDirectory(sBackupPath);
            else
                return false;

            return true;
        }

        private string genBackupPath(String backupPath)
        {
            String sFolder = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            backupPath = Path.Combine(backupPath, sFolder);

            if (!Directory.Exists(backupPath))
            {
                Directory.CreateDirectory(backupPath);
            }
            else
            {
                throw new Exception("Backup directories collition, tried to override backup: " + backupPath);
            }

            return backupPath;
        }
    }
}
