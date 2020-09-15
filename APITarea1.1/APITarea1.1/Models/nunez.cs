using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APITarea1._1.Models
{
    public enum Places
    {
        SantaCruz = 1,
        Montero,
        Concepcion,
        Warnes,
        Porongo
    };
    public class nunez
    {
        [Key]
        public int nunezID { get; set; }
        [Required]
        [Display(Name = "Nombre completo")]
        [StringLength(24, MinimumLength = 2)]
        public string Friendofnunez { get; set; }
        [Required]
        public Places Place { get; set; }
        // VALIDACION PARA CORREOS
        [EmailAddress]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email no valido")]
        public string Email { get; set; }
        [Display(Name = "Cumpleaños")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }


    }
}