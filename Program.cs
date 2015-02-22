using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace senukaiDeployTool
{
    class Program
    {
        static int SOURCE_PATH = 0;
        static int LIVE_PATH = 1;
        static int BACKUP_PATH = 2;

        static string source_path;
        static string live_path;
        static string backup_path;


        static void Main(string[] args)
        {
            

            try
            {
                init();

                FileBackupActioner oFBA = new FileBackupActioner(source_path, live_path, backup_path);

                DirectoryWalker oDW = new DirectoryWalker(source_path, oFBA);
                oDW.start();

                FileDeployActioner oFDA = new FileDeployActioner(source_path, live_path);
                oDW.setActioner(oFDA);
                oDW.start();
                

            }
            
            catch (Exception exp) 
            {
                System.Console.WriteLine(" ERROR: " + exp.Message);
                System.Console.ReadLine();
            }
            System.Console.WriteLine("Finish");
            System.Console.ReadLine();

        }


        private static void init()
        {
            FileReader oFR = new FileReader();
            String[] aPaths = oFR.readConfigFile();

            if ( aPaths.Length != 3 )
                throw new Exception("Bad config file params count: " + aPaths.Length);

            if ( !Directory.Exists(aPaths[SOURCE_PATH]) )
                throw new Exception("Source directory not found " + aPaths[SOURCE_PATH]);

            if (!Directory.Exists(aPaths[LIVE_PATH]))
                throw new Exception("Source directory not found " + aPaths[LIVE_PATH]);

            if (!Directory.Exists(aPaths[BACKUP_PATH]))
                throw new Exception("Source directory not found " + aPaths[BACKUP_PATH]);

            source_path = aPaths[SOURCE_PATH];
            live_path = aPaths[LIVE_PATH];
            backup_path = aPaths[BACKUP_PATH];
        }
    }
}
