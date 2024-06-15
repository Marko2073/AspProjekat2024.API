using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Application.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int ModelVersionId { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }
        public List<SpecificationDto> Specifications { get; set; }
        public List<PicturesDto> Pictures { get; set; }



    }
    public class SpecificationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Parent { get; set; }
    }
    public class PicturesDto
    {
        public int Id { get; set; }
        public string Path { get; set; }
    }

}
