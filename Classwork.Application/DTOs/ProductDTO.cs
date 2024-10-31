

namespace Classwork.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }


        public class ProductCreateDto : IDto
        {
            public required string Name { get; set; }
            public int CategoryId { get; set; }
            public decimal Price { get; set; }
        }

        public class ProductUpdateDto : IDto
        {
            public string? Name { get; set; }
            public decimal Price { get; set; }
            public int CategoryId { get; set; }

        }

        public class ProductListDto :IDto//, BasePageableDTO
        {

        }
    }
}
