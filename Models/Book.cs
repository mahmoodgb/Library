using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
	public class Book
	{
		[Key]
		public int BookID { get; set; }
		[Required(ErrorMessage ="Book Title is Required!")]
		[StringLength(60,MinimumLength =5,ErrorMessage = "FullTitle between 5 - 60 char!")]
		public string FullTitle { get; set; }
		[Range(0,100,ErrorMessage ="Parice betwen 0 - 100!")]
		public double Price { get; set; }

		public BookType Type { get; set; } = BookType.New;
	}
}
