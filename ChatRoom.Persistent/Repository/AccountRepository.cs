using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataObj;
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

        public (Exception exception, Login login) Login(Login login)
        {
            try
            {
                //會有錯誤碼跟回傳值
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.QueryMultiple(
                        "pro_accountLogin",
                        //參數名稱為PROCEDURE中宣告的變數名稱
                        new
                        {
                            account  = login.f_account,
                            password = login.f_password
                        },
                        commandType: CommandType.StoredProcedure
                        );

                    
                    var resultCode = result.ReadFirstOrDefault<AccountResult>();
                    var resultData = result.ReadFirstOrDefault<Account>();
                    //var resultData = result.Read();


                    return (null, new Login() { resultCode = resultCode, data = resultData });

                }
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
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
                            account = account.f_account,
                            password = account.f_password,
                            nickName = account.f_nickName
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

        public (Exception exception, Account account) Delete(int id)
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
                            id = id,
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
                            account = account
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
                            @IsLocked = account.f_isLocked,
                            @IsMuted = account.f_isMuted,
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
