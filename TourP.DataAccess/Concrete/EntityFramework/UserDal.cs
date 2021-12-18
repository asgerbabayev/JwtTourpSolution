using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourP.Core.DataAccess.EntityFramework;
using TourP.Core.Utilities.Results;
using TourP.DataAccess.Abstract;
using TourP.Entities.Concrete;

namespace TourP.DataAccess.Concrete.EntityFramework
{
    public class UserDal : EfCoreRepositoryBase<User, EfCoreDbContext>, IUserDal
    {
        public async Task<bool> Authenticate(User user)
        {
            using (var context = new EfCoreDbContext())
            {
                if (await context.Users.FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password && x.IsConfirmed == true) != null)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> CheckIsConfirmedLoginUser(User user)
        {
            using (var context = new EfCoreDbContext())
            {
                if (await context.Users.FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password && x.IsConfirmed == false) != null)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> CheckIsConfirmedCreateUser(User user)
        {
            using (var context = new EfCoreDbContext())
            {
                if (await context.Users.FirstOrDefaultAsync(x => x.Email == user.Email && x.IsConfirmed) != null)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> CheckCreatingUser(User user)
        {
            using (var context = new EfCoreDbContext())
            {
                if (await context.Users.FirstOrDefaultAsync(x => x.Email == user.Email) != null)
                {
                    return true;
                }
                return false;
            }
        }

        public User ForgotPassword(string email)
        {
            using (var context = new EfCoreDbContext())
            {
                User user = context.Users.Where(x => x.Email == email).FirstOrDefault();
                if (user != null)
                {
                    return user;
                }
                return null;
            }
        }

        public User MailConfirmation(string email)
        {
            using (var context = new EfCoreDbContext())
            {
                User user = context.Users.Where(x => x.Email == email && x.IsConfirmed == false).FirstOrDefault();
                if (user != null)
                {
                    return user;
                }
                return null;
            }
        }

        public User ResetPassword(User user)
        {
            using (var context = new EfCoreDbContext())
            {
                user = context.Users.Where(x => x.Email == user.Email).FirstOrDefault();
                if (user != null)
                {
                    return user;
                }
                return null;
            }
        }
    }
}
