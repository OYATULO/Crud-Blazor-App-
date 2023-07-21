using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_Company
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Поля Фамилия обязательны для заполнения")]
        [MaxLength(50)]
        [Display(Name = "Фамилия")]
        public string? Surname { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Поля Имя обязательны для заполнения")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)]
        [Display(Name = "Отчество")]
        public string? MiddleName { get; set; }

        [MaxLength(128)]
        [Display(Name = "ФИО")]
        public string FullName => $"{Surname} {Name} {MiddleName}";

        [Display(Name="Компания")]
        public Guid CompanyId { get; set; }
      
        [Display(Name = "ЛПР")]
        public bool IsDecisionMaker { get; set; } = false;

        [MaxLength(128)]
        [Display(Name="Должность")]
        public string JobTitle { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Дата создания")]
        public DateTime CreationTime { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Дата изменения")]
        public DateTime ModificationTime { get; set; } = DateTime.Now;
    }
}
