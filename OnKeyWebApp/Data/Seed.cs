using OnKeyWebApp.Models;
using OnKeyWebApp.Data.Enum;
namespace OnKeyWebApp.Data

{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.MusicClubs.Any())
                {
                    context.MusicClubs.AddRange(new List<MusicClub>()
                    {
                        new MusicClub()
                        {
                            Title = "Running Club 1",
                            Description = "This is the description of the first cinema",
                            Genre  = Genre.HipHop,
                            Street = "67 Zapiro Street",
                            Neighbourhood = "67 Zapiro Street",
                            ProfilePicUrl = "https://mg.co.za/wp-content/uploads/2022/08/b9cb50e3-nastyc-1024x684.jpg",
                         },
                        new MusicClub()
                        {
                            Title = "Running Club 1",
                            Description = "This is the description of the first cinema",
                            Genre  = Genre.HipHop,
                            Street = "67 Zapiro Street",
                            Neighbourhood = "67 Zapiro Street",
                            ProfilePicUrl = "https://mg.co.za/wp-content/uploads/2022/08/b9cb50e3-nastyc-1024x684.jpg",
                         },
                        new MusicClub()
                        {
                            Title = "Running Club 1",
                            Description = "This is the description of the first cinema",
                            Genre  = Genre.HipHop,
                            Street = "67 Zapiro Street",
                            Neighbourhood = "67 Zapiro Street",
                            ProfilePicUrl = "https://mg.co.za/wp-content/uploads/2022/08/b9cb50e3-nastyc-1024x684.jpg",
                         },
                        new MusicClub()
                        {
                            Title = "Running Club 1",
                            Description = "This is the description of the first cinema",
                            Genre  = Genre.HipHop,
                            Street = "67 Zapiro Street",
                            Neighbourhood = "67 Zapiro Street",
                            ProfilePicUrl = "https://mg.co.za/wp-content/uploads/2022/08/b9cb50e3-nastyc-1024x684.jpg",
                         },
                    });
                    context.SaveChanges();
                }
                //Races
                if (!context.Events.Any())
                {
                    context.Events.AddRange(new List<Event>()
                    {
                        new Event()
                        {
                            Title = "Mad Rhymes",
                            Description = "This is the description of the first race",
                            Location = "Liquid Lounge, Central",
                            ProfilePicUrl = "https://scontent.fcpt1-1.fna.fbcdn.net/v/t39.30808-6/318455614_586316676828682_5354823968135870578_n.jpg?_nc_cat=111&ccb=1-7&_nc_sid=52f669&_nc_ohc=Ckb_nms-OeMAX_kbQJv&_nc_ht=scontent.fcpt1-1.fna&oh=00_AfBmhMfgydl9dVfziMHeuPWL79t-6grqLm3aIgpAdAUA2A&oe=65074F94",

                        },
                        new Event()
                        {
                            Title = "Mad Rhymes",
                            Description = "This is the description of the first race",
                            Location = "Liquid Lounge, Central",
                            ProfilePicUrl = "https://scontent.fcpt1-1.fna.fbcdn.net/v/t39.30808-6/318455614_586316676828682_5354823968135870578_n.jpg?_nc_cat=111&ccb=1-7&_nc_sid=52f669&_nc_ohc=Ckb_nms-OeMAX_kbQJv&_nc_ht=scontent.fcpt1-1.fna&oh=00_AfBmhMfgydl9dVfziMHeuPWL79t-6grqLm3aIgpAdAUA2A&oe=65074F94",

                        },
                    });
                    context.SaveChanges();
                }
            }
        }

        //public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        //Roles
        //        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //        if (!await roleManager.RoleExistsAsync(UserRoles.User))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //        //Users
        //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
        //        string adminUserEmail = "shasazondani@gmail.com";

        //        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
        //        if (adminUser == null)
        //        {
        //            var newAdminUser = new User()
        //            {
        //                UserName = "vuyisazondani",
        //                Email = adminUserEmail,
        //                EmailConfirmed = true,
        //                Address = new Address()
        //                {
        //                    Street = "47 Clyde Street",
        //                    City = "Port Elizabeth",
        //                    Provinces = "Eastern Cape"
        //                }
        //            };
        //            await userManager.CreateAsync(newAdminUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
        //        }

        //        string appUserEmail = "user@etickets.com";

        //        var appUser = await userManager.FindByEmailAsync(appUserEmail);
        //        if (appUser == null)
        //        {
        //            var newAppUser = new User()
        //            {
        //                UserName = "app-user",
        //                Email = appUserEmail,
        //                EmailConfirmed = true,
        //                Address = new Address()
        //                {
        //                    Street = "123 Main St",
        //                    City = "Charlotte",
        //                    Provinces = "NC"
        //                }
        //            };
        //            await userManager.CreateAsync(newAppUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
        //        }
        //    }
        }
   }


