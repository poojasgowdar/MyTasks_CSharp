﻿using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Application.ViewModels
{
    public class ProductUpdateDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
