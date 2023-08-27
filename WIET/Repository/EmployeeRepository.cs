using WIET.Models;

namespace WIET.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        WietContext db;
        public EmployeeRepository(WietContext _context) { 
            db = _context;
        }

        public List<Employee> GetAll()
        {
            return db.Employees.ToList();

        }
        public List<Employee> GetActive()
        {
            return db.Employees.ToList();

        }
        public Employee GetById(int id)
        {

            return db.Employees.FirstOrDefault(e => e.Id == id);

        }

        public Employee GetByName(string name)
        {
            return db.Employees.FirstOrDefault(e => e.FName.Contains(name));

        }

        public void Insert(Employee emp)
        {
            db.Employees.Add(emp);

        }

        public void Update(int id, Employee emp)
        {
            Employee oldEmp = GetById(id);

            if (oldEmp != null)
            {
                oldEmp.FName = emp.FName;
                oldEmp.LName = emp.LName;
                oldEmp.Gender = emp.Gender;
                oldEmp.Phone = emp.Phone;
                oldEmp.Email = emp.Email;
                oldEmp.Active = emp.Active;
                oldEmp.Postal = emp.Postal;
                oldEmp.City = emp.City;
                oldEmp.Country = emp.Country;
                oldEmp.Address = emp.Address;
                oldEmp.BirthDate = emp.BirthDate;

            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public int AllCount()
        {
            return db.Employees.Count();
        }

        public int ActiveCount()
        {
            return db.Employees.Where(e=>e.Active==true).Count();
        }

        public int MaleCount()
        {
            return db.Employees.Where(e=>e.Gender == Gender.male).Count();
        }

        public int FemaleCount()
        {
            return db.Employees.Where(e => e.Gender == Gender.female).Count();

        }
    }
}
