using CatsAndDogs.Data.Enum;
using CatsAndDogs.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsAndDogs.Data.DTOs
{
	public class FormDTO
	{
		public int Id;
		public string Forename;
		public string Surname;
		public CatOrDog COD;
		public bool Deleted;

		public FormDTO()
		{

		}
		
		public FormDTO(List<string> Data) 
		{ 
			Id = Convert.ToInt32(Data[0]);
			Forename = Data[1];
			Surname = Data[2];
			COD = (CatOrDog)Convert.ToInt32(Data[3]);
			Deleted = Convert.ToBoolean(Convert.ToInt32(Data[4]));
		
		}

		public FormDTO(FormViewModel data)
		{
			Id = data.Id;
			Forename = data.Forename;
			Surname = data.Surname;
			COD = data.COD;
			Deleted= Convert.ToBoolean(data.Deleted);
		}
	}
}
