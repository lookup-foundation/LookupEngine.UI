using Build.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularPipelines;
using ModularPipelines.Extensions;

var builder = Pipeline.CreateBuilder();

builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddUserSecrets<Program>();
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddOptions<PublishOptions>().Bind(builder.Configuration.GetSection("Publish")).ValidateDataAnnotations();
builder.Services.AddModulesFromAssemblyContainingType<Program>();

builder.Options.RunOnlyCategories = args.Length == 0 ? ["compile"] : args;

await builder.Build().RunAsync();