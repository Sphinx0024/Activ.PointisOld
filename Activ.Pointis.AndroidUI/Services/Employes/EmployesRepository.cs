using ProjetScan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetScan.Services.Employes
{
    public interface EmployesRepository
    {
        Task<bool> SaveEmployes(EmployesModel employesModel);
        Task<bool> DeleteEmployes(long EmployesID);
        Task<EmployesModel> GetEmployes(long EmployesID);
        Task<IEnumerable<EmployesModel>> GetEmployes();
    }
}
