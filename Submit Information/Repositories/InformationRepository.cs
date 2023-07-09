using Submit_Information.Data;
using Submit_Information.Entity;

namespace Submit_Information.Repositories
{
    public class InformationRepository : IInformationRepository
    {
        private readonly DataContext _dataContext;
        public InformationRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Information GetInformationById(int id)
        {
            return _dataContext.Informations.Find(id);
        }
        public Information GetInformationByNationalCode(string nationalCode)
        {
            return _dataContext.Informations.Where(p => p.NationalCode == nationalCode).FirstOrDefault();
        }
    }
}
