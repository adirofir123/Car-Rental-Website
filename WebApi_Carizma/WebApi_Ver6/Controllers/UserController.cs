using DLL_Ver6;
using DLL_Ver6.MainClass;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_Ver6.Controllers
{
    [ApiController]
    [Route("UserCarPage")]
    public class UserController : ControllerBase
    {

        UserClass userClass = new UserClass(); //יצירת משתנה מהקלאס כדי שיהיה גישה לדיאלאל

        #region Get Function
        // GET: api/<UserController>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllCars()
        {
            return Ok(userClass.GetAllCars());
        } //פונקציה להצגת כל הרכבים לאורח

        // GET api/<UserController>/5
        [HttpGet]
        [Route("[action]/{carNum}")]
        public IActionResult GetCarsByNumber(int carNum)
        {
            if (carNum == 0)
            {
                return NotFound("Invalid license number");
            }
            return Ok(new UserClass().GetCarsByNumber(carNum));
        }//פונקציה להשגת רכב לפי מספר רכב


        [HttpGet]
        [Route("[action]/{userId}")] 
        public IActionResult ShowUserOrder(int userId)
        {
            var result = userClass.ShowUserOrder(userId);
            if (result.IsSuccess)
            {
                return Ok(result.RespObject);
            }
            else
            {
                return NotFound();
            }
        }//פונקציה להשגת כל ההזמנות של המשתמש לפי יוזר איידיי


        [HttpGet]
        [Route("[action]/{OrderId}")] 
        public IActionResult GetOrderById(int OrderId)
        {
            var result = userClass.GetOrderById(OrderId);
            if (result.IsSuccess)
            {
                return Ok(result.RespObject);
            }
            else
            {
                return NotFound();
            }
        }  //פונקציה להצגת הזמנה לפי מספר הזמנה


        [HttpGet]
        [Route("[action]/{NickName}/{Password}")] 
        public IActionResult Login(string NickName, string Password)
        {
            var logIn = userClass.LogIn(NickName, Password);
            if (logIn.IsSuccess==true)
            {
                return Ok(logIn.RespObject);
            }
            else
            {
                return NotFound(logIn.IsSuccess);
            }
            } //פונקציה להתחברות למערכת

        #endregion


        #region Post Function 

        [Route("upload-image/{nickName}")]
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload(string nickName)
        {
            try
            {

                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        try
                        {
                            file.CopyTo(stream);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    var result = userClass.setImgeToDB(nickName, dbPath);
                    if (result.IsSuccess)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest(result.error);
                    }
                }
                else
                {
                    return BadRequest("not work!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }//פונקציה להעלת תמונה לפי ניקניים


        [HttpPost]
        [Route("Register")] 
        public IActionResult Register([FromBody] UserTable value)
        {

            var result = userClass.Register(value);
            if (result.IsSuccess)
            {
                return Ok(result.IsSuccess);
            }
            else
            {
                return BadRequest(result.IsSuccess);
            }

        }//פונקציה להרשמת משתמש חדש למערכת

        //[Route("get-image")]
        //ניסיונות לפונקציות לקבלת תמונה ולהציג אותה באנגולר בצורה נכונה
        //[HttpGet, DisableRequestSizeLimit]
        //public IActionResult GetImage([FromQuery] string nickName)
        //{
        //    try
        //    {
        //        UserTable user = db.UserTables.FirstOrDefault(x => x.NickName == nickName);
        //        if (user != null)
        //        {
        //            var imgPath = user?.Picture;
        //            Byte[] b = System.IO.File.ReadAllBytes(imgPath);          
        //            var base64 = Convert.ToBase64String(b);
        //            return Ok(base64);
        //        }
        //        var status = "invalid user";
        //        return Ok(new { status });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex}");
        //    }
        //}



        //[Route("get-image")]
        //[HttpGet, DisableRequestSizeLimit]
        //public IActionResult GetImage([FromQuery] int id)
        //{
        //    try
        //    {
        //        UserTable user = db.UserTables.FirstOrDefault(x => x.UserTz == id);
        //        if (user != null || true)
        //        {
        //            var imgPath = user?.Picture;
        //            Byte[] b = System.IO.File.ReadAllBytes(imgPath);          
        //            return File(b, "image/jpeg");
        //        }
        //        var status = "invalid user";
        //        return Ok(new { status });    
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex}");
        //    }
        //}


        [HttpPost]
        [Route("[action]")]  
        public IActionResult NewUserOrder(RentTable value) 
        {
            var result = userClass.PostUserOrder(value);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
            }



        }//פונקציה להזמנה חדשה שמעבירה את הרכב שהוזמן ללא פנוי

        #endregion



    }
}
