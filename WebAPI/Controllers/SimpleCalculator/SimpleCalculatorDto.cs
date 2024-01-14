namespace WebAPI.Controllers.SimpleCalculator
{
	public class SimpleCalculatorRequestDto
	{
		public int Start { get; set; }
		public int Amount { get; set; }
	}

	public class SimpleCalculatorResultDto : SimpleCalculatorRequestDto
	{
		public SimpleCalculatorResultDto(SimpleCalculatorRequestDto dto, int result)
		{
			Start = dto.Start;
			Amount = dto.Amount;
			Result = result;
		}

		public int Result { get; set; }
	}
}