using Microsoft.Extensions.DependencyInjection;
using Actions.Core;
using Actions.Core.Extensions;
using Actions.Core.Services;

Console.WriteLine("Running Predictor");

using var provider = new ServiceCollection()
    .AddGitHubActionsCore()
    .BuildServiceProvider();

var core = provider.GetRequiredService<ICoreService>();
var issueNumbers = core.GetInput("issue-numbers");

core.StartGroup("Inputs");
core.WriteInfo($"issue-numbers: ${issueNumbers}");
core.EndGroup();
