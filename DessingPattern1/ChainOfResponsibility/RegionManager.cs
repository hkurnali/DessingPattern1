using DessingPattern1.Dal;
using DessingPattern1.Models;

namespace DessingPattern1.ChainOfResponsibility
{
    public class RegionManager : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            var context = new Context();
            if (req.Amount <= 350000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                customerProcess.EmployeeName = "Serkan Kaya";
                customerProcess.EmployeeDescription = "Müşterinin talep ettiği tutar müşteriye bölge müdürü tarafından ödendi, işlem kapatıldı";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();

            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                customerProcess.EmployeeName = "Serkan Kaya";
                customerProcess.EmployeeDescription = "Müşterinin ettiği tutar bölge  müdürü  tarafından ödenemedi, işlem yapılamadı.";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();

               

            }
        }
    }
}
