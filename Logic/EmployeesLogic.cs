using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data;

namespace Logic
{
    public class EmployeesLogic : BaseLogic, IABMLogic<Employees>
    {
        public List<Employees> GetAll()
        {
            return context.Employees.ToList();
        }

        public int GetLastID()
        {
            throw new NotImplementedException();
        }

        public Employees GetData(int id)
        {
            Employees employee = new Employees();
            var seleccionEmpleado = context.Employees.FirstOrDefault(e => e.EmployeeID == id); // throws an exception if producto does not exist
            return seleccionEmpleado;
        }

        public void Add(Employees newObject)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Employees objectSelected)
        {
            throw new NotImplementedException();
        }
    }
}
