using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.Linq;
using WeeklyPlaner.Logging;

namespace WeeklyPlaner.DAL
{
    // Interceptor that will generate dummy transient errors when you enter "Throw" in the Search box
    public class WeeklyPlanerInterceptorTransientErrors : DbCommandInterceptor
    {
        /*
         * When you run the WeeklyPlaner page and enter "Throw" as the search string, this code creates 
         * a dummy SQL Database exception for error number 20, a type know to be typically transient. 
         * Other error numbers currently recognized as transiet are 64, 233, 10053, 10054, 10060, 
         * 10928, 40197, 40501, 40613,
         * but these are subject to change in new versions of SQL Databse.
         * 
         * The code returns the exception to Entity Framework instead of running the query and passing 
         * back query results. The transient exception is returned four times, and then the code reverts 
         * to the normal procedure of passing the query to the database.
         * 
         * Because everything is logged, you'll be able to see that Entity Framework tries to execute the 
         * query four times before finally succeeding, and the only difference in the application is that 
         * it takes longer to render a page with query results.
         * 
         * The number of times the Entity Framework will retry is configurable; the code specifies four 
         * times because that's the default value for the SQL Database execution policy. If you change 
         * the execution policy, you'd also change the code here that specifies how many times transient 
         * errors are generated. You could also change the code to generate more exceptions so that 
         * Entity Framework will throw the RetryLimitExceededException exception.
         *
         * The value you enter in the Search box will be in command.Parameters[0] and command.Parameters[1] 
         * (one is used for the first name and one for the last name). When the value "%Throw%" is found, 
         * "Throw" is replaced in those parameters by "an" so that some students will be found and returned. 
         *
         * This is just a convenient way to test connection resiliency based on changing some input to 
         * the application UI. You can also write code that generates transient errors for all queries or 
         * updates, as explained later in the comments about the DbInterception.Add method.
         */

        private int _counter = 0;
        private ILogger _logger = new Logger();

        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            bool throwTransientErrors = false;
            if (command.Parameters.Count > 0 && command.Parameters[0].Value.ToString() == "%Throw%")
            {
                throwTransientErrors = true;
                command.Parameters[0].Value = "%an%";
                command.Parameters[1].Value = "%an%";
            }

            if (throwTransientErrors && _counter < 4)
            {
                _logger.Information("Returning transient error for command: {0}", command.CommandText);
                _counter++;
                interceptionContext.Exception = CreateDummySqlException();
            }
        }

        private SqlException CreateDummySqlException()
        {
            // The instance of SQL Server you attempted to connect to does not support encryption
            var sqlErrorNumber = 20;

            var sqlErrorCtor = typeof(SqlError).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).Where(c => c.GetParameters().Count() == 7).Single();
            var sqlError = sqlErrorCtor.Invoke(new object[] { sqlErrorNumber, (byte)0, (byte)0, "", "", "", 1 });

            var errorCollection = Activator.CreateInstance(typeof(SqlErrorCollection), true);
            var addMethod = typeof(SqlErrorCollection).GetMethod("Add", BindingFlags.Instance | BindingFlags.NonPublic);
            addMethod.Invoke(errorCollection, new[] { sqlError });

            var sqlExceptionCtor = typeof(SqlException).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).Where(c => c.GetParameters().Count() == 4).Single();
            var sqlException = (SqlException)sqlExceptionCtor.Invoke(new object[] { "Dummy", errorCollection, null, Guid.NewGuid() });

            return sqlException;
        }
    }
}