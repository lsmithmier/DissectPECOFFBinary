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

Scenario Outline: Read the Debug Directory from a file check values
	Given a PECOFF binary file named <File Name>
	When I read in the MSDOS20Section
	And I read in the COFFHeader
	And I read in the COFFOptionalHeaderStandardFields
	And I read in the OptionalHeaderDataDirectories
	And I read the SectionTables
	And I read the Debug Directory
	Then the Debug Characteristics should be <Characteristics>
	And the Debug TimeDateStamp should be <TimeDateStamp>
	And the Debug Major Version should be <Major Version>
	And the Debug Minor Version should be <Minor Version>
	And the Debug Type should be <Type>
	And the Debug SizeOfData should be <SizeOfData>
	And the Debug AddressOfRawData should be <AddressOfRawData>

Examples: 
	| File Name                        | Characteristics | TimeDateStamp | Major Version | Minor Version | Type | SizeOfData | AddressOfRawData |
	| HelloWorld_CSC_2.0.exe           | 0x0             | 0x0           | 0x0           | 0x0           | 0x0  | 0x0        | 0x0              |
	| HelloWorld_CSC_3.5.exe           | 0x0             | 0x0           | 0x0           | 0x0           | 0x0  | 0x0        | 0x0              |
	| HelloWorld_CSC_4.0.exe           | 0x0             | 0x0           | 0x0           | 0x0           | 0x0  | 0x0        | 0x0              |
	| HelloWorld_VS_2.0.exe            | 0x0             | 0x586C5B43    | 0x0           | 0x0           | 0x2  | 0x11C      | 0x263C           |
	| HelloWorld_VS_3.0.exe            | 0x0             | 0x586C5B43    | 0x0           | 0x0           | 0x2  | 0x11C      | 0x2638           |
	| HelloWorld_VS_3.5.exe            | 0x0             | 0x586C5B43    | 0x0           | 0x0           | 0x2  | 0x11C      | 0x2638           |
	| HelloWorld_VS_4.5.1.exe          | 0x0             | 0x586C5B43    | 0x0           | 0x0           | 0x2  | 0x11C      | 0x26D0           |
	| HelloWorld_VS_4.5.2.exe          | 0x0             | 0x586C5B43    | 0x0           | 0x0           | 0x2  | 0x11C      | 0x26D0           |
	| HelloWorld_VS_4.5.exe            | 0x0             | 0x586C5B43    | 0x0           | 0x0           | 0x2  | 0x11C      | 0x26C4           |
	| HelloWorld_VS_4.6.1.exe          | 0x0             | 0x586C5B43    | 0x0           | 0x0           | 0x2  | 0x11C      | 0x26D0           |
	| HelloWorld_VS_4.6.2.exe          | 0x0             | 0x586C5B43    | 0x0           | 0x0           | 0x2  | 0x11C      | 0x26BC           |
	| HelloWorld_VS_4.6.exe            | 0x0             | 0x586C5B43    | 0x0           | 0x0           | 0x2  | 0x11C      | 0x26C4           |
	| HelloWorld_VS_4.exe              | 0x0             | 0x586C5B43    | 0x0           | 0x0           | 0x2  | 0x11C      | 0x26BC           |
	| HelloWorld_VS_Core_1.0.dll       | 0x0             | 0x586B021F    | 0x0           | 0x0           | 0x2  | 0x11C      | 0x268C           |
	| HelloWorld_Xamarin_2.0.exe       | 0x0             | 0x0           | 0x0           | 0x0           | 0x0  | 0x0        | 0x0              |
	| HelloWorld_Xamarin_4.0.exe       | 0x0             | 0x0           | 0x0           | 0x0           | 0x0  | 0x0        | 0x0              |
	| HelloWorld_Xamarin_4.0Client.exe | 0x0             | 0x0           | 0x0           | 0x0           | 0x0  | 0x0        | 0x0              |
	| HelloWorld_Xamarin_4.5.1.exe     | 0x0             | 0x0           | 0x0           | 0x0           | 0x0  | 0x0        | 0x0              |
	| HelloWorld_Xamarin_4.5.2.exe     | 0x0             | 0x0           | 0x0           | 0x0           | 0x0  | 0x0        | 0x0              |
	| HelloWorld_Xamarin_4.5.exe       | 0x0             | 0x0           | 0x0           | 0x0           | 0x0  | 0x0        | 0x0              |
	| HelloWorld_Xamarin_4.6.1.exe     | 0x0             | 0x0           | 0x0           | 0x0           | 0x0  | 0x0        | 0x0              |
	| HelloWorld_Xamarin_4.6.exe       | 0x0             | 0x0           | 0x0           | 0x0           | 0x0  | 0x0        | 0x0              |

