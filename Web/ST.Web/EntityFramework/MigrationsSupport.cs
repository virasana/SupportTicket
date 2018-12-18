using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ST.SQLServerRepoLib;
using ST.UsersRepoLib;
using ST.Web.Services;

// https://github.com/aspnet/EntityFrameworkCore/issues/12331
// TODO: How to get Entity Framework out of the UI!
// Could create a dummy startup project for the purpose of EF Migrations
namespace ST.Web.EntityFramework
{
    public class STDbContextFactory<TDbContext> : 
        IDesignTimeDbContextFactory<TDbContext> 
        where TDbContext: DbContext
    {
        private readonly string _connString;

        public STDbContextFactory(string connString)
        {
            _connString = connString;
        }
        public TDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TDbContext>();
            optionsBuilder.UseSqlServer(_connString);
            TDbContext result = (TDbContext) Activator.CreateInstance(typeof(TDbContext), optionsBuilder.Options);
            return result;
        }
    }

    public class UsersDbContextFactory : STDbContextFactory<UsersDbContext>
    {
        public UsersDbContextFactory() :
            base(Environment.GetEnvironmentVariable(
                App.Constants.ConnStringAuth))
        {}
    }

    public class SupportTicketDbContextFactory: 
        STDbContextFactory<SupportTicketDbContext>
    {
        public SupportTicketDbContextFactory() :
            base(Environment.GetEnvironmentVariable(
                App.Constants.ConnStringSupportTicket))
        {}
    }
}
