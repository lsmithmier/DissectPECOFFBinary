Feature: MSDOS20Section
	In order to dissect a PECOFF binary file
	As an interested party
	I want to read the MSDOS20Section from the file
	And I want to see the component parts

Scenario Outline: Read the MSDOS20Section from a given PECOFF binary file
	Given a PECOFF binary file named <File Name>
	When I read in the MSDOS20Section
	Then the Signature shoud be <Signature>
	And the OffsetToPEHeader should be <OffsetToPEHeader>

Examples: 
	| File Name                        | Signature | OffsetToPEHeader |
	| HelloWorld_CSC_2.0.exe           | MZ        | 0x80             |
	| HelloWorld_CSC_3.5.exe           | MZ        | 0x80             |
	| HelloWorld_CSC_4.0.exe           | MZ        | 0x80             |
	| HelloWorld_VS_2.0.exe            | MZ        | 0x80             |
	| HelloWorld_VS_3.0.exe            | MZ        | 0x80             |
	| HelloWorld_VS_3.5.exe            | MZ        | 0x80             |
	| HelloWorld_VS_4.5.1.exe          | MZ        | 0x80             |
	| HelloWorld_VS_4.5.2.exe          | MZ        | 0x80             |
	| HelloWorld_VS_4.5.exe            | MZ        | 0x80             |
	| HelloWorld_VS_4.6.1.exe          | MZ        | 0x80             |
	| HelloWorld_VS_4.6.2.exe          | MZ        | 0x80             |
	| HelloWorld_VS_4.6.exe            | MZ        | 0x80             |
	| HelloWorld_VS_4.exe              | MZ        | 0x80             |
	| HelloWorld_VS_Core_1.0.dll       | MZ        | 0x80             |
	| HelloWorld_Xamarin_2.0.exe       | MZ        | 0x80             |
	| HelloWorld_Xamarin_4.0.exe       | MZ        | 0x80             |
	| HelloWorld_Xamarin_4.0Client.exe | MZ        | 0x80             |
	| HelloWorld_Xamarin_4.5.1.exe     | MZ        | 0x80             |
	| HelloWorld_Xamarin_4.5.2.exe     | MZ        | 0x80             |
	| HelloWorld_Xamarin_4.5.exe       | MZ        | 0x80             |
	| HelloWorld_Xamarin_4.6.1.exe     | MZ        | 0x80             |
	| HelloWorld_Xamarin_4.6.exe       | MZ        | 0x80             |
