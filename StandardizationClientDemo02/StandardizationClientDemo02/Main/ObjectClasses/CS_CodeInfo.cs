using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardizationClientDemo02.ProductionReality.ObjectClasses
{
    public class CS_CodeInfo
    {
        public int NumberOne { get; set; }
        public int NumberTwo { get; set; }
        public int NumberThree { get; set; }
        public string OneLevel { get; set; }
        public string TwoLevel { get; set; }
        public string ThreeLevel { get; set; }

        public CS_CodeInfo(int numberOne, int numberTwo, int numberThree, string oneLevel, string twoLevel, string threeLevel)
        {
            this.NumberOne = numberOne;
            this.NumberTwo = numberTwo;
            this.NumberThree = numberThree;
            this.OneLevel = oneLevel;
            this.TwoLevel = twoLevel;
            this.ThreeLevel = threeLevel;
        }
    }
}
