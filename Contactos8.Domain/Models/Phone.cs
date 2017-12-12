namespace Contactos8.Domain.Models
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Phone
    {
        [Key]
        public int PhoneId
        {
            get;
            set;
        }
        public int PerfilId
        {

            get;
            set;
        }
        [Required(ErrorMessage = "The fiel {0} is required.")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters lengthh")]
        [Index("Phone_PhoneNumber_Index", IsUnique = true)]
        public string PhoneNumber
        {
            get;
            set;
        }
        public string DescriptionPhone
        {
            get;
            set;
        }
        [DataType(DataType.Date)]
        public DateTime LastUpdate
        {
            get;
            set;
        }
        [JsonIgnore]
        public virtual Perfil Perfil
        {
            get;
            set;

        }
    }
}
