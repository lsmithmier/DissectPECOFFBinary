using CommandLine;
using CommandLine.Text;

namespace DissectPECOFFBinary
{
    internal class Options
    {
        [Option('v', "verbose", DefaultValue = true,
                  HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }

        [Option('f', "fileName", Required = true,
          HelpText = "File name of the file to dissect.")]
        public string FileName { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            ShowingHelp = true;
            return HelpText.AutoBuild(this,
              (HelpText current) =>
              HelpText.DefaultParsingErrorsHandler(this, current));
        }

        public bool ShowingHelp { get; set; }

        public Options()
        {
        }
    }
}