Scenario Outline: Read the CodeViewHeader from a file check values
	Given a PECOFF binary file named <File Name>
	When I read in the MSDOS20Section
	And I read in the COFFHeader
	And I read in the COFFOptionalHeaderStandardFields
	And I read in the OptionalHeaderDataDirectories
	And I read the SectionTables
	And I read the Debug Directory
	And I read the CodeView Header
	Then the CvSignature should be <CvSignature>
	And the Signature should be <Signature>
	And the Age should be <Age>
	And the PdbFileName should be '<PdbFileName>'

Examples: 
	| File Name                        | CvSignature | Signature                            | Age | PdbFileName                                                                            |
	| HelloWorld_CSC_2.0.exe           |             |                                      | 0x0 |                                                                                        |
	| HelloWorld_CSC_3.5.exe           |             |                                      | 0x0 |                                                                                        |
	| HelloWorld_CSC_4.0.exe           |             |                                      | 0x0 |                                                                                        |
	| HelloWorld_VS_2.0.exe            | RSDS        | 9d262c59-dbb1-4517-866a-e5a7f2babb32 | 1   | D:\Source\HelloWorld\HelloWorld_VS_2.0\obj\Release\HelloWorld_VS_2.0.pdb               |
	| HelloWorld_VS_3.0.exe            | RSDS        | 875cbf0a-0cad-44f0-a131-9844c3a8be11 | 1   | D:\Source\HelloWorld\HelloWorld_3.0\obj\Release\HelloWorld_VS_3.0.pdb                  |
	| HelloWorld_VS_3.5.exe            | RSDS        | fea38570-ba5f-4ea1-8d2f-c1fea71fca9f | 1   | D:\Source\HelloWorld\HelloWorld_3.5\obj\Release\HelloWorld_VS_3.5.pdb                  |
	| HelloWorld_VS_4.5.1.exe          | RSDS        | 3de14e5f-9600-447e-941b-347ee0736fb0 | 1   | D:\Source\HelloWorld\HelloWorld_4.5.1\obj\Release\HelloWorld_VS_4.5.1.pdb              |
	| HelloWorld_VS_4.5.2.exe          | RSDS        | 873c0c33-52e9-4c04-a817-a0225f03579c | 1   | D:\Source\HelloWorld\HelloWorld_4.5.2\obj\Release\HelloWorld_VS_4.5.2.pdb              |
	| HelloWorld_VS_4.5.exe            | RSDS        | 7be5edb3-7e51-4533-9f28-bf7b207ab22c | 1   | D:\Source\HelloWorld\HelloWorld_4.5\obj\Release\HelloWorld_VS_4.5.pdb                  |
	| HelloWorld_VS_4.6.1.exe          | RSDS        | a1e697d6-2db5-43ba-9e2f-ad8e30a09c13 | 1   | D:\Source\HelloWorld\HelloWorld_4.6.1\obj\Release\HelloWorld_VS_4.6.1.pdb              |
	| HelloWorld_VS_4.6.2.exe          | RSDS        | 02173892-8a8a-43dd-aa4c-7b8cc1af10e0 | 1   | D:\Source\HelloWorld\HelloWorld_VS_4.6.2\obj\Release\HelloWorld_VS_4.6.2.pdb           |
	| HelloWorld_VS_4.6.exe            | RSDS        | e24c3f67-f504-4ce8-94b2-204e4cdce7e8 | 1   | D:\Source\HelloWorld\HelloWorld_4.6\obj\Release\HelloWorld_VS_4.6.pdb                  |
	| HelloWorld_VS_4.exe              | RSDS        | 0590a9a9-7279-4c01-bcbd-64c648b238dd | 1   | D:\Source\HelloWorld\HelloWorld_4\obj\Release\HelloWorld_VS_4.pdb                      |
	# Ok, this is strange, but if I put the full path in as it should be then SpecFlow tries to parse it differently.  It might be a Gherkin keyword or something, but this is a workaround.
	| HelloWorld_VS_Core_1.0.dll       | RSDS        | ae8dc3e2-b3d7-490a-a1b9-2bd7e3f9c53a | 1   | D:\Source\HelloWorld\HelloWorld_VS_Core_1.0\bin\Release\~.0\HelloWorld_VS_Core_1.0.pdb |
	| HelloWorld_Xamarin_2.0.exe       |             |                                      | 0x0 |                                                                                        |
	| HelloWorld_Xamarin_4.0.exe       |             |                                      | 0x0 |                                                                                        |
	| HelloWorld_Xamarin_4.0Client.exe |             |                                      | 0x0 |                                                                                        |
	| HelloWorld_Xamarin_4.5.1.exe     |             |                                      | 0x0 |                                                                                        |
	| HelloWorld_Xamarin_4.5.2.exe     |             |                                      | 0x0 |                                                                                        |
	| HelloWorld_Xamarin_4.5.exe       |             |                                      | 0x0 |                                                                                        |
	| HelloWorld_Xamarin_4.6.1.exe     |             |                                      | 0x0 |                                                                                        |
	| HelloWorld_Xamarin_4.6.exe       |             |                                      | 0x0 |                                                                                        |

