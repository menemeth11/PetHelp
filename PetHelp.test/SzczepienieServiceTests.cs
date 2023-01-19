using PetHelp.Shared;
using PetHelp.Shared.DTO;
using static PetHelp.Shared.SzczepienieDetale;

namespace PetHelp.test
{
    public class SzczepienieServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Szczepienia_Get_ShouldReturnValidListOfSzczepieniaInfo()
        {
            var szczepieniaData = Szczepienia();
            Assert.That(szczepieniaData, Is.Not.Empty);
            Assert.That(szczepieniaData, Has.All.TypeOf<SzczepienieInfo>());
            Assert.That(szczepieniaData.Select(x => x.ID), Is.Unique);
            Assert.That(szczepieniaData.Select(x => x.IntervalArr), Is.Not.Empty);
            Assert.That(szczepieniaData.Select(x => x.IntervalArr), Has.All.Length.GreaterThanOrEqualTo(1));
            Assert.That(szczepieniaData.Select(x => x.ID), Has.All.Not.EqualTo(0));
            Assert.Pass();
        }

        [Test]
        public void GetNext_WhenNumberIsStandardInRangeOfProgrammedInterval_ShouldReturnValidDate()
        {
            DateTime birthday = new(2023, 1, 1);

            var testData = new SzczepienieInfo()
            {
                ID = 1,
                Name = "Szczepienie",
                Description = "no details",
                IntervalArr = new int[5] { 7, 14, 2, 1, 365 }
            };
            Assert.Multiple(() =>
            {
                Assert.That(GetNext(testData, 0, birthday).Data, Is.EqualTo(new DateTime(2023, 1, 8)));
                Assert.That(GetNext(testData, 1, birthday).Data, Is.EqualTo(new DateTime(2023, 1, 22)));
                Assert.That(GetNext(testData, 2, birthday).Data, Is.EqualTo(new DateTime(2023, 1, 24)));
                Assert.That(GetNext(testData, 3, birthday).Data, Is.EqualTo(new DateTime(2023, 1, 25)));
                Assert.That(GetNext(testData, 4, birthday).Data, Is.EqualTo(new DateTime(2023, 1, 25).AddDays(365)));
            });
            Assert.Pass();
        }

        [Test]
        public void GetNext_WhenNumberIsLargerThanProgrammedIntervals_ShouldReturnValidDateUsingLastRepeatableInterval()
        {
            DateTime birthday = new(2023, 1, 1);

            var testData = new SzczepienieInfo()
            {
                ID = 1,
                Name = "Szczepienie",
                Description = "no details",
                IntervalArr = new int[2] { 7, 60 }
            };

            DateTime lastStandardIntervalDate = GetNext(testData, 1, birthday).Data;
            DateTime nextDate = default;
            int differenceInDays = 0;

            Assert.Multiple(() =>
            {
                for (int number = 2; number < 5; number++)
                {
                    nextDate = GetNext(testData, number, birthday).Data;
                    differenceInDays = (nextDate - lastStandardIntervalDate).Days;
                    lastStandardIntervalDate = nextDate;
                    Assert.That(differenceInDays, Is.EqualTo(60));
                }
            });

            Assert.Pass();
        }

        [Test]
        public void GetMergedWithIncomming_ArgumentWithSpecifiedPEtId_ShouldReturnListPopulatedWithPetId()
        {
            DateTime birthday = new(2023, 1, 1);

            var testData = new SzczepienieInfo()
            {
                ID = 1,
                Name = "Szczepienie",
                Description = "no details",
                IntervalArr = new int[2] { 7, 60 }
            };
            var listOfRegistered = new List<SzczepienieDTO>();
            var petId = 1234;
            var lista = GetMergedSzczepeniaMultipleNext(5, birthday, listOfRegistered, petId, new() { testData });

            Assert.That(lista.Select(x => x.ZwierzeId), Has.All.EqualTo(petId));
            Assert.Pass();
        }

        [Test]
        public void GetMergedWithIncomming_ZeroRegisteredvaccinationAndOnlyOneKindOfvaccination_ShouldReturnOnlyFiveNext()
        {
            DateTime birthday = new(2023, 1, 1);

            var testData = new SzczepienieInfo()
            {
                ID = 1,
                Name = "Szczepienie",
                Description = "no details",
                IntervalArr = new int[2] { 7, 60 }
            };
            var listOfRegistered = new List<SzczepienieDTO>();
            var petId = 0;
            var lista = GetMergedSzczepeniaMultipleNext(5, birthday, listOfRegistered, petId, new() { testData });

            Assert.That(lista, Has.Count.EqualTo(5));
            DateTime nextDate = birthday;

            Assert.Multiple(() =>
            {
                for (int i = 0, index = 0; i < 5; i++, index++)
                {
                    if (index >= testData.IntervalArr.Length)
                    {
                        index = testData.IntervalArr.Length - 1;
                    }
                    nextDate = nextDate.AddDays(testData.IntervalArr[index]);
                    Assert.That(lista[i].Data, Is.EqualTo(nextDate));
                }
            });

            Assert.Pass();
        }

