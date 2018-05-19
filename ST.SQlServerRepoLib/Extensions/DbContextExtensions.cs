using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ST.SQLServerRepoLib.Extensions
{
    internal static class DbContextExtensions
    {
        // https://stackoverflow.com/questions/36208580/what-happened-to-addorupdate-in-ef-7
        public static void AddOrUpdate<T>(this DbSet<T> dbSet, T data) where T : class
        {
            var t = typeof(T);
            PropertyInfo keyField = null;
            foreach (var propt in t.GetProperties())
            {
                var keyAttr = propt.GetCustomAttribute<KeyAttribute>();
                if (keyAttr != null)
                {
                    keyField = propt;
                    break; // assume no composite keys
                }
            }

            if (keyField == null)
            {
                throw new Exception($"{t.FullName} does not have a KeyAttribute field. Unable to exec AddOrUpdate call.");
            }

            var keyVal = keyField.GetValue(data);
            var dbVal = dbSet.Find(keyVal);

            if (dbVal != null)
            {
                dbSet.Update(data);
            }

            dbSet.Add(data);
        }

        public static void AddOrUpdateRange<T>(this DbSet<T> dbSet, List<T> data, string uniqueProperty) where T : class
        {
            foreach (T item in data)
            {
                dbSet.AddOrUpdate(item);
            }
        }
        }
}
