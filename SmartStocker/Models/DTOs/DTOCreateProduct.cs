using SmartStocker.Models.Entities;

namespace SmartStocker.Models.DTOs
{
    public class DTOCreateProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int StockLevel { get; set; }
        public int SupplierId { get; set; }
    }
}
