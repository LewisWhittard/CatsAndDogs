using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsAndDogs.Data.Repository
{
	public class BaseRepository
	{
		protected void ClearTXT(string additionalString)
		{
			string BasePath = System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
			String FullPath = BasePath + additionalString;
			File.WriteAllText(FullPath, String.Empty);
		}

		protected string FilteredString(string Data)
		{
			var newResult = Data.Replace("<Completed>", string.Empty);
			newResult = Data.Replace("\r\n", string.Empty);
			return newResult;
		}

		protected List<string> SplitRows(string Data)
		{
			List<string> Content = Data.Split("<DataRow>").ToList();
			Content.RemoveAt(Content.Count - 1);
			return Content;
		}

		protected string GetData(String AdditionalPath)
		{
			string BasePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
			string FullPath = BasePath + AdditionalPath;
			var content = File.ReadAllText(FullPath);
			var FinalResult = FilteredString(content);
			return FinalResult;
		}
	}
}
