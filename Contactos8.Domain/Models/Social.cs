namespace Contactos8.Domain.Models
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    public class Social
    {
        [Key]
        public int SocialiD
        {
            get;
            set;
        }
        public int PerfilId
        {

            get;
            set;
        }
        public string SocialDescription
        {
            get;
            set;
        }
        public string SocialPerfil
        {
            get;
            set;
        }
        [JsonIgnore]
        public virtual Perfil PerfilGeneral
        {
            get;
            set;

        }
    }
}


