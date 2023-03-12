using RestWithASPNET.Model.Context;

namespace RestWithASPNET.Model.Seed
{
    public class DbInitializer
    {
        public void SeedDB(MySQLContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            context.Database.EnsureCreated();
            if (!context.Persons.Any())
            {
                var persons = new Person[]
                {
                    new Person
                    {
                        FirstName = "Cristiano",
                        LastName = "Ap Lázaro",
                        Address = "Rua José de Matos, 79 - Jdim Vale Verde - B Campos SP",
                        Gender = "Male"
                    },
                    new Person
                    {
                        FirstName = "Elenice",
                        LastName = "C Lázaro",
                        Address = "Rua José de Matos, 79 - Jdim Vale Verde - B Campos SP",
                        Gender = "Female"
                    },
                    new Person
                    {
                        FirstName = "Cristiane",
                        LastName = "C Lázaro",
                        Address = "Rua José de Matos, 79 - Jdim Vale Verde - B Campos SP",
                        Gender = "Female"
                    },
                    new Person
                    {
                        FirstName = "Bruno",
                        LastName = "C Lázaro",
                        Address = "Rua José de Matos, 79 - Jdim Vale Verde - B Campos SP",
                        Gender = "Male"
                    }
                };

                foreach (var person in persons)
                    context.Persons.Add(person);

                context.SaveChanges();
            }

            if (!context.Books.Any())
            {
                var books = new Book[]
                {
                    new Book
                    {
                        Author = "Aghata Christie",
                        Launch_Date = DateTime.Parse("10/01/1931", System.Globalization.CultureInfo.InvariantCulture),
                        Title = "O caso dos dez negrinhos",
                        Price = 85.99M
                    },
                    new Book
                    {
                        Author = "Aghata Christie",
                        Launch_Date = DateTime.Parse("21/10/1946", System.Globalization.CultureInfo.InvariantCulture),
                        Title = "O assassinato no expresso do oriente",
                        Price = 77.50M
                    },
                    new Book
                    {
                        Author = "José de Alencar",
                        Launch_Date = DateTime.Parse("10/03/1977", System.Globalization.CultureInfo.InvariantCulture),
                        Title = "O guarani",
                        Price = 54.00M
                    },
                    new Book
                    {
                        Author = "Julio Verne",
                        Launch_Date = DateTime.Parse("15/01/1880", System.Globalization.CultureInfo.InvariantCulture),
                        Title = "A volta ao mundo em 80 dias",
                        Price = 60.99M
                    },
                    new Book
                    {
                        Author = "Julio Verne",
                        Launch_Date = DateTime.Parse("10/11/1976", System.Globalization.CultureInfo.InvariantCulture),
                        Title = "Vinte léguas submarinas",
                        Price = 75.00M
                    }
                };

                foreach (var book in books)
                    context.Books.Add(book);

                context.SaveChanges();
            }

        }
    }
}
