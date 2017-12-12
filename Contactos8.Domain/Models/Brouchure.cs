namespace Contactos8.Domain.Models
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Brouchure
    {
        [Key]
        public int BrouchureId
        {
            get;
            set;
        }
        public int PerfilId
        {

            get;
            set;
        }
        public string BrouchureImage
        {
            get;
            set;
        }
        public string BrochureDescription
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
