Feature: SectionTables
	In order to dissect a PECOFF binary file
	As an interested party
	I want to read the OptionalHeaderDataDirectories from the file
	And I want to see the component parts

Scenario Outline: Read the SectionTables from a given PECOFF binary file and check the number and types
	Given a PECOFF binary file named <File Name>
	When I read in the MSDOS20Section
	And I read in the COFFHeader
	And I read in the COFFOptionalHeaderStandardFields
	And I read the SectionTables
	Then there will be <number of tables> entries
	And they will contain <types of tables>
	And the order will of the tables will be <order of tables>

Examples: 
	| File Name                        | number of tables | types of tables    | order of tables    |
	| HelloWorld_CSC_2.0.exe           | 3                | .text,.rsrc,.reloc | .text,.rsrc,.reloc |
	| HelloWorld_CSC_3.5.exe           | 3                | .text,.rsrc,.reloc | .text,.rsrc,.reloc |
	| HelloWorld_CSC_4.0.exe           | 3                | .text,.rsrc,.reloc | .text,.rsrc,.reloc |
	| HelloWorld_VS_2.0.exe            | 3                | .text,.rsrc,.reloc | .text,.rsrc,.reloc |
	| HelloWorld_VS_3.0.exe            | 3                | .text,.rsrc,.reloc | .text,.rsrc,.reloc |
	| HelloWorld_VS_3.5.exe            | 3                | .text,.rsrc,.reloc | .text,.rsrc,.reloc |
	| HelloWorld_VS_4.5.1.exe          | 3                | .text,.rsrc,.reloc | .text,.rsrc,.reloc |
	| HelloWorld_VS_4.5.2.exe          | 3                | .text,.rsrc,.reloc | .text,.rsrc,.reloc |
	| HelloWorld_VS_4.5.exe            | 3                | .text,.rsrc,.reloc | .text,.rsrc,.reloc |
	| HelloWorld_VS_4.6.1.exe          | 3                | .text,.rsrc,.reloc | .text,.rsrc,.reloc |
	| HelloWorld_VS_4.6.2.exe          | 3                | .text,.rsrc,.reloc | .text,.rsrc,.reloc |
	| HelloWorld_VS_4.6.exe            | 3                | .text,.rsrc,.reloc | .text,.rsrc,.reloc |
	| HelloWorld_VS_4.exe              | 3                | .text,.rsrc,.reloc | .text,.rsrc,.reloc |
	| HelloWorld_VS_Core_1.0.dll       | 3                | .text,.rsrc,.reloc | .text,.rsrc,.reloc |
	| HelloWorld_Xamarin_2.0.exe       | 3                | .text,.rsrc,.reloc | .text,.rsrc,.reloc |
	| HelloWorld_Xamarin_4.0.exe       | 3                | .text,.rsrc,.reloc | .text,.rsrc,.reloc |
	| HelloWorld_Xamarin_4.0Client.exe | 3                | .text,.rsrc,.reloc | .text,.rsrc,.reloc |
	| HelloWorld_Xamarin_4.5.1.exe     | 3                | .text,.rsrc,.reloc | .text,.rsrc,.reloc |
	| HelloWorld_Xamarin_4.5.2.exe     | 3                | .text,.rsrc,.reloc | .text,.rsrc,.reloc |
	| HelloWorld_Xamarin_4.5.exe       | 3                | .text,.rsrc,.reloc | .text,.rsrc,.reloc |
	| HelloWorld_Xamarin_4.6.1.exe     | 3                | .text,.rsrc,.reloc | .text,.rsrc,.reloc |
	| HelloWorld_Xamarin_4.6.exe       | 3                | .text,.rsrc,.reloc | .text,.rsrc,.reloc |


Scenario Outline: Read the SectionTables from a given PECOFF binary file and check the content
	Given a PECOFF binary file named <File Name>
	When I read in the MSDOS20Section
	And I read in the COFFHeader
	And I read in the COFFOptionalHeaderStandardFields
	And I read the SectionTables
	And there is a table with name <Name> 
	Then it's VirtualSize will be <VirtualSize>
	And it's VirtualAddress will be <VirtualAddress>
	And it's SizeOfRawData will be <SizeOfRawData>
	And it's PointerToRawData will be <PointerToRawData>
	And it's PointerToRelocations will be <PointerToRelocations>
	And it's PointerToLinenumbers will be <PointerToLinenumbers>
	And it's NumberOfRelocations will be <NumberOfRelocations>
	And it's NumberOfLinenumbers will be <NumberOfLinenumbers>
	And it's Characteristics will be <Characteristics>

