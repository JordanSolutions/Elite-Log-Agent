using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteLogAgent.DevTool
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
                Environment.Exit(1);
            switch(args[0])
            {
                case "canonn":
                    CanonnApiGenerator.Regenerate("https://api.canonn.tech/openapi.yaml", "../../../DW.ELA.Plugin.Canonn/ApiClient").Wait();
                    break;
                case "merge-events":
                    MergedEventsGenerator.Generate("USSDrop");
                    break;
            }
            Environment.Exit(0);
        }
    }
}
