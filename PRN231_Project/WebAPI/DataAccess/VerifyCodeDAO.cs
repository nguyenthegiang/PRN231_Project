using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.DataAccess
{
    public class VerifyCodeDAO
    {
        public static VerifyCode CreateVerifyCode(int userId)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    User user = context.Users.Where(u => u.UserId == userId).FirstOrDefault();
                    if (user == null)
                        return null;
                    VerifyCode code = context.VerifyCodes.Where(code => code.UserId == userId).FirstOrDefault();
                    if (code == null)
                    {
                        code = new VerifyCode{ 
                            UserId = userId, 
                            ExpireDatetime = DateTimeOffset.Now.AddMinutes(5), 
                            Code = Helper.CodeGenerate.Generate(6)
                        };
                        context.VerifyCodes.Add(code);
                    }
                    else
                    {
                        if (CodeExpire(code))
                        {
                            code.Code = Helper.CodeGenerate.Generate(6);
                            code.ExpireDatetime = DateTimeOffset.Now.AddMinutes(5);
                            context.Entry<VerifyCode>(code).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        }
                    }
                    context.SaveChanges();
                    return code;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static VerifyCode GetVerifyCode(int userId)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    VerifyCode verifyCode = context.VerifyCodes.Where(vc => vc.UserId == userId).FirstOrDefault();
                    if (verifyCode != null && CodeExpire(verifyCode)) return null;
                    return verifyCode;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static bool CodeValid(int userId, string code)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    VerifyCode verifyCode = context.VerifyCodes.Where(vc => vc.UserId == userId && vc.Code == code).FirstOrDefault();
                    if (verifyCode != null)
                    {
                        if (CodeExpire(verifyCode)) return false;
                        else return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private static bool CodeExpire(VerifyCode code)
        {
            if (code == null)
                return true;
            return DateTimeOffset.Now > code.ExpireDatetime;
        }
    }
}
