using RestWithASPNET.Data.VO;
using RestWithASPNET.Utils;

namespace RestWithASPNET.Services
{
    public interface IPersonService
    {
        List<PersonVO> FindAll(ParamsPagination paramsPagination);
        PersonVO FindById(long id);
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}
