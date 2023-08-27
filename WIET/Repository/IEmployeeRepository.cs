using WIET.Models;

namespace WIET.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();

        int AllCount();
        int ActiveCount();
        int MaleCount();
        int FemaleCount();
        Employee GetById(int id);

        List<Employee> GetActive();

        Employee GetByName(string name);

        void Insert(Employee emp);

        void Update(int id, Employee emp);

        void Save();
    }
}
