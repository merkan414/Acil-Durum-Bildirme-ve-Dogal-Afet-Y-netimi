using System;
using System.Collections.Generic;

namespace AGAD.Models
{
    [Serializable]
    public partial class AGADTYPE
    {
        public AGADTYPE()
        {
            this.AGADs = new List<AGAD>();
        }

        public int Id { get; set; }
        public string NAME { get; set; }
        public string NAMEUNICODE { get; set; }
        public virtual ICollection<AGAD> AGADs { get; set; }
    }
}
