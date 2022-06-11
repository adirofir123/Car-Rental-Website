using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL_Ver6.ClassModels.PropInfos;
using DLL_Ver6.TableModels;

namespace DLL_Ver6.MainClass
{
  public  class UserClass
    {
        CarProjectContext db = new CarProjectContext();  //חיבור של הוובאייפיאיי עם הדאטה בייס

        #region GetFunction's
        public IEnumerable<CarInformation> GetAllCars()
        {
            var Cars = (from Ctype in db.CarTypes
                        join Cinfo in db.CarInfos
                        on Ctype.CarId equals Cinfo.CarId
                        select new CarInformation()
                        {
                            carId = Ctype.CarId,
                            carNumber = Cinfo.CarNum,
                            quantity = Ctype.Quantity,
                            manufactor = Ctype.Manufactor,
                            model = Ctype.Model,
                            km = Cinfo.Km,
                            year = Ctype.Year,
                            dayPrice = Ctype.Dprice,
                            delayPrice = Ctype.DelayPrice,
                            available = Cinfo.Available,
                            rentable = Cinfo.Rentable,
                            picture = Cinfo.Pic
                        }).ToList();
            return Cars;
        }//פונקציה להצגת כל הרכבים לאורח

        public IEnumerable<CarInformation> GetCarsByNumber(int carNum)
        {
            var CarsByNum = (from Ctype in db.CarTypes
                             join Cinfo in db.CarInfos on Ctype.CarId equals Cinfo.CarId
                             where Cinfo.CarNum == carNum
                             select new CarInformation()
                             {
                                 carId = Ctype.CarId,
                                 carNumber = Cinfo.CarNum,
                                 quantity = Ctype.Quantity,
                                 manufactor = Ctype.Manufactor,
                                 model = Ctype.Model,
                                 km = Cinfo.Km,
                                 year = Ctype.Year,
                                 dayPrice = Ctype.Dprice,
                                 delayPrice = Ctype.DelayPrice,
                                 available = Cinfo.Available,
                                 rentable = Cinfo.Rentable,
                                 picture = Cinfo.Pic
                             }).ToList();
            return CarsByNum;

        }//פונקציה להשגת רכב לפי מספר רכב

        public RespModel ShowUserOrder(int userId)
        {
            RespModel resp = new RespModel();
            var orders = db.RentTables.Where(orders => orders.UserId == userId);

            if (orders != null)
            {
                resp.IsSuccess = true;
                resp.RespObject = orders;
            }
            else
            {
                resp.IsSuccess = false;
            }
            return resp;
        }//פונקציה להשגת כל ההזמנות של המשתמש לפי יוזר איידיי

        public RespModel GetOrderById(int OrderId)
        {
            RespModel resp = new RespModel();
            RentTable ExistingOrder = db.RentTables.FirstOrDefault(order => order.OrderNum == OrderId);
            if (ExistingOrder != null)
            {
                resp.IsSuccess = true;
                resp.RespObject = ExistingOrder;
            }
            else
            {
                resp.IsSuccess = false;
            }
            return resp;
        }//פונקציה להצגת הזמנה לפי מספר הזמנה
        #endregion

        #region login & Register Functions
        public RespModel LogIn(string nickName, string password)
        {
            RespModel resp = new RespModel();
            UserTable login = db.UserTables.FirstOrDefault(log => log.NickName == nickName && log.Password == password);
            if (login != null)
            {
                resp.IsSuccess = true;
                resp.RespObject = login;
            }
            else
            {
                resp.IsSuccess = false;
            }
            return resp;
        }//פונקציה להתחברות למערכת

        public RespModel setImgeToDB(string nickName, string dbPath)
        {
            RespModel resp = new RespModel();
            UserTable userImage = db.UserTables.FirstOrDefault(r => r.NickName == nickName);
            if (userImage != null)
            {
                userImage.Picture = dbPath;
                db.SaveChanges();
                resp.IsSuccess = true;
                resp.RespObject = "image upload";
            }
            else
            {
                resp.IsSuccess = false;
            }
            return resp;
        }//פונקציה להעלת תמונה לפי ניקניים

        public RespModel Register(UserTable NewUser)
        {
            RespModel respModel = new RespModel();
            try
            {

                UserTable isexist = db.UserTables.FirstOrDefault(nick => nick.NickName == NewUser.NickName);
                if (isexist!=null)
                {
                    respModel.IsSuccess=false;
                    respModel.error = "nickname already exist";
                    return respModel;
                }

                db.UserTables.Add(NewUser);
                db.SaveChanges();
                respModel.IsSuccess = true;

            }
            catch (Exception ex)
            {
                respModel.IsSuccess = false;
                respModel.error = ex.Message;
            }
            return respModel;
        }//פונקציה להרשמת משתמש חדש למערכת
        #endregion

        #region PostNewOrder
        public RespModel PostUserOrder(RentTable Order)
        {
            RespModel respModel = new RespModel();
            try
            {

                CarInfo info = db.CarInfos.FirstOrDefault(carNum => carNum.CarNum == Order.CarNum);
                if (info.Available == "no")
                {
                    respModel.IsSuccess = false;
                    respModel.error = "car already taken";
                    return respModel;
                }
                db.RentTables.Add(Order);
                info.Available = CarStatus.no.ToString();
                db.SaveChanges();
                respModel.IsSuccess = true;

            }
            catch (Exception ex)
            {
                respModel.IsSuccess = false;
                respModel.error = ex.Message;
            }
            return respModel;
        } //פונקציה להזמנה חדשה שמעבירה את הרכב שהוזמן ללא פנוי
        #endregion
    }
}
