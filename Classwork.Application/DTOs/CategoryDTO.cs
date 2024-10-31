

namespace Classwork.Application.DTOs
{
    public class CategoryDTO : IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }

    public class CategoryCreateDTO : IDto 
    {
        public required string Name { get; set; }
    }

    public class CategoryUpdateDTO : IDto
    {
        public required string Name { get; set; }
    }

    public class CategoryListDTO : IDto//, BasePageableDTO
    {

    }
}
