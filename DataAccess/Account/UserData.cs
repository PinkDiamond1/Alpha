﻿using Auctus.DomainObjects.Account;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Auctus.DataAccess.Account
{
    public class UserData : BaseData<User>
    {
        public override string TableName => "[User]";

        private const string SELECT_BY_API_KEY = @"SELECT u.* FROM [User] u INNER JOIN ApiAccess a ON a.UserId = u.Id 
                                                   WHERE a.CreationDate = (SELECT max(a2.CreationDate) FROM ApiAccess a2 WHERE a2.UserId = u.Id)
                                                   AND a.ApiKey = @ApiKey";

        private const string SELECT_WITH_WALLET_BY_EMAIL = @"SELECT u.*, w.* FROM [User] u INNER JOIN [Wallet] w ON w.UserId = u.Id 
                                                   WHERE u.Email = @Email";

        private const string SELECT_WITH_WALLET_BY_EMAIL_OR_USERNAME = @"SELECT u.*, w.* FROM [User] u INNER JOIN [Wallet] w ON w.UserId = u.Id 
                                                   WHERE u.Email = @Email OR u.Username = @Username";

        private const string SELECT_WITH_WALLET_BY_WALLET = @"SELECT u.*, w.* FROM [User] u INNER JOIN [Wallet] w ON w.UserId = u.Id 
                                                   WHERE w.Address = @Address";

        public User Get(string email)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Email", email.ToLower().Trim(), DbType.AnsiString);

            return Query<User, Wallet, User>(SELECT_WITH_WALLET_BY_EMAIL,
                                (user, wallet) =>
                                {
                                    user.Wallet = wallet;
                                    return user;
                                }, "UserId", parameters).SingleOrDefault();
        }

        public User GetByEmail(string email)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Email", email.ToLower().Trim(), DbType.AnsiString);
            return SelectByParameters<User>(parameters).SingleOrDefault();
        }

        public User GetByUsername(string username)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Username", username.ToLower().Trim(), DbType.AnsiString);
            return SelectByParameters<User>(parameters).SingleOrDefault();
        }

        public User GetByWalletAddress(string address)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Address", address.ToUpper().Trim(), DbType.AnsiStringFixedLength);
            return Query<User, Wallet, User>(SELECT_WITH_WALLET_BY_WALLET,
                                (user, wallet) =>
                                {
                                    user.Wallet = wallet;
                                    return user;
                                }, "UserId", parameters).SingleOrDefault();
        }

        public User GetByEmailOrUsername(string emailOrUsername)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Email", emailOrUsername.ToLower().Trim(), DbType.AnsiString);
            parameters.Add("Username", emailOrUsername.ToLower().Trim(), DbType.AnsiString);

            return Query<User, Wallet, User>(SELECT_WITH_WALLET_BY_EMAIL_OR_USERNAME,
                                (user, wallet) =>
                                {
                                    user.Wallet = wallet;
                                    return user;
                                }, "UserId", parameters).SingleOrDefault();
        }

        public User Get(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            return SelectByParameters<User>(parameters).SingleOrDefault();
        }

        public User GetByConfirmationCode(string confirmationCode)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("ConfirmationCode", confirmationCode, DbType.AnsiString);
            return SelectByParameters<User>(parameters).SingleOrDefault();
        }

        public User Get(Guid guid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("ApiKey", guid.ToString(), DbType.AnsiString);
            return Query<User>(SELECT_BY_API_KEY, parameters).SingleOrDefault();
        }
    }
}
