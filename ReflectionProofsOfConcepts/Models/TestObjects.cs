using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionProofsOfConcepts.Models
{
    public class ConsumingObj
    {
        public object innerObj { get; set; }
    }

    public class ObjWithNamedProps
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ObjWithList
    {
        public List<string> Names { get; set; }
    }

    public class ObjWithAttributedProps
    {
        [DisplayName("Name Of")]
        public string Name { get; set; }
        [Bindable(false)]
        public string Description { get; set; }
    }


}
