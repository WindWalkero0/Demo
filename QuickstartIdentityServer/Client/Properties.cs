using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Properties
    {
        public string Code { get; set; }

        public string Message { get; set; }
        public List<Assemblage>[] Data { get; set; }
    }

    public class Assemblage
    {
        public string type { get; set; }
        public string value { get; set; }
        //public string iss { get; set; }
        //public string aud { get; set; }
        //public string client_id { get; set; }
        //public string scope { get; set; }
    }
}
