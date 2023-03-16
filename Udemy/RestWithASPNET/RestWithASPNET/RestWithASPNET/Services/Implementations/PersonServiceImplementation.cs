using RestWithASPNET.Data.Converter.Implementations;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using RestWithASPNET.Repository.Generic;
using RestWithASPNET.Utils;

namespace RestWithASPNET.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private IRepository<Person> _personRepository;
        private readonly PersonConverter _converter;

        public PersonServiceImplementation(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
            _converter = new PersonConverter();
        }

        public List<PersonVO> FindAll(ParamsPagination paramsPagination)
        {
            return _converter.Parse(_personRepository.FindAll(paramsPagination));
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_personRepository.FindById(id));
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _personRepository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _personRepository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _personRepository.Delete(id);
        }
    }
}
