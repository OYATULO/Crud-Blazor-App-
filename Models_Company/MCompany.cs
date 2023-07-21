using System.ComponentModel.DataAnnotations;

namespace Models_Company
{
    public class MCompany
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Поля Название обязательны для заполнения")]
        [StringLength(128)]
        [Display(Name = "Название")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Поля Уровень доверия обязательны для заполнения")]
        [Display(Name="Уровень доверия")]
        public EnumType Level { get; set; }

        [Display(Name="ЛПР")]
        public Guid DecisionMakerId { get; set; }

        [MaxLength(200,ErrorMessage ="Error")]
        [Display(Name="Комментарий")]
        public string? Comment { get; set; }

        [Required]
        [Display(Name="Дата создания")]
        public DateTime CreationTime { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Дата изменения")]
        public DateTime ModificationTime { get; set; } = DateTime.Now;


        public enum EnumType
        {
            Premium,
            First,
            Second,
            Third,
        }
    }
}