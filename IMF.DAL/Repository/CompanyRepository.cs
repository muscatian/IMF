using IMF.DAL.Data;
using IMF.DAL.Models.Common;
using IMF.DAL.Repository.IMF.DAL.Repository;
using IMF.DAL.Repository.IRepository;

namespace IMF.DAL.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Company obj)
        {
            _db.Company.Update(obj);
        }
    }
}
