namespace Calculator.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models;

    public class HomeController : Controller
    {
        private readonly List<string> bitList = new List<string>()
        { "bit","Byte", "Kilobit", "KilobyteB","Megabit", "Megabyte","Gigabit",
           "Gigabyte", "Terabit", "Terabyte", "Petabit", "Petabyte", "Exabit",
           "Exabyte", "Zettabit","Zettabyte","Yottabit", "Yottabyte"
        };

        public HomeController()
        {
            this.Types = new List<SelectListItem>();
            this.Kilos = new List<SelectListItem>();

            for (int i = 0; i < bitList.Count; i++)
            {
                this.Types.Add(new SelectListItem() { Text = bitList[i], Value = i.ToString() });
            }

            this.Kilos.Add(new SelectListItem() { Text = "1024", Value = "1024" });
            this.Kilos.Add(new SelectListItem() { Text = "1000", Value = "1000" });
        }

        public List<SelectListItem> Types { get; set; }
        public List<SelectListItem> Kilos { get; set; }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Kilo = this.Kilos;
            ViewBag.Type = this.Types;
            ViewBag.Storage = "Storage(Kilo = 1024 bits)";
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Quantity, string Type, string Kilo)
        {
            int index = int.Parse(Type);
            int currentMultiply;

            if (Kilo == "1000")
            {
                ViewBag.Storage = "Bandwidth (Kilo = 1000 bits)";
                currentMultiply = 1000;
            }
            else
            {
                ViewBag.Storage = "Storage(Kilo = 1024 bits)";
                currentMultiply = 1024;
            }

            ViewBag.Kilo = this.Kilos;
            ViewBag.Type = this.Types;
            List<UnitsModel> results = new List<UnitsModel>(this.Types.Count);
            for (int i = 0; i < bitList.Count; i++)
            {
                results.Add(new UnitsModel()
                {
                    Name = bitList[i]
                });
            }
            double quantity = Convert.ToDouble(Quantity);

            results = this.CalculateResult(index, results, quantity, currentMultiply);
            ViewBag.Result = results;
            return View();
        }

        private List<UnitsModel> CalculateResult(int index, List<UnitsModel> results, double quantity, int currentMultiply)
        {
            double tempQuantity = quantity;
            results[index].Size = quantity;
            for (int i = index; ;)
            {
                i -= 2;
                if (i < 0) { break; }

                tempQuantity *= currentMultiply;
                results[i].Size = tempQuantity;

                if (results[i].Name.IndexOf("bit") >= 0)
                {
                    results[i + 1].Size = results[i].Size / 8;
                }
                else
                {
                    results[i + 1].Size = results[i + 2].Size * 8;
                }
            }

            if (results[0].Size == 0)
            {
                results[0].Size = results[1].Size * 8;
            }

            tempQuantity = quantity;
            for (int i = index; ;)
            {
                i += 2;

                if (i >= results.Count) {break; }

                tempQuantity /= currentMultiply;
                results[i].Size = tempQuantity;

                if (results[i].Name.IndexOf("bit") >= 0)
                {
                    results[i - 1].Size = results[i - 2].Size / 8;
                }
                else
                {
                    results[i - 1].Size = results[i].Size * 8;
                }
            }

            if (results[results.Count - 1].Size == 0)
            {
                results[results.Count - 1].Size = results[results.Count - 2].Size / 8;
            }

            return results;
        }
    }
}
