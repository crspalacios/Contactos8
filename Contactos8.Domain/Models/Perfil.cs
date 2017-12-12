namespace Contactos8.Domain.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Perfil
    {
        [Key]
        public int PerfilId
        {

            get;
            set;
        }
        /*public string ImagePerfil
        {
            get;
            set;
        }*/
        [Required(ErrorMessage = "The fiel {0} is required.")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters lengthh")]
        [Index("Perfil_Name_Index")]
        public string Name
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        [JsonIgnore]
        public virtual ICollection<Address> Addresses
        {
            get;
            set;
        }

        [JsonIgnore]
        public virtual ICollection<Job> Jobs
        {
            get;
            set;
        }
        [JsonIgnore]
        public virtual ICollection<Phone> Phones
        {
            get;
            set;
        }
        [JsonIgnore]
        public virtual ICollection<Social> Socials
        {
            get;
            set;
        }
        [JsonIgnore]
        public virtual ICollection<Url> Urls
        {
            get;
            set;
        }
        [JsonIgnore]
        public virtual ICollection<Email> Emails
        {
            get;
            set;
        }
        [JsonIgnore]
        public virtual ICollection<Brouchure> Brouchures
        {
            get;
            set;
        }

    }
}
