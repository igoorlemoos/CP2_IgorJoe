using System.ComponentModel.DataAnnotations;

namespace CP2_IgorJoe.Models
{
    public class Mouses
    {
        [Key]
        public int Id { get; set; }
        public string Modelo { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Peso { get; set; } = string.Empty;
        public string Preco { get; set; } = string.Empty;
    }
}
