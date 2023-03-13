using Microsoft.EntityFrameworkCore;

namespace RestWithASPNET.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().HasData(
                    new Person
                    {
                        Id = 1,
                        FirstName = "Cristiano",
                        LastName = "Ap Lázaro",
                        Address = "Rua José de Matos, 79 - Jdim Vale Verde - B Campos SP",
                        Gender = "Male"
                    },
                    new Person
                    {
                        Id = 2,
                        FirstName = "Elenice",
                        LastName = "C Lázaro",
                        Address = "Rua José de Matos, 79 - Jdim Vale Verde - B Campos SP",
                        Gender = "Female"
                    },
                    new Person
                    {
                        Id = 3,
                        FirstName = "Cristiane",
                        LastName = "C Lázaro",
                        Address = "Rua José de Matos, 79 - Jdim Vale Verde - B Campos SP",
                        Gender = "Female"
                    },
                    new Person
                    {
                        Id = 4,
                        FirstName = "Bruno",
                        LastName = "C Lázaro",
                        Address = "Rua José de Matos, 79 - Jdim Vale Verde - B Campos SP",
                        Gender = "Male"
                    }
            );

            modelBuilder.Entity<Book>().HasData(
                    new Book
                    {
                        Id = 1,
                        Author = "Aghata Christie",
                        Launch_Date = DateTime.Parse("10/01/1931", System.Globalization.CultureInfo.InvariantCulture),
                        Title = "O caso dos dez negrinhos",
                        Price = 85.99M
                    },
                    new Book
                    {
                        Id = 2,
                        Author = "Aghata Christie",
                        Launch_Date = DateTime.Parse("1946-10-21", System.Globalization.CultureInfo.InvariantCulture),
                        Title = "O assassinato no expresso do oriente",
                        Price = 77.50M
                    },
                    new Book
                    {
                        Id = 3,
                        Author = "José de Alencar",
                        Launch_Date = DateTime.Parse("1977-03-10", System.Globalization.CultureInfo.InvariantCulture),
                        Title = "O guarani",
                        Price = 54.00M
                    },
                    new Book
                    {
                        Id = 4,
                        Author = "Julio Verne",
                        Launch_Date = DateTime.Parse("1880-01-15", System.Globalization.CultureInfo.InvariantCulture),
                        Title = "A volta ao mundo em 80 dias",
                        Price = 60.99M
                    },
                    new Book
                    {
                        Id = 5,
                        Author = "Julio Verne",
                        Launch_Date = DateTime.Parse("1976-11-10", System.Globalization.CultureInfo.InvariantCulture),
                        Title = "Vinte léguas submarinas",
                        Price = 75.00M
                    }
            );
        }
    }
}
