namespace Contactos8.Domain.Models
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class Address
    {
        [Key]
        public int AddressId
        {
            get;
            set;
        }
        public int PerfilId
        {

            get;
            set;
        }
        public string DescriptionAddress
        {
            get;
            set;
        }
        public string NameAddress
        {
            get;
            set;
        }
        public string Ubications
        {
            get;
            set;
        }
        public string Barrio
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
