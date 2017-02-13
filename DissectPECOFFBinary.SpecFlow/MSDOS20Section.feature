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
	| File Name              | Signature | OffsetToPEHeader |
	| HelloWorld_CSC_2.0.exe | MZ&#144;  | 0x80             |