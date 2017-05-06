Feature: TextSection
	In order to dissect a PECOFF binary file
	As an interested party
	I want to read the .Text from the file
	And I want to see the component parts

Scenario Outline: Read the Import Address Table from a file check the number of entries
	Given a PECOFF binary file named <File Name>
	When I read in the MSDOS20Section
	And I read in the COFFHeader
	And I read in the COFFOptionalHeaderStandardFields
	And I read in the OptionalHeaderDataDirectories
	And I read the SectionTables
	And I read the Import Address Table
	Then the number of entries should be <Number of Entries>
	And the values should be <Entry Values>

Examples: 
	| File Name                        | Number of Entries | Entry Values                                           |
	| HelloWorld_CSC_2.0.exe           | 0x8               | 0x2390,0x0,0x48,0x50002,0x2070,0x2EC,0x1,0x6000001     |
	| HelloWorld_CSC_3.5.exe           | 0x8               | 0x2390,0x0,0x48,0x50002,0x2070,0x2EC,0x1,0x6000001     |
	| HelloWorld_CSC_4.0.exe           | 0x8               | 0x2390,0x0,0x48,0x50002,0x2070,0x2EC,0x1,0x6000001     |
	| HelloWorld_VS_2.0.exe            | 0x8               | 0x278C,0x0,0x48,0x50002,0x2070,0x5B0,0x1,0x6000001     |
	| HelloWorld_VS_3.0.exe            | 0x8               | 0x2788,0x0,0x48,0x50002,0x2070,0x5AC,0x1,0x6000001     |
	| HelloWorld_VS_3.5.exe            | 0x8               | 0x2788,0x0,0x48,0x50002,0x2070,0x5AC,0x1,0x6000001     |
	| HelloWorld_VS_4.5.1.exe          | 0x8               | 0x2820,0x0,0x48,0x50002,0x2070,0x644,0x20003,0x6000001 |
	| HelloWorld_VS_4.5.2.exe          | 0x8               | 0x2820,0x0,0x48,0x50002,0x2070,0x644,0x20003,0x6000001 |
	| HelloWorld_VS_4.5.exe            | 0x8               | 0x2814,0x0,0x48,0x50002,0x2070,0x638,0x20003,0x6000001 |
	| HelloWorld_VS_4.6.1.exe          | 0x8               | 0x2820,0x0,0x48,0x50002,0x2070,0x644,0x20003,0x6000001 |
	| HelloWorld_VS_4.6.2.exe          | 0x8               | 0x280C,0x0,0x48,0x50002,0x2070,0x630,0x20003,0x6000001 |
	| HelloWorld_VS_4.6.exe            | 0x8               | 0x2814,0x0,0x48,0x50002,0x2070,0x638,0x20003,0x6000001 |
	| HelloWorld_VS_4.exe              | 0x8               | 0x280C,0x0,0x48,0x50002,0x2070,0x630,0x1,0x6000001     |
	| HelloWorld_VS_Core_1.0.dll       | 0x8               | 0x27DC,0x0,0x48,0x50002,0x20A4,0x5CC,0x1,0x6000001     |
	| HelloWorld_Xamarin_2.0.exe       | 0x8               | 0x24E0,0x0,0x48,0x50002,0x2070,0x440,0x3,0x6000002     |
	| HelloWorld_Xamarin_4.0.exe       | 0x8               | 0x2560,0x0,0x48,0x50002,0x2070,0x4C0,0x3,0x6000002     |
	| HelloWorld_Xamarin_4.0Client.exe | 0x8               | 0x2590,0x0,0x48,0x50002,0x2070,0x4E8,0x3,0x6000002     |
	| HelloWorld_Xamarin_4.5.1.exe     | 0x8               | 0x2570,0x0,0x48,0x50002,0x2070,0x4C8,0x3,0x6000002     |
	| HelloWorld_Xamarin_4.5.2.exe     | 0x8               | 0x2570,0x0,0x48,0x50002,0x2070,0x4C8,0x3,0x6000002     |
	| HelloWorld_Xamarin_4.5.exe       | 0x8               | 0x2560,0x0,0x48,0x50002,0x2070,0x4C0,0x3,0x6000002     |
	| HelloWorld_Xamarin_4.6.1.exe     | 0x8               | 0x2570,0x0,0x48,0x50002,0x2070,0x4C8,0x3,0x6000002     |
	| HelloWorld_Xamarin_4.6.exe       | 0x8               | 0x2560,0x0,0x48,0x50002,0x2070,0x4C0,0x3,0x6000002     |

