using Microsoft.Extensions.DependencyInjection;
using Actions.Core;
using Actions.Core.Extensions;
using Actions.Core.Services;

Console.WriteLine("Running Predictor");

using var provider = new ServiceCollection()
    .AddGitHubActionsCore()
    .BuildServiceProvider();

var core = provider.GetRequiredService<ICoreService>();
var modelPath = core.GetInput("model_path");
var issueNumbers = core.GetInput("issue_numbers");

core.StartGroup("Inputs");
core.WriteInfo($"model_path: {modelPath}");
core.WriteInfo($"issue_numbers: {issueNumbers}");
core.EndGroup();

core.StartGroup("Model");
core.WriteInfo($"Exists: {System.IO.File.Exists(modelPath)}");
core.EndGroup();
