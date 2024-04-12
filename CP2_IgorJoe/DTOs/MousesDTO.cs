using System.ComponentModel.DataAnnotations;

namespace CP2_IgorJoe.DTOs
{
    public class MousesDTO
    {
        public int Id { get; set; }

        [Required]
        public string Modelo { get; set; } = string.Empty;

        [Required]
        public string Marca { get; set; } = string.Empty;

        [Required]
        public string Peso { get; set; } = string.Empty;

        [Required]
        public string Preco { get; set; } = string.Empty;
    }
}
