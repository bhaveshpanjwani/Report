using GeneratorReport.BusinessLogic.Repositories;
using GeneratorReport.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GeneratorReport.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{

		private readonly HomeRepository homeRepository;

		private readonly IConfiguration _configuration;

		public HomeController(IConfiguration configuration)
		{
			_configuration = configuration;
			homeRepository = new HomeRepository(_configuration);
		}

		[HttpGet]
		public JsonResult GetTodaysData()
		{
			List<Home>? products = homeRepository.GetTodaysData();
			return new JsonResult(products);
		}


	}
}
