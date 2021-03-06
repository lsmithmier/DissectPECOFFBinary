﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace DissectPECOFFBinary.SpecFlow
{
    [Binding]
    public class OptionalHeaderDataDirectoriesSteps
    {
        [When(@"I read in the OptionalHeaderDataDirectories")]
        public void WhenIReadInTheOptionalHeaderDataDirectories()
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
                var coffOptionalHeaderStandardFields = ScenarioContext.Current.Get<COFFOptionalHeaderStandardFields>("COFFOptionalHeaderStandardFields");
                inputFile.Position = OptionalHeaderDataDirectories.StartingPosition(msdos20Section,coffOptionalHeaderStandardFields);
                OptionalHeaderDataDirectories? optionalHeaderDataDirectories =
                    inputFile.ReadStructure<OptionalHeaderDataDirectories>();
                ScenarioContext.Current.Add("OptionalHeaderDataDirectories", optionalHeaderDataDirectories.Value);
            }
        }

        [Then(@"the ExportTable shoud be (.*)")]
        public void ThenTheExportTableShoudBe(string exportTable)
        {
            UInt64 exportTableValue = Convert.ToUInt64(exportTable, 16);
            var optionalHeaderDataDirectories = ScenarioContext.Current.Get<OptionalHeaderDataDirectories>("OptionalHeaderDataDirectories");
            Assert.AreEqual(exportTableValue, optionalHeaderDataDirectories.ExportTable);
        }

        [Then(@"the ImportTable shoud be (.*)")]
        public void ThenTheImportTableShoudBe(string importTable)
        {
            UInt64 importTableValue = Convert.ToUInt64(importTable, 16);
            var optionalHeaderDataDirectories = ScenarioContext.Current.Get<OptionalHeaderDataDirectories>("OptionalHeaderDataDirectories");
            Assert.AreEqual(importTableValue, optionalHeaderDataDirectories.ImportTable, string.Format("Assert.AreEqual failed on ImportTable.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", importTableValue, optionalHeaderDataDirectories.ImportTable));
        }

        [Then(@"the ResourceTable shoud be (.*)")]
        public void ThenTheResourceTableShoudBe(string resourceTable)
        {
            UInt64 resourceTableValue = Convert.ToUInt64(resourceTable, 16);
            var optionalHeaderDataDirectories = ScenarioContext.Current.Get<OptionalHeaderDataDirectories>("OptionalHeaderDataDirectories");
            Assert.AreEqual(resourceTableValue, optionalHeaderDataDirectories.ResourceTable, string.Format("Assert.AreEqual failed on ResourceTable.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", resourceTableValue, optionalHeaderDataDirectories.ResourceTable));
        }

        [Then(@"the ExceptionTable shoud be (.*)")]
        public void ThenTheExceptionTableShoudBe(string exceptionTable)
        {
            UInt64 exceptionTableValue = Convert.ToUInt64(exceptionTable, 16);
            var optionalHeaderDataDirectories = ScenarioContext.Current.Get<OptionalHeaderDataDirectories>("OptionalHeaderDataDirectories");
            Assert.AreEqual(exceptionTableValue, optionalHeaderDataDirectories.ExceptionTable, string.Format("Assert.AreEqual failed on ExceptionTable.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", exceptionTableValue, optionalHeaderDataDirectories.ExceptionTable));
        }

        [Then(@"the CertificateTable shoud be (.*)")]
        public void ThenTheCertificateTableShoudBe(string certificateTable)
        {
            UInt64 certificateTableValue = Convert.ToUInt64(certificateTable, 16);
            var optionalHeaderDataDirectories = ScenarioContext.Current.Get<OptionalHeaderDataDirectories>("OptionalHeaderDataDirectories");
            Assert.AreEqual(certificateTableValue, optionalHeaderDataDirectories.CertificateTable, string.Format("Assert.AreEqual failed on CertificateTable.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", certificateTableValue, optionalHeaderDataDirectories.CertificateTable));
        }

        [Then(@"the BaseRelocationTable shoud be (.*)")]
        public void ThenTheBaseRelocationTableShoudBe(string baseRelocationTable)
        {
            UInt64 baseRelocationTableValue = Convert.ToUInt64(baseRelocationTable, 16);
            var optionalHeaderDataDirectories = ScenarioContext.Current.Get<OptionalHeaderDataDirectories>("OptionalHeaderDataDirectories");
            Assert.AreEqual(baseRelocationTableValue, optionalHeaderDataDirectories.BaseRelocationTable, string.Format("Assert.AreEqual failed on BaseRelocationTable.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", baseRelocationTableValue, optionalHeaderDataDirectories.BaseRelocationTable));
        }

        [Then(@"the Debug shoud be (.*)")]
        public void ThenTheDebugShoudBe(string debug)
        {
            UInt64 debugValue = Convert.ToUInt64(debug, 16);
            var optionalHeaderDataDirectories = ScenarioContext.Current.Get<OptionalHeaderDataDirectories>("OptionalHeaderDataDirectories");
            Assert.AreEqual(debugValue, optionalHeaderDataDirectories.Debug, string.Format("Assert.AreEqual failed on Debug.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", debugValue, optionalHeaderDataDirectories.Debug));
        }

        [Then(@"the Architecture shoud be (.*)")]
        public void ThenTheArchitectureShoudBe(string architecture)
        {
            UInt64 architectureValue = Convert.ToUInt64(architecture, 16);
            var optionalHeaderDataDirectories = ScenarioContext.Current.Get<OptionalHeaderDataDirectories>("OptionalHeaderDataDirectories");
            Assert.AreEqual(architectureValue, optionalHeaderDataDirectories.Architecture, string.Format("Assert.AreEqual failed on Architecture.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", architectureValue, optionalHeaderDataDirectories.Architecture));
        }

        [Then(@"the GlobalPtr shoud be (.*)")]
        public void ThenTheGlobalPtrShoudBe(string globalPtr)
        {
            UInt64 globalPtrValue = Convert.ToUInt64(globalPtr, 16);
            var optionalHeaderDataDirectories = ScenarioContext.Current.Get<OptionalHeaderDataDirectories>("OptionalHeaderDataDirectories");
            Assert.AreEqual(globalPtrValue, optionalHeaderDataDirectories.GlobalPtr, string.Format("Assert.AreEqual failed on GlobalPtr.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", globalPtrValue, optionalHeaderDataDirectories.GlobalPtr));
        }

        [Then(@"the TLSTable shoud be (.*)")]
        public void ThenTheTLSTableShoudBe(string tlsTable)
        {
            UInt64 tlsTableValue = Convert.ToUInt64(tlsTable, 16);
            var optionalHeaderDataDirectories = ScenarioContext.Current.Get<OptionalHeaderDataDirectories>("OptionalHeaderDataDirectories");
            Assert.AreEqual(tlsTableValue, optionalHeaderDataDirectories.TLSTable, string.Format("Assert.AreEqual failed on TLSTable.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", tlsTableValue, optionalHeaderDataDirectories.TLSTable));
        }

        [Then(@"the LoadConfigTable shoud be (.*)")]
        public void ThenTheLoadConfigTableShoudBe(string loadConfigTable)
        {
            UInt64 loadConfigTableValue = Convert.ToUInt64(loadConfigTable, 16);
            var optionalHeaderDataDirectories = ScenarioContext.Current.Get<OptionalHeaderDataDirectories>("OptionalHeaderDataDirectories");
            Assert.AreEqual(loadConfigTableValue, optionalHeaderDataDirectories.LoadConfigTable, string.Format("Assert.AreEqual failed on LoadConfigTable.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", loadConfigTableValue, optionalHeaderDataDirectories.LoadConfigTable));
        }

        [Then(@"the BoundImport shoud be (.*)")]
        public void ThenTheBoundImportShoudBe(string boundImport)
        {
            UInt64 boundImportValue = Convert.ToUInt64(boundImport, 16);
            var optionalHeaderDataDirectories = ScenarioContext.Current.Get<OptionalHeaderDataDirectories>("OptionalHeaderDataDirectories");
            Assert.AreEqual(boundImportValue, optionalHeaderDataDirectories.BoundImport, string.Format("Assert.AreEqual failed on BoundImport.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", boundImportValue, optionalHeaderDataDirectories.BoundImport));
        }

        [Then(@"the IAT shoud be (.*)")]
        public void ThenTheIATShoudBe(string iat)
        {
            UInt64 iatValue = Convert.ToUInt64(iat, 16);
            var optionalHeaderDataDirectories = ScenarioContext.Current.Get<OptionalHeaderDataDirectories>("OptionalHeaderDataDirectories");
            Assert.AreEqual(iatValue, optionalHeaderDataDirectories.IAT, string.Format("Assert.AreEqual failed on IAT.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", iatValue, optionalHeaderDataDirectories.IAT));
        }

        [Then(@"the DelayImportDescriptor shoud be (.*)")]
        public void ThenTheDelayImportDescriptorShoudBe(string delayImportDescriptor)
        {
            UInt64 delayImportDescriptorValue = Convert.ToUInt64(delayImportDescriptor, 16);
            var optionalHeaderDataDirectories = ScenarioContext.Current.Get<OptionalHeaderDataDirectories>("OptionalHeaderDataDirectories");
            Assert.AreEqual(delayImportDescriptorValue, optionalHeaderDataDirectories.DelayImportDescriptor, string.Format("Assert.AreEqual failed on DelayImportDescriptor.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", delayImportDescriptorValue, optionalHeaderDataDirectories.DelayImportDescriptor));
        }

        [Then(@"the CLRRuntimeHeader shoud be (.*)")]
        public void ThenTheCLRRuntimeHeaderShoudBe(string clrRuntimeHeader)
        {
            UInt64 clrRuntimeHeaderValue = Convert.ToUInt64(clrRuntimeHeader, 16);
            var optionalHeaderDataDirectories = ScenarioContext.Current.Get<OptionalHeaderDataDirectories>("OptionalHeaderDataDirectories");
            Assert.AreEqual(clrRuntimeHeaderValue, optionalHeaderDataDirectories.CLRRuntimeHeader, string.Format("Assert.AreEqual failed on CLRRuntimeHeader.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", clrRuntimeHeaderValue, optionalHeaderDataDirectories.CLRRuntimeHeader));
        }

        [Then(@"the Reserved shoud be (.*)")]
        public void ThenTheReservedShoudBe(string reserved)
        {
            UInt64 reservedValue = Convert.ToUInt64(reserved, 16);
            var optionalHeaderDataDirectories = ScenarioContext.Current.Get<OptionalHeaderDataDirectories>("OptionalHeaderDataDirectories");
            Assert.AreEqual(reservedValue, optionalHeaderDataDirectories.Reserved,string.Format("Assert.AreEqual failed on Reserved.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", reservedValue, optionalHeaderDataDirectories.Reserved));
        }

        [Then(@"the IAT Address should be (.*)")]
        public void ThenTheIATAddressShouldBe(string iatAddress)
        {
            UInt32 iatAddressValue = Convert.ToUInt32(iatAddress, 16);
            var optionalHeaderDataDirectories = ScenarioContext.Current.Get<OptionalHeaderDataDirectories>("OptionalHeaderDataDirectories");
            Assert.AreEqual(iatAddressValue, optionalHeaderDataDirectories.IATAddress, string.Format("Assert.AreEqual failed on IAT Address.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", iatAddressValue, optionalHeaderDataDirectories.IATAddress));
        }

        [Then(@"the IAT Count should be (.*)")]
        public void ThenTheIATCountShouldBe(string iatCount)
        {
            UInt32 iatCountValue = Convert.ToUInt32(iatCount, 16);
            var optionalHeaderDataDirectories = ScenarioContext.Current.Get<OptionalHeaderDataDirectories>("OptionalHeaderDataDirectories");
            Assert.AreEqual(iatCountValue, optionalHeaderDataDirectories.IATSize, string.Format("Assert.AreEqual failed on IAT Count.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", iatCountValue, optionalHeaderDataDirectories.IATSize));
        }

        [Then(@"the CLR Runtime Header Address should be (.*)")]
        public void ThenTheCLRRuntimeHeaderAddressShouldBe(string address)
        {
            UInt32 addressValue = Convert.ToUInt32(address, 16);
            var optionalHeaderDataDirectories = ScenarioContext.Current.Get<OptionalHeaderDataDirectories>("OptionalHeaderDataDirectories");
            Assert.AreEqual(addressValue, optionalHeaderDataDirectories.CLRRuntimeHeaderAddress, string.Format("Assert.AreEqual failed on CLRRuntimeHeaderAddress.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", addressValue, optionalHeaderDataDirectories.CLRRuntimeHeaderAddress));
        }

        [Then(@"the CLR Runtime Header Size should be (.*)")]
        public void ThenTheCLRRuntimeHeaderSizeShouldBe(string size)
        {
            UInt32 sizeValue = Convert.ToUInt32(size, 16);
            var optionalHeaderDataDirectories = ScenarioContext.Current.Get<OptionalHeaderDataDirectories>("OptionalHeaderDataDirectories");
            Assert.AreEqual(sizeValue, optionalHeaderDataDirectories.CLRRuntimeHeaderSize, string.Format("Assert.AreEqual failed on CLRRuntimeHeaderSize.  Expected: <0x{0:X}>.  Actual: <0x{1:X}>", sizeValue, optionalHeaderDataDirectories.CLRRuntimeHeaderSize));
        }
    }
}
