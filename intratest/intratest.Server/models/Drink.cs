using System.ComponentModel.DataAnnotations;
namespace intratest.Server.models
{
    public class Drink
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано название напитка")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Не указан путь к изображению")]
        public string Path { get; set; } = "";

        [Required(ErrorMessage = "Не указана стоимость")]
        public int Cost { get; set; } = 0;

        [Required(ErrorMessage = "Не указано кол-во товара")]
        public int Quantity { get; set; } = 1;
    }
}
