using System;
using System.Collections.Generic;
using RazorLight;
using ShitConsoleApp.TemplateModels;

namespace ShitConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseDir = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin", StringComparison.Ordinal));

            var engine = new RazorLightEngineBuilder()
                .UseFilesystemProject(dir)
                .UseMemoryCachingProvider()
                .Build();

            var result = engine.CompileRenderAsync("Templates/EntityTemplate.cshtml", new Entity("TestNamespace",
                "TestClass", KeyType.Long, new List<Property>()
                {
                    new Property("Prop1", "int")
                }));
            Console.WriteLine(result);
        }
    }
}
