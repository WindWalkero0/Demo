using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexOfDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string iWeight;
            string PCS;
            string weight = "NET:   0.000 kgPCS:        1";
            weight.Replace(" ", "1");
            int iNET = weight.IndexOf("NET");
            int iPCS = weight.IndexOf("PCS");
            string str = string.Format(@"SN.00003
2
NET: 6.895 kg
U / W:  286.927  g
  PCS:       24

");
            string[] strArr = str.Split('\n');

            Console.WriteLine(weight.Substring(0, iPCS));
            Console.WriteLine(weight.IndexOf("/"));
            iWeight = weight.Substring(iNET + 4, iPCS - iNET - 4).Trim(' ');
            PCS = weight.Substring(iPCS + 4, weight.Length - iPCS - 4).Trim(' ');
            Console.WriteLine(iNET);
            Console.WriteLine(iPCS);
            Console.WriteLine(iWeight);
            Console.WriteLine(PCS);
            Console.WriteLine(str.LastIndexOf(" ").ToString());
            Console.ReadKey();
        }
    }
}
