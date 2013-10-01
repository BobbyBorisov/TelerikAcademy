using ASP_MVC_Essensials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace ASP_MVC_Essensials.Controllers
{
    public class CalculatorController : Controller
    {
        //
        // GET: /Calculator/

        private List<SelectListItem> dropDownItems = new List<SelectListItem>(){
                new SelectListItem(){ Text="USD"},
                new SelectListItem(){ Text="BGN"},
                new SelectListItem(){ Text="EUR"},
                new SelectListItem(){ Text="GBP"}
            };

      
         
        public ActionResult Index()
        {
            ViewBag.Currencies = dropDownItems;  

            return View();
        }

        [HttpPost]
        public ActionResult Calculate(CalculationModel model)
        {
            //getting all current rates from the remote google api for currencies ;)))
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://rate-exchange.appspot.com/");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));


            var converts = new List<MoneyExchangeModel>();
            foreach (var currencyItem in dropDownItems)
            {
                if (currencyItem.Text == model.Currency)
                {
                    continue;
                }

                var query = "currency?from=" + model.Currency + "&to="+currencyItem.Text;
                HttpResponseMessage response = client.GetAsync(query).Result;

                if (response.IsSuccessStatusCode)
                {
                    var exchange = response.Content.ReadAsAsync<MoneyExchangeModel>().Result;
                    exchange.Result = model.Quantity * exchange.Rate;
                    converts.Add(exchange);
                }
                else
                {
                    //In case of error.. TODO
                    //ViewBag.Currencies = dropDownItems;
                    //return View("Index");
                }
            }

            ViewBag.Quantity = model.Quantity;
            ViewBag.Currencies = dropDownItems;
            return View("Index", converts);
        }
	}
}