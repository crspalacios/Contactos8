using Contactos8.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contactos8.Backend.Models
{
    [NotMapped]
    public class BrouchureView : Brouchure
    {
        public HttpPostedFileBase ImageBrouchureFile { get; set; }
    }
}