using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Notifications_SignalR.Controllers
{
    public class DemoUserController : Controller
    {
        // GET: DemoUser
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        public JsonResult GetDemoUsers()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NotificationsDBCon"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT [UserId],[UserName] FROM DemoUsers WHERE [Status] <> 0", connection))
                {
                    command.Notification = null;
                    SqlDependency dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    SqlDataReader reader = command.ExecuteReader();
                    var listUsers = reader.Cast<IDataRecord>()
                            .Select(x => new
                            {
                                UserId = (int)x["UserId"],
                                UserName = (string)x["UserName"],
                            }).ToList();
                    return Json(new { listUsers = listUsers }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            UserHub.Show();
        }
    }
}
 