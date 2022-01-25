using HM4.BackgroundJobs.JobManagers;
using Microsoft.AspNetCore.Mvc;

namespace HM4.BackgroundJobs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserJobController : ControllerBase
    {
        // Bu Api projesini oluşturarak, job ekleme-silme işlemlerini bu uygulama üzerinden yönetmek istedim.

        // Burda her 15 dakikalık insert atma job'ını kaydediyorum.
        [HttpPost("AddUser")]
        public IActionResult RegisterAddUserJob()
        {
            UserRecurringJobManager.AddUsersEveryFifteenMinutes();
            return Ok();
        }

        // Burda da günlük update job'ını kaydediyorum.
        [HttpPost("UpdateUsers")]
        public IActionResult RegisterUpdateUsersJob()
        {
            UserRecurringJobManager.UpdateUserStatusDaily();
            return Ok();
        }

        // Burda da gelen job id mevcut ise o job id'ye bağlı job'ı silmiş oluyorum.
        [HttpDelete]
        public IActionResult RemoveJob(string jobId)
        {
            UserRecurringJobManager.RemoveJob(jobId);
            return Ok();
        }
    }
}
