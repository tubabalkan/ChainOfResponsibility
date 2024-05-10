using ChainOfResponsibility.DAL;
using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.ChainOfRespPattern
{
    public class AreaDirektor : Employee
    {
        private readonly Context _context;

        public AreaDirektor(Context context)
        {
            _context = context;
        }

        public override void ProcessRequest(CustomerViewModel customerViewModel)
        {
            if (customerViewModel.Amount <= 360000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Name = customerViewModel.Name;
                customerProcess.Amount = customerViewModel.Amount;
                customerProcess.EmployeeName = "Talha Yıldız";
                customerProcess.Description = "Talep Edilen Tutar Bölge Müdürü Tarafından Ödendi";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();

            }
            else 
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Name = customerViewModel.Name;
                customerProcess.Amount = customerViewModel.Amount;
                customerProcess.EmployeeName = "Ezelhan Dikmenoğlu";
                customerProcess.Description = "Talep Edilen Tutar Bölge Müdürü Tarafından Ödenemedi. İşlem Sona Erdi";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
               
            }
        }
    }
}
