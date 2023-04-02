using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatsAndDogs.Data.DTOs;
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
        public bool Deleted { get; set; } = false;

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

        public FormViewModel(FormDTO data)
        {
            Id = data.Id;
            Forename = data.Forename;
            Surname = data.Surname;
            COD = data.COD;
            Deleted = data.Deleted;
        }
    }

}
