using Build.Modules;
using Build.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularPipelines;
using ModularPipelines.Extensions;

var builder = Pipeline.CreateBuilder();

builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddUserSecrets<Program>();
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddOptions<PublishOptions>().Bind(builder.Configuration.GetSection("Publish"));

if (args.Contains("compile"))
{
    builder.Services.AddModule<CompileProjectModule>();
}

if (args.Contains("publish"))
{
    builder.Services.AddModule<PublishGithubModule>();
}

await builder.Build().RunAsync();