using Bogus;
using Taller1IDWM.Src.Models;

namespace Taller1IDWM.Src.Data
{
    public class DataSeeder
    {
        static readonly List<string> GenderOptions = ["Femenino", "Masculino", "Prefiero no decirlo", "Otro"];
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<DataContext>();

                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(
                        new Role { Name = "Admin" },
                        new Role { Name = "User" }
                     );
                    context.SaveChanges();
                }

                if (!context.Categories.Any()){
                    context.Categories.AddRange(
                        new Category {Name = "Tecnología"},
                        new Category {Name = "Electrohogar"},
                        new Category {Name = "Juguetería"},
                        new Category {Name = "Ropa"},
                        new Category {Name = "Muebles"},
                        new Category {Name = "Comida"},
                        new Category {Name = "Libros"}
                    );
                }

                if (!context.Users.Any())
                {
                    var adminRole = context.Roles.FirstOrDefault(role => role.Name == "Admin");
                    Console.WriteLine(adminRole);
                    if (adminRole != null)
                    {
                        var user = new User
                        {
                            Name = "Nelson Soto",
                            Gender = "Masculino",
                            Birthdate = DateTime.Parse("May 29, 1998"),
                            Rut = "199626086",
                            Email = "nelson.soto@gmail.com",
                            Password = BCrypt.Net.BCrypt.HashPassword("password"),
                            RoleId = adminRole.Id,
                            Role = adminRole
                        };

                        context.Users.Add(user);
                    }

                    var userRole = context.Roles.FirstOrDefault(role => role.Name == "User");
                    if (userRole != null){
                        var faker = new Faker<User>()
                        .RuleFor(u => u.Name, f => f.Person.FullName)
                        .RuleFor(u => u.Gender, f => f.PickRandom(GenderOptions))
                        .RuleFor(u => u.Birthdate, f => f.Date.PastOffset(60, DateTime.Now.AddYears(-18)).Date)
                        .RuleFor(u => u.Rut, f => f.Random.ReplaceNumbers("#########"))
                        .RuleFor(u => u.Email, f => f.Internet.Email())
                        .RuleFor(u => u.Password, f => BCrypt.Net.BCrypt.HashPassword("password"))
                        .RuleFor(u => u.RoleId, f => userRole.Id)
                        .RuleFor(u => u.Role, f => userRole)
                        .RuleFor(u => u.IsEnabled, f => 1);

                        var users = faker.Generate(10);
                        foreach (User user in users){
                            if (false == context.Users.Any(x => x.Rut == user.Rut || x.Email == user.Email)){
                                context.Users.AddRange(user);
                                context.SaveChanges();                                
                            }
                        }
                    }
                }
            }
        }
    }
}