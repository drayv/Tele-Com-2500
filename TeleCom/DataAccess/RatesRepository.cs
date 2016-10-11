using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TeleCom.Core;

namespace TeleCom.DataAccess
{
    public class RatesRepository
    {
        public static List<Rate> GetAll()
        {
            var rates = new List<Rate>();

            var sscsb = new SqlConnectionStringBuilder(Helper.GetConnectionString()) { ConnectTimeout = 5 };
            using (var sqlConnection = new SqlConnection(sscsb.ConnectionString))
            {
                using (var cmd = sqlConnection.CreateCommand())
                {
                    sqlConnection.Open();
                    cmd.CommandText = @"SELECT rat.Id, rat.Amount, rat.StartDate,
                    svc.Id as ServiceId, svc.Name as ServiceName FROM Rates rat
                    LEFT JOIN Services svc on svc.Id = rat.Service";

                    using (var res = cmd.ExecuteReader())
                    {
                        while (res.Read())
                        {
                            var id = (int)(res["Id"]);
                            var amount = (decimal)(res["Amount"]);
                            var startDate = (DateTime)(res["StartDate"]);
                            var serviceId = (int)(res["ServiceId"]);
                            var serviceName = (string)(res["ServiceName"]);
                            var service = new Service() { Id = serviceId, Name = serviceName };
                            rates.Add(new Rate { Id = id, Service = service, Amount = amount, StartDate = startDate });
                        }
                    }
                }
            }

            return rates;
        }

        public static Rate GetById(int findId)
        {
            Rate rate = null;

            var sscsb = new SqlConnectionStringBuilder(Helper.GetConnectionString()) { ConnectTimeout = 5 };
            using (var sqlConnection = new SqlConnection(sscsb.ConnectionString))
            {
                using (var cmd = sqlConnection.CreateCommand())
                {
                    sqlConnection.Open();
                    cmd.CommandText = @"SELECT rat.Id, rat.Amount, rat.StartDate,
                    svc.Id as ServiceId, svc.Name as ServiceName FROM Rates rat
                    LEFT JOIN Services svc on svc.Id = rat.Service
                    WHERE rat.Id = @Id";
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = findId;

                    using (var res = cmd.ExecuteReader())
                    {
                        while (res.Read())
                        {
                            var id = (int)(res["Id"]);
                            var amount = (decimal)(res["Amount"]);
                            var startDate = (DateTime)(res["StartDate"]);
                            var serviceId = (int)(res["ServiceId"]);
                            var serviceName = (string)(res["ServiceName"]);
                            var service = new Service() { Id = serviceId, Name = serviceName };
                            rate = new Rate { Id = id, Service = service, Amount = amount, StartDate = startDate };
                        }
                    }
                }
            }

            return rate;
        }

        public static void Insert(Rate rate)
        {
            var sscsb = new SqlConnectionStringBuilder(Helper.GetConnectionString()) { ConnectTimeout = 5 };
            using (var sqlConnection = new SqlConnection(sscsb.ConnectionString))
            {
                using (var cmd = sqlConnection.CreateCommand())
                {
                    sqlConnection.Open();
                    cmd.CommandText = @"INSERT INTO Rates (Amount, StartDate, Service)
                    VALUES (@Amount, @StartDate, @Service)";
                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = rate.Amount;
                    cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = rate.StartDate;
                    cmd.Parameters.Add("@Service", SqlDbType.Int).Value = rate.Service.Id;

                    cmd.ExecuteReader();
                }
            }
        }

        public static void Update(Rate rate)
        {
            var sscsb = new SqlConnectionStringBuilder(Helper.GetConnectionString()) { ConnectTimeout = 5 };
            using (var sqlConnection = new SqlConnection(sscsb.ConnectionString))
            {
                using (var cmd = sqlConnection.CreateCommand())
                {
                    sqlConnection.Open();
                    cmd.CommandText = @"UPDATE Rates SET Amount = @Amount,
                    StartDate = @StartDate, Service = @Service
                    WHERE Id = @Id";
                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = rate.Amount;
                    cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = rate.StartDate;
                    cmd.Parameters.Add("@Service", SqlDbType.Int).Value = rate.Service.Id;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = rate.Id;

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
                    cmd.CommandText = "DELETE FROM Rates WHERE Id = @Id";
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    cmd.ExecuteReader();
                }
            }
        }
    }
}