using DLL_Ver6;
using DLL_Ver6.MainClass;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_Ver6.Controllers
{
   
    [Route("EmployeePage")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        EmployeeClass emp = new EmployeeClass(); //יצירת משתנה מהקלאס כדי שיהיה גישה לדיאלאל

        #region GetFunction

        // GET: api/<EmployeeController>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllCars()
        {
            return Ok(emp.GetAllCars());
        }//פונקציה למציאת כל הרכבים, לא בשימוש

        // GET: api/<EmployeeController>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllOrders()
        {
            var result = emp.GetAllOrders();
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }//פונקציה למציאת כל ההזמנות, לא בשימוש

        // GET api/<EmployeeController>/5
        [HttpGet]
        [Route("[action]/{carNumber}")]
        public IActionResult GetCarByNumber(int carNumber)
        { 
            return Ok(emp.GetCarsByNumber(carNumber));
        }//פונקציה למציאת רכב לפי מספר רכב

        // GET api/<EmployeeController>/5
        [HttpGet]
        [Route("[action]/{orderId}")]
        public IActionResult GetOrderById(int orderId)
        {
            var result = emp.GetOrderById(orderId);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }//פונקציה למציאת הזמנה לפי מספר הזמנה, לא בשימוש

        // GET api/<EmployeeController>/5
        [HttpGet]
        [Route("[action]/{userId}")]
        public IActionResult GetUserById(int userId)
        {
            var result = emp.GetUserById(userId);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }//פונקציה למציאת משתמש לפי מספר משתמש, לא בשימוש

        #endregion

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }//פוסט לא בשימוש

        // PUT api/<EmployeeController>/5
        [HttpPut]
        [Route("[action]/{OrderNum}")]
        public IActionResult EmployeeReturnCar(int OrderNum, RentTable RRD)
        {
            var result = emp.EmployeeReturnCar(OrderNum, RRD);
            if (result.IsSuccess)
            {
            return Ok(result.IsSuccess);
            }
            else
            {
                return BadRequest(result.IsSuccess);
            }
        } //פונקציה לעדכון תאריך החזרה אמיתי של הרכב והחזרתו לפנוי


        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }//לא בשימוש 
    }
}
