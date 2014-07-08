using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ben.BLL.IBLL;
using Ben.DAL;
using Ben.DAL.DAL;
using Ben.DAL.IDAL;
using Ben.Entity;


namespace Ben.BLL.BLL
{
    class UserService : IUserService
    {
        private IBaseRepository<User> _userRepository = new BaseRepository<User>();
        
    }
}
