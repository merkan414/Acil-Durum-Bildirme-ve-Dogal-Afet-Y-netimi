using System;
using System.Collections.Generic;

namespace AGAD.Models
{
    public partial class AGAD
    {
        public int Id { get; set; }
        public int AGADTYPE { get; set; }
        public System.DateTime STARTDATE { get; set; }
        public System.DateTime ENDDATE { get; set; }
        public int TIME { get; set; }
        public int IL { get; set; }
        public int ILCESEMT { get; set; }
        public string KOY { get; set; }
        public string MAHALLE { get; set; }
        public string BELDEMEVKI { get; set; }
        public string LATITUDE { get; set; }
        public string LONGITUDE { get; set; }
        public string COMMENT { get; set; }
        public string EFFECTTEDAREA { get; set; }
        public string IMAGEPATH { get; set; }
        public int CONFIRMSTATEID { get; set; }
        public string CONFIRMCOMMENT { get; set; }
        public Nullable<int> USER_ID { get; set; }
        public virtual AGADTYPE AGADTYPE1 { get; set; }
        public virtual CITY CITY { get; set; }
        public virtual CONFIRMSTATE CONFIRMSTATE { get; set; }
        public virtual TOWN TOWN { get; set; }
    }
}
