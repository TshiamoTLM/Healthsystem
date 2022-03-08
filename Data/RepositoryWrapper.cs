using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace healthsystem.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AppDbContext appDbContext;
        private IPatientRepository patient;
        private IHealthWorkerRepository healthworker;
        private IPatientTypeRepository patientType;
        private IWorkerTypeRepository workerType;
        private IHistoryRepository history;
        private IConsultationRepository consultation;
        private IAppUserRepository appuser;
        private IReminderRepository reminder;
        private INewsFeedRepository newsFeed;
        public RepositoryWrapper(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        public IAppUserRepository AppUser
        {
            get
            {
                if (appuser == null)
                {
                    appuser = new EFAppUserRepository(appDbContext);
                }

                return appuser;
            }
        }
        public IPatientRepository Patient
        {
            get
            {
                if (patient == null)
                {
                    patient = new EFPatientRepository(appDbContext);
                }

                return patient;
            }
        }

        public IHealthWorkerRepository HealthWorker
        {
            get
            {
                if (healthworker == null)
                {
                    healthworker = new EFHealthWorkerRepository(appDbContext);
                }

                return healthworker;
            }
        }

       

        public IPatientTypeRepository PatientType
        {
            get
            {
                if (patientType == null)
                {
                    patientType = new EFPatientTypeRepository(appDbContext);
                }

                return patientType;
            }
        }

        public IHistoryRepository History
        {
            get
            {
                if (history == null)
                {
                    history = new EFHistoryRepository(appDbContext);
                }

                return history;
            }
        }

        

        public IConsultationRepository Consultation
        {
            get
            {
                if (consultation == null)
                {
                    consultation = new EFConsultationRepository(appDbContext);
                }

                return consultation;
            }
        }

        public IWorkerTypeRepository WorkerType
        {
            get
            {
                if (workerType == null)
                {
                    workerType = new EFWorkerTypeRepository(appDbContext);
                }

                return workerType;
            }
        }

        public IReminderRepository Reminder
        {
            get
            {
                if (reminder == null)
                {
                    reminder = new EFReminderRepository(appDbContext);
                }

                return reminder;
            }
        }

        public INewsFeedRepository NewsFeed
        {
            get
            {
                if (newsFeed == null)
                {
                    newsFeed = new EFNewsFeedRepository(appDbContext);
                }

                return newsFeed;
            }
        }
    }
}
