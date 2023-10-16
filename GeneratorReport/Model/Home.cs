using System.Diagnostics.Contracts;

namespace GeneratorReport.Model
{
	public class Home
	{
		public int Id { get; set; }
		public string? Label_Id { get; set; }
		public string? Print_Job_Id { get; set; }
		public string? Verification_Type { get; set; }
		public string? Passing_Grade_Threshold { get; set; }
		public DateTime Date { get; set; }
		public TimeSpan Time { get; set; }
		public string? Label_Numeric_Grade { get; set; }
		public string? Label_Grade { get; set; }
		public string? Label_Status { get; set; }
		public string? Barcode_ID { get; set; }
		public string? Grade { get; set; }
		public string? Data { get; set; }
		public string? PrinterName { get; set; }
	}
}
