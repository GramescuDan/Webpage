using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPage.Domain.Models;

namespace WebPage.API.Controllers
{
    [Route("/api/[controller]")]
    public class ArticleController : Controller
    {
        public ArticleController()
        {

        }

        [HttpGet]
        public IActionResult Get()
            {
            }
    }
}
