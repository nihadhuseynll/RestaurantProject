﻿namespace SignalRWebUI.Dtos.ProductDtos
{
	public class GetProductDto
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public string ProductDescription { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
		public bool ProductStatus { get; set; }
		public int CategoryId { get; set; }
	}
}