Scenario Outline: Read the General Metadata Header from a file check values
	Given a PECOFF binary file named <File Name>
	When I read in the MSDOS20Section
	And I read in the COFFHeader
	And I read in the COFFOptionalHeaderStandardFields
	And I read in the OptionalHeaderDataDirectories
	And I read the SectionTables
	And I read the CLR Header
	And I read the General Metadata Header
	Then the lSignature should be <lSignature>
	And the iMajorVer should be <iMajorVer>
	And the iMinorVer should be <iMinorVer>
	And the iExtraData should be <iExtraData>
	And the iVersionString should be <iVersionString>
	And the pVersion should be <pVersion>

Examples: 
	| File Name                        | lSignature | iMajorVer | iMinorVer | iExtraData | iVersionString | pVersion   |
	| HelloWorld_CSC_2.0.exe           | BSJB       | 0x1       | 0x1       | 0X0        | 0xC            | v2.0.50727 |
	| HelloWorld_CSC_3.5.exe           | BSJB       | 0x1       | 0x1       | 0X0        | 0xC            | v2.0.50727 |
	| HelloWorld_CSC_4.0.exe           | BSJB       | 0x1       | 0x1       | 0X0        | 0xC            | v4.0.30319 |
	| HelloWorld_VS_2.0.exe            | BSJB       | 0x1       | 0x1       | 0X0        | 0xC            | v2.0.50727 |
	| HelloWorld_VS_3.0.exe            | BSJB       | 0x1       | 0x1       | 0X0        | 0xC            | v2.0.50727 |
	| HelloWorld_VS_3.5.exe            | BSJB       | 0x1       | 0x1       | 0X0        | 0xC            | v2.0.50727 |
	| HelloWorld_VS_4.5.1.exe          | BSJB       | 0x1       | 0x1       | 0X0        | 0xC            | v4.0.30319 |
	| HelloWorld_VS_4.5.2.exe          | BSJB       | 0x1       | 0x1       | 0X0        | 0xC            | v4.0.30319 |
	| HelloWorld_VS_4.5.exe            | BSJB       | 0x1       | 0x1       | 0X0        | 0xC            | v4.0.30319 |
	| HelloWorld_VS_4.6.1.exe          | BSJB       | 0x1       | 0x1       | 0X0        | 0xC            | v4.0.30319 |
	| HelloWorld_VS_4.6.2.exe          | BSJB       | 0x1       | 0x1       | 0X0        | 0xC            | v4.0.30319 |
	| HelloWorld_VS_4.6.exe            | BSJB       | 0x1       | 0x1       | 0X0        | 0xC            | v4.0.30319 |
	| HelloWorld_VS_4.exe              | BSJB       | 0x1       | 0x1       | 0X0        | 0xC            | v4.0.30319 |
	| HelloWorld_VS_Core_1.0.dll       | BSJB       | 0x1       | 0x1       | 0X0        | 0xC            | v4.0.30319 |
	| HelloWorld_Xamarin_2.0.exe       | BSJB       | 0x1       | 0x1       | 0X0        | 0xC            | v2.0.50727 |
	| HelloWorld_Xamarin_4.0.exe       | BSJB       | 0x1       | 0x1       | 0X0        | 0xC            | v4.0.30319 |
	| HelloWorld_Xamarin_4.0Client.exe | BSJB       | 0x1       | 0x1       | 0X0        | 0xC            | v4.0.30319 |
	| HelloWorld_Xamarin_4.5.1.exe     | BSJB       | 0x1       | 0x1       | 0X0        | 0xC            | v4.0.30319 |
	| HelloWorld_Xamarin_4.5.2.exe     | BSJB       | 0x1       | 0x1       | 0X0        | 0xC            | v4.0.30319 |
	| HelloWorld_Xamarin_4.5.exe       | BSJB       | 0x1       | 0x1       | 0X0        | 0xC            | v4.0.30319 |
	| HelloWorld_Xamarin_4.6.1.exe     | BSJB       | 0x1       | 0x1       | 0X0        | 0xC            | v4.0.30319 |
	| HelloWorld_Xamarin_4.6.exe       | BSJB       | 0x1       | 0x1       | 0X0        | 0xC            | v4.0.30319 |

