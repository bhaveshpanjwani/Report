using GeneratorReport.Model;

namespace GeneratorReport.BusinessLogic.Repositories
{
	public interface IHomeRepository
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public List<Home> GetTodaysData();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="fromDate"></param>
		/// <param name="toDate"></param>
		/// <returns></returns>
		public IEnumerable<Home> GetByDateRange(string fromDate, string toDate);
	}
}
