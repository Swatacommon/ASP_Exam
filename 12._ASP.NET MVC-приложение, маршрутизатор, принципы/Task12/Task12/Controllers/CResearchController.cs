using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task12.Controllers
{
    public class CResearchController : Controller
    {
        // GET: CResearch
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public string C01()
        {
            return "Ответ на Cresearch действия C01 GET или POST запросы";
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public string C02()
        {
            return "Ответ на Cresearch действия C02 GET или POST запросы";
        }

    }
}