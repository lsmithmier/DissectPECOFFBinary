﻿using DissectPECOFFBinary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace PECOFFBinary.SpecFlow
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
        [When(@"I read the CodeView Header")]
        public void WhenIReadTheCodeViewHeader()
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
                    var sectionTables = ScenarioContext.Current.Get<List<SectionTable>>("SectionTables");
                    var debugDirectory = ScenarioContext.Current.Get<DebugDirectory>("DebugDirectory");
                    if (debugDirectory.PointerToRawData != 0)
                    {
                        inputFile.Position = CodeViewHeader.StartingPosition(debugDirectory, sectionTables);
                        CodeViewHeader? codeViewHeader =
                            inputFile.ReadStructure<CodeViewHeader>();
                        ScenarioContext.Current.Add("CodeViewHeader", codeViewHeader.Value);
                    } else
                    {
                        ScenarioContext.Current.Add("CodeViewHeader", new CodeViewHeader { });
                    }
                }
            }
            catch
            {
                ScenarioContext.Current.Add("CodeViewHeader", new CodeViewHeader { });
            }
        }

        [When(@"I read the General Metadata Header")]
        public void WhenIReadTheGeneralMetadataHeader()
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
                var sectionTables = ScenarioContext.Current.Get<List<SectionTable>>("SectionTables");
                var clrHeader = ScenarioContext.Current.Get<CLRHeader>("CLRHeader");
                GeneralMetadataHeader generalMetadataHeader = new GeneralMetadataHeader(clrHeader, sectionTables, inputFile);
                ScenarioContext.Current.Add("GeneralMetadataHeader", generalMetadataHeader);
            }
        }

        [When(@"I read the Metadata Storage Header")]
        public void WhenIReadTheMetadataStorageHeader()
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
                var generalMetadataHeader = ScenarioContext.Current.Get<GeneralMetadataHeader>("GeneralMetadataHeader");
                inputFile.Position = MetadataStorageHeader.StartingPosition(generalMetadataHeader);
                MetadataStorageHeader? metadataStorageHeader =
                    inputFile.ReadStructure<MetadataStorageHeader>();
                ScenarioContext.Current.Add("MetadataStorageHeader", metadataStorageHeader);
            }
        }

        [When(@"I read the Metadata Stream Headers")]
        public void WhenIReadTheMetadataStreamHeaders()
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
                var generalMetadataHeader = ScenarioContext.Current.Get<GeneralMetadataHeader>("GeneralMetadataHeader");
                var metadataStorageHeader = ScenarioContext.Current.Get<MetadataStorageHeader>("MetadataStorageHeader");
                Dictionary<string, MetadataStreamHeader> streams = new Dictionary<string, MetadataStreamHeader>();
                if (metadataStorageHeader.iStreams > 0)
                {
                    var metadataStreamHeader = new MetadataStreamHeader(generalMetadataHeader, inputFile);
                    streams.Add(metadataStreamHeader.rcName, metadataStreamHeader);
                    for (int i = 1; i < metadataStorageHeader.iStreams; i++)
                    {
                        MetadataStreamHeader
                            streamHeader = new MetadataStreamHeader(inputFile);
                        streams.Add(streamHeader.rcName, streamHeader);
                    }
                }
                ScenarioContext.Current.Add("MetadataStreamHeaders", streams);
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

        [Then(@"the CvSignature should be (.*)")]
        public void ThenTheCvSignatureShouldBe(string cvSignature)
        {
            if (string.IsNullOrEmpty(cvSignature))
            {
                cvSignature = "\0\0\0\0";
            }
            var codeViewHeader= ScenarioContext.Current.Get<CodeViewHeader>("CodeViewHeader");
            Assert.AreEqual(cvSignature, codeViewHeader.CvSignature, string.Format("Assert.AreEqual failed on CodeViewHeader CvSignature.  Expected: <{0}>.  Actual: <{1}>", cvSignature, codeViewHeader.CvSignature));
        }

        [Then(@"the Signature should be (.*)")]
        public void ThenTheSignatureShouldBe(Guid signature)
        {
            var codeViewHeader = ScenarioContext.Current.Get<CodeViewHeader>("CodeViewHeader");
            Assert.AreEqual(signature, codeViewHeader.Signature, string.Format("Assert.AreEqual failed on CodeViewHeader Signature.  Expected: <{0}>.  Actual: <{1}>", signature, codeViewHeader.Signature));
        }

        [Then(@"the Age should be (.*)")]
        public void ThenTheAgeShouldBe(string age)
        {
            UInt32 managedNativeHeaderValue = Convert.ToUInt32(age, 16);
            var codeViewHeader = ScenarioContext.Current.Get<CodeViewHeader>("CodeViewHeader");
            Assert.AreEqual(managedNativeHeaderValue, codeViewHeader.Age, string.Format("Assert.AreEqual failed on CodeViewHeader Age.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", managedNativeHeaderValue, codeViewHeader.Age));
        }

        [Then(@"the PdbFileName should be '(.*)'")]
        public void ThenThePdbFileNameShouldBe(string pdbFileName)
        {
            if (string.IsNullOrEmpty(pdbFileName))
            {
                pdbFileName = null;
            } else
            {
                //Ok, this is strange, but if I put the full path in as it should be then SpecFlow tries to parse it differently.  It might be a Gherkin keyword or something, but this is a workaround.
                pdbFileName = pdbFileName.Replace("~", "netcoreapp1");
            }
            var codeViewHeader = ScenarioContext.Current.Get<CodeViewHeader>("CodeViewHeader");
            Assert.AreEqual(pdbFileName, codeViewHeader.PdbFileName, string.Format("Assert.AreEqual failed on CodeViewHeader PdbFileName.  Expected: <{0}>.  Actual: <{1}>", pdbFileName, codeViewHeader.PdbFileName));
        }

        [Then(@"the lSignature should be (.*)")]
        public void ThenTheLSignatureShouldBe(string lSignature)
        {
            var generalMetadataHeader = ScenarioContext.Current.Get<GeneralMetadataHeader>("GeneralMetadataHeader");
            Assert.AreEqual(lSignature, generalMetadataHeader.lSignature, string.Format("Assert.AreEqual failed on GeneralMetadataHeader lSignature.  Expected: <{0}>.  Actual: <{1}>", lSignature, generalMetadataHeader.lSignature));
        }

        [Then(@"the iMajorVer should be (.*)")]
        public void ThenTheIMajorVerShouldBe(string iMajorVer)
        {
            UInt16 managedNativeHeaderValue = Convert.ToUInt16(iMajorVer, 16);
            var generalMetadataHeader = ScenarioContext.Current.Get<GeneralMetadataHeader>("GeneralMetadataHeader");
            Assert.AreEqual(managedNativeHeaderValue, generalMetadataHeader.iMajorVer, string.Format("Assert.AreEqual failed on GeneralMetadataHeader iMajorVer.  Expected: <{0}>.  Actual: <{1}>", managedNativeHeaderValue, generalMetadataHeader.iMajorVer));
        }

        [Then(@"the iMinorVer should be (.*)")]
        public void ThenTheIMinorVerShouldBe(string iMinorVer)
        {
            UInt16 managedNativeHeaderValue = Convert.ToUInt16(iMinorVer, 16);
            var generalMetadataHeader = ScenarioContext.Current.Get<GeneralMetadataHeader>("GeneralMetadataHeader");
            Assert.AreEqual(managedNativeHeaderValue, generalMetadataHeader.iMinorVer, string.Format("Assert.AreEqual failed on GeneralMetadataHeader iMinorVer.  Expected: <{0}>.  Actual: <{1}>", managedNativeHeaderValue, generalMetadataHeader.iMinorVer));
        }

        [Then(@"the iExtraData should be (.*)")]
        public void ThenTheIExtraDataShouldBe(string iExtraData)
        {
            UInt32 managedNativeHeaderValue = Convert.ToUInt32(iExtraData, 16);
            var generalMetadataHeader = ScenarioContext.Current.Get<GeneralMetadataHeader>("GeneralMetadataHeader");
            Assert.AreEqual(managedNativeHeaderValue, generalMetadataHeader.iExtraData, string.Format("Assert.AreEqual failed on GeneralMetadataHeader iExtraData.  Expected: <{0}>.  Actual: <{1}>", managedNativeHeaderValue, generalMetadataHeader.iExtraData));
        }

        [Then(@"the iVersionString should be (.*)")]
        public void ThenTheIVersionStringShouldBe(string iVersionString)
        {
            UInt32 managedNativeHeaderValue = Convert.ToUInt32(iVersionString, 16);
            var generalMetadataHeader = ScenarioContext.Current.Get<GeneralMetadataHeader>("GeneralMetadataHeader");
            Assert.AreEqual(managedNativeHeaderValue, generalMetadataHeader.iVersionString, string.Format("Assert.AreEqual failed on GeneralMetadataHeader iVersionString.  Expected: <{0}>.  Actual: <{1}>", managedNativeHeaderValue, generalMetadataHeader.iVersionString));
        }

        [Then(@"the pVersion should be (.*)")]
        public void ThenThePVersionShouldBe(string pVersion)
        {
            var generalMetadataHeader = ScenarioContext.Current.Get<GeneralMetadataHeader>("GeneralMetadataHeader");
            Assert.AreEqual(pVersion, generalMetadataHeader.pVersion, string.Format("Assert.AreEqual failed on GeneralMetadataHeader pVersion.  Expected: <{0}>.  Actual: <{1}>", pVersion, generalMetadataHeader.pVersion));
        }

        [Then(@"the fFlags should be (.*)")]
        public void ThenTheFFlagsShouldBe(string fFlags)
        {
            byte managedNativeHeaderValue = Convert.ToByte(fFlags, 16);
            var metadataStorageHeader = ScenarioContext.Current.Get<MetadataStorageHeader>("MetadataStorageHeader");
            Assert.AreEqual(managedNativeHeaderValue, metadataStorageHeader.fFlags, string.Format("Assert.AreEqual failed on MetadataStorageHeader fFlags.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", managedNativeHeaderValue, metadataStorageHeader.fFlags));
        }

        [Then(@"the padding should be (.*)")]
        public void ThenThePaddingShouldBe(string padding)
        {
            byte managedNativeHeaderValue = Convert.ToByte(padding, 16);
            var metadataStorageHeader = ScenarioContext.Current.Get<MetadataStorageHeader>("MetadataStorageHeader");
            Assert.AreEqual(managedNativeHeaderValue, metadataStorageHeader.padding, string.Format("Assert.AreEqual failed on MetadataStorageHeader padding.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", managedNativeHeaderValue, metadataStorageHeader.padding));
        }

        [Then(@"the iStreams should be (.*)")]
        public void ThenTheIStreamsShouldBe(string iStreams)
        {
            byte managedNativeHeaderValue = Convert.ToByte(iStreams, 16);
            var metadataStorageHeader = ScenarioContext.Current.Get<MetadataStorageHeader>("MetadataStorageHeader");
            Assert.AreEqual(managedNativeHeaderValue, metadataStorageHeader.iStreams, string.Format("Assert.AreEqual failed on MetadataStorageHeader iStreams.  Expected: <{0}>.  Actual: <{1}>", managedNativeHeaderValue, metadataStorageHeader.iStreams));
        }

        [Then(@"if the rcName is (.*)")]
        public void ThenIfTheRcNameIs(string rcName)
        {
            var streams = ScenarioContext.Current.Get<Dictionary<string,MetadataStreamHeader>>("MetadataStreamHeaders");
            Assert.IsTrue(streams.ContainsKey(rcName));
            ScenarioContext.Current.Add("CurrentMetadataStreamHeader", streams[rcName]);
        }

        [Then(@"the iOffset should be (.*)")]
        public void ThenTheIOffsetShouldBe(string iOffset)
        {
            UInt32 managedNativeHeaderValue = Convert.ToUInt32(iOffset, 16);
            var metadataStreamHeader = ScenarioContext.Current.Get<MetadataStreamHeader>("CurrentMetadataStreamHeader");
            Assert.AreEqual(managedNativeHeaderValue, metadataStreamHeader.iOffset, string.Format("Assert.AreEqual failed on MetadataStreamHeader iOffset.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", managedNativeHeaderValue, metadataStreamHeader.iOffset));
        }

        [Then(@"the iSize should be (.*)")]
        public void ThenTheISizeShouldBe(string iSize)
        {
            UInt32 managedNativeHeaderValue = Convert.ToUInt32(iSize, 16);
            var metadataStreamHeader = ScenarioContext.Current.Get<MetadataStreamHeader>("CurrentMetadataStreamHeader");
            Assert.AreEqual(managedNativeHeaderValue, metadataStreamHeader.iSize, string.Format("Assert.AreEqual failed on MetadataStreamHeader iSize.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", managedNativeHeaderValue, metadataStreamHeader.iSize));
        }
    }
}
