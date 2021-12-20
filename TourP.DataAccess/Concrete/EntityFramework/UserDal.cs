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
                return await context.Users.FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password && x.IsConfirmed == true) != null ? true : false;
            }
        }

        public async Task<bool> CheckIsConfirmedLoginUser(User user)
        {
            using (var context = new EfCoreDbContext())
            {
                return await context.Users.FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password && x.IsConfirmed == false) != null ? true : false;
            }
        }

        public async Task<bool> CheckIsConfirmedCreateUser(User user)
        {
            using (var context = new EfCoreDbContext())
            {
                return await context.Users.FirstOrDefaultAsync(x => x.Email == user.Email && x.IsConfirmed) != null ? true : false;
            }
        }

        public async Task<bool> CheckCreatingUser(User user)
        {
            using (var context = new EfCoreDbContext())
            {
                return await context.Users.FirstOrDefaultAsync(x => x.Email == user.Email) != null ? true : false;
            }
        }

        public User ForgotPassword(string email)
        {
            using (var context = new EfCoreDbContext())
            {
                User user = context.Users.Where(x => x.Email == email).FirstOrDefault();
                return user != null ? user : null;
            }
        }

        public User MailConfirmation(string email)
        {
            using (var context = new EfCoreDbContext())
            {
                User user = context.Users.Where(x => x.Email == email && x.IsConfirmed == false).FirstOrDefault();
                return user != null ? user : null;
            }
        }

        public User ResetPassword(User user)
        {
            using (var context = new EfCoreDbContext())
            {
                user = context.Users.Where(x => x.Email == user.Email).FirstOrDefault();
                return user != null ? user : null;
            }
        }
    }
}
