using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Security;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourP.Business.Abstract;
using TourP.Business.Constants;
using TourP.Core.Utilities.Hash;
using TourP.Core.Utilities.Helper;
using TourP.Core.Utilities.MailHelper;
using TourP.Core.Utilities.Results;
using TourP.DataAccess.Abstract;
using TourP.Entities.Concrete;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace TourP.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly EmailConfiguration _emailConfiguration;
        private readonly AppSettings _appSettings;
        public UserManager(IUserDal userDal, EmailConfiguration emailConfiguration, IOptions<AppSettings> appSettings)
        {
            _userDal = userDal;
            _emailConfiguration = emailConfiguration;
            _appSettings = appSettings.Value;
        }

        public async Task<IResult> Add(User user)
        {
            user.Password = Util.ComputeSha256Hash(user.Password);
            if (await _userDal.CheckCreatingUser(user) == true)
            {
                return new SuccessResult(Messages.UserAlreadyCreated);
            }
            else if (await _userDal.CheckIsConfirmedCreateUser(user) == true)
            {
                return new SuccessResult(Messages.VerifyMail);
            }
            else
            {
                _userDal.Add(user);
                string url = "https://localhost:5001/api/User/MailConfirmation?email=" + user.Email;
                var message = new MailRequest()
                {
                    To = user.Email,
                    Subject = "Mail Confirmation",
                    Content = string.Format(@$"<div style = 'text-align: center;'>
                                          <h1>Welcome to TourP</h1>
                                          <h3>Click below button for verify your Email</h3>
                                          <form method = 'post' action = '{url}' style = 'display: inline;'>
                                          <button type='submit' style='display: block;
                                                                       text-align: center;
                                                                       font-weight: bold;
                                                                       background-color: #008CBA;
                                                                       font-size: 16px;
                                                                       border-radius: 10px;
                                                                       color: pointer;
                                                                       width: 100%;
                                                                       padding: 10px;'>
                                              Confirm Mail
                                            </button>
                                          </form>
                                         </div>", user.Email)
                };
                SendMail(message);
                return new SuccessResult(Messages.UserCreatedVerifyMail);
            }
        }

        public async Task<IResult> Authenticate(User user)
        {
            user.Password = Util.ComputeSha256Hash(user.Password);
            if (await _userDal.Authenticate(user) == true)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Email)
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return new SuccessResult(tokenHandler.WriteToken(token));
            }
            else if (await _userDal.CheckIsConfirmedLoginUser(user) == true)
            {
                return new SuccessResult(Messages.VerifyMailForLogin);
            }
            else
            {
                return new SuccessResult(Messages.InvalidUser);
            }
        }

        public List<User> GetAll()
        {
            var list = _userDal.GetAll();
            return list;
        }

        public IResult MailConfirmation(string email)
        {
            User user = _userDal.MailConfirmation(email);
            if (user != null)
            {
                user.IsConfirmed = true;
                _userDal.Update(user);
                return new SuccessResult(Messages.MailIsVerified);
            }
            return new SuccessResult(Messages.ErrorFound);
        }

        public IResult ForgotPassword(string email)
        {
            User user = _userDal.ForgotPassword(email);
            if (user != null)
            {
                string url = "https://localhost:5001/ResetPassword?email=" + user.Email;
                var message = new MailRequest()
                {
                    To = email,
                    Subject = $"TourP Reset Password Link",
                    Content = string.Format(@$"<div style = 'text-align: center;'>
                                          <h1>TourP Application</h1>
                                          <h3>Click below button for reset your password</h3>
                                          <a href ='{url}' style='display: block;
                                                                       text-align: center;
                                                                       font-weight: bold;
                                                                       background-color: #94B3FD;
                                                                       font-size: 16px;
                                                                       border-radius: 10px;
                                                                       color: pointer;
                                                                       width: 100%;
                                                                       padding: 10px;'>
                                              Reset Password
                                            </a>
                                         </div>")
                };
                SendMail(message);
                return new SuccessResult(Messages.PasswordRecoveryMail);
            }
            return new SuccessResult(Messages.InvalidEmail);
        }

        public IResult ResetPassword(User user)
        {
            if (user != null)
            {
                user.Password = Util.ComputeSha256Hash(user.Password);
                _userDal.Update(user);
                return new SuccessResult(Messages.Success);
            }
            return new SuccessResult(Messages.ErrorFound);
        }


        public void SendMail(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_emailConfiguration.From);
            email.To.Add(MailboxAddress.Parse(mailRequest.To));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Content;
            email.Body = builder.ToMessageBody();
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailConfiguration.Username, _emailConfiguration.Password);
                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
    }
}
