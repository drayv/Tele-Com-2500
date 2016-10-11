using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TeleCom.Core;

namespace TeleCom.DataAccess
{
    public class StandardsRepository
    {
        public static List<Standard> GetAll()
        {
            var rates = new List<Standard>();

            var sscsb = new SqlConnectionStringBuilder(Helper.GetConnectionString()) { ConnectTimeout = 5 };
            using (var sqlConnection = new SqlConnection(sscsb.ConnectionString))
            {
                using (var cmd = sqlConnection.CreateCommand())
                {
                    sqlConnection.Open();
                    cmd.CommandText = @"SELECT st.Id, st.Name, st.Value,
                    svc.Id as ServiceId, svc.Name as ServiceName FROM Standards st
                    LEFT JOIN Services svc on svc.Id = st.Service";

                    using (var res = cmd.ExecuteReader())
                    {
                        while (res.Read())
                        {
                            var id = (int)(res["Id"]);
                            var name = (string)(res["Name"]);
                            var value = (string)(res["Value"]);
                            var serviceId = (int)(res["ServiceId"]);
                            var serviceName = (string)(res["ServiceName"]);
                            var service = new Service() { Id = serviceId, Name = serviceName };
                            rates.Add(new Standard { Id = id, Service = service, Name = name, Value = value });
                        }
                    }
                }
            }

            return rates;
        }

        public static Standard GetById(int findId)
        {
            Standard rate = null;

            var sscsb = new SqlConnectionStringBuilder(Helper.GetConnectionString()) { ConnectTimeout = 5 };
            using (var sqlConnection = new SqlConnection(sscsb.ConnectionString))
            {
                using (var cmd = sqlConnection.CreateCommand())
                {
                    sqlConnection.Open();
                    cmd.CommandText = @"SELECT st.Id, st.Name, st.Value,
                    svc.Id as ServiceId, svc.Name as ServiceName FROM Standards st
                    LEFT JOIN Services svc on svc.Id = st.Service
                    WHERE st.Id = @Id";
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = findId;

                    using (var res = cmd.ExecuteReader())
                    {
                        while (res.Read())
                        {
                            var id = (int)(res["Id"]);
                            var name = (string)(res["Name"]);
                            var value = (string)(res["Value"]);
                            var serviceId = (int)(res["ServiceId"]);
                            var serviceName = (string)(res["ServiceName"]);
                            var service = new Service() { Id = serviceId, Name = serviceName };
                            rate = new Standard { Id = id, Service = service, Name = name, Value = value };
                        }
                    }
                }
            }

            return rate;
        }

        public static void Insert(Standard standard)
        {
            var sscsb = new SqlConnectionStringBuilder(Helper.GetConnectionString()) { ConnectTimeout = 5 };
            using (var sqlConnection = new SqlConnection(sscsb.ConnectionString))
            {
                using (var cmd = sqlConnection.CreateCommand())
                {
                    sqlConnection.Open();
                    cmd.CommandText = @"INSERT INTO Standards (Name, Value, Service)
                    VALUES (@Name, @Value, @Service)";
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = standard.Name;
                    cmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = standard.Value;
                    cmd.Parameters.Add("@Service", SqlDbType.Int).Value = standard.Service.Id;

                    cmd.ExecuteReader();
                }
            }
        }

        public static void Update(Standard standard)
        {
            var sscsb = new SqlConnectionStringBuilder(Helper.GetConnectionString()) { ConnectTimeout = 5 };
            using (var sqlConnection = new SqlConnection(sscsb.ConnectionString))
            {
                using (var cmd = sqlConnection.CreateCommand())
                {
                    sqlConnection.Open();
                    cmd.CommandText = @"UPDATE Standards SET Name = @Name,
                    Value = @Value, Service = @Service
                    WHERE Id = @Id";
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = standard.Name;
                    cmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = standard.Value;
                    cmd.Parameters.Add("@Service", SqlDbType.Int).Value = standard.Service.Id;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = standard.Id;

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
                    cmd.CommandText = "DELETE FROM Standards WHERE Id = @Id";
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    cmd.ExecuteReader();
                }
            }
        }
    }
}