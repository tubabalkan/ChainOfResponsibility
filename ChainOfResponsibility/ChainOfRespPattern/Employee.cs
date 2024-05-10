using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.ChainOfRespPattern
{
    public abstract class Employee
    {
        protected Employee NextAprrover;
        public void SetNextApprover(Employee employee)
        {
            this.NextAprrover = employee;
        }
        public abstract void ProcessRequest(CustomerViewModel customerViewModel);
    }
}
