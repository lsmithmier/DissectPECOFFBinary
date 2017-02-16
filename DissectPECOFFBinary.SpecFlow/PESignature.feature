Feature: PESignature
	In order to dissect a PECOFF binary file
	As an interested party
	I want to read the PESignature from the file
	And I want to see the component parts

Scenario Outline: Read the PESignature from a given PECOFF binary file
	Given a PECOFF binary file named <File Name>
	When I read in the MSDOS20Section
	And I read in the PESignature
	Then the PE Signature shoud be <Signature>

Examples: 
	| File Name              | Signature |
	| HelloWorld_CSC_2.0.exe | PE        |
	| HelloWorld_CSC_3.5.exe           | PE        |
	| HelloWorld_CSC_4.0.exe           | PE        |
	| HelloWorld_VS_2.0.exe            | PE        |
	| HelloWorld_VS_3.0.exe            | PE        |
	| HelloWorld_VS_3.5.exe            | PE        |
	| HelloWorld_VS_4.5.1.exe          | PE        |
	| HelloWorld_VS_4.5.2.exe          | PE        |
	| HelloWorld_VS_4.5.exe            | PE        |
	| HelloWorld_VS_4.6.1.exe          | PE        |
	| HelloWorld_VS_4.6.2.exe          | PE        |
	| HelloWorld_VS_4.6.exe            | PE        |
	| HelloWorld_VS_4.exe              | PE        |
	| HelloWorld_VS_Core_1.0.dll       | PE        |
	| HelloWorld_Xamarin_2.0.exe       | PE        |
	| HelloWorld_Xamarin_4.0.exe       | PE        |
	| HelloWorld_Xamarin_4.0Client.exe | PE        |
	| HelloWorld_Xamarin_4.5.1.exe     | PE        |
	| HelloWorld_Xamarin_4.5.2.exe     | PE        |
	| HelloWorld_Xamarin_4.5.exe       | PE        |
	| HelloWorld_Xamarin_4.6.1.exe     | PE        |
	| HelloWorld_Xamarin_4.6.exe       | PE        |
