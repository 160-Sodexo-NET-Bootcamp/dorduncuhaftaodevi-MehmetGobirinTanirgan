using Hangfire;
using HM4.BackgroundJobs.Jobs;
using System;

namespace HM4.BackgroundJobs.JobManagers
{
    // Burda ilgili jobları Hangfire'a kaydetme/silme işlemlerini yürütüyorum.
    public static class UserRecurringJobManager
    {
        // 15 dakikada bir insert atma işi.
        public static void AddUsersEveryFifteenMinutes()
        {
            RecurringJob.AddOrUpdate<UserJobs>("add-user-job", job => job.AddUserAsync(), "*/15 * * * *", TimeZoneInfo.Local);
        }

        // Günlük status alanını güncelleyecek iş.
        public static void UpdateUserStatusDaily()
        {
            RecurringJob.AddOrUpdate<UserJobs>("update-users-job", job => job.UpdateStatusOfUsers(), "00 18 * * *", TimeZoneInfo.Local);
        }

        // Burda da job id'ye göre job silme işlemi ekledim.
        public static void RemoveJob(string jobId)
        {
            RecurringJob.RemoveIfExists(jobId);
        }

    }
}
