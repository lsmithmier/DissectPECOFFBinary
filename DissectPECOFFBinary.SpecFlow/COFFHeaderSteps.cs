using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace DissectPECOFFBinary.SpecFlow
{
    [Binding]
    public class COFFHeaderSteps
    {
        [When(@"I read in the COFFHeader")]
        public void WhenIReadInTheCOFFHeader()
        {
            var fileName = ScenarioContext.Current.Get<string>("FileName");
            using (FileStream inputFile =
                File.OpenRead(
                    string.Format(@"..\..\TestArtifacts\{0}", fileName)))
            {
                var msdos20Section = ScenarioContext.Current.Get<MSDOS20Section>("MSDOS20Section");
                inputFile.Position = COFFHeader.StartingPosition(msdos20Section);
                COFFHeader? coffHeader =
                    inputFile.ReadStructure<COFFHeader>();
                ScenarioContext.Current.Add("COFFHeader", coffHeader.Value);
            }
        }

        [Then(@"the MachineType shoud be (.*)")]
        public void ThenTheMachineTypeShoudBe(string machineType)
        {
            UInt16 machineTypeValue = Convert.ToUInt16(machineType, 16);
            var coffHeader = ScenarioContext.Current.Get<COFFHeader>("COFFHeader");
            Assert.AreEqual<UInt16>(machineTypeValue, coffHeader.MachineType);
        }
        
        [Then(@"the NumberOfSections should be (.*)")]
        public void ThenTheNumberOfSectionsShouldBe(UInt16 numberOfSections)
        {
            var coffHeader = ScenarioContext.Current.Get<COFFHeader>("COFFHeader");
            Assert.AreEqual<UInt16>(numberOfSections, coffHeader.NumberOfSections);
        }

        [Then(@"the PointerToSymbolTable should be (.*)")]
        public void ThenThePointerToSymbolTableShouldBe(string pointerToSymbolTable)
        {
            UInt32 pointerToSymbolTableValue = Convert.ToUInt32(pointerToSymbolTable, 16);
            var coffHeader = ScenarioContext.Current.Get<COFFHeader>("COFFHeader");
            Assert.AreEqual<UInt32>(pointerToSymbolTableValue, coffHeader.PointerToSymbolTable);
        }
        
        [Then(@"the NumberOfSymbols should be (.*)")]
        public void ThenTheNumberOfSymbolsShouldBe(UInt32 numberOfSymbols)
        {
            var coffHeader = ScenarioContext.Current.Get<COFFHeader>("COFFHeader");
            Assert.AreEqual<UInt32>(numberOfSymbols, coffHeader.NumberOfSymbols);
        }

        [Then(@"the SizeOfOptionalHeader should be (.*)")]
        public void ThenTheSizeOfOptionalHeaderShouldBe(string sizeOfOptionalHeader)
        {
            UInt16 sizeOfOptionalHeaderValue = Convert.ToUInt16(sizeOfOptionalHeader, 16);
            var coffHeader = ScenarioContext.Current.Get<COFFHeader>("COFFHeader");
            Assert.AreEqual<UInt16>(sizeOfOptionalHeaderValue, coffHeader.SizeOfOptionalHeader);
        }

        [Then(@"the Characteristics should be (.*)")]
        public void ThenTheCharacteristicsShouldBe(string characteristics)
        {
            UInt16 characteristicsValue = Convert.ToUInt16(characteristics, 16);
            var coffHeader = ScenarioContext.Current.Get<COFFHeader>("COFFHeader");
            Assert.AreEqual<UInt16>(characteristicsValue, coffHeader.Characteristics);
        }
    }
}
