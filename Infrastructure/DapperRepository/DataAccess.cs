using Infrastructure.Persistance;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain.Common;
using Microsoft.Extensions.Logging;

namespace Infrastructure.DapperRepository
{
    public static class DataAccess
    {
        #region singleton
        // if you want use singleton use seald instead of static
        //public DataAccess()
        //{

        //}
        //private static readonly object lock1 = new object();
        //private static DataAccess instance = null;
        //public static DataAccess Instance
        //{
        //    get 
        //    {
        //        lock (lock1)
        //        {
        //            if (instance == null)
        //            {
        //                instance = new DataAccess();  
        //            }
        //            return instance; 
        //        }
        //    }
        //}
        #endregion singleton 
        public static async Task<Result> Execute<T>(string command, object conditionValues, int? timeOut = null) where T : new()
        {
            var result = new Result(false);
            try
            {
                using (var connection = new SqlConnection(ConnectionFactory.GetConnectionString()))
                {

                    connection.Execute(command, connection, commandTimeout: timeOut);

                    await connection.CloseAsync();

                    result.State = true;

                }
            }
            catch (Exception ex)
            {
                result.State = false;
                result.ResultDesc = ex.Message;
            }

            return result;
        }
        public static async Task<List<T>> SelectList<T>(string command, object conditionValues, int? timeOut = null) where T : new()
        {
            //IEnumerable<T> result;
            try
            {
                using (var connection = new SqlConnection(ConnectionFactory.GetConnectionString()))
                {

                    var result = await connection.QueryAsync<T>(command, conditionValues, commandTimeout: timeOut);
                    await connection.CloseAsync();

                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<T> Select<T>(string command, object conditionValues, int? timeOut = null) where T : new()
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionFactory.GetConnectionString()))
                {

                    var result = await connection.QueryAsync<T>(command, conditionValues, commandTimeout: timeOut);
                    await connection.CloseAsync();

                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
