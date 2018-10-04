using NSwag;
using NSwag.CodeGeneration.CSharp;
using System;
using System.IO;
using System.Threading.Tasks;

namespace EliteLogAgent.DevTool
{
    internal static class CanonnApiGenerator
    {
        internal static async Task Regenerate(string apiUrl, string clientOutputLocation)
        {
            const string className = "CanonnApiClient";

            var document = await SwaggerYamlDocument.FromUrlAsync(apiUrl);

            var settings = new SwaggerToCSharpClientGeneratorSettings
            {
                ClassName = className,
                CSharpGeneratorSettings = { Namespace = "DW.ELA.Plugin.Canonn.ApiClient", GenerateDataAnnotations = false }
            };

            var generator = new SwaggerToCSharpClientGenerator(document, settings);
            var code = generator.GenerateFile();
            var fileName = Path.GetFullPath(Path.Combine(clientOutputLocation, className + ".cs"));
            File.WriteAllText(fileName, code);
        }
    }
}