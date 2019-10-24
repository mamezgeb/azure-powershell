﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Batch.Properties;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzurePrefix + "BatchJobSchedule", SupportsShouldProcess = true), OutputType(typeof(void))]
    public class RemoveBatchJobScheduleCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The id of the job schedule to delete.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter]
        public SwitchParameter Force { get; set; }

        protected override void ExecuteCmdletImpl()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemoveJobScheduleConfirm, this.Id),
                Resources.RemoveJobSchedule,
                this.Id,
                () => BatchClient.DeleteJobSchedule(this.BatchContext, this.Id, this.AdditionalBehaviors));
        }
    }
}