Scenario Outline: Read the CLR Header from a file check values
	Given a PECOFF binary file named <File Name>
	When I read in the MSDOS20Section
	And I read in the COFFHeader
	And I read in the COFFOptionalHeaderStandardFields
	And I read in the OptionalHeaderDataDirectories
	And I read the SectionTables
	And I read the CLR Header
	Then the Cb should be <Cb>
	And the Major Runtime Version should be <Major Runtime Version>
	And the Minor Runtime Version should be <Minor Runtime Version>
	And the Metadata should be <Metadata>
	And the Flags should be <Flags>
	And the Entry Point Token/Entry Point RVA should be <Entry Point Token/Entry Point RVA>
	And the Resources should be <Resources>
	And the Strong Name Signature should be <Strong Name Signature>
	And the Code Manager Table should be <Code Manager Table>
	And the VTable Fixups should be <VTable Fixups>
	And the Export Address Table Jumps should be <Export Address Table Jumps>
	And the Managed Native Header should be <Managed Native Header>

Examples: 
	| File Name                        | Cb   | Major Runtime Version | Minor Runtime Version | Metadata      | Flags   | Entry Point Token/Entry Point RVA | Resources | Strong Name Signature | Code Manager Table | VTable Fixups | Export Address Table Jumps | Managed Native Header |
	| HelloWorld_CSC_2.0.exe           | 0x48 | 0x2                   | 0x5                   | 0x2EC00002070 | 0x1     | 0x6000001                         | 0x0       | 0x0                   | 0x0                | 0x0           | 0x0                        | 0x0                   |
	| HelloWorld_CSC_3.5.exe           | 0x48 | 0x2                   | 0x5                   | 0x2EC00002070 | 0x1     | 0x6000001                         | 0x0       | 0x0                   | 0x0                | 0x0           | 0x0                        | 0x0                   |
	| HelloWorld_CSC_4.0.exe           | 0x48 | 0x2                   | 0x5                   | 0x2EC00002070 | 0x1     | 0x6000001                         | 0x0       | 0x0                   | 0x0                | 0x0           | 0x0                        | 0x0                   |
	| HelloWorld_VS_2.0.exe            | 0x48 | 0x2                   | 0x5                   | 0x5B000002070 | 0x1     | 0x6000001                         | 0x0       | 0x0                   | 0x0                | 0x0           | 0x0                        | 0x0                   |
	| HelloWorld_VS_3.0.exe            | 0x48 | 0x2                   | 0x5                   | 0x5AC00002070 | 0x1     | 0x6000001                         | 0x0       | 0x0                   | 0x0                | 0x0           | 0x0                        | 0x0                   |
	| HelloWorld_VS_3.5.exe            | 0x48 | 0x2                   | 0x5                   | 0x5AC00002070 | 0x1     | 0x6000001                         | 0x0       | 0x0                   | 0x0                | 0x0           | 0x0                        | 0x0                   |
	| HelloWorld_VS_4.5.1.exe          | 0x48 | 0x2                   | 0x5                   | 0x64400002070 | 0x20003 | 0x6000001                         | 0x0       | 0x0                   | 0x0                | 0x0           | 0x0                        | 0x0                   |
	| HelloWorld_VS_4.5.2.exe          | 0x48 | 0x2                   | 0x5                   | 0x64400002070 | 0x20003 | 0x6000001                         | 0x0       | 0x0                   | 0x0                | 0x0           | 0x0                        | 0x0                   |
	| HelloWorld_VS_4.5.exe            | 0x48 | 0x2                   | 0x5                   | 0x63800002070 | 0x20003 | 0x6000001                         | 0x0       | 0x0                   | 0x0                | 0x0           | 0x0                        | 0x0                   |
	| HelloWorld_VS_4.6.1.exe          | 0x48 | 0x2                   | 0x5                   | 0x64400002070 | 0x20003 | 0x6000001                         | 0x0       | 0x0                   | 0x0                | 0x0           | 0x0                        | 0x0                   |
	| HelloWorld_VS_4.6.2.exe          | 0x48 | 0x2                   | 0x5                   | 0x63000002070 | 0x20003 | 0x6000001                         | 0x0       | 0x0                   | 0x0                | 0x0           | 0x0                        | 0x0                   |
	| HelloWorld_VS_4.6.exe            | 0x48 | 0x2                   | 0x5                   | 0x63800002070 | 0x20003 | 0x6000001                         | 0x0       | 0x0                   | 0x0                | 0x0           | 0x0                        | 0x0                   |
	| HelloWorld_VS_4.exe              | 0x48 | 0x2                   | 0x5                   | 0x63000002070 | 0x1     | 0x6000001                         | 0x0       | 0x0                   | 0x0                | 0x0           | 0x0                        | 0x0                   |
	| HelloWorld_VS_Core_1.0.dll       | 0x48 | 0x2                   | 0x5                   | 0x5CC000020A4 | 0x1     | 0x6000001                         | 0x0       | 0x0                   | 0x0                | 0x0           | 0x0                        | 0x0                   |
	| HelloWorld_Xamarin_2.0.exe       | 0x48 | 0x2                   | 0x5                   | 0x44000002070 | 0x3     | 0x6000002                         | 0x0       | 0x0                   | 0x0                | 0x0           | 0x0                        | 0x0                   |
	| HelloWorld_Xamarin_4.0.exe       | 0x48 | 0x2                   | 0x5                   | 0x4C000002070 | 0x3     | 0x6000002                         | 0x0       | 0x0                   | 0x0                | 0x0           | 0x0                        | 0x0                   |
	| HelloWorld_Xamarin_4.0Client.exe | 0x48 | 0x2                   | 0x5                   | 0x4E800002070 | 0x3     | 0x6000002                         | 0x0       | 0x0                   | 0x0                | 0x0           | 0x0                        | 0x0                   |
	| HelloWorld_Xamarin_4.5.1.exe     | 0x48 | 0x2                   | 0x5                   | 0x4C800002070 | 0x3     | 0x6000002                         | 0x0       | 0x0                   | 0x0                | 0x0           | 0x0                        | 0x0                   |
	| HelloWorld_Xamarin_4.5.2.exe     | 0x48 | 0x2                   | 0x5                   | 0x4C800002070 | 0x3     | 0x6000002                         | 0x0       | 0x0                   | 0x0                | 0x0           | 0x0                        | 0x0                   |
	| HelloWorld_Xamarin_4.5.exe       | 0x48 | 0x2                   | 0x5                   | 0x4C000002070 | 0x3     | 0x6000002                         | 0x0       | 0x0                   | 0x0                | 0x0           | 0x0                        | 0x0                   |
	| HelloWorld_Xamarin_4.6.1.exe     | 0x48 | 0x2                   | 0x5                   | 0x4C800002070 | 0x3     | 0x6000002                         | 0x0       | 0x0                   | 0x0                | 0x0           | 0x0                        | 0x0                   |
	| HelloWorld_Xamarin_4.6.exe       | 0x48 | 0x2                   | 0x5                   | 0x4C000002070 | 0x3     | 0x6000002                         | 0x0       | 0x0                   | 0x0                | 0x0           | 0x0                        | 0x0                   |