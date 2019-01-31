// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using CommandLine;
using Microsoft.DotNet.Darc.Operations;
using System.Collections.Generic;

namespace Microsoft.DotNet.Darc.Options
{
    [Verb("update-subscription", HelpText = "Update an existing subscription.")]
    class UpdateSubscriptionCommandLineOptions : CommandLineOptions
    {
        [Option("id", Required = true, HelpText = "Subscription's id.")]
        public string Id { get; set; }

        [Option("channel", HelpText = "Name of channel to pull from.")]
        public string Channel { get; set; }

        [Option("source-repo", HelpText = "Source repository for the subscription.")]
        public string SourceRepository { get; set; }

        [Option("batchable", HelpText = "Whether the subscription is batchable or not.")]
        public bool Batchable { get; set; }

        [Option("update-frequency", HelpText = "Frequency of updates. Valid values are: 'none', 'everyDay', or 'everyBuild'.")]
        public string UpdateFrequency { get; set; }

        [Option("all-checks-passed", HelpText = "PR is automatically merged if there is at least one checks and all are passed. " +
            "Optionally provide a comma separated list of ignored check with --ignore-checks.")]
        public bool AllChecksSuccessfulMergePolicy { get; set; }

        [Option("ignore-checks", Separator = ',', HelpText = "For use with --all-checks-passed. A set of checks that are ignored.")]
        public IEnumerable<string> IgnoreChecks { get; set; }

        [Option("no-extra-commits", HelpText = "PR is automatically merged if no non-bot commits exist in the PR.")]
        public bool NoExtraCommitsMergePolicy { get; set; }

        [Option("require-checks", Separator = ',', HelpText = "PR is automatically merged if the specified checks are passed. " +
            "Provide a comma separate list of required checks.")]
        public IEnumerable<string> RequireChecksMergePolicy { get; set; }

        [Option("enabled", HelpText = "Whether the subscription is enabled or not.")]
        public bool Enabled { get; set; }

        [Option('q', "quiet", HelpText = "Non-interactive mode (requires all elements to be passed on the command line).")]
        public bool Quiet { get; set; }

        public override Operation GetOperation()
        {
            return new UpdateSubscriptionOperation(this);
        }
    }
}
