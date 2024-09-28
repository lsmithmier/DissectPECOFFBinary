Feature: COFFOptionalHeaderStandardFields
	In order to dissect a PECOFF binary file
	As an interested party
	I want to read the COFFOptionalHeaderStandardFields from the file
	And I want to see the component parts

Scenario Outline: Read the COFFOptionalHeaderStandardFields from a given PECOFF binary file
	Given a PECOFF binary file named <File Name>
	When I read in the MSDOS20Section
	And I read in the COFFOptionalHeaderStandardFields
	Then the Magic shoud be <Magic>
	And the MajorLinkerVersion should be <MajorLinkerVersion>
	And the MinorLinkerVersion should be <MinorLinkerVersion>
	And the SizeOfCode should be <SizeOfCode>
	And the SizeOfInitializedData should be <SizeOfInitializedData>
	And the SizeOfUninitializedData should be <SizeOfUninitializedData>
	And the AddressOfEntryPoint should be <AddressOfEntryPoint>
	And the BaseOfCode should be <BaseOfCode>
Examples: 
	| File Name                        | Magic | MajorLinkerVersion | MinorLinkerVersion | SizeOfCode | SizeOfInitializedData | SizeOfUninitializedData | AddressOfEntryPoint | BaseOfCode |
	| HelloWorld_CSC_2.0.exe           | 0x10B | 0x8                | 0x0                | 1024       | 1536                  | 0                       | 0x23AE              | 0x2000     |
	| HelloWorld_CSC_3.5.exe           | 0x10B | 0x8                | 0x0                | 1024       | 2048                  | 0                       | 0x23AE              | 0x2000     |
	| HelloWorld_CSC_4.0.exe           | 0x10B | 0xB                | 0x0                | 1024       | 2048                  | 0                       | 0x23AE              | 0x2000     |
	| HelloWorld_VS_2.0.exe            | 0x10B | 0x30               | 0x0                | 2048       | 2560                  | 0                       | 0x27AA              | 0x2000     |
	| HelloWorld_VS_3.0.exe            | 0x10B | 0x30               | 0x0                | 2048       | 2560                  | 0                       | 0x27A6              | 0x2000     |
	| HelloWorld_VS_3.5.exe            | 0x10B | 0x30               | 0x0                | 2048       | 2560                  | 0                       | 0x27A6              | 0x2000     |
	| HelloWorld_VS_4.5.1.exe          | 0x10B | 0x30               | 0x0                | 2560       | 2560                  | 0                       | 0x283E              | 0x2000     |
	| HelloWorld_VS_4.5.2.exe          | 0x10B | 0x30               | 0x0                | 2560       | 2560                  | 0                       | 0x283E              | 0x2000     |
	| HelloWorld_VS_4.5.exe            | 0x10B | 0x30               | 0x0                | 2560       | 2560                  | 0                       | 0x2832              | 0x2000     |
	| HelloWorld_VS_4.6.1.exe          | 0x10B | 0x30               | 0x0                | 2560       | 2560                  | 0                       | 0x283E              | 0x2000     |
	| HelloWorld_VS_4.6.2.exe          | 0x10B | 0x30               | 0x0                | 2560       | 2048                  | 0                       | 0x282A              | 0x2000     |
	| HelloWorld_VS_4.6.exe            | 0x10B | 0x30               | 0x0                | 2560       | 2560                  | 0                       | 0x2832              | 0x2000     |
	| HelloWorld_VS_4.exe              | 0x10B | 0x30               | 0x0                | 2560       | 2048                  | 0                       | 0x282A              | 0x2000     |
	| HelloWorld_VS_Core_1.0.dll       | 0x10B | 0x30               | 0x0                | 2048       | 2048                  | 0                       | 0x27FA              | 0x2000     |
	| HelloWorld_Xamarin_2.0.exe       | 0x10B | 0x8                | 0x0                | 1536       | 1536                  | 0                       | 0x24FE              | 0x2000     |
	| HelloWorld_Xamarin_4.0.exe       | 0x10B | 0x8                | 0x0                | 1536       | 1536                  | 0                       | 0x257E              | 0x2000     |
	| HelloWorld_Xamarin_4.0Client.exe | 0x10B | 0x8                | 0x0                | 1536       | 1536                  | 0                       | 0x25AE              | 0x2000     |
	| HelloWorld_Xamarin_4.5.1.exe     | 0x10B | 0x8                | 0x0                | 1536       | 1536                  | 0                       | 0x258E              | 0x2000     |
	| HelloWorld_Xamarin_4.5.2.exe     | 0x10B | 0x8                | 0x0                | 1536       | 1536                  | 0                       | 0x258E              | 0x2000     |
	| HelloWorld_Xamarin_4.5.exe       | 0x10B | 0x8                | 0x0                | 1536       | 1536                  | 0                       | 0x257E              | 0x2000     |
	| HelloWorld_Xamarin_4.6.1.exe     | 0x10B | 0x8                | 0x0                | 1536       | 1536                  | 0                       | 0x258E              | 0x2000     |
	| HelloWorld_Xamarin_4.6.exe       | 0x10B | 0x8                | 0x0                | 1536       | 1536                  | 0                       | 0x257E              | 0x2000     |
