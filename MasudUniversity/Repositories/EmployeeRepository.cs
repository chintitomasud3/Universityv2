using MasudUniversity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using MasudUniversity.Data;
using System.Linq;
using MasudUniversity.Repositories.interfaces;

namespace MasudUniversity.Repositories
{
    public class EmployeeRepository:IEmployeeRepositories
    {
        private readonly ApplicationDbContext _context;
        //public EmployeeRepository()
        //{
        //    _context = new ApplicationDbContext();
        //}
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Employee> GetAllEmployee()
        {
            return _context.Employees.ToList();
        }
        public Employee GetById(int EmployeeID)
        {
            return _context.Employees.Find(EmployeeID);
        }
        public void Insert(Employee employee)
        {
            _context.Employees.Add(employee);
        }
        public void Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
        }
        public void Delete(int EmployeeID)
        {
            Employee employee = _context.Employees.Find(EmployeeID);
            _context.Employees.Remove(employee);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

