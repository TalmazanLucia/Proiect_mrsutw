using MRSUTW.BusinessLogic.DBModel;
using MRSUTW.Domain.Entities.User;
using MRSUTW.Helpers.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MRSUTW.BusinessLogic.Core
{
    internal class UserApi
    {
        internal PostResponse UserLoginAction(ULoginData data)
        {

            UDbTable result;
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Credential))
            {
                var pass = LoginHelper.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Email == data.Credential && u.Password == pass);
                }

                if (result == null)
                {
                    return new PostResponse { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }

                using (var todo = new UserContext())
                {
                    result.LasIp = data.LoginIp;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                return new PostResponse { Status = true };
            }
            else
            {
                var pass = LoginHelper.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Username == data.Credential && u.Password == pass);
                }

                if (result == null)
                {
                    return new PostResponse { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }

                using (var todo = new UserContext())
                {
                    result.LasIp = data.LoginIp;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                return new PostResponse { Status = true };
            }
        }

        internal PostResponse UserRegisterAction(USignupData data)
        {
            UDbTable result;
            Table_Activities tt = new Table_Activities();
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Email))
            {
                if (data.Password1 == null || data.Email == null)
                {
                    return new PostResponse { Status = false, StatusMsg = "Complet all fields" };
                }

                if (data.Password1 != data.Password2)
                {
                    return new PostResponse { Status = false, StatusMsg = "The Passwords don't match" };
                }

                if (data.Password1.Length < 8)
                {
                    return new PostResponse { Status = false, StatusMsg = "Password min 8 characters" };
                }

                if (data.Username.Length < 5)
                {
                    return new PostResponse { Status = false, StatusMsg = "Username min 5 characters" };
                }

                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Email == data.Email);
                }

                if (result != null)
                {
                    return new PostResponse { Status = false, StatusMsg = "The Email is already taken" };
                }

                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Username == data.Username);
                }
                if (result != null)
                {
                    return new PostResponse { Status = false, StatusMsg = "Please use a unique username" };
                }

                var pass = LoginHelper.HashGen(data.Password1);
                result = new UDbTable
                {
                    Username = data.Username,
                    Email = data.Email,
                    Password = pass,
                    LasIp = data.LoginIp,
                    LastLogin = data.LoginDateTime,
                    Registred = DateTime.Now,
                };

                using (var db = new UserContext())
                {
                    db.Users.Add(result);
                    db.SaveChanges();
                }

                return new PostResponse { Status = true };
            }
            else
            {
                return new PostResponse { Status = false, StatusMsg = "Invalid email" };

            }
        }

        internal HttpCookie Cookie(string loginCredential)
        {
            var apiCookie = new HttpCookie("MRSUTW")
            {
                Value = CookieGenerator.Create(loginCredential)
            };

            //find email if username used
            UDbTable result;
            using (var db = new UserContext())
            {
                result = db.Users.FirstOrDefault(u => u.Email == loginCredential || u.Username == loginCredential);
            }

            loginCredential = result.Email;


            using (var db = new UserContext())
            {
                SessionsDbTable curent;
                curent = (from e in db.Sessions where e.UserEmail == loginCredential select e).FirstOrDefault();

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var up = new UserContext())
                    {
                        up.Entry(curent).State = EntityState.Modified;
                        up.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new SessionsDbTable
                    {
                        UserEmail = loginCredential,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }
            return apiCookie;
        }

        internal UProfileData GetProfileByCookieAction(string cookie)
        {
            SessionsDbTable session;
            UDbTable curentUser;

            using (var db = new UserContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new UserContext())
            {
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(session.UserEmail))
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Email == session.UserEmail);
                }
                else
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Email == session.UserEmail);
                }
            }

            if (curentUser == null) return null;
            var userprofile = new UProfileData
            {
                ID = curentUser.Id,
                Username = curentUser.Username,
                Email = curentUser.Email,
                Registred = curentUser.Registred,
                Identity = curentUser.Identity,
                Description = curentUser.Description,
                Age = curentUser.Age,
                Weight = curentUser.Weight,
                Height = curentUser.Height,
                Role = curentUser.Role,
            };

            return userprofile;
        }

        internal UProfileData GetProfileByIdAction(int id)
        {
            UDbTable curentUser;
            using (var db = new UserContext())
            {
                curentUser = db.Users.FirstOrDefault(u => u.Id == id);

            }

            if (curentUser == null) return null;
            var userprofile = new UProfileData
            {
                ID = curentUser.Id,
                Username = curentUser.Username,
                Email = curentUser.Email,
                Registred = curentUser.Registred,
                Identity = curentUser.Identity,
                Description = curentUser.Description,
                Age = curentUser.Age,
                Weight = curentUser.Weight,
                Height = curentUser.Height,
                Role = curentUser.Role,
            };

            return userprofile;
        }

        internal PostResponse UpdateProfileAction(UProfileData profile)
        {
            using (var db = new UserContext())
            {
                var result = db.Users.FirstOrDefault(u => u.Id == profile.ID);

                if (result == null)
                {
                    return new PostResponse { Status = false, StatusMsg = "User not found" };
                }

                if (profile.Username.Length < 5)
                {
                    return new PostResponse { Status = false, StatusMsg = "Username too short" };
                }

                    result.Username = profile.Username;
                    result.Identity = profile.Identity;
                    result.Age = profile.Age;
                    result.Description = profile.Description;
                    result.Weight = profile.Weight;
                    result.Height = profile.Height;
                    result.Email = profile.Email;
                    result.Role = profile.Role;

                db.SaveChanges();
            }

            return new PostResponse { Status = true };
        }

        internal List<UProfileData> GetUsersAction()
        {
            List<UProfileData> users = new List<UProfileData>();

            using (var db = new UserContext())
            {
                var userList = db.Users.ToList();

                foreach (var user in userList)
                {
                    var userprofile = new UProfileData
                    {
                        ID = user.Id,
                        Username = user.Username,
                        Email = user.Email,
                        Registred = user.Registred,
                        Identity = user.Identity,
                        Description = user.Description,
                        Age = user.Age,
                        Weight = user.Weight,
                        Height = user.Height,
                        Role = user.Role
                    };

                    users.Add(userprofile);
                }
            }

            return users;
        }

          internal List<UProfileData> GetTrainersAction()
          {
               List<UProfileData> users = new List<UProfileData>();

               using (var db = new UserContext())
               {
                    var userList = db.Users.ToList();

                    foreach (var user in userList)
                    {
                         if (user.Role == Domain.Enums.URole.Trainer)
                         {
                              var userprofile = new UProfileData
                              {
                                   ID = user.Id,
                                   Username = user.Username,
                                   Email = user.Email,
                                   Registred = user.Registred,
                                   Identity = user.Identity,
                                   Description = user.Description,
                                   Age = user.Age,
                                   Weight = user.Weight,
                                   Height = user.Height,
                                   Role = user.Role
                              };

                              users.Add(userprofile);
                         }
                    }
               }

               return users;
          }

          public bool GetIsAdminTypeByCookieAction(string cookie)
          {
               SessionsDbTable session;
               UDbTable curentUser;

               using (var db = new UserContext())
               {
                    session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
               }

               using (var db = new UserContext())
               {
                    var validate = new EmailAddressAttribute();
                    if (validate.IsValid(session.UserEmail))
                    {
                         curentUser = db.Users.FirstOrDefault(u => u.Email == session.UserEmail);
                    }
                    else
                    {
                         curentUser = db.Users.FirstOrDefault(u => u.Email == session.UserEmail);
                    }
               }
               var userprofile = new UProfileData
               {
                    ID = curentUser.Id,
                    Username = curentUser.Username,
                    Email = curentUser.Email,
                    Registred = curentUser.Registred,
                    Identity = curentUser.Identity,
                    Description = curentUser.Description,
                    Age = curentUser.Age,
                    Weight = curentUser.Weight,
                    Height = curentUser.Height,
                    Role = curentUser.Role,
               };

               if (userprofile.Role == Domain.Enums.URole.Administrator)
               {
                    return true;
               }
               else
               {
                    return false;
               }
          }
     }
}
