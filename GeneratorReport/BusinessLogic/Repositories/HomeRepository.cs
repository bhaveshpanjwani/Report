using Dapper;
using GeneratorReport.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GeneratorReport.BusinessLogic.Repositories
{
	public class HomeRepository : IHomeRepository
	{
		private readonly IConfiguration _configuration;

		private SqlConnection sqlConnection;

		public HomeRepository(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		private void Connection(IConfiguration configuration)
		{
			string constring = configuration.GetConnectionString("conString");
			sqlConnection = new SqlConnection(constring);
		}

		/// <summary>
		/// Get All Product data
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public List<Home>? GetTodaysData()
		{
			try
			{
				Connection(_configuration);
				sqlConnection.Open();

				var spName = "SelectReportData";
				var reportData = sqlConnection.Query<Home>(spName, commandType: CommandType.StoredProcedure).ToList();
				sqlConnection.Close();
				if (reportData.Any())
				{
					return reportData;
				}
				return null;
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Get data by date range
		/// </summary>
		/// <param name="fromDate"></param>
		/// <param name="toDate"></param>
		/// <returns></returns>
		[HttpGet]
		public IEnumerable<Home> GetByDateRange(string fromDate, string toDate)
		{
			try
			{
				Connection(_configuration);
				sqlConnection.Open();
				var spName = "SelectReportDataByDate";
				var parameters = new
				{
					StartDate = fromDate,
					EndDate = toDate
				};
				var reportData = sqlConnection.Query<Home>(spName, parameters, commandType: CommandType.StoredProcedure);
				sqlConnection.Close();
				return reportData;
			}
			catch (Exception)
			{
				throw;
			}
		}

	}
}
