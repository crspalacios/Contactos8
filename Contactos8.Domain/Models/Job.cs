namespace Contactos8.Domain.Models
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Job
    {
        [Key]
        public int JobId
        {
            get;
            set;
        }
        public int PerfilId
        {

            get;
            set;
        }
        public string JobCompany
        {
            get;
            set;
        }
        public string JobPosition
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