Scenario Outline: Read the Metadata Storage Header from a file check values
	Given a PECOFF binary file named <File Name>
	When I read in the MSDOS20Section
	And I read in the COFFHeader
	And I read in the COFFOptionalHeaderStandardFields
	And I read in the OptionalHeaderDataDirectories
	And I read the SectionTables
	And I read the CLR Header
	And I read the General Metadata Header
	And I read the Metadata Storage Header
	Then the fFlags should be <fFlags>
	And the padding should be <padding>
	And the iStreams should be <iStreams>

Examples: 
	| File Name                        | fFlags | padding | iStreams |
	| HelloWorld_CSC_2.0.exe           | 0x0    | 0x0     | 0x5      |
	| HelloWorld_CSC_3.5.exe           | 0x0    | 0x0     | 0x5      |
	| HelloWorld_CSC_4.0.exe           | 0x0    | 0x0     | 0x5      |
	| HelloWorld_VS_2.0.exe            | 0x0    | 0x0     | 0x5      |
	| HelloWorld_VS_3.0.exe            | 0x0    | 0x0     | 0x5      |
	| HelloWorld_VS_3.5.exe            | 0x0    | 0x0     | 0x5      |
	| HelloWorld_VS_4.5.1.exe          | 0x0    | 0x0     | 0x5      |
	| HelloWorld_VS_4.5.2.exe          | 0x0    | 0x0     | 0x5      |
	| HelloWorld_VS_4.5.exe            | 0x0    | 0x0     | 0x5      |
	| HelloWorld_VS_4.6.1.exe          | 0x0    | 0x0     | 0x5      |
	| HelloWorld_VS_4.6.2.exe          | 0x0    | 0x0     | 0x5      |
	| HelloWorld_VS_4.6.exe            | 0x0    | 0x0     | 0x5      |
	| HelloWorld_VS_4.exe              | 0x0    | 0x0     | 0x5      |
	| HelloWorld_VS_Core_1.0.dll       | 0x0    | 0x0     | 0x5      |
	| HelloWorld_Xamarin_2.0.exe       | 0x0    | 0x0     | 0x5      |
	| HelloWorld_Xamarin_4.0.exe       | 0x0    | 0x0     | 0x5      |
	| HelloWorld_Xamarin_4.0Client.exe | 0x0    | 0x0     | 0x5      |
	| HelloWorld_Xamarin_4.5.1.exe     | 0x0    | 0x0     | 0x5      |
	| HelloWorld_Xamarin_4.5.2.exe     | 0x0    | 0x0     | 0x5      |
	| HelloWorld_Xamarin_4.5.exe       | 0x0    | 0x0     | 0x5      |
	| HelloWorld_Xamarin_4.6.1.exe     | 0x0    | 0x0     | 0x5      |
	| HelloWorld_Xamarin_4.6.exe       | 0x0    | 0x0     | 0x5      |

