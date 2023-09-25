using System;
namespace Tangy_Models
{
	public class SuccessModelDTO
	{
        public string Title { get; set; }
        public int StatusCode { get; set; }
        public string SuccessMessage { get; set; }
        public object Data { get; set; }
    }
}

