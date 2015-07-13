using System;
using System.Collections.Generic;

namespace AGAD.Models
{
    public partial class AGAD
    {

        public AGAD()
        {
            this.ImagePATHS = new List<IMAGEPATH>();
            this.STARTDATE = DateTime.Now;
            this.ENDDATE = DateTime.Now;
            this.CITY = 1;
            this.TOWN = 1;
            this.CONFIRMSTATEID = (int)CONFIRMSTATEENUM.NOTACCEPTED;
            this.USER_TC = "12345678911";
            this.VILLAGE = "-";
            this.REGION = "-";
            this.DISTINCT_REGION = "-";
            
     
        }

        public int Id { get; set; }
        public int AGADTYPE { get; set; }
        public Nullable<DateTime> STARTDATE { get; set; }
        public Nullable<DateTime> ENDDATE { get; set; }
        public int CITY { get; set; }
        public int TOWN { get; set; }
        public string VILLAGE { get; set; }
        public string DISTINCT_REGION { get; set; }
        public string REGION { get; set; }
        public string COMMENT { get; set; }
        public string EFFECTTEDAREA { get; set; }
   
        public int CONFIRMSTATEID { get; set; }
        public string CONFIRMCOMMENT { get; set; }
        public string USER_TC { get; set; }
        public virtual AGADTYPE AGADTYPE_Item { get; set; }
        public virtual CITY CITY_Item { get; set; }
        public virtual CONFIRMSTATE CONFIRMSTATE_Item { get; set; }
        public virtual TOWN TOWN_Item { get; set; }
        public virtual USER USER_Item { get; set; }
        public virtual ICollection<IMAGEPATH> ImagePATHS { get; set; }
    }
}
