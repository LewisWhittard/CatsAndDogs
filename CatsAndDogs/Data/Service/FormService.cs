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
			var data = Import();
			var toReturn = data.Last().Id;
			return toReturn;

		}

		public int GetNextId()
		{
			var LastId = GetlastId();
			var toReturn = LastId + 1;
			return toReturn;
		}

		public List<FormViewModel> GetAllDataToDisplay()
		{
			return null;
		}

	}
}
