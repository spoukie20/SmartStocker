﻿namespace SmartStocker.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StockLevel { get; set; }
        public bool IsActive { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
