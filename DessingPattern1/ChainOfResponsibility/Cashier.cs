using DessingPattern1.Dal;
using DessingPattern1.Models;

namespace DessingPattern1.ChainOfResponsibility
{
    public class Cashier : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            var context = new Context();
            if (req.Amount <= 100000)
            {
               CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName= req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                customerProcess.EmployeeName = "Ali Yıldız";
                customerProcess.EmployeeDescription = "Müşterinin talep ettiği tutar müşteriye ödendi, işlem kapatıldı";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();

            }
            else if(NextApprover!=null) 
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName=req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                customerProcess.EmployeeName = "Ali Yıldız";
                customerProcess.EmployeeDescription = "Müşterinin ettiği tutar vezneder tarafından ödenemedi, şube müdür yardımcısına yöndirildi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();

                NextApprover.ProcessRequest(req);

            }
        }
    }
}
