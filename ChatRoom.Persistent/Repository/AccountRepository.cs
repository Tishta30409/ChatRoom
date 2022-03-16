using ChatRoom.Domain.Model;
using ChatRoom.Domain.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ChatRoom.Persistent.Repository
{
    public class AccountRepository : IAccountRepository
    {
        /// <summary>
        /// 連線字串
        /// </summary>
        private string connectionString;

        public AccountRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public (Exception exception, Account account) Add(Account account)
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.QueryFirstOrDefault<Account>(
                        "pro_accountAdd",
                        //參數名稱為PROCEDURE中宣告的變數名稱
                        new
                        {
                            @Account = account.f_account,
                            @Password = account.f_password,
                            @NickName = account.f_nickName
                        },
                        commandType: CommandType.StoredProcedure);

                    return (null, result);
                }
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, Account account) Delete(string account)
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.QueryFirstOrDefault<Account>(
                        "pro_accountDelete",
                        //參數名稱為PROCEDURE中宣告的變數名稱
                        new
                        {
                            @Account = account,
                        },
                        commandType: CommandType.StoredProcedure);

                    return (null, result);
                }
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, Account account) Query(string account)
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.QueryFirstOrDefault<Account>(
                        "pro_accountQuery",
                        //參數名稱為PROCEDURE中宣告的變數名稱
                        new
                        {
                            @Account = account
                        },
                        commandType: CommandType.StoredProcedure);

                    return (null, result);
                }
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, IEnumerable<Account> accounts) QueryList()
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.Query<Account>(
                        "pro_accountQueryList",
                        //參數名稱為PROCEDURE中宣告的變數名稱
                        commandType: CommandType.StoredProcedure);

                    return (null, result);
                }
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, Account account) Update(Account account)
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.QueryFirstOrDefault<Account>(
                        "pro_accountUpdate",
                        //參數名稱為PROCEDURE中宣告的變數名稱
                        new
                        {
                            @Account = account.f_account,
                            @Password = account.f_password,
                            @NickName = account.f_nickName,
                            @State = account.f_state,
                            @ErrorTimes = account.f_errorTimes,
                        },
                        commandType: CommandType.StoredProcedure);

                    return (null, result);
                }
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }
    }
}
