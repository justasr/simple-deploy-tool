using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace senukaiDeployTool
{
    class FileReader
    {
        String sConfigPath;
        public FileReader( String sConfigFilename = "config.txt" )
        {
            String sAppDir = AppDomain.CurrentDomain.BaseDirectory;
            this.sConfigPath = sAppDir + sConfigFilename;


            if (!File.Exists(this.sConfigPath))
                throw new Exception("Bad Config File Path: " + sConfigPath);
        }

        public string[] readConfigFile()
        {
            List<string> aLines = new List<string>();

            StreamReader oConfigFile =  new StreamReader(this.sConfigPath);
            string[] lines = File.ReadAllLines(this.sConfigPath);
            string sLine;
            while ((sLine = oConfigFile.ReadLine()) != null)
                aLines.Add(sLine);

            oConfigFile.Close();

            return aLines.ToArray();
        }
    }
}
