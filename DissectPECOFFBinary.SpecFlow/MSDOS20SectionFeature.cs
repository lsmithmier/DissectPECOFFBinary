using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DissectPECOFFBinary.SpecFlow
{
    [DeploymentItem((@".\TestArtifacts\HelloWorld_CSC_2.0.exe"))]
    [DeploymentItem((@".\TestArtifacts\HelloWorld_CSC_3.5.exe"))]
    [DeploymentItem((@".\TestArtifacts\HelloWorld_CSC_4.0.exe"))]
    [DeploymentItem((@".\TestArtifacts\HelloWorld_VS_2.0.exe"))]
    [DeploymentItem((@".\TestArtifacts\HelloWorld_VS_3.0.exe"))]
    [DeploymentItem((@".\TestArtifacts\HelloWorld_VS_3.5.exe"))]
    [DeploymentItem((@".\TestArtifacts\HelloWorld_VS_4.5.1.exe"))]
    [DeploymentItem((@".\TestArtifacts\HelloWorld_VS_4.5.2.exe"))]
    [DeploymentItem((@".\TestArtifacts\HelloWorld_VS_4.5.exe"))]
    [DeploymentItem((@".\TestArtifacts\HelloWorld_VS_4.6.1.exe"))]
    [DeploymentItem((@".\TestArtifacts\HelloWorld_VS_4.6.2.exe"))]
    [DeploymentItem((@".\TestArtifacts\HelloWorld_VS_4.6.exe"))]
    [DeploymentItem((@".\TestArtifacts\HelloWorld_VS_4.exe"))]
    [DeploymentItem((@".\TestArtifacts\HelloWorld_VS_Core_1.0.dll"))]
    [DeploymentItem((@".\TestArtifacts\HelloWorld_Xamarin_2.0.exe"))]
    [DeploymentItem((@".\TestArtifacts\HelloWorld_Xamarin_4.0.exe"))]
    [DeploymentItem((@".\TestArtifacts\HelloWorld_Xamarin_4.0Client.exe"))]
    [DeploymentItem((@".\TestArtifacts\HelloWorld_Xamarin_4.5.1.exe"))]
    [DeploymentItem((@".\TestArtifacts\HelloWorld_Xamarin_4.5.2.exe"))]
    [DeploymentItem((@".\TestArtifacts\HelloWorld_Xamarin_4.5.exe"))]
    [DeploymentItem((@".\TestArtifacts\HelloWorld_Xamarin_4.6.1.exe"))]
    [DeploymentItem((@".\TestArtifacts\HelloWorld_Xamarin_4.6.exe"))]
    public partial class MSDOS20SectionFeature
    {
    }
}
