﻿using Quadro.DataModel.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Api
{
    public interface IAuthService
    {
        //Auth
        Task<UserAccountInfo> CreateUserAccount(NewUserAccountInfo accountInfo);
        Task<UserSignInResult> SignIn(string email, string password);
        Task<UserSignOutResult> SignOut();
        Task<UserRoleInfo> GetUserRoleInfo();

        //Auth users
        Task<UserAccountInfo> UpdateUserAccount(UserAccountInfo accountInfo);
        Task<DeleteUserAccountResult> DeleteUserAccount(string email);
        Task<ChangePasswordResult> ResetPassword(string oldpassword, string newpassword);

        //Auth business
        Task<NewBusinessAccountResult> CreateBusinessAccount(BusinessAccountInfo accountInfo);
        Task<BusinessAccountInfo> ReadBusinessAccountInfo();
        Task<BusinessAccountInfo> UpdateBusinessAccountInfo(BusinessAccountInfo accountInfo);
        Task<DeleteBusinessAccountResult> DeleteBusinessAccount();
    }
}
