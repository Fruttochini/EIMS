using EIMS.AuthorizationIdentity;
using EIMS.Common;
using EIMS.Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Repository
{
    public static class Extensions
    {
        /// <summary>
        /// Converts stored procedure result to Teacher class
        /// </summary>
        /// <param name="item">Object of GetUsersByRole_Result class</param>
        /// <returns>Teacher object</returns>
        /// 

        //public static Teacher ToTeacher(this UserInfo item)
        //{
        //    var teacher = new Teacher()
        //    {
        //        ID = item.ID,
        //        Username = item.Username,
        //        Email = item.Email,
        //        Password = item.Password,
        //        RoleID = item.RoleID,
        //        CreationDate = item.CreationDate,
        //        Name = item.Name,
        //        Surname = item.Surname,
        //        MiddleName = item.MiddleName,
        //        photoLink = item.photoLink,
        //        address = item.address,
        //        sex = item.sex,
        //        Subjects = new List<Common.Subject>(),
        //        Groups = new List<Common.UniversityGroup>()


        //    };
        //    return teacher;
        //}


    }
}
