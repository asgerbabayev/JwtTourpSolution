using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourP.Core.DataAccess;
using TourP.Core.Utilities.Results;
using TourP.Entities.Concrete;

namespace TourP.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        Task<bool> CheckIsConfirmedLoginUser(User user);
        Task<bool> CheckIsConfirmedCreateUser(User user);
        Task<bool> CheckCreatingUser(User user);
        Task<bool> Authenticate(User user);
        User ForgotPassword(string email);
        User MailConfirmation(string email);
        User ResetPassword(User user);
    }
}
