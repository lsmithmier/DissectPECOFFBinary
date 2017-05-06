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

        [When(@"I read the CLR Header")]
        public void WhenIReadTheCLRHeader()
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
                inputFile.Position = CLRHeader.StartingPosition(optionalHeaderDataDirectories, sectionTables);
                CLRHeader? clrHeader =
                    inputFile.ReadStructure<CLRHeader>();
                ScenarioContext.Current.Add("CLRHeader", clrHeader.Value);
            }
        }

        [When(@"I read the Debug Directory")]
        public void WhenIReadTheDebugDirectory()
        {
            var fileName = ScenarioContext.Current.Get<string>("FileName");
            var filePath = string.Format(@".\TestArtifacts\{0}", fileName);
            if (!File.Exists(filePath))
            {
                filePath = string.Format(@".\{0}", fileName);
                Console.WriteLine(string.Format(@"File not Found: .\TestArtifacts\{0}", fileName));
            }
            try
            {
                using (FileStream inputFile = File.OpenRead(filePath))
                {
                    var optionalHeaderDataDirectories = ScenarioContext.Current.Get<OptionalHeaderDataDirectories>("OptionalHeaderDataDirectories");
                    var sectionTables = ScenarioContext.Current.Get<List<SectionTable>>("SectionTables");
                    inputFile.Position = DebugDirectory.StartingPosition(optionalHeaderDataDirectories, sectionTables);
                    DebugDirectory? debugDirectory =
                        inputFile.ReadStructure<DebugDirectory>();
                    ScenarioContext.Current.Add("DebugDirectory", debugDirectory.Value);
                }
            }
            catch
            {
                ScenarioContext.Current.Add("DebugDirectory", new DebugDirectory { });
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

        [Then(@"the Cb should be (.*)")]
        public void ThenTheCbShouldBe(string cb)
        {
            UInt32 cbValue = Convert.ToUInt32(cb, 16);
            var clrHeader = ScenarioContext.Current.Get<CLRHeader>("CLRHeader");
            Assert.AreEqual(cbValue, clrHeader.Cb, string.Format("Assert.AreEqual failed on CLRHeader Cb.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", cbValue, clrHeader.Cb));
        }

        [Then(@"the Major Runtime Version should be (.*)")]
        public void ThenTheMajorRuntimeVersionShouldBe(string majorRuntimeVersion)
        {
            UInt16 majorRuntimeVersionValue = Convert.ToUInt16(majorRuntimeVersion, 16);
            var clrHeader = ScenarioContext.Current.Get<CLRHeader>("CLRHeader");
            Assert.AreEqual(majorRuntimeVersionValue, clrHeader.MajorRuntimeVersion, string.Format("Assert.AreEqual failed on CLRHeader MajorRuntimeVersion.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", majorRuntimeVersionValue, clrHeader.MajorRuntimeVersion));
        }

        [Then(@"the Minor Runtime Version should be (.*)")]
        public void ThenTheMinorRuntimeVersionShouldBe(string minorRuntimeVersion)
        {
            UInt16 minorRuntimeVersionValue = Convert.ToUInt16(minorRuntimeVersion, 16);
            var clrHeader = ScenarioContext.Current.Get<CLRHeader>("CLRHeader");
            Assert.AreEqual(minorRuntimeVersionValue, clrHeader.MinorRuntimeVersion, string.Format("Assert.AreEqual failed on CLRHeader MinorRuntimeVersion.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", minorRuntimeVersionValue, clrHeader.MinorRuntimeVersion));
        }

        [Then(@"the Metadata should be (.*)")]
        public void ThenTheMetadataShouldBe(string metadata)
        {
            UInt64 metadataValue = Convert.ToUInt64(metadata, 16);
            var clrHeader = ScenarioContext.Current.Get<CLRHeader>("CLRHeader");
            Assert.AreEqual(metadataValue, clrHeader.Metadata, string.Format("Assert.AreEqual failed on CLRHeader Metadata.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", metadataValue, clrHeader.Metadata));
        }

        [Then(@"the Flags should be (.*)")]
        public void ThenTheFlagsShouldBe(string flags)
        {
            UInt32 flagsValue = Convert.ToUInt32(flags, 16);
            var clrHeader = ScenarioContext.Current.Get<CLRHeader>("CLRHeader");
            Assert.AreEqual(flagsValue, clrHeader.Flags, string.Format("Assert.AreEqual failed on CLRHeader Flags.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", flagsValue, clrHeader.Flags));
        }

        [Then(@"the Entry Point Token/Entry Point RVA should be (.*)")]
        public void ThenTheEntryPointTokenEntryPointRVAShouldBe(string entryPoint)
        {
            UInt32 entryPointValue = Convert.ToUInt32(entryPoint, 16);
            var clrHeader = ScenarioContext.Current.Get<CLRHeader>("CLRHeader");
            Assert.AreEqual(entryPointValue, clrHeader.EntryPoint, string.Format("Assert.AreEqual failed on CLRHeader EntryPoint.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", entryPointValue, clrHeader.EntryPoint));
        }

        [Then(@"the Resources should be (.*)")]
        public void ThenTheResourcesShouldBe(string resources)
        {
            UInt64 resourcesValue = Convert.ToUInt64(resources, 16);
            var clrHeader = ScenarioContext.Current.Get<CLRHeader>("CLRHeader");
            Assert.AreEqual(resourcesValue, clrHeader.Resources, string.Format("Assert.AreEqual failed on CLRHeader Resources.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", resourcesValue, clrHeader.Resources));
        }

        [Then(@"the Strong Name Signature should be (.*)")]
        public void ThenTheStrongNameSignatureShouldBe(string strongNameSignature)
        {
            UInt64 strongNameSignatureValue = Convert.ToUInt64(strongNameSignature, 16);
            var clrHeader = ScenarioContext.Current.Get<CLRHeader>("CLRHeader");
            Assert.AreEqual(strongNameSignatureValue, clrHeader.StrongNameSignature, string.Format("Assert.AreEqual failed on CLRHeader StrongNameSignature.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", strongNameSignatureValue, clrHeader.StrongNameSignature));
        }

        [Then(@"the Code Manager Table should be (.*)")]
        public void ThenTheCodeManagerTableShouldBe(string codeManagerTable)
        {
            UInt64 codeManagerTableValue = Convert.ToUInt64(codeManagerTable, 16);
            var clrHeader = ScenarioContext.Current.Get<CLRHeader>("CLRHeader");
            Assert.AreEqual(codeManagerTableValue, clrHeader.CodeManagerTable, string.Format("Assert.AreEqual failed on CLRHeader CodeManagerTable.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", codeManagerTableValue, clrHeader.CodeManagerTable));
        }

        [Then(@"the VTable Fixups should be (.*)")]
        public void ThenTheVTableFixupsShouldBe(string vTableFixups)
        {
            UInt64 vTableFixupsValue = Convert.ToUInt64(vTableFixups, 16);
            var clrHeader = ScenarioContext.Current.Get<CLRHeader>("CLRHeader");
            Assert.AreEqual(vTableFixupsValue, clrHeader.VTableFixups, string.Format("Assert.AreEqual failed on CLRHeader VTableFixups.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", vTableFixupsValue, clrHeader.VTableFixups));
        }

        [Then(@"the Export Address Table Jumps should be (.*)")]
        public void ThenTheExportAddressTableJumpsShouldBe(string exportAddressTableJumps)
        {
            UInt64 exportAddressTableJumpsValue = Convert.ToUInt64(exportAddressTableJumps, 16);
            var clrHeader = ScenarioContext.Current.Get<CLRHeader>("CLRHeader");
            Assert.AreEqual(exportAddressTableJumpsValue, clrHeader.ExportAddressTableJumps, string.Format("Assert.AreEqual failed on CLRHeader ExportAddressTableJumps.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", exportAddressTableJumpsValue, clrHeader.ExportAddressTableJumps));
        }

        [Then(@"the Managed Native Header should be (.*)")]
        public void ThenTheManagedNativeHeaderShouldBe(string managedNativeHeader)
        {
            UInt64 managedNativeHeaderValue = Convert.ToUInt64(managedNativeHeader, 16);
            var clrHeader = ScenarioContext.Current.Get<CLRHeader>("CLRHeader");
            Assert.AreEqual(managedNativeHeaderValue, clrHeader.ManagedNativeHeader, string.Format("Assert.AreEqual failed on CLRHeader ManagedNativeHeader.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", managedNativeHeaderValue, clrHeader.ManagedNativeHeader));
        }

        [Then(@"the Debug Characteristics should be (.*)")]
        public void ThenTheDebugCharacteristicsShouldBe(string characteristics)
        {
            UInt32 managedNativeHeaderValue = Convert.ToUInt32(characteristics, 16);
            var debugDirectory = ScenarioContext.Current.Get<DebugDirectory>("DebugDirectory");
            Assert.AreEqual(managedNativeHeaderValue, debugDirectory.Characteristics, string.Format("Assert.AreEqual failed on DebugDirectory Characteristics.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", managedNativeHeaderValue, debugDirectory.Characteristics));
        }

        [Then(@"the Debug TimeDateStamp should be (.*)")]
        public void ThenTheDebugTimeDateStampShouldBe(string timeDateStamp)
        {
            UInt32 managedNativeHeaderValue = Convert.ToUInt32(timeDateStamp, 16);
            var debugDirectory = ScenarioContext.Current.Get<DebugDirectory>("DebugDirectory");
            Assert.AreEqual(managedNativeHeaderValue, debugDirectory.TimeDateStamp, string.Format("Assert.AreEqual failed on DebugDirectory TimeDateStamp.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", managedNativeHeaderValue, debugDirectory.TimeDateStamp));
        }

        [Then(@"the Debug Major Version should be (.*)")]
        public void ThenTheDebugMajorVersionShouldBe(string majorVersion)
        {
            UInt16 managedNativeHeaderValue = Convert.ToUInt16(majorVersion, 16);
            var debugDirectory = ScenarioContext.Current.Get<DebugDirectory>("DebugDirectory");
            Assert.AreEqual(managedNativeHeaderValue, debugDirectory.MajorVersion, string.Format("Assert.AreEqual failed on DebugDirectory MajorVersion.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", managedNativeHeaderValue, debugDirectory.MajorVersion));
        }

        [Then(@"the Debug Minor Version should be (.*)")]
        public void ThenTheDebugMinorVersionShouldBe(string minorVersion)
        {
            UInt16 managedNativeHeaderValue = Convert.ToUInt16(minorVersion, 16);
            var debugDirectory = ScenarioContext.Current.Get<DebugDirectory>("DebugDirectory");
            Assert.AreEqual(managedNativeHeaderValue, debugDirectory.MinorVersion, string.Format("Assert.AreEqual failed on DebugDirectory MinorVersion.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", managedNativeHeaderValue, debugDirectory.MinorVersion));
        }

        [Then(@"the Debug Type should be (.*)")]
        public void ThenTheDebugTypeShouldBe(string type)
        {
            UInt32 managedNativeHeaderValue = Convert.ToUInt32(type, 16);
            var debugDirectory = ScenarioContext.Current.Get<DebugDirectory>("DebugDirectory");
            Assert.AreEqual(managedNativeHeaderValue, debugDirectory.Type, string.Format("Assert.AreEqual failed on DebugDirectory Type.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", managedNativeHeaderValue, debugDirectory.Type));
        }

        [Then(@"the Debug SizeOfData should be (.*)")]
        public void ThenTheDebugSizeOfDataShouldBe(string sizeOfData)
        {
            UInt32 managedNativeHeaderValue = Convert.ToUInt32(sizeOfData, 16);
            var debugDirectory = ScenarioContext.Current.Get<DebugDirectory>("DebugDirectory");
            Assert.AreEqual(managedNativeHeaderValue, debugDirectory.SizeOfData, string.Format("Assert.AreEqual failed on DebugDirectory SizeOfData.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", managedNativeHeaderValue, debugDirectory.SizeOfData));
        }

        [Then(@"the Debug AddressOfRawData should be (.*)")]
        public void ThenTheDebugAddressOfRawDataShouldBe(string addressOfRawData)
        {
            UInt32 managedNativeHeaderValue = Convert.ToUInt32(addressOfRawData, 16);
            var debugDirectory = ScenarioContext.Current.Get<DebugDirectory>("DebugDirectory");
            Assert.AreEqual(managedNativeHeaderValue, debugDirectory.AddressOfRawData, string.Format("Assert.AreEqual failed on DebugDirectory AddressOfRawData.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", managedNativeHeaderValue, debugDirectory.AddressOfRawData));
        }
    }
}
