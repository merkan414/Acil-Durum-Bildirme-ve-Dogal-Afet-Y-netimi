using System;
using System.Collections.Generic;

namespace AGAD.Models
{
    public partial class CONFIRMSTATE
    {
        public CONFIRMSTATE()
        {
            this.AGADs = new List<AGAD>();
        }

        public int Id { get; set; }
        public string NAME { get; set; }
        public string NAMEUNICODE { get; set; }
        public virtual ICollection<AGAD> AGADs { get; set; }
    }
}
