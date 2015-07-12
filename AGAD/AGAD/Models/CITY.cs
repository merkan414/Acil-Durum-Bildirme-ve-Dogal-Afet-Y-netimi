using System;
using System.Collections.Generic;

namespace AGAD.Models
{
    public partial class CITY
    {
        public CITY()
        {
            this.AGADs = new List<AGAD>();
        }

        public int Id { get; set; }
        public string NAME { get; set; }
        public virtual ICollection<AGAD> AGADs { get; set; }
    }
}
