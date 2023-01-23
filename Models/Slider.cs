using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Indigo.Models
{
	public class Slider
	{
		public int Id { get; set; }
		[StringLength(maximumLength:100,ErrorMessage = "Image size is large")]
		public string? Image { get; set; }
		[StringLength(maximumLength: 50, ErrorMessage = "The volume of titles is high")]
		public string Title { get; set; }
		[StringLength(maximumLength: 256, ErrorMessage = "The volume of desc is high")]
		public string Desc { get; set; }
		public string Button { get; set; }
		public string URl { get; set; }
		[NotMapped]
		public IFormFile? FormFile { get; set; }
	}
}
