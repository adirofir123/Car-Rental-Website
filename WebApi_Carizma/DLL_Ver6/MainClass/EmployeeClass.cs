using DLL_Ver6.ClassModels.PropInfos;
using DLL_Ver6.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Ver6.MainClass
{
   public class EmployeeClass
    {
        CarProjectContext db = new CarProjectContext(); //חיבור של הוובאייפיאיי עם הדאטה בייס

        #region GetFunction

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
        }//פונקציה למציאת כל הרכבים, לא בשימוש

        public RespModel GetAllOrders()
        {
            RespModel resp = new RespModel();
            resp.RespObject = db.RentTables;
            if (resp != null)
            {
                resp.IsSuccess = true;

            }
            else
            {
                resp.IsSuccess = false;
            }
            return resp;
        } //פונקציה למציאת כל ההזמנות, לא בשימוש

        public IEnumerable<CarInformation> GetCarsByNumber(int carNum)
        {
            RespModel resp = new RespModel();

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

        } //פונקציה למציאת רכב לפי מספר רכב

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
        }//פונקציה למציאת הזמנה לפי מספר הזמנה, לא בשימוש

        public RespModel GetUserById(int Userid)
        {
            RespModel resp = new RespModel();
            UserTable ExistingUser = db.UserTables.FirstOrDefault(user => user.UserTz == Userid);
            if (ExistingUser != null)
            {
                resp.IsSuccess = true;
                resp.RespObject = ExistingUser;
            }
            else
            {
                resp.IsSuccess = false;
            }
            return resp;

        } //פונקציה למציאת משתמש לפי מספר משתמש, לא בשימוש

        #endregion

        #region PutFunction
        public RespModel EmployeeReturnCar(int OrderNum, RentTable RRD)
        {
            RespModel resp = new RespModel();
            RentTable Rent = db.RentTables.FirstOrDefault(carNum => carNum.OrderNum == OrderNum);//השגת ההזמנה הנכונה
            CarInfo info = db.CarInfos.FirstOrDefault(carNum => carNum.CarNum == Rent.CarNum);//השגת הרכב של ההזמנה
            if (info.Available == "no")
            {
                info.Available = CarStatus.yes.ToString();//הפיכת הרכב לפנוי
                Rent.RealReturnDate = RRD.RealReturnDate;//השמה של התאריך האמיתי של החזרת הרכב
                db.SaveChanges();
                resp.IsSuccess = true;
            }
   
            else
            {
                resp.IsSuccess = false;
            }

            return resp;

        } //פונקציה לעדכון תאריך החזרה אמיתי של הרכב והחזרתו לפנוי
        #endregion
    }
}
