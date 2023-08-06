using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatsAndDogs.Data.DTOs;
using CatsAndDogs.Data.Enum;
using CatsAndDogs.Data.Repository;
using CatsAndDogs.Data.Service;
using CatsAndDogs.Data.ViewModels;

namespace UnitTest
{
    public class FormRepositoryTests
    {
        [Fact]
        public void SaveProcess()
        {
            BaseRepository BR = new BaseRepository();
            BR.ClearTXT(@"\Data\DataStorage\Form.txt");

            FormViewModel FVM1 = new FormViewModel(0,"Forname1","Surname1",CatOrDog.Cat,true);
            FormViewModel FVM2 = new FormViewModel(1, "Forname2", "Surname2", CatOrDog.Cat, false);
            FormViewModel FVM3 = new FormViewModel(2, "Forname3", "Surname3", CatOrDog.Dog, true);

            FormDTO FDTO1 = new FormDTO(FVM1);
            FormDTO FDTO2 = new FormDTO(FVM2);
            FormDTO FDTO3 = new FormDTO(FVM3);

            List<FormViewModel> formDTOsList = new List<FormViewModel>
            {
                FVM1, FVM2 , FVM3
            };

            FormService FS = new FormService();

            foreach (var item in formDTOsList)
            {
                FS.SaveForm(item);
            }

            var Data = FS.Import();
            BR.ClearTXT(@"\Data\DataStorage\Form.txt");

            Assert.True(FDTO1.Id == Data[0].Id);
            Assert.True(FDTO1.Forename == Data[0].Forename);
            Assert.True(FDTO1.Surname == Data[0].Surname);
            Assert.True(FDTO1.COD == Data[0].COD);
            Assert.True(FDTO1.Deleted == Data[0].Deleted);

            Assert.True(FDTO2.Id == Data[1].Id);
            Assert.True(FDTO2.Forename == Data[1].Forename);
            Assert.True(FDTO2.Surname == Data[1].Surname);
            Assert.True(FDTO2.COD == Data[1].COD);
            Assert.True(FDTO2.Deleted == Data[1].Deleted);

            Assert.True(FDTO3.Id == Data[2].Id);
            Assert.True(FDTO3.Forename == Data[2].Forename);
            Assert.True(FDTO3.Surname == Data[2].Surname);
            Assert.True(FDTO3.COD == Data[2].COD);
            Assert.True(FDTO3.Deleted == Data[2].Deleted);

        }
    }
}
