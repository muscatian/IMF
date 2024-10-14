using IMF.DAL.Models.Common;

namespace IMF.DAL.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company obj);
    }
}
