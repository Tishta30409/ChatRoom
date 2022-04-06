using ChatRoom.Domain.Model.DataType;
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

        public (Exception exception, AccountResult result) Login(Account login)
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
                            account = login.f_account,
                            password = login.f_password,
                            loginIdentifier = Guid.NewGuid().ToString()
                        },
                        commandType: CommandType.StoredProcedure
                        );

                    var resultCode = result.ReadFirstOrDefault<ResultCode>();
                    var resultData = result.ReadFirstOrDefault<Account>();
                    //var resultData = result.Read();
                    
                    return (null, new AccountResult() { ResultCode = resultCode, Account = resultData });
                }
            }
            catch (Exception ex)
            {
                return (ex, new AccountResult()
                {
                    ResultCode = ResultCode.DEFAULT_ERROR,
                    Account = null
                });
            }
        }

        public (Exception exception, ResultCode result) Add(Account account)
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.QueryMultiple(
                        "pro_accountAdd",
                        //參數名稱為PROCEDURE中宣告的變數名稱
                        new
                        {
                            account = account.f_account,
                            password = account.f_password,
                            nickName = account.f_nickName
                        },
                        commandType: CommandType.StoredProcedure);

                    var resultCode = result.ReadFirstOrDefault<ResultCode>();

                    return (null, resultCode);
                }
            }
            catch (Exception ex)
            {
                return (ex, ResultCode.DEFAULT_ERROR);
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

        public (Exception exception, AccountResult result) Update(Account account)
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.QueryMultiple(
                        "pro_accountUpdate",
                        //參數名稱為PROCEDURE中宣告的變數名稱
                        new
                        {
                            account = account.f_account,
                            nickName = account.f_nickName,
                            isLocked = account.f_isLocked,
                            isMuted = account.f_isMuted,
                            errorTimes = account.f_errorTimes,
                            loginIdentifier = account.f_loginIdentifier,
                            serialNumber = account.f_serialNumber,
                        },
                        commandType: CommandType.StoredProcedure);

                    var resultCode = result.ReadFirstOrDefault<ResultCode>();
                    var resultData = result.ReadFirstOrDefault<Account>();

                    return (null, new AccountResult()
                    {
                        ResultCode = resultCode,
                        Account = resultData
                    });
                }
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, Account account) ChangePwd(Account account)
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.QueryFirstOrDefault<Account>(
                        "pro_accountChangePassword",
                        //參數名稱為PROCEDURE中宣告的變數名稱
                        new
                        {
                            account = account.f_account,
                            password = account.f_password
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
