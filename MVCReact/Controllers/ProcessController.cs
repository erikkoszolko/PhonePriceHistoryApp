using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCReact.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCReact.Controllers
{
    
    public class ProcessController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProcessController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public string Index()
        {
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(_context.Products.OrderBy(x => x.Nazwa));
                return JSONString;   
        }
        [HttpGet]
        public string Details(int Id)
        {
            string JSONString = string.Empty;             
            JSONString = JsonConvert.SerializeObject(_context.Danes.Where(x => x.ProduktID == Id ).OrderByDescending(x => x.Data));
            return JSONString;
        }

              
    }
}
