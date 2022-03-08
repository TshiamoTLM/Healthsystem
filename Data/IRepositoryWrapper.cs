using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace healthsystem.Data
{
    public interface IRepositoryWrapper
    {
        public IPatientRepository Patient { get; }
        public IHealthWorkerRepository HealthWorker { get; }
        public IPatientTypeRepository PatientType { get; }
        public IHistoryRepository History { get; }
        public IConsultationRepository Consultation { get; }
        public IWorkerTypeRepository WorkerType { get; }
        public IReminderRepository Reminder { get; }
        public INewsFeedRepository NewsFeed { get; }
        public IAppUserRepository AppUser { get; }


    }
}
