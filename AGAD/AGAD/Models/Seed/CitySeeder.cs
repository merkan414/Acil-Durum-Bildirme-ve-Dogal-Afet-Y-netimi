using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AGAD.Models.Seed
{
    public class CitySeeder : DropCreateDatabaseAlways<agadContext>
    {
        protected override void Seed(agadContext context)
        {
            var list = new List<CITY>
            {
                new CITY{ID=1,NAME="Adana"},
                new CITY{ID=2,NAME="Adiyaman"},
                new CITY{ID=3,NAME="Afyon"},
                new CITY{ID=4,NAME="Ağri"},
                new CITY{ID=5,NAME="Amasya"},
                new CITY{ID=6,NAME="Ankara"},
                new CITY{ID=7,NAME="Antalya"},
                new CITY{ID=8,NAME="Artvin"},
                new CITY{ID=9,NAME="Aydin"},
                new CITY{ID=10,NAME="Balikesir"},
                new CITY{ID=11,NAME="Bilecik"},
                new CITY{ID=12,NAME="Bingöl"},
                new CITY{ID=13,NAME="Bitlis"},
                new CITY{ID=14,NAME="Bolu"},
                new CITY{ID=15,NAME="Burdur"},
                new CITY{ID=16,NAME="Bursa"},
                new CITY{ID=17,NAME="Çanakkale"},
                new CITY{ID=18,NAME="Çankiri"},
                new CITY{ID=19,NAME="Çorum"},
                new CITY{ID=20,NAME="Denizlİ"},
                new CITY{ID=21,NAME="Diyarbakir"},
                new CITY{ID=22,NAME="Edirne"},
                new CITY{ID=23,NAME="Elaziğ"},
                new CITY{ID=24,NAME="Erzincan"},
                new CITY{ID=25,NAME="Erzurum"},
                new CITY{ID=26,NAME="Eskişehir"},
                new CITY{ID=27,NAME="Gaziantep"},
                new CITY{ID=28,NAME="Giresun"},
                new CITY{ID=29,NAME="Gümüşhane"},
                new CITY{ID=30,NAME="Hakkari"},
                new CITY{ID=31,NAME="Hatay"},
                new CITY{ID=32,NAME="Isparta"},
                new CITY{ID=33,NAME="İçel"},
                new CITY{ID=34,NAME="İstanbul"},
                new CITY{ID=35,NAME="İzmir"},
                new CITY{ID=36,NAME="Kars"},
                new CITY{ID=37,NAME="Kastamonu"},
                new CITY{ID=38,NAME="Kayserİ"},
                new CITY{ID=39,NAME="Kirklareli"},
                new CITY{ID=40,NAME="Kirşehir"},
                new CITY{ID=41,NAME="Kocaeli"},
                new CITY{ID=42,NAME="Konya"},
                new CITY{ID=43,NAME="Kütahya"},
                new CITY{ID=44,NAME="Malatya"},
                new CITY{ID=45,NAME="Manisa"},
                new CITY{ID=46,NAME="Kahramanmaraş"},
                new CITY{ID=47,NAME="Mardin"},
                new CITY{ID=48,NAME="Muğla"},
                new CITY{ID=49,NAME="Muş"},
                new CITY{ID=50,NAME="Nevşehir"},
                new CITY{ID=51,NAME="Niğde"},
                new CITY{ID=52,NAME="Ordu"},
                new CITY{ID=53,NAME="Rize"},
                new CITY{ID=54,NAME="Sakarya"},
                new CITY{ID=55,NAME="Samsun"},
                new CITY{ID=56,NAME="Siirt"},
                new CITY{ID=57,NAME="Sinop"},
                new CITY{ID=58,NAME="Sivas"},
                new CITY{ID=59,NAME="Tekirdağ"},
                new CITY{ID=60,NAME="Tokat"},
                new CITY{ID=61,NAME="Trabzon"},
                new CITY{ID=62,NAME="Tuncelİ"},
                new CITY{ID=63,NAME="Şanliurfa"},
                new CITY{ID=64,NAME="Uşak"},
                new CITY{ID=65,NAME="Van"},
                new CITY{ID=66,NAME="Yozgat"},
                new CITY{ID=67,NAME="Zonguldak"},
                new CITY{ID=68,NAME="Aksaray"},
                new CITY{ID=69,NAME="Bayburt"},
                new CITY{ID=70,NAME="Karaman"},
                new CITY{ID=71,NAME="Kirikkale"},
                new CITY{ID=72,NAME="Batman"},
                new CITY{ID=73,NAME="Şirnak"},
                new CITY{ID=74,NAME="Bartin"},
                new CITY{ID=75,NAME="Ardahan"},
                new CITY{ID=76,NAME="Iğdir"},
                new CITY{ID=77,NAME="Yalova"},
                new CITY{ID=78,NAME="Karabük"},
                new CITY{ID=79,NAME="Kilis"},
                new CITY{ID=80,NAME="Osmaniye"},
                new CITY{ID=81,NAME="Düzce"}
            };
            list.ForEach(f => context.CITies.Add(f));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}