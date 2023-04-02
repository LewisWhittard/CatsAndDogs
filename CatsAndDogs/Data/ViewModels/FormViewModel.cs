using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatsAndDogs.Data.Enum;

namespace CatsAndDogs.Data.ViewModels
{
    public class FormViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required, StringLength(64, ErrorMessage = "Forename (64)")]
        public string Forename { get; set; }
        [Required, StringLength(64, ErrorMessage = "Surname (64)")]
        public string Surname { get; set; }
        [Required]
        public CatOrDog COD { get; set; }
        public bool Deleted { get; set; } = true;

        public FormViewModel()
        {



        }

        public FormViewModel(int id, string forename, string surname, CatOrDog cOD, bool deleted)
        {
            Id = id;
            Forename = forename;
            Surname = surname;
            COD = cOD;
            Deleted = deleted;
        }
    }

}
