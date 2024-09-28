Feature: COFFHeader
	In order to dissect a PECOFF binary file
	As an interested party
	I want to read the COFFHeader from the file
	And I want to see the component parts

Scenario Outline: Read the COFFHeader from a given PECOFF binary file
	Given a PECOFF binary file named <File Name>
	When I read in the MSDOS20Section
	And I read in the COFFHeader
	Then the MachineType shoud be <MachineType>
	And the NumberOfSections should be <NumberOfSections>
	And the PointerToSymbolTable should be <PointerToSymbolTable>
	And the NumberOfSymbols should be <NumberOfSymbols>
	And the SizeOfOptionalHeader should be <SizeOfOptionalHeader>
	And the Characteristics should be <Characteristics>

Examples: 
	| File Name                        | MachineType | NumberOfSections | PointerToSymbolTable | NumberOfSymbols | SizeOfOptionalHeader | Characteristics |
	| HelloWorld_CSC_2.0.exe           | 0x14C       | 3                | 0x0                  | 0               | 0xE0                 | 0x102           |
	| HelloWorld_CSC_3.5.exe           | 0x14C       | 3                | 0x0                  | 0               | 0xE0                 | 0x102           |
	| HelloWorld_CSC_4.0.exe           | 0x14C       | 3                | 0x0                  | 0               | 0xE0                 | 0x102           |
	| HelloWorld_VS_2.0.exe            | 0x14C       | 3                | 0x0                  | 0               | 0xE0                 | 0x22            |
	| HelloWorld_VS_3.0.exe            | 0x14C       | 3                | 0x0                  | 0               | 0xE0                 | 0x22            |
	| HelloWorld_VS_3.5.exe            | 0x14C       | 3                | 0x0                  | 0               | 0xE0                 | 0x22            |
	| HelloWorld_VS_4.5.1.exe          | 0x14C       | 3                | 0x0                  | 0               | 0xE0                 | 0x22            |
	| HelloWorld_VS_4.5.2.exe          | 0x14C       | 3                | 0x0                  | 0               | 0xE0                 | 0x22            |
	| HelloWorld_VS_4.5.exe            | 0x14C       | 3                | 0x0                  | 0               | 0xE0                 | 0x22            |
	| HelloWorld_VS_4.6.1.exe          | 0x14C       | 3                | 0x0                  | 0               | 0xE0                 | 0x22            |
	| HelloWorld_VS_4.6.2.exe          | 0x14C       | 3                | 0x0                  | 0               | 0xE0                 | 0x22            |
	| HelloWorld_VS_4.6.exe            | 0x14C       | 3                | 0x0                  | 0               | 0xE0                 | 0x22            |
	| HelloWorld_VS_4.exe              | 0x14C       | 3                | 0x0                  | 0               | 0xE0                 | 0x22            |
	| HelloWorld_VS_Core_1.0.dll       | 0x14C       | 3                | 0x0                  | 0               | 0xE0                 | 0x22            |
	| HelloWorld_Xamarin_2.0.exe       | 0x14C       | 3                | 0x0                  | 0               | 0xE0                 | 0x102           |
	| HelloWorld_Xamarin_4.0.exe       | 0x14C       | 3                | 0x0                  | 0               | 0xE0                 | 0x102           |
	| HelloWorld_Xamarin_4.0Client.exe | 0x14C       | 3                | 0x0                  | 0               | 0xE0                 | 0x102           |
	| HelloWorld_Xamarin_4.5.1.exe     | 0x14C       | 3                | 0x0                  | 0               | 0xE0                 | 0x102           |
	| HelloWorld_Xamarin_4.5.2.exe     | 0x14C       | 3                | 0x0                  | 0               | 0xE0                 | 0x102           |
	| HelloWorld_Xamarin_4.5.exe       | 0x14C       | 3                | 0x0                  | 0               | 0xE0                 | 0x102           |
	| HelloWorld_Xamarin_4.6.1.exe     | 0x14C       | 3                | 0x0                  | 0               | 0xE0                 | 0x102           |
	| HelloWorld_Xamarin_4.6.exe       | 0x14C       | 3                | 0x0                  | 0               | 0xE0                 | 0x102           |