using RestWithASPNET.Model;

namespace RestWithASPNET.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        public PersonServiceImplementation()
        {
            
        }

        public List<Person> FindAll()
        {
            throw new NotImplementedException();
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Cristiano",
                LastName = "Ap Lázaro",
                Address = "Rua José de Matos, 79 - Vale Verde - Bernardino de Campos - SP",
                Gender = "Male"
            };
        }

        public Person Create(Person person)
        {
            return person;
        }

        public Person Update(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }
    }
}
