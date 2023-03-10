
using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;

namespace RestWithASPNET.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private MySQLContext _context;

        public PersonRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.FirstOrDefault(p => p.Id.Equals(id));
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Persons.Add(person);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw;
            }
            return person;
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();
            try
            {
                var result = FindById(person.Id);
                if (result != null)
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = FindById(id);
            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        private bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }

    }
}
