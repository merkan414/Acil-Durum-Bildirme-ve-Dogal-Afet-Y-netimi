using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGAD.Models
{
    public partial class IMAGEPATH
    {

        public int Id { get; set; }
        public int AGAD_ID { get; set; }
        public string PATH { get; set; }
        public virtual AGAD AGAD_ { get; set; }
        
    }
}