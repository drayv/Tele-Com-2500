using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TeleCom.Core;

namespace TeleCom.DataAccess
{
    public class ServicesRepository
    {
        public static List<Service> GetAll()
        {
            var services = new List<Service>();

            var sscsb = new SqlConnectionStringBuilder(Helper.GetConnectionString()) { ConnectTimeout = 5 };
            using (var sqlConnection = new SqlConnection(sscsb.ConnectionString))
            {
                using (var cmd = sqlConnection.CreateCommand())
                {
                    sqlConnection.Open();
                    cmd.CommandText = @"SELECT svc.Id, svc.Name, MAX(rat.Amount) as CurAmount FROM Services svc
                    LEFT JOIN Rates rat on rat.Service = svc.Id
                    AND rat.StartDate <= CAST(GETDATE() AS DATE)
                    GROUP BY svc.Id, svc.Name";

                    using (var res = cmd.ExecuteReader())
                    {
                        while (res.Read())
                        {
                            var id = (int)(res["Id"]);
                            var name = (string)(res["Name"]);
                            decimal curAmount = 0;
                            if (res["CurAmount"] != System.DBNull.Value)
                            {
                                curAmount = (decimal)(res["CurAmount"]);
                            }
                            services.Add(new Service { Id = id, Name = name, CurAmount = curAmount });
                        }
                    }
                }
            }

            return services;
        }

        public static Service GetById(int findId)
        {
            Service service = null;

            var sscsb = new SqlConnectionStringBuilder(Helper.GetConnectionString()) { ConnectTimeout = 5 };
            using (var sqlConnection = new SqlConnection(sscsb.ConnectionString))
            {
                using (var cmd = sqlConnection.CreateCommand())
                {
                    sqlConnection.Open();
                    cmd.CommandText = @"SELECT svc.Id, svc.Name, MAX(rat.Amount) as CurAmount FROM Services svc
                    LEFT JOIN Rates rat on rat.Service = svc.Id
                    AND rat.StartDate <= CAST(GETDATE() AS DATE)
                    WHERE svc.Id = @Id
                    GROUP BY svc.Id, svc.Name";
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = findId;

                    using (var res = cmd.ExecuteReader())
                    {
                        while (res.Read())
                        {
                            var id = (int)(res["Id"]);
                            var name = (string)(res["Name"]);
                            decimal curAmount = 0;
                            if (res["CurAmount"] != System.DBNull.Value)
                            {
                                curAmount = (decimal)(res["CurAmount"]);
                            }
                            service = new Service { Id = id, Name = name, CurAmount = curAmount };
                        }
                    }
                }
            }

            return service;
        }

        public static void Insert(Service service)
        {
            var sscsb = new SqlConnectionStringBuilder(Helper.GetConnectionString()) { ConnectTimeout = 5 };
            using (var sqlConnection = new SqlConnection(sscsb.ConnectionString))
            {
                using (var cmd = sqlConnection.CreateCommand())
                {
                    sqlConnection.Open();
                    cmd.CommandText = "INSERT INTO Services (Name) VALUES (@Name)";
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = service.Name;

                    cmd.ExecuteReader();
                }
            }
        }

        public static void Update(Service service)
        {
            var sscsb = new SqlConnectionStringBuilder(Helper.GetConnectionString()) { ConnectTimeout = 5 };
            using (var sqlConnection = new SqlConnection(sscsb.ConnectionString))
            {
                using (var cmd = sqlConnection.CreateCommand())
                {
                    sqlConnection.Open();
                    cmd.CommandText = "UPDATE Services SET Name = @Name WHERE Id = @Id";
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = service.Id;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = service.Name;

                    cmd.ExecuteReader();
                }
            }
        }

        public static void Delete(int id)
        {
            var sscsb = new SqlConnectionStringBuilder(Helper.GetConnectionString()) { ConnectTimeout = 5 };
            using (var sqlConnection = new SqlConnection(sscsb.ConnectionString))
            {
                using (var cmd = sqlConnection.CreateCommand())
                {
                    sqlConnection.Open();
                    cmd.CommandText = "DELETE FROM Services WHERE Id = @Id";
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    cmd.ExecuteReader();
                }
            }
        }
    }
}