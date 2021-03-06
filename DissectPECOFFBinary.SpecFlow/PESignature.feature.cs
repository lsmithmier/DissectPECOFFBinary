﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace DissectPECOFFBinary.SpecFlow
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class PESignatureFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PESignature.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "PESignature", "\tIn order to dissect a PECOFF binary file\r\n\tAs an interested party\r\n\tI want to re" +
                    "ad the PESignature from the file\r\n\tAnd I want to see the component parts", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "PESignature")))
            {
                global::DissectPECOFFBinary.SpecFlow.PESignatureFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void ReadThePESignatureFromAGivenPECOFFBinaryFile(string fileName, string signature, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read the PESignature from a given PECOFF binary file", exampleTags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given(string.Format("a PECOFF binary file named {0}", fileName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.When("I read in the MSDOS20Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.And("I read in the PESignature", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.Then(string.Format("the PE Signature shoud be {0}", signature), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read the PESignature from a given PECOFF binary file: HelloWorld_CSC_2.0.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PESignature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "HelloWorld_CSC_2.0.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:File Name", "HelloWorld_CSC_2.0.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Signature", "PE")]
        public virtual void ReadThePESignatureFromAGivenPECOFFBinaryFile_HelloWorld_CSC_2_0_Exe()
        {
            this.ReadThePESignatureFromAGivenPECOFFBinaryFile("HelloWorld_CSC_2.0.exe", "PE", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read the PESignature from a given PECOFF binary file: HelloWorld_CSC_3.5.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PESignature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "HelloWorld_CSC_3.5.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:File Name", "HelloWorld_CSC_3.5.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Signature", "PE")]
        public virtual void ReadThePESignatureFromAGivenPECOFFBinaryFile_HelloWorld_CSC_3_5_Exe()
        {
            this.ReadThePESignatureFromAGivenPECOFFBinaryFile("HelloWorld_CSC_3.5.exe", "PE", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read the PESignature from a given PECOFF binary file: HelloWorld_CSC_4.0.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PESignature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "HelloWorld_CSC_4.0.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:File Name", "HelloWorld_CSC_4.0.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Signature", "PE")]
        public virtual void ReadThePESignatureFromAGivenPECOFFBinaryFile_HelloWorld_CSC_4_0_Exe()
        {
            this.ReadThePESignatureFromAGivenPECOFFBinaryFile("HelloWorld_CSC_4.0.exe", "PE", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read the PESignature from a given PECOFF binary file: HelloWorld_VS_2.0.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PESignature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "HelloWorld_VS_2.0.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:File Name", "HelloWorld_VS_2.0.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Signature", "PE")]
        public virtual void ReadThePESignatureFromAGivenPECOFFBinaryFile_HelloWorld_VS_2_0_Exe()
        {
            this.ReadThePESignatureFromAGivenPECOFFBinaryFile("HelloWorld_VS_2.0.exe", "PE", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read the PESignature from a given PECOFF binary file: HelloWorld_VS_3.0.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PESignature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "HelloWorld_VS_3.0.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:File Name", "HelloWorld_VS_3.0.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Signature", "PE")]
        public virtual void ReadThePESignatureFromAGivenPECOFFBinaryFile_HelloWorld_VS_3_0_Exe()
        {
            this.ReadThePESignatureFromAGivenPECOFFBinaryFile("HelloWorld_VS_3.0.exe", "PE", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read the PESignature from a given PECOFF binary file: HelloWorld_VS_3.5.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PESignature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "HelloWorld_VS_3.5.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:File Name", "HelloWorld_VS_3.5.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Signature", "PE")]
        public virtual void ReadThePESignatureFromAGivenPECOFFBinaryFile_HelloWorld_VS_3_5_Exe()
        {
            this.ReadThePESignatureFromAGivenPECOFFBinaryFile("HelloWorld_VS_3.5.exe", "PE", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read the PESignature from a given PECOFF binary file: HelloWorld_VS_4.5.1.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PESignature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "HelloWorld_VS_4.5.1.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:File Name", "HelloWorld_VS_4.5.1.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Signature", "PE")]
        public virtual void ReadThePESignatureFromAGivenPECOFFBinaryFile_HelloWorld_VS_4_5_1_Exe()
        {
            this.ReadThePESignatureFromAGivenPECOFFBinaryFile("HelloWorld_VS_4.5.1.exe", "PE", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read the PESignature from a given PECOFF binary file: HelloWorld_VS_4.5.2.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PESignature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "HelloWorld_VS_4.5.2.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:File Name", "HelloWorld_VS_4.5.2.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Signature", "PE")]
        public virtual void ReadThePESignatureFromAGivenPECOFFBinaryFile_HelloWorld_VS_4_5_2_Exe()
        {
            this.ReadThePESignatureFromAGivenPECOFFBinaryFile("HelloWorld_VS_4.5.2.exe", "PE", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read the PESignature from a given PECOFF binary file: HelloWorld_VS_4.5.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PESignature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "HelloWorld_VS_4.5.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:File Name", "HelloWorld_VS_4.5.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Signature", "PE")]
        public virtual void ReadThePESignatureFromAGivenPECOFFBinaryFile_HelloWorld_VS_4_5_Exe()
        {
            this.ReadThePESignatureFromAGivenPECOFFBinaryFile("HelloWorld_VS_4.5.exe", "PE", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read the PESignature from a given PECOFF binary file: HelloWorld_VS_4.6.1.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PESignature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "HelloWorld_VS_4.6.1.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:File Name", "HelloWorld_VS_4.6.1.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Signature", "PE")]
        public virtual void ReadThePESignatureFromAGivenPECOFFBinaryFile_HelloWorld_VS_4_6_1_Exe()
        {
            this.ReadThePESignatureFromAGivenPECOFFBinaryFile("HelloWorld_VS_4.6.1.exe", "PE", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read the PESignature from a given PECOFF binary file: HelloWorld_VS_4.6.2.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PESignature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "HelloWorld_VS_4.6.2.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:File Name", "HelloWorld_VS_4.6.2.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Signature", "PE")]
        public virtual void ReadThePESignatureFromAGivenPECOFFBinaryFile_HelloWorld_VS_4_6_2_Exe()
        {
            this.ReadThePESignatureFromAGivenPECOFFBinaryFile("HelloWorld_VS_4.6.2.exe", "PE", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read the PESignature from a given PECOFF binary file: HelloWorld_VS_4.6.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PESignature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "HelloWorld_VS_4.6.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:File Name", "HelloWorld_VS_4.6.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Signature", "PE")]
        public virtual void ReadThePESignatureFromAGivenPECOFFBinaryFile_HelloWorld_VS_4_6_Exe()
        {
            this.ReadThePESignatureFromAGivenPECOFFBinaryFile("HelloWorld_VS_4.6.exe", "PE", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read the PESignature from a given PECOFF binary file: HelloWorld_VS_4.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PESignature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "HelloWorld_VS_4.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:File Name", "HelloWorld_VS_4.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Signature", "PE")]
        public virtual void ReadThePESignatureFromAGivenPECOFFBinaryFile_HelloWorld_VS_4_Exe()
        {
            this.ReadThePESignatureFromAGivenPECOFFBinaryFile("HelloWorld_VS_4.exe", "PE", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read the PESignature from a given PECOFF binary file: HelloWorld_VS_Core_1.0.dll")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PESignature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "HelloWorld_VS_Core_1.0.dll")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:File Name", "HelloWorld_VS_Core_1.0.dll")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Signature", "PE")]
        public virtual void ReadThePESignatureFromAGivenPECOFFBinaryFile_HelloWorld_VS_Core_1_0_Dll()
        {
            this.ReadThePESignatureFromAGivenPECOFFBinaryFile("HelloWorld_VS_Core_1.0.dll", "PE", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read the PESignature from a given PECOFF binary file: HelloWorld_Xamarin_2.0.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PESignature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "HelloWorld_Xamarin_2.0.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:File Name", "HelloWorld_Xamarin_2.0.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Signature", "PE")]
        public virtual void ReadThePESignatureFromAGivenPECOFFBinaryFile_HelloWorld_Xamarin_2_0_Exe()
        {
            this.ReadThePESignatureFromAGivenPECOFFBinaryFile("HelloWorld_Xamarin_2.0.exe", "PE", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read the PESignature from a given PECOFF binary file: HelloWorld_Xamarin_4.0.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PESignature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "HelloWorld_Xamarin_4.0.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:File Name", "HelloWorld_Xamarin_4.0.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Signature", "PE")]
        public virtual void ReadThePESignatureFromAGivenPECOFFBinaryFile_HelloWorld_Xamarin_4_0_Exe()
        {
            this.ReadThePESignatureFromAGivenPECOFFBinaryFile("HelloWorld_Xamarin_4.0.exe", "PE", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read the PESignature from a given PECOFF binary file: HelloWorld_Xamarin_4.0Clien" +
            "t.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PESignature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "HelloWorld_Xamarin_4.0Client.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:File Name", "HelloWorld_Xamarin_4.0Client.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Signature", "PE")]
        public virtual void ReadThePESignatureFromAGivenPECOFFBinaryFile_HelloWorld_Xamarin_4_0Client_Exe()
        {
            this.ReadThePESignatureFromAGivenPECOFFBinaryFile("HelloWorld_Xamarin_4.0Client.exe", "PE", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read the PESignature from a given PECOFF binary file: HelloWorld_Xamarin_4.5.1.ex" +
            "e")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PESignature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "HelloWorld_Xamarin_4.5.1.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:File Name", "HelloWorld_Xamarin_4.5.1.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Signature", "PE")]
        public virtual void ReadThePESignatureFromAGivenPECOFFBinaryFile_HelloWorld_Xamarin_4_5_1_Exe()
        {
            this.ReadThePESignatureFromAGivenPECOFFBinaryFile("HelloWorld_Xamarin_4.5.1.exe", "PE", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read the PESignature from a given PECOFF binary file: HelloWorld_Xamarin_4.5.2.ex" +
            "e")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PESignature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "HelloWorld_Xamarin_4.5.2.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:File Name", "HelloWorld_Xamarin_4.5.2.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Signature", "PE")]
        public virtual void ReadThePESignatureFromAGivenPECOFFBinaryFile_HelloWorld_Xamarin_4_5_2_Exe()
        {
            this.ReadThePESignatureFromAGivenPECOFFBinaryFile("HelloWorld_Xamarin_4.5.2.exe", "PE", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read the PESignature from a given PECOFF binary file: HelloWorld_Xamarin_4.5.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PESignature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "HelloWorld_Xamarin_4.5.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:File Name", "HelloWorld_Xamarin_4.5.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Signature", "PE")]
        public virtual void ReadThePESignatureFromAGivenPECOFFBinaryFile_HelloWorld_Xamarin_4_5_Exe()
        {
            this.ReadThePESignatureFromAGivenPECOFFBinaryFile("HelloWorld_Xamarin_4.5.exe", "PE", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read the PESignature from a given PECOFF binary file: HelloWorld_Xamarin_4.6.1.ex" +
            "e")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PESignature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "HelloWorld_Xamarin_4.6.1.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:File Name", "HelloWorld_Xamarin_4.6.1.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Signature", "PE")]
        public virtual void ReadThePESignatureFromAGivenPECOFFBinaryFile_HelloWorld_Xamarin_4_6_1_Exe()
        {
            this.ReadThePESignatureFromAGivenPECOFFBinaryFile("HelloWorld_Xamarin_4.6.1.exe", "PE", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read the PESignature from a given PECOFF binary file: HelloWorld_Xamarin_4.6.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PESignature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "HelloWorld_Xamarin_4.6.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:File Name", "HelloWorld_Xamarin_4.6.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Signature", "PE")]
        public virtual void ReadThePESignatureFromAGivenPECOFFBinaryFile_HelloWorld_Xamarin_4_6_Exe()
        {
            this.ReadThePESignatureFromAGivenPECOFFBinaryFile("HelloWorld_Xamarin_4.6.exe", "PE", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
