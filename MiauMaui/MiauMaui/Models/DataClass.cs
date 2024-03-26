using System;
namespace MiauMaui.Models
{
	public class DataClass
	{
		public string Id { get; set; } = Guid.NewGuid().ToString();
		public string Title { get; set; }
		public bool IsDone { get; set; }
        public bool IsVisible { get; set; }

    }
}

