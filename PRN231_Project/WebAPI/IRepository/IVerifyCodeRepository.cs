using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.IRepository
{
    public interface IVerifyCodeRepository
    {
        public VerifyCode CreateVerifyCode(int userId);
        public VerifyCode GetVerifyCode(int userId);
        public bool CodeValid(int userId, string code);

    }
}
