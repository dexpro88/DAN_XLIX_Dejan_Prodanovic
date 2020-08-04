using DAN_XLIX_Dejan_Prodanovic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIX_Dejan_Prodanovic.Service
{
    class HotelService:IHotelService
    {
        public tblUser AddUser(tblUser user)
        {
            try
            {
                using (HotelDataBaseEntities context = new HotelDataBaseEntities())
                {

                    tblUser newUser = new tblUser();
                    newUser.FullName = user.FullName;
                    newUser.DateOfBirth = user.DateOfBirth;
                    newUser.Mail = user.Mail;
                    newUser.Username = user.Username;
                    newUser.Passwd = user.Passwd;


                    context.tblUsers.Add(newUser);
                    context.SaveChanges();
                    return newUser;

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblManager AddManager(tblManager manager)
        {
            try
            {
                using (HotelDataBaseEntities context = new HotelDataBaseEntities())
                {

                    tblManager newManager = new tblManager();
                    newManager.HotelFloor = manager.HotelFloor;
                    newManager.Experience = manager.Experience;
                    newManager.QualificationsLevel = manager.QualificationsLevel;
                    newManager.UserId = manager.UserId;
                   

                    context.tblManagers.Add(newManager);
                    context.SaveChanges();

                    return newManager;

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

    }
}
