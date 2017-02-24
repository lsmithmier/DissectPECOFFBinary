using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using TechTalk.SpecFlow;

namespace DissectPECOFFBinary.SpecFlow
{
    [Binding]
    public class SectionTablesSteps
    {
        [When(@"I read the SectionTables")]
        public void WhenIReadTheSectionTables()
        {
            var fileName = ScenarioContext.Current.Get<string>("FileName");
            var filePath = string.Format(@".\TestArtifacts\{0}", fileName);
            if (!File.Exists(filePath))
            {
                filePath = string.Format(@".\{0}", fileName);
                Console.WriteLine(string.Format(@"File not Found: .\TestArtifacts\{0}", fileName));
            }
            using (FileStream inputFile = File.OpenRead(filePath))
            {
                var msdos20Section = ScenarioContext.Current.Get<MSDOS20Section>("MSDOS20Section");
                var coffHeader = ScenarioContext.Current.Get<COFFHeader>("COFFHeader");
                var coffOptionalHeaderStandardFields = ScenarioContext.Current.Get<COFFOptionalHeaderStandardFields>("COFFOptionalHeaderStandardFields");
                List<SectionTable> sectionTables = new List<SectionTable>();
                inputFile.Position = SectionTable.StartingPosition(msdos20Section, coffOptionalHeaderStandardFields);
                for (int i = 0; i < coffHeader.NumberOfSections; i++)
                {
                    SectionTable? sectionTable =
                        inputFile.ReadStructure<SectionTable>();
                    sectionTables.Add(sectionTable.Value);
                }
                ScenarioContext.Current.Add("SectionTables", sectionTables);
            }
        }

        [When(@"there is a table with name (.*)")]
        public void WhenThereIsATableWithName(string name)
        {
            ScenarioContext.Current.Add("Current SectionTable Name",name);
        }

        [Then(@"there will be (.*) entries")]
        public void ThenThereWillBeEntries(ushort numberOfEntries)
        {
            var coffHeader = ScenarioContext.Current.Get<COFFHeader>("COFFHeader");
            Assert.AreEqual<ushort>(coffHeader.NumberOfSections, numberOfEntries);
        }

        [Then(@"they will contain (.*)")]
        public void ThenTheyWillContain(string listOfSections)
        {
            var sectionTables = ScenarioContext.Current.Get<List<SectionTable>>("SectionTables");
            foreach (var sectionTableName in listOfSections.Split(','))
            {
                Assert.IsNotNull(sectionTables.Find(x => x.Name == sectionTableName));
            }
        }

        [Then(@"the order will of the tables will be (.*)")]
        public void ThenTheOrderWillOfTheTablesWillBe(string listOfSections)
        {
            var sectionTables = ScenarioContext.Current.Get<List<SectionTable>>("SectionTables");
            var orderedListOfSections = listOfSections.Split(',');
            for (int x = 0; x< orderedListOfSections.Length; x++)
            {
                Assert.AreEqual<string>(orderedListOfSections[x], sectionTables[x].Name);
            }
        }

        [Then(@"it's VirtualSize will be (.*)")]
        public void ThenItSVirtualSizeWillBe(string virtualSize)
        {
            UInt32 virtualSizeValue = Convert.ToUInt32(virtualSize, 16);
            var sectionTables = ScenarioContext.Current.Get<List<SectionTable>>("SectionTables");
            var currentSectionTableName = ScenarioContext.Current.Get<string>("Current SectionTable Name");
            Assert.AreEqual<UInt32>(virtualSizeValue, sectionTables.Find(x=>x.Name==currentSectionTableName).VirtualSize);
        }

        [Then(@"it's VirtualAddress will be (.*)")]
        public void ThenItSVirtualAddressWillBe(string virutualAddress)
        {
            UInt32 virutualAddressValue = Convert.ToUInt32(virutualAddress, 16);
            var sectionTables = ScenarioContext.Current.Get<List<SectionTable>>("SectionTables");
            var currentSectionTableName = ScenarioContext.Current.Get<string>("Current SectionTable Name");
            Assert.AreEqual<UInt32>(virutualAddressValue, sectionTables.Find(x => x.Name == currentSectionTableName).VirtualAddress);
        }

