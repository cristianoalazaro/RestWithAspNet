using RestWithASPNET.Data.VO;

namespace RestWithASPNET.Services
{
    public interface IPersonService
    {
        List<PersonVO> FindAll();
        PersonVO FindById(long id);
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}
