using System;
using TranslationManagement.Domain.Models;

namespace TranslationManagement.Infrastructure.Validators
{
    public static class StatusChangeValidator
    {
        public static bool IsStatusChangeValid(JobStatuses oldJobStatus, JobStatuses newJobStatus)
        {
            if (oldJobStatus == JobStatuses.New && newJobStatus == JobStatuses.Completed)
            {
                return false;
            }

            if (oldJobStatus == JobStatuses.Completed && newJobStatus == JobStatuses.New)
            {
                return false;
            }

            return true;
        }
    }
}
