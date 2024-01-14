using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
	public interface ISimpleCalculator
	{
		int Add(int start, int amount);
		int Subtract(int start, int amount);
	}
}
