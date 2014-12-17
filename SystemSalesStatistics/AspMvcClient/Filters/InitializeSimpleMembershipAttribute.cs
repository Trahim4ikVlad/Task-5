using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using AspMvcClient.Models;

namespace AspMvcClient.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<UsersContext>(null);

                try
                {
                    using (var context = new UsersContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // Create the SimpleMembership database without Entity Framework migration schema
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }

                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                    InitDefaultUsersAndRoles();
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }

            private void InitDefaultUsersAndRoles()
            {
                var roles = (SimpleRoleProvider)Roles.Provider;
                var membership = (SimpleMembershipProvider)Membership.Provider;

                // проверяю наличие ролей, если нет создаем
                if (!roles.GetAllRoles().Contains("Administrator"))
                {
                    roles.CreateRole("Administrator");
                }
                if (!roles.GetAllRoles().Contains("User"))
                {
                    roles.CreateRole("User");
                }

                // проверяю наличие зарегистрированного пользователя
                MembershipUser user = membership.GetUser("Administrator", false);

                //создаю, если пользователя не найдено
                if (user == null)
                {
                    membership.CreateUserAndAccount("Administrator", "Administrator");
                }

                //добавляю пользователю права администратора
                if (!roles.GetRolesForUser("Administrator").Contains("Administrator"))
                {
                    roles.AddUsersToRoles(
                        new[] { "Administrator" },
                        new[] { "Administrator" });
                }
            }
        }
    }
}
