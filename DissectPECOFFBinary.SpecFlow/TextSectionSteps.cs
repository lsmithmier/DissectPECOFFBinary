using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using TechTalk.SpecFlow;

namespace DissectPECOFFBinary.SpecFlow
{
    [Binding]
    public class TextSectionSteps
    {
        [When(@"I read the Import Address Table")]
        public void WhenIReadTheImportAddressTable()
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
                var optionalHeaderDataDirectories = ScenarioContext.Current.Get<OptionalHeaderDataDirectories>("OptionalHeaderDataDirectories");
                var sectionTables = ScenarioContext.Current.Get<List<SectionTable>>("SectionTables");
                var importAddressTable = ImportAddressTable.ReadImportAddresses(inputFile, optionalHeaderDataDirectories, sectionTables);
                ScenarioContext.Current.Add("ImportAddressTable", importAddressTable);
            }
        }

        [Then(@"the number of entries should be (.*)")]
        public void ThenTheNumberOfEntriesShouldBe(string iatSize)
        {
            UInt32 iatSizeValue = Convert.ToUInt32(iatSize, 16);
            var importAddressTable = ScenarioContext.Current.Get<List<UInt32>>("ImportAddressTable");
            Assert.AreEqual(iatSizeValue, (UInt32)importAddressTable.Count, string.Format("Assert.AreEqual failed on ImportAddress values count.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", iatSizeValue, (UInt32)importAddressTable.Count));
        }

        [Then(@"the values should be (.*)")]
        public void ThenTheValuesShouldBe(string values)
        {
            var valueList = values.Split(',');
            var importAddressTable = ScenarioContext.Current.Get<List<UInt32>>("ImportAddressTable");
            for (int i = 0; i < valueList.Length; i++)
            {
                UInt32 valueValue = Convert.ToUInt32(valueList[i], 16);
                Assert.AreEqual(valueValue, importAddressTable[i], string.Format("Assert.AreEqual failed on ImportAddress value {2}.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", valueValue, importAddressTable[i], i));
            }
        }
    }
}
