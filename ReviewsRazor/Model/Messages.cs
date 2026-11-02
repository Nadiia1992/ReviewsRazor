
using System;
using System.ComponentModel.DataAnnotations;


namespace ReviewsRazor.Models
{
    public class Message
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Поле є обов'язковим для заповнення")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Довжина має бути від 5 до 500 символів.")]
        [Display(Name = "Відгук")]
        public string? Comment { get; set; }


        [Required(ErrorMessage = "Поле є обов'язковим для заповнення")]
        [Display(Name = "Дата відгуку")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime MessageDate { get; set; }

        [Display(Name = "Фото")]
        public string? Foto { get; set; }

        public int UserId { get; set; }

        public Users? User { get; set; }
    }
}