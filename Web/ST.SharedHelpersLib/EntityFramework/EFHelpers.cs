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
        public static TResult Execute<TResult, TDbContext>(TDbContext ctx, string errorMessage, Func<TDbContext, TResult> func) 
            where TDbContext : DbContext
        {
            try
            {
               var result = func(ctx);
               return result;
            }
            catch (Exception ex)
            {
                throw new SupportTicketApplicationException(errorMessage,
                    new SupportTicketDatabaseException(ex));
            }
        }
    }
}
