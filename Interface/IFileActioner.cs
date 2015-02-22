using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace senukaiDeployTool.Interface
{
    interface IFileActioner
    {
        bool actionWithFile(String sPath);
        bool actionWithDirectory(String sPath);
    }
}
