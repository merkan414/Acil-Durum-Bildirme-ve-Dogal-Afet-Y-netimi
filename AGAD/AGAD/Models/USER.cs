using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AGAD.Models
{
    public partial class USER
    {
        public USER()
        {
            this.AGADs = new List<AGAD>();
        }

        public string TC { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        [Required(ErrorMessage = "Email Adresi Giriniz")]
        [DataType(DataType.EmailAddress,ErrorMessage="Ge�erli Email Adresi Giriniz")]
        public string EMAIL { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [MinLength(6,ErrorMessage="En az 6 karakter olmal�")]
        public string PASS { get; set; }
        public string ADRES { get; set; }
        public string PHONE { get; set; }
        public virtual ICollection<AGAD> AGADs { get; set; }

        
    }
}
