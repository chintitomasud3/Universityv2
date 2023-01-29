using MasudUniversity.Models;
using System.Collections.Generic;

namespace MasudUniversity.Repositories.interfaces
{
    public interface IEmployeeRepositories
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetById(int EmployeeID);
        void Insert(Employee employee);
        void Update(Employee employee);
        void Delete(int EmployeeID);
        void Save();

    }
}
