using DLL_Ver6;
using DLL_Ver6.MainClass;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_Ver6.Controllers
{
    [Route("ManagerPage")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        ManagerClass Manag = new ManagerClass(); //יצירת משתנה מהקלאס כדי שיהיה גישה לדיאלאל

        #region Get Functions
        // GET: api/<ManagerController>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllUsers()
        {
            var result = Manag.GetAllUsers();
            if (result.IsSuccess)
            {
                return Ok(result.RespObject);
            }
            else
            {
                return NotFound();
            }
        }//השגת כל המשתמשים

        // GET api/<ManagerController>/5
        [HttpGet]
        [Route("[action]/{UserTz}")]
        public IActionResult GetUserByTz(int UserTz)
        {
            var result = Manag.GetUserByTz(UserTz);
            if (result.IsSuccess)
            {
                return Ok(result.RespObject);
            }
            else
            {
                return NotFound();
            }
        }//השגת משתמש יחיד על פי מספר תז

        // GET: api/<ManagerController>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllCars()
        {
            return Ok(Manag.GetAllCars());
        }//השגת כל הרכבים משני הטבלאות


        // GET api/<ManagerController>/5
        [HttpGet]
        [Route("[action]/{carNum}")]
        public IActionResult GetCarsByNumber(int carNum)
        {
            return Ok(Manag.GetCarsByNumber(carNum));
        }//השגת רכב יחיד על פי מספר רכב

        // GET: api/<ManagerController>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllOrders()
        {
            var result = Manag.GetAllOrders();
            if (result.IsSuccess)
            {
                return Ok(result.RespObject);
            }
            else
            {
                return NotFound();
            }
        }//השגת כל ההזמנות

        // GET api/<ManagerController>/5
        [HttpGet]
        [Route("[action]/{orderId}")]
        public IActionResult GetOrderById(int orderId)
        {
            var result = Manag.GetOrderById(orderId);
            if (result.IsSuccess)
            {
                return Ok(result.RespObject);
            }
            else
            {
                return NotFound();
            }
        }//השגת הזמנה יחידה על פי מספר הזמנה
        #endregion

        #region Post Functions
        [HttpPost]
        [Route("[action]")]
        public IActionResult PostNewUser([FromBody] UserTable value)
        {
            var result = Manag.PostNewUser(value);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
            }


        } //הוספת משתמש

        [HttpPost]
        [Route("[action]")]
        public IActionResult PostUserOrder(RentTable value)
        {
            var result = Manag.PostUserOrder(value);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
            }


        } //הוספת הזמנה

        [HttpPost]
        [Route("[action]")]
        public IActionResult PostCarTypeTable(CarType value)
        {
            var result = Manag.PostCarTypeTable(value);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }


        } //הוספת סוג רכב

        [HttpPost]
        [Route("[action]")]
        public IActionResult PostCarInfoTable(CarInfo value)
        {
            var result = Manag.PostCarInfoTable(value);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
            }


        } //הוספת סוג רכב
        #endregion

        #region Put Functions
        // PUT api/<ManagerController>/5
        [HttpPut("[action]/{orderNum}")]
        public IActionResult UpdateOrder(int orderNum, [FromBody] RentTable value)
        {
            var result = Manag.UpdateOrderInfo(orderNum, value);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
            }
        }//פונקציה לעריכת המידע בטבלת ההזמנות

        // PUT api/<ManagerController>/5
        [HttpPut("[action]/{userTz}")]
        public IActionResult UpdateUserInfo(int userTz, [FromBody] UserTable value)
        {
            var result = Manag.UpdateUserInfo(userTz, value);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
            }
        }//פונקציה לעריכת המידע בטבלת המשתמשים


        // PUT api/<ManagerController>/5
        [HttpPut("[action]/{carNum}")]
        public IActionResult UpdateCarsInfo(int carNum, [FromBody] CarInfo value)
        {
            var result = Manag.UpdateCarsInfo(carNum, value);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
            }
        }//פונקציה לעריכת המידע בטבלת מידע הרכב

        // PUT api/<ManagerController>/5
        [HttpPut("[action]/{carId}")]
        public IActionResult UpdateCarsType(int carId, [FromBody] CarType value)
        {
            var result = Manag.UpdateCarsType(carId, value);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
            }
        }//פונקציה לעריכת המידע בטבלת סוג הרכב
        #endregion

        #region Delete Functions
        // DELETE api/<ManagerController>/5
        [HttpDelete("[action]/{userTz}")]
        public IActionResult DeleteUser(int userTz)
        {
            var result = Manag.DeleteUser(userTz);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.IsSuccess);
            }
        }//מחיקת משתמש


        // DELETE api/<ManagerController>/5
        [HttpDelete("[action]/{orderNum}")]
        public IActionResult DeleteOrder(int orderNum)
        {
            var result = Manag.DeleteOrder(orderNum);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
            }
        }//מחיקת הזמנה


        // DELETE api/<ManagerController>/5
        [HttpDelete("[action]/{carTypeId}")]
        public IActionResult DeleteCarType(int carTypeId)
        {
            var result = Manag.DeleteCarType(carTypeId);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
            }
        }//מחיקת סוג רכב


        // DELETE api/<ManagerController>/5
        [HttpDelete("[action]/{carNumInfo}")]
        public IActionResult DeleteCarInfo(int carNumInfo)
        {
            var result = Manag.DeleteCarInfo(carNumInfo);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
            }
        }//מחיקת מידע רכב

        #endregion
    }
}
