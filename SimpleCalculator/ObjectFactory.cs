using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
	public class ObjectFactory : IObjectFactory
	{
		private static readonly Lazy<ObjectFactory> _factory = new Lazy<ObjectFactory>(() => new ObjectFactory());

		public static IObjectFactory Instance()
		{
			return _factory.Value;
		}

		public ISimpleCalculator CreateSimpleCalcultor() => new SimpleCalculator();
	}
}