Scenario Outline: Read the Metadata Stream Headers from a file check values
	Given a PECOFF binary file named <File Name>
	When I read in the MSDOS20Section
	And I read in the COFFHeader
	And I read in the COFFOptionalHeaderStandardFields
	And I read in the OptionalHeaderDataDirectories
	And I read the SectionTables
	And I read the CLR Header
	And I read the General Metadata Header
	And I read the Metadata Storage Header
	And I read the Metadata Stream Headers
	Then if the rcName is <rcName>
	Then the iOffset should be <iOffset>
	And the iSize should be <iSize>

Examples: 
	| File Name                        | rcName   | iOffset | iSize |
	| HelloWorld_CSC_2.0.exe           | #~       | 0x6C    | 0x104 |
	| HelloWorld_CSC_3.5.exe           | #~       | 0x6C    | 0x104 |
	| HelloWorld_CSC_4.0.exe           | #~       | 0x6C    | 0x104 |
	| HelloWorld_VS_2.0.exe            | #~       | 0x6C    | 0x1D0 |
	| HelloWorld_VS_3.0.exe            | #~       | 0x6C    | 0x1D0 |
	| HelloWorld_VS_3.5.exe            | #~       | 0x6C    | 0x1D0 |
	| HelloWorld_VS_4.5.1.exe          | #~       | 0x6C    | 0x1E4 |
	| HelloWorld_VS_4.5.2.exe          | #~       | 0x6C    | 0x1E4 |
	| HelloWorld_VS_4.5.exe            | #~       | 0x6C    | 0x1E4 |
	| HelloWorld_VS_4.6.1.exe          | #~       | 0x6C    | 0x1E4 |
	| HelloWorld_VS_4.6.2.exe          | #~       | 0x6C    | 0x1E4 |
	| HelloWorld_VS_4.6.exe            | #~       | 0x6C    | 0x1E4 |
	| HelloWorld_VS_4.exe              | #~       | 0x6C    | 0x1E4 |
	| HelloWorld_VS_Core_1.0.dll       | #~       | 0x6C    | 0x1E0 |
	| HelloWorld_Xamarin_2.0.exe       | #~       | 0x6C    | 0x170 |
	| HelloWorld_Xamarin_4.0.exe       | #~       | 0x6C    | 0x184 |
	| HelloWorld_Xamarin_4.0Client.exe | #~       | 0x6C    | 0x184 |
	| HelloWorld_Xamarin_4.5.1.exe     | #~       | 0x6C    | 0x184 |
	| HelloWorld_Xamarin_4.5.2.exe     | #~       | 0x6C    | 0x184 |
	| HelloWorld_Xamarin_4.5.exe       | #~       | 0x6C    | 0x184 |
	| HelloWorld_Xamarin_4.6.1.exe     | #~       | 0x6C    | 0x184 |
	| HelloWorld_Xamarin_4.6.exe       | #~       | 0x6C    | 0x184 |
	| HelloWorld_CSC_2.0.exe           | #Strings | 0x170   | 0x100 |
	| HelloWorld_CSC_3.5.exe           | #Strings | 0x170   | 0x100 |
	| HelloWorld_CSC_4.0.exe           | #Strings | 0x170   | 0x100 |
	| HelloWorld_VS_2.0.exe            | #Strings | 0x23C   | 0x258 |
	| HelloWorld_VS_3.0.exe            | #Strings | 0x23C   | 0x258 |
	| HelloWorld_VS_3.5.exe            | #Strings | 0x23C   | 0x258 |
	| HelloWorld_VS_4.5.1.exe          | #Strings | 0x250   | 0x28C |
	| HelloWorld_VS_4.5.2.exe          | #Strings | 0x250   | 0x28C |
	| HelloWorld_VS_4.5.exe            | #Strings | 0x250   | 0x288 |
	| HelloWorld_VS_4.6.1.exe          | #Strings | 0x250   | 0x28C |
	| HelloWorld_VS_4.6.2.exe          | #Strings | 0x250   | 0x28C |
	| HelloWorld_VS_4.6.exe            | #Strings | 0x250   | 0x288 |
	| HelloWorld_VS_4.exe              | #Strings | 0x250   | 0x284 |
	| HelloWorld_VS_Core_1.0.dll       | #Strings | 0x24C   | 0x264 |
	| HelloWorld_Xamarin_2.0.exe       | #Strings | 0x1DC   | 0x1C0 |
	| HelloWorld_Xamarin_4.0.exe       | #Strings | 0x1F0   | 0x1F4 |
	| HelloWorld_Xamarin_4.0Client.exe | #Strings | 0x1F0   | 0x208 |
	| HelloWorld_Xamarin_4.5.1.exe     | #Strings | 0x1F0   | 0x1F8 |
	| HelloWorld_Xamarin_4.5.2.exe     | #Strings | 0x1F0   | 0x1F8 |
	| HelloWorld_Xamarin_4.5.exe       | #Strings | 0x1F0   | 0x1F4 |
	| HelloWorld_Xamarin_4.6.1.exe     | #Strings | 0x1F0   | 0x1F8 |
	| HelloWorld_Xamarin_4.6.exe       | #Strings | 0x1F0   | 0x1F4 |
	| HelloWorld_CSC_2.0.exe           | #US      | 0x270   | 0x1C  |
	| HelloWorld_CSC_3.5.exe           | #US      | 0x270   | 0x1C  |
	| HelloWorld_CSC_4.0.exe           | #US      | 0x270   | 0x1C  |
	| HelloWorld_VS_2.0.exe            | #US      | 0x494   | 0x1C  |
	| HelloWorld_VS_3.0.exe            | #US      | 0x494   | 0x1C  |
	| HelloWorld_VS_3.5.exe            | #US      | 0x494   | 0x1C  |
	| HelloWorld_VS_4.5.1.exe          | #US      | 0x4DC   | 0x1C  |
	| HelloWorld_VS_4.5.2.exe          | #US      | 0x4DC   | 0x1C  |
	| HelloWorld_VS_4.5.exe            | #US      | 0x4D8   | 0x1C  |
	| HelloWorld_VS_4.6.1.exe          | #US      | 0x4DC   | 0x1C  |
	| HelloWorld_VS_4.6.2.exe          | #US      | 0x4DC   | 0x1C  |
	| HelloWorld_VS_4.6.exe            | #US      | 0x4D8   | 0x1C  |
	| HelloWorld_VS_4.exe              | #US      | 0x4D4   | 0x1C  |
	| HelloWorld_VS_Core_1.0.dll       | #US      | 0x4B0   | 0x1C  |
	| HelloWorld_Xamarin_2.0.exe       | #US      | 0x39C   | 0x1C  |
	| HelloWorld_Xamarin_4.0.exe       | #US      | 0x3E4   | 0x1C  |
	| HelloWorld_Xamarin_4.0Client.exe | #US      | 0x3F8   | 0x1C  |
	| HelloWorld_Xamarin_4.5.1.exe     | #US      | 0x3E8   | 0x1C  |
	| HelloWorld_Xamarin_4.5.2.exe     | #US      | 0x3E8   | 0x1C  |
	| HelloWorld_Xamarin_4.5.exe       | #US      | 0x3E4   | 0x1C  |
	| HelloWorld_Xamarin_4.6.1.exe     | #US      | 0x3E8   | 0x1C  |
	| HelloWorld_Xamarin_4.6.exe       | #US      | 0x3E4   | 0x1C  |
	| HelloWorld_CSC_2.0.exe           | #GUID    | 0x28C   | 0x10  |
	| HelloWorld_CSC_3.5.exe           | #GUID    | 0x28C   | 0x10  |
	| HelloWorld_CSC_4.0.exe           | #GUID    | 0x28C   | 0x10  |
	| HelloWorld_VS_2.0.exe            | #GUID    | 0x4B0   | 0x10  |
	| HelloWorld_VS_3.0.exe            | #GUID    | 0x4B0   | 0x10  |
	| HelloWorld_VS_3.5.exe            | #GUID    | 0x4B0   | 0x10  |
	| HelloWorld_VS_4.5.1.exe          | #GUID    | 0x4F8   | 0x10  |
	| HelloWorld_VS_4.5.2.exe          | #GUID    | 0x4F8   | 0x10  |
	| HelloWorld_VS_4.5.exe            | #GUID    | 0x4F4   | 0x10  |
	| HelloWorld_VS_4.6.1.exe          | #GUID    | 0x4F8   | 0x10  |
	| HelloWorld_VS_4.6.2.exe          | #GUID    | 0x4F8   | 0x10  |
	| HelloWorld_VS_4.6.exe            | #GUID    | 0x4F4   | 0x10  |
	| HelloWorld_VS_4.exe              | #GUID    | 0x4F0   | 0x10  |
	| HelloWorld_VS_Core_1.0.dll       | #GUID    | 0x4CC   | 0x10  |
	| HelloWorld_Xamarin_2.0.exe       | #GUID    | 0x3B8   | 0x10  |
	| HelloWorld_Xamarin_4.0.exe       | #GUID    | 0x400   | 0x10  |
	| HelloWorld_Xamarin_4.0Client.exe | #GUID    | 0x414   | 0x10  |
	| HelloWorld_Xamarin_4.5.1.exe     | #GUID    | 0x404   | 0x10  |
	| HelloWorld_Xamarin_4.5.2.exe     | #GUID    | 0x404   | 0x10  |
	| HelloWorld_Xamarin_4.5.exe       | #GUID    | 0x400   | 0x10  |
	| HelloWorld_Xamarin_4.6.1.exe     | #GUID    | 0x404   | 0x10  |
	| HelloWorld_Xamarin_4.6.exe       | #GUID    | 0x400   | 0x10  |
	| HelloWorld_CSC_2.0.exe           | #Blob    | 0x29C   | 0x50  |
	| HelloWorld_CSC_3.5.exe           | #Blob    | 0x29C   | 0x50  |
	| HelloWorld_CSC_4.0.exe           | #Blob    | 0x29C   | 0x50  |
	| HelloWorld_VS_2.0.exe            | #Blob    | 0x4C0   | 0xF0  |
	| HelloWorld_VS_3.0.exe            | #Blob    | 0x4C0   | 0xEC  |
	| HelloWorld_VS_3.5.exe            | #Blob    | 0x4C0   | 0xEC  |
	| HelloWorld_VS_4.5.1.exe          | #Blob    | 0x508   | 0x13C |
	| HelloWorld_VS_4.5.2.exe          | #Blob    | 0x508   | 0x13C |
	| HelloWorld_VS_4.5.exe            | #Blob    | 0x504   | 0x134 |
	| HelloWorld_VS_4.6.1.exe          | #Blob    | 0x508   | 0x13C |
	| HelloWorld_VS_4.6.2.exe          | #Blob    | 0x508   | 0x128 |
	| HelloWorld_VS_4.6.exe            | #Blob    | 0x504   | 0x134 |
	| HelloWorld_VS_4.exe              | #Blob    | 0x500   | 0x130 |
	| HelloWorld_VS_Core_1.0.dll       | #Blob    | 0x4DC   | 0xF0  |
	| HelloWorld_Xamarin_2.0.exe       | #Blob    | 0x3C8   | 0x78  |
	| HelloWorld_Xamarin_4.0.exe       | #Blob    | 0x410   | 0xB0  |
	| HelloWorld_Xamarin_4.0Client.exe | #Blob    | 0x424   | 0xC4  |
	| HelloWorld_Xamarin_4.5.1.exe     | #Blob    | 0x414   | 0xB4  |
	| HelloWorld_Xamarin_4.5.2.exe     | #Blob    | 0x414   | 0xB4  |
	| HelloWorld_Xamarin_4.5.exe       | #Blob    | 0x410   | 0xB0  |
	| HelloWorld_Xamarin_4.6.1.exe     | #Blob    | 0x414   | 0xB4  |
	| HelloWorld_Xamarin_4.6.exe       | #Blob    | 0x410   | 0xB0  |
