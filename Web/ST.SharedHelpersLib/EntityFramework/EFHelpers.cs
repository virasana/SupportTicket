using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ST.SharedHelpersLib.Exceptions;

namespace ST.SharedHelpersLib.EntityFramework
{
    public static class EfHelpers
    {
        /// <summary>
        /// Creates an instance of the specified DbContext type,
        /// and then executes the Func within the context of a suitable try...catch
        /// </summary>
        /// <typeparam name="TDbContext"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="connectionString"></param>
        /// <param name="func">The delegate that you want to execute</param>
        /// <returns>TResult</returns>
        public static TResult Execute<TDbContext, TResult>(string connectionString, Func<TDbContext, TResult> func)
        where TDbContext : DbContext
        {
            try
            {
                using (var ctx = (TDbContext) Activator.CreateInstance(typeof(TDbContext),
                    connectionString))
                {
                    var result = func(ctx);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new SupportTicketDatabaseException(ex);
            }
        }
    }
}
