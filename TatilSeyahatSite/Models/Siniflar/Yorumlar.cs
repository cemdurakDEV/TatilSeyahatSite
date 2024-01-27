using System.ComponentModel.DataAnnotations;

namespace TatilSeyahatSite.Models.Siniflar
{
    public class Yorumlar
    {
        [Key]
        public int ID { get; set; }
        public string Kullanici { get; set; }
        public string Mail { get; set; }
        public string Yorum { get; set; }
        public int Blogid { get; set; }
        public virtual Blog Blog { get; set; }

    }
}