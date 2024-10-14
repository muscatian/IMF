using System.Threading.Tasks;

namespace IMF.DAL.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICompanyRepository Company { get; }
        void Save();
        Task SaveChangesAsync();
    }
}
