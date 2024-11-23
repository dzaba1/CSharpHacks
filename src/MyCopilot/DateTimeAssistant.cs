using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using System;
using System.Threading.Tasks;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace MyCopilot;

public sealed class DateTimeAssistant
{
    private static readonly Regex DateRegex = new Regex(@"(?<D>\d{2})\/(?<M>\d{2})\/(?<Y>\d{4})");

    public async Task<DateTime?> AskForDateAsync(string prompt)
    {
        var builder = Kernel.CreateBuilder();

        builder.Services.AddOpenAIChatCompletion(
            "gpt-4",
            Secrets.ApiKey
        );

        var kernel = builder.Build();

        var fullPrompt = $"Today is {DateTime.Today}. Return a next date in format dd/MM/yyyy of {prompt}. If not found then return 'N/A'. If found, return a date in dd/MM/yyyy format.";
        var chatMessages = new ChatHistory(fullPrompt);

        var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

        var result =
            chatCompletionService.GetStreamingChatMessageContentsAsync(
                chatMessages,
                executionSettings: new OpenAIPromptExecutionSettings
                {
                    ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions,
                    Temperature = 0.2
                },
                kernel: kernel);

        var respBuilder = new StringBuilder();

        await foreach (var content in result)
        {
            respBuilder.Append(content.Content);
        }

        var resp = respBuilder.ToString().Trim();

        Debug.WriteLine($"AI date: {resp}");

        if (resp.Contains("N/A"))
        {
            return null;
        }

        var match = DateRegex.Match(resp);
        var year = int.Parse(match.Groups["Y"].Value);
        var month = int.Parse(match.Groups["M"].Value);
        var day = int.Parse(match.Groups["D"].Value);

        return new DateTime(year, month, day);
    }
}