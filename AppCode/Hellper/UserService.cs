using DAPPER_CURD.Models;
using System.Collections.Generic;

namespace DAPPER_CURD.AppCode.Hellper
{
    public class UserService: IUserService
    {
        private IDB_Helper _dB_Helper;
        public UserService(IDB_Helper dB_Helper)
        {
            _dB_Helper = dB_Helper;
        }
        public IEnumerable<UsersList> GetUsersList()
        {
            var data = _dB_Helper.ExecuteProcList<UsersList>("Proc_getData",new {Id = 0});
            return data;
        }
        public UsersList GetUsersById(int Id)
        {
            var data = _dB_Helper.ExecuteQueryFirst<UsersList>("Proc_getData", new { Id });
            return data;
        }
        public AppResponse Save(Users users)
        {
            var response = _dB_Helper.ExecuteQueryFirst<AppResponse>("Proc_AddUpdateUsers", users);
            return response;
        }
        public AppResponse Delete(int Id)
        {
            var response = _dB_Helper.ExecuteQueryFirst<AppResponse>("Proc_DeleteUsers", new {Id});
            return response;
        }
    }
}
