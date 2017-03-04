Feature: OptionalHeaderDataDirectories
	In order to dissect a PECOFF binary file
	As an interested party
	I want to read the OptionalHeaderDataDirectories from the file
	And I want to see the component parts

Scenario Outline: Read the OptionalHeaderDataDirectories from a given PECOFF binary file
	Given a PECOFF binary file named <File Name>
	When I read in the MSDOS20Section
	And I read in the COFFOptionalHeaderStandardFields
	And I read in the OptionalHeaderDataDirectories
	Then the ExportTable shoud be <ExportTable>
	And the ImportTable shoud be <ImportTable>
	And the ResourceTable shoud be <ResourceTable>
	And the ExceptionTable shoud be <ExceptionTable>
	And the CertificateTable shoud be <CertificateTable>
	And the BaseRelocationTable shoud be <BaseRelocationTable>
	And the Debug shoud be <Debug>
	And the Architecture shoud be <Architecture>
	And the GlobalPtr shoud be <GlobalPtr>
	And the TLSTable shoud be <TLSTable>
	And the LoadConfigTable shoud be <LoadConfigTable>
	And the BoundImport shoud be <BoundImport>
	And the IAT shoud be <IAT>
	And the DelayImportDescriptor shoud be <DelayImportDescriptor>
	And the CLRRuntimeHeader shoud be <CLRRuntimeHeader>
	And the Reserved shoud be <Reserved>
	And the IAT Address should be <IAT Address>
	And the IAT Count should be <IAT Count>
	And the CLR Runtime Header Address should be <CLR Runtime Header Address>
	And the CLR Runtime Header Size should be <CLR Runtime Header Size>

