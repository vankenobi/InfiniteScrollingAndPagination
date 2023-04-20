using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ScrollPagination.Model
{
	public class PageResult<T>
	{
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public List<T> Items { get; set; }
		public int TotalRecord { get; set; }

    }
}

