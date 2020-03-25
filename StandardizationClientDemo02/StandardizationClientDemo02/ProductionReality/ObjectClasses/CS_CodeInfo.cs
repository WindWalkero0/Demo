using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardizationClientDemo02.ProductionReality.ObjectClasses
{
    public class CS_CodeInfo
    {
        public int Number { get; set; }
        public string OneLevel { get; set; }
        public string TwoLevel { get; set; }
        public string ThreeLevel { get; set; }

        public CS_CodeInfo(int number, string oneLevel, string twoLevel, string threeLevel)
        {
            this.Number = number;
            this.OneLevel = oneLevel;
            this.TwoLevel = twoLevel;
            this.ThreeLevel = threeLevel;
        }
    }
}