        [Then(@"it's SizeOfRawData will be (.*)")]
        public void ThenItSSizeOfRawDataWillBe(string sizeOfRawData)
        {
            UInt32 sizeOfRawDataValue = Convert.ToUInt32(sizeOfRawData, 16);
            var sectionTables = ScenarioContext.Current.Get<List<SectionTable>>("SectionTables");
            var currentSectionTableName = ScenarioContext.Current.Get<string>("Current SectionTable Name");
            Assert.AreEqual<UInt32>(sizeOfRawDataValue, sectionTables.Find(x => x.Name == currentSectionTableName).SizeOfRawData);
        }

        [Then(@"it's PointerToRawData will be (.*)")]
        public void ThenItSPointerToRawDataWillBe(string pointerToRawData)
        {
            UInt32 pointerToRawDataValue = Convert.ToUInt32(pointerToRawData, 16);
            var sectionTables = ScenarioContext.Current.Get<List<SectionTable>>("SectionTables");
            var currentSectionTableName = ScenarioContext.Current.Get<string>("Current SectionTable Name");
            Assert.AreEqual<UInt32>(pointerToRawDataValue, sectionTables.Find(x => x.Name == currentSectionTableName).PointerToRawData);
        }

        [Then(@"it's PointerToRelocations will be (.*)")]
        public void ThenItSPointerToRelocationsWillBe(string pointerToRelocations)
        {
            UInt32 pointerToRelocationsValue = Convert.ToUInt32(pointerToRelocations, 16);
            var sectionTables = ScenarioContext.Current.Get<List<SectionTable>>("SectionTables");
            var currentSectionTableName = ScenarioContext.Current.Get<string>("Current SectionTable Name");
            Assert.AreEqual<UInt32>(pointerToRelocationsValue, sectionTables.Find(x => x.Name == currentSectionTableName).PointerToRelocations);
        }

        [Then(@"it's PointerToLinenumbers will be (.*)")]
        public void ThenItSPointerToLinenumbersWillBe(string pointerToLinenumbers)
        {
            UInt32 pointerToLinenumbersValue = Convert.ToUInt32(pointerToLinenumbers, 16);
            var sectionTables = ScenarioContext.Current.Get<List<SectionTable>>("SectionTables");
            var currentSectionTableName = ScenarioContext.Current.Get<string>("Current SectionTable Name");
            Assert.AreEqual<UInt32>(pointerToLinenumbersValue, sectionTables.Find(x => x.Name == currentSectionTableName).PointerToLinenumbers);
        }

        [Then(@"it's NumberOfRelocations will be (.*)")]
        public void ThenItSNumberOfRelocationsWillBe(string numberOfRelocations)
        {
            UInt32 numberOfRelocationsValue = Convert.ToUInt32(numberOfRelocations, 16);
            var sectionTables = ScenarioContext.Current.Get<List<SectionTable>>("SectionTables");
            var currentSectionTableName = ScenarioContext.Current.Get<string>("Current SectionTable Name");
            Assert.AreEqual<UInt32>(numberOfRelocationsValue, sectionTables.Find(x => x.Name == currentSectionTableName).NumberOfRelocations);
        }

        [Then(@"it's NumberOfLinenumbers will be (.*)")]
        public void ThenItSNumberOfLinenumbersWillBe(string numberOfLinenumbers)
        {
            UInt32 numberOfLinenumbersValue = Convert.ToUInt32(numberOfLinenumbers, 16);
            var sectionTables = ScenarioContext.Current.Get<List<SectionTable>>("SectionTables");
            var currentSectionTableName = ScenarioContext.Current.Get<string>("Current SectionTable Name");
            Assert.AreEqual<UInt32>(numberOfLinenumbersValue, sectionTables.Find(x => x.Name == currentSectionTableName).NumberOfLinenumbers);
        }

        [Then(@"it's Characteristics will be (.*)")]
        public void ThenItSCharacteristicsWillBe(string characteristics)
        {
            UInt32 characteristicsValue = Convert.ToUInt32(characteristics, 16);
            var sectionTables = ScenarioContext.Current.Get<List<SectionTable>>("SectionTables");
            var currentSectionTableName = ScenarioContext.Current.Get<string>("Current SectionTable Name");
            Assert.AreEqual<UInt32>(characteristicsValue, sectionTables.Find(x => x.Name == currentSectionTableName).Characteristics);
        }
    }
}
