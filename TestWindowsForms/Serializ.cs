using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWindowsForms
{
    class objectList
    {
        public string question { get; set; }
        public string[] answer { get; set; }
    }

    class Serializ
    {
        public objectList[] question_level1 { get; set; }
        public objectList[] question_level2 { get; set; }
    }

    class ObjectSettings
    {
        public int NumberQuestion1 { get; set; }
        public int NumberQuestion2 { get; set; }
        public int SUCCESSFUL { get; set; }
        public int GOOD { get; set; }
        public int NORMAL { get; set; }
    }
}
