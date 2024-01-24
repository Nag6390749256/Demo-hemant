using DAPPER_CURD.Models;
using System.Collections.Generic;

namespace DAPPER_CURD.AppCode.Hellper
{
    public interface IUserService
    {
        IEnumerable<UsersList> GetUsersList();
        UsersList GetUsersById(int Id);
        AppResponse Save(Users users);
        AppResponse Delete(int Id);
    }
}
