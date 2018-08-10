var target = Argument ("Target", "Default");
var configuration = Argument ("Configuration", "Release");
var distDirectory = Directory ("./dist");

// Publish the app to the /dist folder
Task ("PublishWeb")
    .Does (() => {
        DotNetCorePublish (
            "./src/BetAppUltra.csproj",
            new DotNetCorePublishSettings () {
                Configuration = configuration,
                    OutputDirectory = distDirectory,
                    ArgumentCustomization = args => args.Append ("--no-restore"),
            });
    });

Task ("Default")
    .IsDependentOn ("Build")
    .IsDependentOn ("PublishWeb");

// Executes the task specified in the target argument.
RunTarget (target);