Examples: 
	| File Name                        | Name   | VirtualSize | VirtualAddress | SizeOfRawData | PointerToRawData | PointerToRelocations | PointerToLinenumbers | NumberOfRelocations | NumberOfLinenumbers | Characteristics |
	| HelloWorld_CSC_2.0.exe           | .text  | 0x3B4       | 0x2000         | 0x400         | 0x200            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x60000020      |
	| HelloWorld_CSC_2.0.exe           | .rscs  | 0x0         | 0x0            | 0x0           | 0x0              | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x0             |
	| HelloWorld_CSC_2.0.exe           | .reloc | 0xC         | 0x6000         | 0x200         | 0xA00            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x42000040      |
	| HelloWorld_CSC_3.5.exe           | .text  | 0x3B4       | 0x2000         | 0x400         | 0x200            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x60000020      |
	| HelloWorld_CSC_3.5.exe           | .rscs  | 0x0         | 0x0            | 0x0           | 0x0              | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x0             |
	| HelloWorld_CSC_3.5.exe           | .reloc | 0xC         | 0x6000         | 0x200         | 0xC00            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x42000040      |
	| HelloWorld_CSC_4.0.exe           | .text  | 0x3B4       | 0x2000         | 0x400         | 0x200            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x60000020      |
	| HelloWorld_CSC_4.0.exe           | .rscs  | 0x0         | 0x0            | 0x0           | 0x0              | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x0             |
	| HelloWorld_CSC_4.0.exe           | .reloc | 0xC         | 0x6000         | 0x200         | 0xC00            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x42000040      |
	| HelloWorld_VS_2.0.exe            | .text  | 0x7B0       | 0x2000         | 0x800         | 0x200            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x60000020      |
	| HelloWorld_VS_2.0.exe            | .rscs  | 0x0         | 0x0            | 0x0           | 0x0              | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x0             |
	| HelloWorld_VS_2.0.exe            | .reloc | 0xC         | 0x6000         | 0x200         | 0x1200           | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x42000040      |
	| HelloWorld_VS_3.0.exe            | .text  | 0x7AC       | 0x2000         | 0x800         | 0x200            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x60000020      |
	| HelloWorld_VS_3.0.exe            | .rscs  | 0x0         | 0x0            | 0x0           | 0x0              | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x0             |
	| HelloWorld_VS_3.0.exe            | .reloc | 0xC         | 0x6000         | 0x200         | 0x1200           | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x42000040      |
	| HelloWorld_VS_3.5.exe            | .text  | 0x7AC       | 0x2000         | 0x800         | 0x200            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x60000020      |
	| HelloWorld_VS_3.5.exe            | .rscs  | 0x0         | 0x0            | 0x0           | 0x0              | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x0             |
	| HelloWorld_VS_3.5.exe            | .reloc | 0xC         | 0x6000         | 0x200         | 0x1200           | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x42000040      |
	| HelloWorld_VS_4.5.1.exe          | .text  | 0x844       | 0x2000         | 0xA00         | 0x200            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x60000020      |
	| HelloWorld_VS_4.5.1.exe          | .rscs  | 0x0         | 0x0            | 0x0           | 0x0              | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x0             |
	| HelloWorld_VS_4.5.1.exe          | .reloc | 0xC         | 0x6000         | 0x200         | 0x1400           | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x42000040      |
	| HelloWorld_VS_4.5.2.exe          | .text  | 0x844       | 0x2000         | 0xA00         | 0x200            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x60000020      |
	| HelloWorld_VS_4.5.2.exe          | .rscs  | 0x0         | 0x0            | 0x0           | 0x0              | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x0             |
	| HelloWorld_VS_4.5.2.exe          | .reloc | 0xC         | 0x6000         | 0x200         | 0x1400           | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x42000040      |
	| HelloWorld_VS_4.5.exe            | .text  | 0x838       | 0x2000         | 0xA00         | 0x200            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x60000020      |
	| HelloWorld_VS_4.5.exe            | .rscs  | 0x0         | 0x0            | 0x0           | 0x0              | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x0             |
	| HelloWorld_VS_4.5.exe            | .reloc | 0xC         | 0x6000         | 0x200         | 0x1400           | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x42000040      |
	| HelloWorld_VS_4.6.1.exe          | .text  | 0x844       | 0x2000         | 0xA00         | 0x200            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x60000020      |
	| HelloWorld_VS_4.6.1.exe          | .rscs  | 0x0         | 0x0            | 0x0           | 0x0              | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x0             |
	| HelloWorld_VS_4.6.1.exe          | .reloc | 0xC         | 0x6000         | 0x200         | 0x1400           | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x42000040      |
	| HelloWorld_VS_4.6.2.exe          | .text  | 0x830       | 0x2000         | 0xA00         | 0x200            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x60000020      |
	| HelloWorld_VS_4.6.2.exe          | .rscs  | 0x0         | 0x0            | 0x0           | 0x0              | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x0             |
	| HelloWorld_VS_4.6.2.exe          | .reloc | 0xC         | 0x6000         | 0x200         | 0x1200           | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x42000040      |
	| HelloWorld_VS_4.6.exe            | .text  | 0x838       | 0x2000         | 0xA00         | 0x200            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x60000020      |
	| HelloWorld_VS_4.6.exe            | .rscs  | 0x0         | 0x0            | 0x0           | 0x0              | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x0             |
	| HelloWorld_VS_4.6.exe            | .reloc | 0xC         | 0x6000         | 0x200         | 0x1400           | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x42000040      |
	| HelloWorld_VS_4.exe              | .text  | 0x830       | 0x2000         | 0xA00         | 0x200            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x60000020      |
	| HelloWorld_VS_4.exe              | .rscs  | 0x0         | 0x0            | 0x0           | 0x0              | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x0             |
	| HelloWorld_VS_4.exe              | .reloc | 0xC         | 0x6000         | 0x200         | 0x1200           | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x42000040      |
	| HelloWorld_VS_Core_1.0.dll       | .text  | 0x800       | 0x2000         | 0x800         | 0x200            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x60000020      |
	| HelloWorld_VS_Core_1.0.dll       | .rscs  | 0x0         | 0x0            | 0x0           | 0x0              | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x0             |
	| HelloWorld_VS_Core_1.0.dll       | .reloc | 0xC         | 0x6000         | 0x200         | 0x1000           | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x42000040      |
	| HelloWorld_Xamarin_2.0.exe       | .text  | 0x504       | 0x2000         | 0x600         | 0x200            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x60000020      |
	| HelloWorld_Xamarin_2.0.exe       | .rscs  | 0x0         | 0x0            | 0x0           | 0x0              | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x0             |
	| HelloWorld_Xamarin_2.0.exe       | .reloc | 0xC         | 0x6000         | 0x200         | 0xC00            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x42000040      |
	| HelloWorld_Xamarin_4.0.exe       | .text  | 0x584       | 0x2000         | 0x600         | 0x200            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x60000020      |
	| HelloWorld_Xamarin_4.0.exe       | .rscs  | 0x0         | 0x0            | 0x0           | 0x0              | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x0             |
	| HelloWorld_Xamarin_4.0.exe       | .reloc | 0xC         | 0x6000         | 0x200         | 0xC00            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x42000040      |
	| HelloWorld_Xamarin_4.0Client.exe | .text  | 0x5B4       | 0x2000         | 0x600         | 0x200            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x60000020      |
	| HelloWorld_Xamarin_4.0Client.exe | .rscs  | 0x0         | 0x0            | 0x0           | 0x0              | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x0             |
	| HelloWorld_Xamarin_4.0Client.exe | .reloc | 0xC         | 0x6000         | 0x200         | 0xC00            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x42000040      |
	| HelloWorld_Xamarin_4.5.1.exe     | .text  | 0x594       | 0x2000         | 0x600         | 0x200            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x60000020      |
	| HelloWorld_Xamarin_4.5.1.exe     | .rscs  | 0x0         | 0x0            | 0x0           | 0x0              | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x0             |
	| HelloWorld_Xamarin_4.5.1.exe     | .reloc | 0xC         | 0x6000         | 0x200         | 0xC00            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x42000040      |
	| HelloWorld_Xamarin_4.5.2.exe     | .text  | 0x594       | 0x2000         | 0x600         | 0x200            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x60000020      |
	| HelloWorld_Xamarin_4.5.2.exe     | .rscs  | 0x0         | 0x0            | 0x0           | 0x0              | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x0             |
	| HelloWorld_Xamarin_4.5.2.exe     | .reloc | 0xC         | 0x6000         | 0x200         | 0xC00            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x42000040      |
	| HelloWorld_Xamarin_4.5.exe       | .text  | 0x584       | 0x2000         | 0x600         | 0x200            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x60000020      |
	| HelloWorld_Xamarin_4.5.exe       | .rscs  | 0x0         | 0x0            | 0x0           | 0x0              | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x0             |
	| HelloWorld_Xamarin_4.5.exe       | .reloc | 0xC         | 0x6000         | 0x200         | 0xC00            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x42000040      |
	| HelloWorld_Xamarin_4.6.1.exe     | .text  | 0x594       | 0x2000         | 0x600         | 0x200            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x60000020      |
	| HelloWorld_Xamarin_4.6.1.exe     | .rscs  | 0x0         | 0x0            | 0x0           | 0x0              | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x0             |
	| HelloWorld_Xamarin_4.6.1.exe     | .reloc | 0xC         | 0x6000         | 0x200         | 0xC00            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x42000040      |
	| HelloWorld_Xamarin_4.6.exe       | .text  | 0x584       | 0x2000         | 0x600         | 0x200            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x60000020      |
	| HelloWorld_Xamarin_4.6.exe       | .rscs  | 0x0         | 0x0            | 0x0           | 0x0              | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x0             |
	| HelloWorld_Xamarin_4.6.exe       | .reloc | 0xC         | 0x6000         | 0x200         | 0xC00            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x42000040      |
