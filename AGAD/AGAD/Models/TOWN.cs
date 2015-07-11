using System;
using System.Collections.Generic;

namespace AGAD.Models
{
    public partial class TOWN
    {
        public TOWN()
        {
            this.AGADs = new List<AGAD>();
        }

        public int ID { get; set; }
        public int CITY_ID { get; set; }
        public string NAME { get; set; }
        public virtual ICollection<AGAD> AGADs { get; set; }
    }
}
