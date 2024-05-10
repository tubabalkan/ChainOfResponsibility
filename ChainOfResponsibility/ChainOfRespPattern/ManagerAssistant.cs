using ChainOfResponsibility.DAL;
using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.ChainOfRespPattern
{
    public class ManagerAssistant : Employee
    {
        private readonly Context _context;

        public ManagerAssistant(Context context)
        {
            _context = context;
        }

        public override void ProcessRequest(CustomerViewModel customerViewModel)
        {
           if(customerViewModel.Amount <= 150000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Name = customerViewModel.Name;
                customerProcess.Amount = customerViewModel.Amount;
                customerProcess.EmployeeName = "Baki Emre Çetin";
                customerProcess.Description = "Talep Edilen Tutar Şube Müdür Yardımcısı Tarafından Ödendi";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
            else if (NextAprrover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Name = customerViewModel.Name;
                customerProcess.Amount = customerViewModel.Amount;
                customerProcess.EmployeeName = "Baki Emre Çetin";
                customerProcess.Description = "Talep Edilen Tutar Şube Müdür Yardımcısı Tarafından Ödenemedi İşlem Şube Müdürüne  Aktarıldı";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
                NextAprrover.ProcessRequest(customerViewModel);
            }
        }
    }
}
