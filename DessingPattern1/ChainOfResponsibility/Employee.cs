using DessingPattern1.Models;

namespace DessingPattern1.ChainOfResponsibility
{
    public abstract class Employee
    {
        protected Employee NextApprover;
       public void SetNextApprover(Employee superVisor) 
        { 
         this.NextApprover = superVisor;
        
        
        }

        public abstract void ProcessRequest(CustomerProcessViewModel req);
    }
}
