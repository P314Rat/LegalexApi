using System.ComponentModel.DataAnnotations;


namespace LegalexApi.DAL.Models.OrderAggregate
{
    public enum Service
    {
        [Display(Name = "Не выбран")]
        NonSelected,
        [Display(Name = "Юридические услуги")]
        Legal,
        [Display(Name = "Антикризисное управление и банкротство")]
        CrisisManagement,
        [Display(Name = "Медиация")]
        Mediation,
        [Display(Name = "HR-услуги")]
        HR,
        [Display(Name = "Услуги кадрового специалиста")]
        HRSupport,
        [Display(Name = "Охрана труда")]
        OccupationalSafetyAndHealth,
        [Display(Name = "Защита персональных данных")]
        ProtectionOfPersonalInformation,
        [Display(Name = "Услуги экономиста")]
        Finance
    }

    public enum ClientType
    {
        [Display(Name = "Юридическое лицо")]
        Legal,
        [Display(Name = "Физическое лицо")]
        Person
    }

    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public ClientType ClientType { get; set; }
        public Service Service { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
