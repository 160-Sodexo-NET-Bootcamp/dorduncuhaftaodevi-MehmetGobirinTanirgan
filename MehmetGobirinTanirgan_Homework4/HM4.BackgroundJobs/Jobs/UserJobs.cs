using HM4.Core.DataAccess.Uow;
using HM4.Entities.DataModels;
using HM4.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HM4.BackgroundJobs.Jobs
{
    public class UserJobs
    {
        private readonly IUnitOfWork unitOfWork;

        public UserJobs(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // 15 dakikada bir insert atma job'ı için yazdığım method. Rastgele isim, soyisim oluşturarak tabloya kayıt atacak.
        public async Task AddUserAsync()
        {
            var newUser = new User()
            {
                Firstname = $"{StringGenerator(7)}",
                Lastname = $"{StringGenerator(8)}",
                CreatedDate = DateTime.Now,
                Status = Status.Passive
            };
            unitOfWork.Users.Add(newUser);
            await unitOfWork.SaveAsync();
        }

        // Burda da tablodaki kayıtlardan oluşturulma tarihi bugün olanların status durumlarını güncelliyorum.
        public async Task UpdateStatusOfUsers()
        {
            var newUsersOfCurrentDay = await unitOfWork.Users
                .GetListByExp(x => x.CreatedDate.Date == DateTime.Today.Date)
                .ToListAsync();
            newUsersOfCurrentDay.ForEach(x => x.Status = Status.Active);
            unitOfWork.Users.UpdateRange(newUsersOfCurrentDay);
            await unitOfWork.SaveAsync();
        }

        // Rastgele string üretimi.
        private static string StringGenerator(int length)
        {
            Random rnd = new();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }

    }
}
