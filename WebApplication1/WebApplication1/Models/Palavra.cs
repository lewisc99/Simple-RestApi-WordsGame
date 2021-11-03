using Microsoft.VisualBasic.CompilerServices;
using System;

using System.ComponentModel.DataAnnotations;

using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Palavra
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is Required to filled")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Score is Required to filled")]
        public int Pontuacao { get; set; }

        [Required(ErrorMessage = "Creation date is Required to filled")]

        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]

        [DataType(DataType.Date)]

        public DateTime Criado { get; set; }

        [DataType(DataType.Date)]


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime Atualizado { get; set; }

    }
}
