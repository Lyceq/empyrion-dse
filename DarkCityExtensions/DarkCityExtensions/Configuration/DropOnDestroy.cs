using System;
using System.IO;

namespace DarkCity.Configuration
{
    class DropOnDestroy
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public float Probability { get; set; }

        public DropOnDestroy() { }

        public DropOnDestroy(StreamReader config)
        {
        }
    }
}
