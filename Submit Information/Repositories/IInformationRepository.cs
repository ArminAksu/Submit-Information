using Submit_Information.Entity;

namespace Submit_Information.Repositories
{
    public interface IInformationRepository
    {
        Information  GetInformationById(int id);
        Information GetInformationByNationalCode(string nationalCode);
    }
}
