using DessingPattern1.Dal;
using DessingPattern1.Models;

namespace DessingPattern1.ChainOfResponsibility
{
    public class AssistanManager : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            var context = new Context();
            if (req.Amount <= 150000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                customerProcess.EmployeeName = "Merve Çınar";
                customerProcess.EmployeeDescription = "Müşterinin talep ettiği tutar müşteriye müdür yardımcısı tarafından ödendi, işlem kapatıldı";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();

            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                customerProcess.EmployeeName = "Merve Çınar";
                customerProcess.EmployeeDescription = "Müşterinin ettiği tutar müdür yardımcısı tarafından ödenemedi, şube müdürüne yöndirildi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();

                NextApprover.ProcessRequest(req);

            }
        }
    }
}
