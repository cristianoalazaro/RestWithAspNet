using RestWithASPNET.Model;

namespace RestWithASPNET.Repository
{
    public interface IPersonRepository
    {
        List<Person> FindAll();
        Person FindById(long id);
        Person Create(Person person);
        Person Update(Person person);
        void Delete(long id);

    }
}
