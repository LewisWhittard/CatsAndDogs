using CatsAndDogs.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsAndDogs.Data.Repository
{
	public class FormRepository : BaseRepository
	{
		public void SaveNewForm(FormDTO newData)
		{
			var currentData = Import();
			currentData.Add(newData);
			SaveProcess(currentData);

		}

		private void SaveProcess(List<FormDTO> Data)
		{
			ClearTXT(@"\Data\DataStorage\Form.txt");
			SaveData(Data);
		}

		private void SaveData(List<FormDTO> newData)
		{
			string BasePath = System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
			string FullPath = BasePath + @"\Data\DataStorage";

			using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(FullPath, "Form.txt")))
			{
				foreach (var item in newData)
				{
					outputFile.WriteLine(
						item.Id +
						"<Data>" +
						item.Forename +
						"<Data>" +
						item.Surname +
						"<Data>" +
						Convert.ToInt32(item.COD) +
                        "<Data>" +
                        Convert.ToInt32(item.Deleted) +
						"<DataRow>"
						);
				}

				outputFile.Close();
			}

		}

		public List<FormDTO> Import()
		{
			string Data = GetData(@"\Data\DataStorage\Form.txt");
			List<string> DataAsRows = SplitRows(Data);
			List<FormDTO> FormData = ReturnAllData(DataAsRows);

			return FormData;

		}

		private List<FormDTO> ReturnAllData(List<string> Data)
		{
			List<FormDTO> FormData = new List<FormDTO>();

			foreach (var item in Data)
			{
				FormDTO newRow = ReturnSingleFormData(item);
				FormData.Add(newRow);

			}

			return FormData;
		}

		private FormDTO ReturnSingleFormData(string Data)
		{
			List<string> SplitData = Data.Split("<Data>").ToList();
			FormDTO Content;

			if (SplitData[0] == "" || SplitData[1] == null)
			{
				Content = new FormDTO();
			}

			else
			{
				Content = new FormDTO(SplitData);
			}
			return Content;
		}

		protected void ClearTXT(string additionalString)
		{
			string BasePath = System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
			String FullPath = BasePath + additionalString;
			File.WriteAllText(FullPath, String.Empty);
		}
	}
}
