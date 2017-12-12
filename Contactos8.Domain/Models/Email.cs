namespace Contactos8.Domain.Models
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Email
    {
        [Key]
        public int EmailId
        {
            get;
            set;
        }
        public int PerfilId
        {

            get;
            set;
        }
        public string DescriptionEmail
        {
            get;
            set;
        }
        [Required(ErrorMessage = "The fiel {0} is required.")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters lengthh")]
        [Index("Phone_PhoneNumber_Index", IsUnique = true)]
        public string NameEmail
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