        [Test]
        public void GetMergedWithIncomming_ZeroRegisteredvaccinationAndMultipleKindOfvaccination_ShouldReturnOnlyFiveNextAmongAvailableVaccies()
        {
            DateTime birthday = new(2023, 1, 1);

            var listaSzczepionek = new List<SzczepienieInfo>() {
                new SzczepienieInfo()
                {
                    ID = 1,
                    Name = "Szczepienie",
                    Description = "small chance for immortiality",
                    IntervalArr = new int[2] { 7, 60 }
                },
                new SzczepienieInfo()
                {
                    ID = 2,
                    Name = "Szczepienie no. 2",
                    Description = "risk of sudden death",
                    IntervalArr = new int[2] { 7, 30 }
                }
            };

            var listOfRegistered = new List<SzczepienieDTO>();
            var petId = 0;
            var lista = GetMergedSzczepeniaMultipleNext(5, birthday, listOfRegistered, petId, listaSzczepionek);

            Assert.That(lista, Has.Count.EqualTo(5));

            Assert.Multiple(() =>
            {
                int index = 0;
                foreach (var item in lista)
                {
                    var _sz = listaSzczepionek.Where(x => x.ID == item.SzczepienieType).Single();

                    if (index >= _sz.IntervalArr.Length)
                    {
                        index = _sz.IntervalArr.Length - 1;
                    }

                    Console.WriteLine(_sz.ID + "\t" + _sz.Name.PadLeft(20) + "\t" + item.Data);
                    DateTime nextDate = GetNext(_sz, lista.Take(lista.IndexOf(item)).Count(x => x.SzczepienieType == _sz.ID), birthday).Data;
                    Assert.That(item.Data, Is.EqualTo(nextDate));

                    index++;
                }
            });

            Assert.Pass();
        }

        [Test]
        public void GetMergedWithIncomming_MultipleRegisteredvaccinationAndMultipleKindOfvaccinationAndHaveSomeRegistered_ShouldReturnAllREgisteredAndFiveNextAmongAvailableVaccies()
        {
            DateTime birthday = new(2023, 1, 1);

            var listaSzczepionek = new List<SzczepienieInfo>() {
                new SzczepienieInfo()
                {
                    ID = 1,
                    Name = "Szczepienie",
                    Description = "small chance for immortiality",
                    IntervalArr = new int[2] { 7, 60 }
                },
                new SzczepienieInfo()
                {
                    ID = 2,
                    Name = "Szczepienie no. 2",
                    Description = "risk of sudden death",
                    IntervalArr = new int[2] { 7, 30 }
                }
            };

            var petId = 0;
            var listOfRegistered = new List<SzczepienieDTO>()
            {
                new SzczepienieDTO()
                {
                    Id = 1,
                    SzczepienieType = listaSzczepionek[0].ID,
                    Data = birthday.AddDays(listaSzczepionek[0].IntervalArr[0]),
                    DataInnyTermin = null,
                    CzyOdbyte = true,
                    ZwierzeId = petId
                },
                new SzczepienieDTO()
                {
                    Id = 1,
                    SzczepienieType = listaSzczepionek[1].ID,
                    Data = birthday.AddDays(listaSzczepionek[1].IntervalArr[0]),
                    DataInnyTermin = null,
                    CzyOdbyte = true,
                    ZwierzeId = petId
                }
            };
            var lista = GetMergedSzczepeniaMultipleNext(5, birthday, listOfRegistered, petId, listaSzczepionek);

            Assert.Multiple(() =>
            {
                int index = 0;
                foreach (var item in lista)
                {
                    var _sz = listaSzczepionek.Where(x => x.ID == item.SzczepienieType).Single();

                    if (index >= _sz.IntervalArr.Length)
                    {
                        index = _sz.IntervalArr.Length - 1;
                    }

                    DateTime nextDate = GetNext(_sz, lista.Take(lista.IndexOf(item)).Count(x => x.SzczepienieType == _sz.ID), birthday).Data;
                    Assert.That(item.Data, Is.EqualTo(nextDate));

                    index++;
                }
            });
            Assert.That(lista, Has.Count.EqualTo(7));
            Assert.Multiple(() =>
            {
                Assert.That(lista.Count(x => x.CzyOdbyte == true), Is.EqualTo(2));
                Assert.That(lista.Count(x => x.CzyOdbyte == false), Is.EqualTo(5));
            });
            Assert.Pass();
        }
    }
}