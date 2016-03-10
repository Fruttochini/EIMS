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

        public static User ToUser(this Datalayer.EIMSUser usr)
        {
            var tmpUsr = new Common.User()
            {
                ID = usr.Id,
                Email = usr.Email,
                Username = usr.Login,
                Password = usr.Password,
                Roles = usr.Role.Select(rol => rol.Name),
                PhoneNumber = usr.PhoneNumber
            };
            IDictionary<string, string> dict = new Dictionary<string, string>();
            var ClaimCol = usr.UserClaim.ToList();
            foreach (var claim in ClaimCol)
            {
                dict.Add(claim.ClaimType, claim.ClaimValue);
            }
            tmpUsr.Name = dict["Name"];
            tmpUsr.Surname = dict["Surname"];
            tmpUsr.Gender = dict["Gender"];


            tmpUsr.MiddleName = dict["MiddleName"];
            tmpUsr.photoLink = dict["photoLink"];

            tmpUsr.Country = dict["Country"];
            tmpUsr.StateOrProvince = dict["StateOrProvince"];
            tmpUsr.StreetAddress = dict["StreetAddress"];
            tmpUsr.PostalCode = dict["PostalCode"];

            tmpUsr.CreationDate = DateTime.Parse(dict["CreationDate"]);
            tmpUsr.LastLoginDate = dict["LastLoginDate"];
            return tmpUsr;
        }



    }
}
