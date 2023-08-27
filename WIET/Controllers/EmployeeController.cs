using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WIET.DTO;
using WIET.Models;
using WIET.Repository;

namespace WIET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeRepository empRepo;

        public EmployeeController(IEmployeeRepository _empRepo)
        {
            empRepo = _empRepo;
        }

        [HttpGet]
        [Route("All")]
        public IActionResult GetAllEmployee()
        {
            List<Employee> employees = empRepo.GetAll();
            List<EmployeeDto> EmpDTOs = new List<EmployeeDto>();

            if (EmpDTOs != null)
            {
                foreach (var emp in employees)
                {
                    EmployeeDto EmpDTO = new EmployeeDto()
                    {
                        Id = emp.Id,
                        FName = emp.FName,
                        LName = emp.LName,
                        Postal = emp.Postal,
                        City = emp.City,
                        Address = emp.Address,
                        Email = emp.Email,
                        BirthDate = emp.BirthDate,
                        Country = emp.Country,
                        Gender = (int)emp.Gender,
                        Phone = emp.Phone,
                        Active = emp.Active == true ? 1 : 0
,
                    };
                    EmpDTOs.Add(EmpDTO);
                }
                return Ok(EmpDTOs);

            }
            return NotFound();
        }

        [HttpGet]
        [Route("AllCount")]
        public int GetAllCount() { 
            return empRepo.AllCount();
        }
        [HttpGet]
        [Route("ActiveCount")]
        public int GetActiveCount()
        {
            return empRepo.ActiveCount();
        }
        [HttpGet]
        [Route("MaleCount")]
        public int GetMaleCount()
        {
            return empRepo.MaleCount();
        }
        [HttpGet]
        [Route("FemaleCount")]
        public int GetFemaleCount()
        {
            return empRepo.FemaleCount();
        }

        [HttpGet]
        [Route("id/{id}")]
        public IActionResult GetByID(int id)
        {
            if (id != null)
            {

                Employee emp = empRepo.GetById(id);
                EmployeeDto EmpDTOs = new EmployeeDto()
                {
                    Id = emp.Id,
                    FName = emp.FName,
                    LName = emp.LName,
                    Postal = emp.Postal,
                    City = emp.City,
                    Address = emp.Address,
                    Email = emp.Email,
                    BirthDate = emp.BirthDate,
                    Country = emp.Country,
                    Gender = (int) emp.Gender,
                    Phone = emp.Phone,
                    Active = emp.Active==true?1:0,
                };
                return Ok(EmpDTOs);

            }


            return NotFound();
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Insert(EmployeeDto empDto)
        {
            if (ModelState.IsValid)
            {
                Employee emp = new Employee()
                {
                    Id = empDto.Id,
                    FName = empDto.FName,
                    LName = empDto.LName,
                    Postal = empDto.Postal,
                    City = empDto.City,
                    Address = empDto.Address,
                    Email = empDto.Email,
                    BirthDate = empDto.BirthDate,
                    Country = empDto.Country,
                    Gender = (Gender)empDto.Gender,
                    Phone = empDto.Phone,
                    Active =empDto.Active==1?true:false,
                };
                empRepo.Insert(emp);
                empRepo.Save();

                return CreatedAtAction("GetByID", new { id = emp.Id }, emp);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Update(int id, EmployeeDto empDto)
        {
            if (id == null) return NotFound();
            if (ModelState.IsValid)
            {

                Employee emp = new Employee()
                {
                    Id = empDto.Id,
                    FName = empDto.FName,
                    LName = empDto.LName,
                    Postal = empDto.Postal,
                    City = empDto.City,
                    Address = empDto.Address,
                    Email = empDto.Email,
                    BirthDate = empDto.BirthDate,
                    Country = empDto.Country,
                    Gender = (Gender)empDto.Gender,
                    Phone = empDto.Phone,
                    Active = empDto.Active == 1 ? true : false,

                };
                empRepo.Update(id, emp);
                empRepo.Save();

                return Ok("Updated");
            }
            return BadRequest(ModelState);
        }

    }
}
