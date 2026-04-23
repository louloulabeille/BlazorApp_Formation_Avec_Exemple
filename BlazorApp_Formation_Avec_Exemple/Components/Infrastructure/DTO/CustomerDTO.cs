using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorApp_Formation_Avec_Exemple.Components.Infrastructure.DTO
{
    public class CustomerDTO
    {
        [Required(ErrorMessage = "Le nom est requis")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Le numéro de rue est requis"), RegularExpression(@"^\d+$", ErrorMessage = "le numéro de rue doit avoir que des chiffres")]
        public string NumRue { get; set; } = string.Empty;
        [Required(ErrorMessage = "Le nom de la rue est requis"), StringLength(64, MinimumLength = 1, ErrorMessage = "Le nom de la rue doit contenir entre 1 et 64 caractères")]
        public string NomRue { get; set; } = string.Empty;
        [Required(ErrorMessage = "Le code postal est requis"), RegularExpression(@"^\d{5}$", ErrorMessage = "Le code postal doit contenir 5 chiffres")]
        public string CodePostal { get; set; } = string.Empty;
    }
}
