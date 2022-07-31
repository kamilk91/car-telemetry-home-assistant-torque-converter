using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterForTorqe
{
    public class Descriptor
    {
        public string type { get; set; }
        public string entity { get; set; }
        public string attribute { get; set; }
        public string name { get; set; }
    }

    public class DescriptorCollection
    {
        public List<Descriptor> descriptors { get; set; }
    }
}
