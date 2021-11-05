using System;
using System.Diagnostics;

namespace git_pr
{
    class Program
    {
        static void Main(string[] args)
        {
            var branch = git_tools.GitTools.CallGit("rev-parse --abbrev-ref HEAD");
            var repo = git_tools.GitTools.CallGit("remote get-url origin");

            var url = $"{repo}/pullrequestcreate?sourceRef={System.Net.WebUtility.UrlEncode(branch)}&targetRef=master";
            Console.WriteLine(url);
            var ps = new ProcessStartInfo(url)
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(ps);
        }

        
    }
}
