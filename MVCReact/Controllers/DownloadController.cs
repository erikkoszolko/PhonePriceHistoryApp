using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using MVCReact.Data;
using MVCReact.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVCReact.Controllers
{
    public class DownloadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IActionResult Index()
        {
            return View();
        }

        public DownloadController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        
       
          
        public string Expert()
        {
            List<string> NazwyZwww = new List<string>();
            List<string> CenyZwww = new List<string>();

            List<string> NoweNazwyDoBazy = new List<string>();
           
            Dictionary<string, string> DaneZwww = new Dictionary<string, string>();

            
                     
           
            List<string> ProduktyZbazy = new List<string>();

            ProduktyZbazy = _context.Products.Select(p => p.Nazwa).ToList();



            string[] telefony = new string[] {"apple", "samsung", "motorola", "xiaomi", "asus", "realme" };
            string[] markizbazy = _context.Markas.Select(m => m.Nazwa).ToArray();
            //tabela w bazie, dodawnie telefonu
            //lista marek telefonów CRUD
            //wykres w widoku
            //dodać mało popularny sklep
            HtmlWeb web = new HtmlWeb();

           
            foreach (var brand in markizbazy)
            {

                HtmlDocument doc = web.Load($"https://www.mediaexpert.pl/smartfony-i-zegarki/smartfony/" + brand + "?limit=500");

                var nodes = doc.DocumentNode.SelectNodes(".//*[@id='section_list-items']/div/span/div[@class='offer-box']");
                foreach (var node in nodes)
                {

                    var nazwa = node.SelectSingleNode(".//a[@class='is-animate spark-link']/text()");
                    var cena = node.SelectSingleNode(".//div[@class='main-price is-big']/span[@class='whole']/text()") ?? node.SelectSingleNode(".//span[@class='unavailable']/text()");


                    if (cena != null && nazwa != null)
                    {
                       
                        if (!NazwyZwww.Contains(nazwa.InnerText.Trim().Replace("&quot;", @"""")))
                        {
                            NazwyZwww.Add(nazwa.InnerText.Trim().Replace("&quot;", @""""));
                            CenyZwww.Add(cena.InnerText.Trim());
                        }
                        //z bazy nie zawiera nazwy z www po zmianie lub nowe do bazy nie zawierają już takiego samego
                        if (!ProduktyZbazy.Contains(nazwa.InnerText.Trim().Replace("&quot;", @"""")) && !NoweNazwyDoBazy.Contains(nazwa.InnerText.Trim().Replace("&quot;", @"""")))
                        {
                            NoweNazwyDoBazy.Add(nazwa.InnerText.Trim().Replace("&quot;", @""""));
                        }

                    }
                   
                }
                 DaneZwww = NazwyZwww.Zip(CenyZwww, (k, v) => new { k, v })
                  .ToDictionary(x => x.k, x => x.v);
            }

            //nowe nazwy do tabeli produkts
                List<Produkt> prod = new List<Produkt>();
                for (int i1 = 0; i1 < NoweNazwyDoBazy.Count; i1++)
                {
                    prod.Add(new Produkt(NoweNazwyDoBazy[i1]));
                }
                prod.ForEach(x => _context.Products.Add(x));


                _context.SaveChanges();

               //nowe ceny do tabeli danes
                List<Dane> dane = new List<Dane>();

                for (int i1 = 0; i1 < CenyZwww.Count; i1++) {

                string ZnajdzNazweWbazie = NazwyZwww[i1];
                var ProduktIdZbazy = _context.Products.Where(x => x.Nazwa == ZnajdzNazweWbazie).Select(x => x.Id).First();
              
                dane.Add(new Dane(CenyZwww[i1], DateTime.Now.Date,ProduktIdZbazy,1));
                }
                dane.ForEach(x => _context.Danes.Add(x));

                //zapisz do bazy danych 
                _context.SaveChanges();

                

                // pho.ForEach(x => _context.Phone.Add(x));
                
             //   var dic = NazwyZwww.Zip(CenyZwww, (k, v) => new { k, v })
               //   .ToDictionary(x => x.k, x => x.v);//

                var result = String.Join("\n ", DaneZwww.ToArray()); 

               // dict.Clear();

             
            
            return result;
        }


        public string Avans()
        {
            List<string> NazwyZwww = new List<string>();
            List<string> CenyZwww = new List<string>();

            List<string> NoweNazwyDoBazy = new List<string>();

            Dictionary<string, string> DaneZwww = new Dictionary<string, string>();

            List<string> ProduktyZbazy = new List<string>();
            HtmlWeb web = new HtmlWeb();

            ProduktyZbazy = _context.Products.Select(p => p.Nazwa).ToList();

           

            

            string[] telefony = new string[] { "apple", "samsung", "motorola", "xiaomi", "asus", "realme" };
            string[] markizbazy = _context.Markas.Select(m => m.Nazwa).ToArray();
            //


            //Console.WriteLine("Pobieram dane z serwera...");

            //telefony Media expert
            //Console.WriteLine($"_______________TELEFONY_MEDIA_EXPERT_____________");

            foreach (var brand in markizbazy)
            {
                //pobierz strony
                HtmlDocument str = web.Load($"https://www.avans.pl/telefony-i-smartfony/smartfony/" + brand);
                var strony = str.DocumentNode.SelectSingleNode(".//span[@class='is-total']/text()") ?? null;
                int IloscStron = 1;
                if (strony != null)
                {
                    IloscStron = Convert.ToInt32(strony.InnerText.Trim());
                }
                else {
                    IloscStron = 1;
                }

                
                //Console.WriteLine($"Ilosc stron: int = {IloscStron}");

                

                    for (int strona = 1; strona <= IloscStron; strona++)
                    {
                    HtmlDocument doc = web.Load($"https://www.avans.pl/telefony-i-smartfony/smartfony/" + brand + "?limit=50&page=" + strona);
                    var nodes = doc.DocumentNode.SelectNodes(".//*[@class='c-grid ']/div/div[@class='c-offerBox is-wide']");
                    foreach (var node in nodes)
                        {
                        var nazwa = node.SelectSingleNode(".//a[@class='a-typo is-secondary']/text()");
                        var cena = node.SelectSingleNode(".//div[@class='c-offerBox_price  is-promoPrice']") ?? null;
                        if (cena == null)
                        {
                            cena = node.SelectSingleNode(".//div[@class='c-offerBox_price  ']/div/div/span[@class='a-price_price']/text()") ?? node.SelectSingleNode(".//div[@class='c-availabilityNotification_text is-heading']/div[@class='a-typo is-text']/text()");
                        };

                        if (cena != null && nazwa != null)
                            {

                                if (!NazwyZwww.Contains(nazwa.InnerText.Trim()))
                                {
                                    NazwyZwww.Add(nazwa.InnerText.Trim());
                                    CenyZwww.Add(cena.InnerText.Trim());
                                }

                                if (!ProduktyZbazy.Contains(nazwa.InnerText.Trim()) && !NoweNazwyDoBazy.Contains(nazwa.InnerText.Trim()))
                                {
                                    NoweNazwyDoBazy.Add(nazwa.InnerText.Trim());
                                }

                            }

                        }
                    }
                DaneZwww = NazwyZwww.Zip(CenyZwww, (k, v) => new { k, v })
                 .ToDictionary(x => x.k, x => x.v);
            }

            //nowe nazwy do tabeli produkts
            List<Produkt> prod = new List<Produkt>();
            for (int i1 = 0; i1 < NoweNazwyDoBazy.Count; i1++)
            {
                prod.Add(new Produkt(NoweNazwyDoBazy[i1]));
            }
            prod.ForEach(x => _context.Products.Add(x));


            _context.SaveChanges();

            //nowe ceny do tabeli danes
            List<Dane> dane = new List<Dane>();

            for (int i1 = 0; i1 < CenyZwww.Count; i1++)
            {

                string ZnajdzNazweWbazie = NazwyZwww[i1];
                var ProduktIdZbazy = _context.Products.Where(x => x.Nazwa == ZnajdzNazweWbazie).Select(x => x.Id).First();

                dane.Add(new Dane(CenyZwww[i1], DateTime.Now.Date, ProduktIdZbazy, 2));
            }
            dane.ForEach(x => _context.Danes.Add(x));

            //zapisz do bazy danych 
            _context.SaveChanges();



            // pho.ForEach(x => _context.Phone.Add(x));

            //   var dic = NazwyZwww.Zip(CenyZwww, (k, v) => new { k, v })
            //   .ToDictionary(x => x.k, x => x.v);//

            var result = String.Join("\n ", DaneZwww.ToArray());

            // dict.Clear();



            return result;
        }
       
    }
}
