using CatsAndDogs.Data.DTOs;
using CatsAndDogs.Data.Repository;
using CatsAndDogs.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsAndDogs.Data.Service
{
	public class FormService : FormRepository
	{
		public void SaveForm(FormViewModel formViewModel)
		{
			FormDTO formDTO = new FormDTO(formViewModel);
			SaveNewForm(formDTO);
		}

		public int GetlastId()
		{
			try
			{
				var data = Import();
				var toReturn = data.Last().Id;
				return toReturn;
			}

			catch (Exception)
			{
				return -1;
			}
		}

		public int GetNextId()
		{
			var LastId = GetlastId();
			var toReturn = LastId + 1;
			return toReturn;
		}

		public List<FormViewModel> GetAllDataToDisplay()
		{
            var data = Import();
			List<FormViewModel> toReturn = new List<FormViewModel>();
			foreach (var item in data)
			{
				FormViewModel newRow = new FormViewModel(item);
				toReturn.Add(newRow);

			}
            return toReturn;
		}

		public int GetDogCount()
		{
			var data = Import();
			var toReturn = Import().Where(x => x.COD == Enum.CatOrDog.Dog && x.Deleted == false).ToList().Count;
			return toReturn;
		}

        public int GetCatCount()
        {
            var data = Import();
            var toReturn = Import().Where(x => x.COD == Enum.CatOrDog.Cat && x.Deleted == false).ToList().Count;
            return toReturn;
        }
    }
}
