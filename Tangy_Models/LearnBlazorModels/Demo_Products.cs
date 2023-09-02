using System;
using TangyWeb_Server.Pages.LearnBlazor;

namespace Tangy_Models.LearnBlazorModels
{
	public class Demo_Products
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsActive { get; set; }
		public double Price { get; set; }

		public IEnumerable<Demo_ProductProp> ProductProperties { get; set; }
	}
}

