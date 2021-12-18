using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourP.Core.Utilities.Results;
using TourP.Entities.Concrete;

namespace TourP.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        Task<IResult> Add(User user);
        Task<IResult> Authenticate(User user);
        IResult MailConfirmation(string email);
        IResult ForgotPassword(string email);
        IResult ResetPassword(User user);
    }
}
