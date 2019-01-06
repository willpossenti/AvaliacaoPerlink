using System;
using System.ComponentModel.DataAnnotations;

namespace AvaliacaoPerlink.Models
{
    public class Avaliacao
    {
        [Required(ErrorMessage = "Informe um número.")]
        public string numero { get; set; }
        public string mensagem { get; set; }
    }
}