using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_Company
{
    public class Communication
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Компания")]
        [ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }= default!;
        private MCompany Company { get; set; } = default!;

        [Display(Name ="Контакт")]
        [ForeignKey(nameof(Contact))]
        public Guid ContacId { get; set; }
        private Contact Contact { get; set; } = default!;
        
        [Display(Name = "Тип связи")]
        public SelectType Type { get; set; } = SelectType.All;

        [Display(Name = "Телефон")]
        [MaxLength(28)]
        public string PhoneNumber { get; set; } =string.Empty;

        [Display(Name = "Email")]
        [MaxLength(50)]
        public string? Email { get; set; }  

        public enum SelectType{
           Phone,
           Email,
           All
        }
    }
}
