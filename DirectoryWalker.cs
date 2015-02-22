using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using senukaiDeployTool.Interface;
using System.IO;

namespace senukaiDeployTool
{
    class DirectoryWalker : IDirectoryWalker
    {
        private IFileActioner oFileActioner;
        private string source_path;


        public DirectoryWalker(String source_path, IFileActioner oFileActioner)
        {
            this.source_path = source_path;
            this.oFileActioner = oFileActioner;
        }


        public void start()
        {
            String sStartPoint = this.source_path;
            this.walk(sStartPoint);
        }

        private void walk( String sDir )
        {
            string[] aFiles = Directory.GetFiles(sDir);
            string[] aDirs = Directory.GetDirectories(sDir);


            foreach ( String sFile in aFiles )
                this.oFileActioner.actionWithFile(sFile);

            foreach (String aDir in aDirs)
            {
               bool bWalk = this.oFileActioner.actionWithDirectory(aDir);

               if (bWalk) this.walk(aDir);
            }
            
        }

        public void setActioner(IFileActioner oFileActioner)
        {
            this.oFileActioner = oFileActioner;
        }
    }
}
