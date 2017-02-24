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
	| File Name              | number of tables | types of tables    | order of tables    |
	| HelloWorld_CSC_2.0.exe | 3                | .text,.rsrc,.reloc | .text,.rsrc,.reloc |

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
	| File Name              | Name   | VirtualSize | VirtualAddress | SizeOfRawData | PointerToRawData | PointerToRelocations | PointerToLinenumbers | NumberOfRelocations | NumberOfLinenumbers | Characteristics |
	| HelloWorld_CSC_2.0.exe | .text  | 0x3B4       | 0x2000         | 0x400         | 0x200            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x60000020      |
	| HelloWorld_CSC_2.0.exe | .rscs  | 0x0         | 0x0            | 0x0           | 0x0              | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x0             |
	| HelloWorld_CSC_2.0.exe | .reloc | 0xC         | 0x6000         | 0x200         | 0xA00            | 0x0                  | 0x0                  | 0x0                 | 0x0                 | 0x42000040      |