Examples: 
	| File Name                        | ExportTable | ImportTable  | ResourceTable | ExceptionTable | CertificateTable | BaseRelocationTable | Debug        | Architecture | GlobalPtr | TLSTable | LoadConfigTable | BoundImport | IAT         | DelayImportDescriptor | CLRRuntimeHeader | Reserved | IAT Address | IAT Count | CLR Runtime Header Address | CLR Runtime Header Size |
	| HelloWorld_CSC_2.0.exe           | 0x0         | 0x4F0000235C | 0x2D000004000 | 0x0            | 0x0              | 0xC00006000         | 0x0          | 0x0          | 0x0       | 0x0      | 0x0             | 0x0         | 0x800002000 | 0x0                   | 0x4800002008     | 0x0      | 0x00002000  | 0x8       | 0x2008                     | 0x48                    |
	| HelloWorld_CSC_3.5.exe           | 0x0         | 0x4F0000235C | 0x50800004000 | 0x0            | 0x0              | 0xC00006000         | 0x0          | 0x0          | 0x0       | 0x0      | 0x0             | 0x0         | 0x800002000 | 0x0                   | 0x4800002008     | 0x0      | 0x00002000  | 0x8       | 0x2008                     | 0x48                    |
	| HelloWorld_CSC_4.0.exe           | 0x0         | 0x4F0000235C | 0x50800004000 | 0x0            | 0x0              | 0xC00006000         | 0x0          | 0x0          | 0x0       | 0x0      | 0x0             | 0x0         | 0x800002000 | 0x0                   | 0x4800002008     | 0x0      | 0x00002000  | 0x8       | 0x2008                     | 0x48                    |
	| HelloWorld_VS_2.0.exe            | 0x0         | 0x4F00002758 | 0x61000004000 | 0x0            | 0x0              | 0xC00006000         | 0x1C00002620 | 0x0          | 0x0       | 0x0      | 0x0             | 0x0         | 0x800002000 | 0x0                   | 0x4800002008     | 0x0      | 0x00002000  | 0x8       | 0x2008                     | 0x48                    |
	| HelloWorld_VS_3.0.exe            | 0x0         | 0x4F00002754 | 0x60800004000 | 0x0            | 0x0              | 0xC00006000         | 0x1C0000261C | 0x0          | 0x0       | 0x0      | 0x0             | 0x0         | 0x800002000 | 0x0                   | 0x4800002008     | 0x0      | 0x00002000  | 0x8       | 0x2008                     | 0x48                    |
	| HelloWorld_VS_3.5.exe            | 0x0         | 0x4F00002754 | 0x60800004000 | 0x0            | 0x0              | 0xC00006000         | 0x1C0000261C | 0x0          | 0x0       | 0x0      | 0x0             | 0x0         | 0x800002000 | 0x0                   | 0x4800002008     | 0x0      | 0x00002000  | 0x8       | 0x2008                     | 0x48                    |
	| HelloWorld_VS_4.5.1.exe          | 0x0         | 0x4F000027EC | 0x61800004000 | 0x0            | 0x0              | 0xC00006000         | 0x1C000026B4 | 0x0          | 0x0       | 0x0      | 0x0             | 0x0         | 0x800002000 | 0x0                   | 0x4800002008     | 0x0      | 0x00002000  | 0x8       | 0x2008                     | 0x48                    |
	| HelloWorld_VS_4.5.2.exe          | 0x0         | 0x4F000027EC | 0x61800004000 | 0x0            | 0x0              | 0xC00006000         | 0x1C000026B4 | 0x0          | 0x0       | 0x0      | 0x0             | 0x0         | 0x800002000 | 0x0                   | 0x4800002008     | 0x0      | 0x00002000  | 0x8       | 0x2008                     | 0x48                    |
	| HelloWorld_VS_4.5.exe            | 0x0         | 0x4F000027E0 | 0x60800004000 | 0x0            | 0x0              | 0xC00006000         | 0x1C000026A8 | 0x0          | 0x0       | 0x0      | 0x0             | 0x0         | 0x800002000 | 0x0                   | 0x4800002008     | 0x0      | 0x00002000  | 0x8       | 0x2008                     | 0x48                    |
	| HelloWorld_VS_4.6.1.exe          | 0x0         | 0x4F000027EC | 0x61800004000 | 0x0            | 0x0              | 0xC00006000         | 0x1C000026B4 | 0x0          | 0x0       | 0x0      | 0x0             | 0x0         | 0x800002000 | 0x0                   | 0x4800002008     | 0x0      | 0x00002000  | 0x8       | 0x2008                     | 0x48                    |
	| HelloWorld_VS_4.6.2.exe          | 0x0         | 0x4F000027D8 | 0x5FC00004000 | 0x0            | 0x0              | 0xC00006000         | 0x1C000026A0 | 0x0          | 0x0       | 0x0      | 0x0             | 0x0         | 0x800002000 | 0x0                   | 0x4800002008     | 0x0      | 0x00002000  | 0x8       | 0x2008                     | 0x48                    |
	| HelloWorld_VS_4.6.exe            | 0x0         | 0x4F000027E0 | 0x60800004000 | 0x0            | 0x0              | 0xC00006000         | 0x1C000026A8 | 0x0          | 0x0       | 0x0      | 0x0             | 0x0         | 0x800002000 | 0x0                   | 0x4800002008     | 0x0      | 0x00002000  | 0x8       | 0x2008                     | 0x48                    |
	| HelloWorld_VS_4.exe              | 0x0         | 0x4F000027D8 | 0x5F800004000 | 0x0            | 0x0              | 0xC00006000         | 0x1C000026A0 | 0x0          | 0x0       | 0x0      | 0x0             | 0x0         | 0x800002000 | 0x0                   | 0x4800002008     | 0x0      | 0x00002000  | 0x8       | 0x2008                     | 0x48                    |
	| HelloWorld_VS_Core_1.0.dll       | 0x0         | 0x4F000027A8 | 0x5B000004000 | 0x0            | 0x0              | 0xC00006000         | 0x1C00002670 | 0x0          | 0x0       | 0x0      | 0x0             | 0x0         | 0x800002000 | 0x0                   | 0x4800002008     | 0x0      | 0x00002000  | 0x8       | 0x2008                     | 0x48                    |
	| HelloWorld_Xamarin_2.0.exe       | 0x0         | 0x4B000024B0 | 0x38400004000 | 0x0            | 0x0              | 0xC00006000         | 0x0          | 0x0          | 0x0       | 0x0      | 0x0             | 0x0         | 0x800002000 | 0x0                   | 0x4800002008     | 0x0      | 0x00002000  | 0x8       | 0x2008                     | 0x48                    |
	| HelloWorld_Xamarin_4.0.exe       | 0x0         | 0x4B00002530 | 0x38400004000 | 0x0            | 0x0              | 0xC00006000         | 0x0          | 0x0          | 0x0       | 0x0      | 0x0             | 0x0         | 0x800002000 | 0x0                   | 0x4800002008     | 0x0      | 0x00002000  | 0x8       | 0x2008                     | 0x48                    |
	| HelloWorld_Xamarin_4.0Client.exe | 0x0         | 0x4B00002560 | 0x3A800004000 | 0x0            | 0x0              | 0xC00006000         | 0x0          | 0x0          | 0x0       | 0x0      | 0x0             | 0x0         | 0x800002000 | 0x0                   | 0x4800002008     | 0x0      | 0x00002000  | 0x8       | 0x2008                     | 0x48                    |
	| HelloWorld_Xamarin_4.5.1.exe     | 0x0         | 0x4B00002540 | 0x39000004000 | 0x0            | 0x0              | 0xC00006000         | 0x0          | 0x0          | 0x0       | 0x0      | 0x0             | 0x0         | 0x800002000 | 0x0                   | 0x4800002008     | 0x0      | 0x00002000  | 0x8       | 0x2008                     | 0x48                    |
	| HelloWorld_Xamarin_4.5.2.exe     | 0x0         | 0x4B00002540 | 0x39000004000 | 0x0            | 0x0              | 0xC00006000         | 0x0          | 0x0          | 0x0       | 0x0      | 0x0             | 0x0         | 0x800002000 | 0x0                   | 0x4800002008     | 0x0      | 0x00002000  | 0x8       | 0x2008                     | 0x48                    |
	| HelloWorld_Xamarin_4.5.exe       | 0x0         | 0x4B00002530 | 0x38400004000 | 0x0            | 0x0              | 0xC00006000         | 0x0          | 0x0          | 0x0       | 0x0      | 0x0             | 0x0         | 0x800002000 | 0x0                   | 0x4800002008     | 0x0      | 0x00002000  | 0x8       | 0x2008                     | 0x48                    |
	| HelloWorld_Xamarin_4.6.1.exe     | 0x0         | 0x4B00002540 | 0x39000004000 | 0x0            | 0x0              | 0xC00006000         | 0x0          | 0x0          | 0x0       | 0x0      | 0x0             | 0x0         | 0x800002000 | 0x0                   | 0x4800002008     | 0x0      | 0x00002000  | 0x8       | 0x2008                     | 0x48                    |
	| HelloWorld_Xamarin_4.6.exe       | 0x0         | 0x4B00002530 | 0x38400004000 | 0x0            | 0x0              | 0xC00006000         | 0x0          | 0x0          | 0x0       | 0x0      | 0x0             | 0x0         | 0x800002000 | 0x0                   | 0x4800002008     | 0x0      | 0x00002000  | 0x8       | 0x2008                     | 0x48                    |
