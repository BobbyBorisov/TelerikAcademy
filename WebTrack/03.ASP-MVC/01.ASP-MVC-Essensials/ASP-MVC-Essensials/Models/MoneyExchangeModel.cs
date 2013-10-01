using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_MVC_Essensials.Models
{
    public class MoneyExchangeModel
    {
        public string From { set; get; }
        public string To { set; get; }

        public decimal Result { set; get; }
        public decimal Rate {set; get;}

        
    }
}