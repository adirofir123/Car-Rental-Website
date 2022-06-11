using DLL_Ver6.ClassModels.PropInfos;
using DLL_Ver6.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Ver6.MainClass
{
  public  class ManagerClass
    {
        CarProjectContext db = new CarProjectContext();  //חיבור של הוובאייפיאיי עם הדאטה בייס

        #region GeneralGet
        public RespModel GetAllUsers()
        {
            RespModel resp = new RespModel();
            resp.RespObject = db.UserTables;
            if (resp != null)
            {
                resp.IsSuccess = true;

            }
            else
            {
                resp.IsSuccess = false;
            }
            return resp;
        } //השגת כל המשתמשים

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
        } //השגת כל הרכבים משני הטבלאות

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
        } //השגת כל ההזמנות   

        #endregion

        #region GetById/Tz
        public RespModel GetUserByTz(int UserTz)
        {
            RespModel resp = new RespModel();
            UserTable ExistingUser = db.UserTables.FirstOrDefault(user => user.UserTz == UserTz);
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

        } //השגת משתמש יחיד על פי מספר תז 

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
        }   //השגת הזמנה יחידה על פי מספר הזמנה

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

        } //השגת רכב יחיד על פי מספר רכב
        #endregion

        #region PostFunction
        public RespModel PostNewUser(UserTable NewUser)
        {
            RespModel respModel = new RespModel();
            try
            {

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
        }//הוספת משתמש

        public RespModel PostCarTypeTable(CarType cType) 
        {
            RespModel resp = new RespModel();
            try
            {

                db.CarTypes.Add(cType);
                db.SaveChanges();
                resp.IsSuccess = true;

            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.error = ex.Message;
            }
            return resp;
        }//הוספת סוג רכב

        public RespModel PostCarInfoTable(CarInfo cInfo) 
        {
            RespModel resp = new RespModel();
            try
            {

                db.CarInfos.Add(cInfo);
                db.SaveChanges();
                resp.IsSuccess = true;

            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.error = ex.Message;
            }
            return resp;
        }//הוספת מידע רכב

        public RespModel PostUserOrder(RentTable Order)
        {
            RespModel respModel = new RespModel();
            try
            {

                db.RentTables.Add(Order);
                db.SaveChanges();
                respModel.IsSuccess = true;

            }
            catch (Exception ex)
            {
                respModel.IsSuccess = false;
                respModel.error = ex.Message;

            }
            return respModel;
        }//הוספת הזמנה


        #endregion

        #region Put Functions

        public RespModel UpdateUserInfo(int userTz, UserTable UserToUpdate)
        {
            RespModel resp = new RespModel();
            UserTable ExistingUser = db.UserTables.FirstOrDefault(user => user.UserTz == userTz);
            ExistingUser.UserTz = UserToUpdate.UserTz;
            ExistingUser.Bday = UserToUpdate.Bday;
            ExistingUser.Email = UserToUpdate.Email;
            ExistingUser.FullName = UserToUpdate.FullName;
            ExistingUser.Gender = UserToUpdate.Gender;
            ExistingUser.Role = UserToUpdate.Role;
            ExistingUser.NickName = UserToUpdate.NickName;
            ExistingUser.Password = UserToUpdate.Password;
            ExistingUser.Picture = UserToUpdate.Picture;
            try
            {
                db.SaveChanges();
                resp.IsSuccess = true;
                resp.RespObject = ExistingUser;
            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.error = ex.Message;

            }
            return resp;

        } //פונקציה לעריכת המידע בטבלת המשתמשים

        public RespModel UpdateOrderInfo(int orderNum, RentTable OrderToUpdate)
        {
            RespModel resp = new RespModel();
            RentTable ExistingOrder = db.RentTables.FirstOrDefault(order => order.OrderNum == orderNum);
            ExistingOrder.ReturnDate = OrderToUpdate.ReturnDate;
            ExistingOrder.RealReturnDate = OrderToUpdate.RealReturnDate;
            ExistingOrder.StartRentDate = OrderToUpdate.StartRentDate;
            ExistingOrder.CarNum = OrderToUpdate.CarNum;
            ExistingOrder.UserId = OrderToUpdate.UserId;
            try
            {
                db.SaveChanges();
                resp.IsSuccess = true;
                resp.RespObject = ExistingOrder;
            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.error = ex.Message;

            }
            return resp;

        } //פונקציה לעריכת המידע בטבלת ההזמנות

        public RespModel UpdateCarsInfo(int carNum, CarInfo cInfoToUpdate)
        {
            RespModel resp = new RespModel();
            CarInfo ExistingCInfo = db.CarInfos.FirstOrDefault(car => car.CarNum == carNum);
            ExistingCInfo.CarType = cInfoToUpdate.CarType;
            ExistingCInfo.Km = cInfoToUpdate.Km;
            ExistingCInfo.Pic = cInfoToUpdate.Pic;
            ExistingCInfo.Rentable = cInfoToUpdate.Rentable;
            ExistingCInfo.Available = cInfoToUpdate.Available;
            ExistingCInfo.CarNum = cInfoToUpdate.CarNum;

            try
            {
                db.SaveChanges();
                resp.IsSuccess = true;
                resp.RespObject = ExistingCInfo;
            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.error = ex.Message;

            }
            return resp;

        } //פונקציה לעריכת המידע בטבלת מידע הרכב

        public RespModel UpdateCarsType(int carId, CarType cTypeToUpdate)
        {
            RespModel resp = new RespModel();
            CarType ExistingCtype = db.CarTypes.FirstOrDefault(car => car.CarId == carId);
            ExistingCtype.Manufactor = cTypeToUpdate.Manufactor;
            ExistingCtype.Quantity = cTypeToUpdate.Quantity;
            ExistingCtype.Model = cTypeToUpdate.Model;
            ExistingCtype.Dprice = cTypeToUpdate.Dprice;
            ExistingCtype.DelayPrice = cTypeToUpdate.DelayPrice;
            ExistingCtype.Year = cTypeToUpdate.Year;

            try
            {
                db.SaveChanges();
                resp.IsSuccess = true;
                resp.RespObject = ExistingCtype;
            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.error = ex.Message;

            }
            return resp;

        } //פונקציה לעריכת המידע בטבלת סוג הרכב





        #endregion

        #region Delete Function

        public RespModel DeleteUser(int userTz)
        {
            RespModel resp = new RespModel();
            UserTable ExistingUser = db.UserTables.FirstOrDefault(delete => delete.UserTz == userTz);


            try
            {
                if (ExistingUser != null)
                {
                    db.Remove(ExistingUser);
                    db.SaveChanges();
                    resp.IsSuccess = true;
                }

            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.error = ex.Message;


            }
            return resp;



        }//מחיקת משתמש

        public RespModel DeleteOrder(int orderNum)
        {
            RespModel resp = new RespModel();
            RentTable ExistingOrder = db.RentTables.FirstOrDefault(delete => delete.OrderNum == orderNum);

            try
            {
                if (ExistingOrder != null)
                {
                    db.Remove(ExistingOrder);
                    db.SaveChanges();
                    resp.IsSuccess = true;
                }

            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.error = ex.Message;


            }
            return resp;


        }//מחיקת הזמנה

        public RespModel DeleteCarType(int CarTypeId)
        {
            RespModel resp = new RespModel();
            CarType ExistingCarType = db.CarTypes.FirstOrDefault(delete => delete.CarId == CarTypeId);

            try
            {
                if (ExistingCarType != null)
                {
                    db.Remove(ExistingCarType);
                    db.SaveChanges();
                    resp.IsSuccess = true;
                }

            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.error = ex.Message;


            }
            return resp;


        }//מחיקת סוג רכב

        public RespModel DeleteCarInfo(int CarNumInfo)
        {
            RespModel resp = new RespModel();
            CarInfo ExistingCarNumIfo = db.CarInfos.FirstOrDefault(delete => delete.CarNum == CarNumInfo);

            try
            {
                if (ExistingCarNumIfo != null)
                {
                    db.Remove(ExistingCarNumIfo);
                    db.SaveChanges();
                    resp.IsSuccess = true;
                }

            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.error = ex.Message;


            }
            return resp;


        }//מחיקת מידע רכב
        #endregion


    }
}
