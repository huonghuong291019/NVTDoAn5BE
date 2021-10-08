using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IUserRepository
    {
        UserModel GetUser(string username, string password);
        UserModel GetDatabyID(string id);
        List<UserModel> Search(int pageIndex, int pageSize, out long total, string tennv, string taikhoan);
        bool Create(UserModel model);
        bool Update(UserModel model);
        bool Delete(string id);
    }
}
