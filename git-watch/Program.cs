using System;
using System.IO;

namespace git_watch
{
    class Program
    {
        static void Main(string[] args)
        {

            var startBranch = git_tools.GitTools.CallGit("rev-parse --abbrev-ref HEAD");

            FileSystemWatcher watcher = new FileSystemWatcher("./");
            while (true)
            {
                var changedResult = watcher.WaitForChanged(WatcherChangeTypes.All);
                if (startBranch != git_tools.GitTools.CallGit("rev-parse --abbrev-ref HEAD"))
                {
                    Console.WriteLine("Branch changed");
                    return;
                }

                git_tools.GitTools.CallGit("add .");
                Console.WriteLine(git_tools.GitTools.CallGit("commit --amend --no-edit"));
            }

        }
    }
}
