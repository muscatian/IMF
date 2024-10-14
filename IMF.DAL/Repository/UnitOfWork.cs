using IMF.DAL.Data;
using IMF.DAL.Repository.IRepository;
using System.Threading.Tasks;

namespace IMF.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICompanyRepository Company { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Company = new CompanyRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
