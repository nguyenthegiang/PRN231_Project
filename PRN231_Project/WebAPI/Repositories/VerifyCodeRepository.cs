using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DataAccess;
using WebAPI.IRepository;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class VerifyCodeRepository : IVerifyCodeRepository
    {
        public bool CodeValid(int userId, string code) => VerifyCodeDAO.CodeValid(userId, code);

        public VerifyCode CreateVerifyCode(int userId) => VerifyCodeDAO.CreateVerifyCode(userId);

        public VerifyCode GetVerifyCode(int userId) => VerifyCodeDAO.GetVerifyCode(userId);
    }
}
