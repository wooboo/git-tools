using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace git_start
{
    class Program
    {
        static void Main(string[] args)
        {
            var prefix = Environment.GetEnvironmentVariable("GITTOOLS_TASK_BRANCH_PREFIX");
            string task = null;
            string title = null;
            if (args.Length > 0)
            {
                task = args[0];
            }
            Console.Write($"Provide task number [{task}]: ");
            var providedTask = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(providedTask))
            {
                providedTask = task;
            }

            var otherArgs = string.Join(' ', args);

            if (!string.IsNullOrWhiteSpace(task))
            {
                otherArgs = string.Join(' ', args.Skip(1));
            }
            Console.Write($"Provide task title [{otherArgs}]: ");
            var providedTitle = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(providedTitle))
            {
                providedTitle = otherArgs;
            }

            title = string.Join('-', providedTitle.Split(' ').Select(o => o.ToLower()));

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Please provide at least title");
                return;
            }
            Console.Write($"Provide branch prefix [{prefix}]: ");
            var providedPrefix = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(providedPrefix))
            {
                providedPrefix = prefix;
            }

            git_tools.GitTools.CallGit("stash");
            git_tools.GitTools.CallGit("checkout master");
            git_tools.GitTools.CallGit("pull");
            git_tools.GitTools.CallGit($"checkout -b {providedPrefix}{providedTask}-{title}");
        }
    }
}
