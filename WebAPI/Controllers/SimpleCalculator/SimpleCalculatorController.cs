using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using SimpleCalculatorLibrary = global::SimpleCalculator;

namespace WebAPI.Controllers.SimpleCalculator
{
	[ApiController]
	[Route("api/simplecalculator")]
	[SwaggerTag("Simple calculator with basic features")]
	public class SimpleCalculatorController : ControllerBase
	{
		private readonly ILogger<SimpleCalculatorController> _logger;

		public SimpleCalculatorController(ILogger<SimpleCalculatorController> logger)
		{
			_logger = logger;
		}

		[ProducesResponseType(typeof(SimpleCalculatorResultDto), StatusCodes.Status200OK)]
		[HttpPost]
		[Route("add")]
		[SwaggerOperation(Tags = new[] { "Add amount to start" })]
		public IActionResult Add([FromBody] SimpleCalculatorRequestDto dto)
		{
			var calculator = SimpleCalculatorLibrary.ObjectFactory.Instance().CreateSimpleCalcultor();
			var result = new SimpleCalculatorResultDto(dto, calculator.Add(dto.Start, dto.Amount));
			return Ok(result);
		}

		[ProducesResponseType(typeof(SimpleCalculatorResultDto), StatusCodes.Status200OK)]
		[HttpPost]
		[Route("subtract")]
		[SwaggerOperation(Tags = new[] { "Subtract amount from start" })]
		public IActionResult Subtract([FromBody] SimpleCalculatorRequestDto dto)
		{
			var calculator = SimpleCalculatorLibrary.ObjectFactory.Instance().CreateSimpleCalcultor();
			var result = new SimpleCalculatorResultDto(dto, calculator.Subtract(dto.Start, dto.Amount));
			return Ok(result);
		}
	}
}