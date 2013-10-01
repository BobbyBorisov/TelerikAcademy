using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController: Controller
    {
    }
}