using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCReact.Models
{
    public class Dane
    {
        [Key]
        public int Id { get; set; }
        public string Cena { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [ForeignKey("Produkt")]
        public int ProduktID { get; set; }
        public Produkt Produkt { get; set; }

        [ForeignKey("Sklepy")]
        public int SklepID { get; set; }
        public Sklepy Sklep { get; set; }

        public Dane(string cena, DateTime data, int produktID, int sklepID) {
            this.Cena = cena;
            this.Data = data;
            this.ProduktID = produktID;
            this.SklepID = sklepID;
        }
    }
}
