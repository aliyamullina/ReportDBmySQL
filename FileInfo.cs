using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportDBmySQL
{
    class FileInfo
    {
        public FileInfo(string Path)
        {
            this.Path = Path;
        }
        public string Path { get; private set; }
    }
}
