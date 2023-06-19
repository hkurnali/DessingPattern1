using DessingPattern1.ChainOfResponsibility;
using DessingPattern1.Models;
using Microsoft.AspNetCore.Mvc;

namespace DessingPattern1.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model)
        {   Employee cashier= new Cashier();
            Employee assistantManager= new AssistanManager();
            Employee manager = new Manager();
            Employee regionManager=new RegionManager();

            cashier.SetNextApprover(assistantManager);
            assistantManager.SetNextApprover(manager);
            manager.SetNextApprover(regionManager);

            cashier.ProcessRequest(model);
            return View();
        }
    }
}
