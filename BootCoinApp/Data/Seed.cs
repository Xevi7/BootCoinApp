using BootCoinApp.Models;
using Microsoft.AspNetCore.Identity;

namespace BootCoinApp.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var ServiceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = ServiceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if(!context.Groups.Any())
                {
                    context.Groups.AddRange(new List<Group>()
                    {
                        new Group()
                        {
                            GroupName = "No Group"
                        },
                        new Group()
                        {
                            GroupName = "Group A"
                        },
                        new Group()
                        {
                            GroupName = "Group B"
                        },
                        new Group()
                        {
                            GroupName = "Group C"
                        },
                        new Group()
                        {
                            GroupName = "Group D"
                        },
                    });
                    context.SaveChanges();
                }
                if (!context.Positions.Any())
                {
                    context.Positions.AddRange(new List<Position>()
                    {
                        new Position()
                        {
                            PositionName = "No Position"
                        },
                        new Position()
                        {
                            PositionName = "Business Solution Architect"
                        },
                        new Position()
                        {
                            PositionName = "Business Intelligence Analyst"
                        },
                        new Position()
                        {
                            PositionName = "Customs Apps Developer"
                        },
                        new Position()
                        {
                            PositionName = "Desain Komunikasi Visual"
                        },
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var ServiceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var RoleManager = ServiceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await RoleManager.RoleExistsAsync(UserRoles.admin))
                {
                    await RoleManager.CreateAsync(new IdentityRole(UserRoles.admin));
                }
                if (!await RoleManager.RoleExistsAsync(UserRoles.user))
                {
                    await RoleManager.CreateAsync(new IdentityRole(UserRoles.user));
                }

                var userManager = ServiceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string AdminUserEmail = "adminBootcoin@gmail.com";

                var AdminUser = await userManager.FindByEmailAsync(AdminUserEmail);
                if (AdminUser == null)
                {
                    var NewAdmin = new AppUser()
                    {
                        UserName = "Admin1",
                        Email = "adminBootcoin@gmail.com",
                        GroupId = 1,
                        PositionId = 1,
                    };
                    await userManager.CreateAsync(NewAdmin, "admin123");
                    await userManager.AddToRoleAsync(NewAdmin, UserRoles.admin);
                }
                //Group A
                string UserEmail = "Nur@gmail.com";

                var AppUser = await userManager.FindByEmailAsync(UserEmail);
                if(AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Nur",
                        Email = "Nur@gmail.com",
                        BootCoin = 78,
                        GroupId = 2,
                        PositionId = 3,
                    };
                    await userManager.CreateAsync(NewUser, "Nur123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Mega@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Mega",
                        Email = "Mega@gmail.com",
                        BootCoin = 94,
                        GroupId = 2,
                        PositionId = 2,
                    };
                    await userManager.CreateAsync(NewUser, "Mega123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Widya@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Widya",
                        Email = "Widya@gmail.com",
                        BootCoin = 92,
                        GroupId = 2,
                        PositionId = 2,
                    };
                    await userManager.CreateAsync(NewUser, "Widya123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Yuda@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Yuda",
                        Email = "Yuda@gmail.com",
                        BootCoin = 93,
                        GroupId = 2,
                        PositionId = 2,
                    };
                    await userManager.CreateAsync(NewUser, "Yuda123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Danial@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Danial",
                        Email = "Danial@gmail.com",
                        BootCoin = 73,
                        GroupId = 2,
                        PositionId = 4,
                    };
                    await userManager.CreateAsync(NewUser, "Danial123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Bima@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Bima",
                        Email = "Bima@gmail.com",
                        BootCoin = 83,
                        GroupId = 2,
                        PositionId = 4,
                    };
                    await userManager.CreateAsync(NewUser, "Bima123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Adi@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Adi",
                        Email = "Adi@gmail.com",
                        BootCoin = 79,
                        GroupId = 2,
                        PositionId = 4,
                    };
                    await userManager.CreateAsync(NewUser, "Adi123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Surya@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Surya",
                        Email = "Surya@gmail.com",
                        BootCoin = 83,
                        GroupId = 2,
                        PositionId = 5,
                    };
                    await userManager.CreateAsync(NewUser, "Surya123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                //Group B
                UserEmail = "Adriel@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Adriel",
                        Email = "Adriel@gmail.com",
                        BootCoin = 74,
                        GroupId = 3,
                        PositionId = 3,
                    };
                    await userManager.CreateAsync(NewUser, "Adriel123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Angie@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Angie",
                        Email = "Angie@gmail.com",
                        BootCoin = 71,
                        GroupId = 3,
                        PositionId = 2,
                    };
                    await userManager.CreateAsync(NewUser, "Angie123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Arya@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Arya",
                        Email = "Arya@gmail.com",
                        BootCoin = 88,
                        GroupId = 3,
                        PositionId = 2,
                    };
                    await userManager.CreateAsync(NewUser, "Arya123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Andreas@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Andreas",
                        Email = "Andreas@gmail.com",
                        BootCoin = 72,
                        GroupId = 3,
                        PositionId = 4,
                    };
                    await userManager.CreateAsync(NewUser, "Andreas123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Dylan@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Dylan",
                        Email = "Dylan@gmail.com",
                        BootCoin = 85,
                        GroupId = 3,
                        PositionId = 4,
                    };
                    await userManager.CreateAsync(NewUser, "Dylan123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Excel@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Excel",
                        Email = "Excel@gmail.com",
                        BootCoin = 84,
                        GroupId = 3,
                        PositionId = 4,
                    };
                    await userManager.CreateAsync(NewUser, "Excel123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Hanny@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Hanny",
                        Email = "Hanny@gmail.com",
                        BootCoin = 94,
                        GroupId = 3,
                        PositionId = 5,
                    };
                    await userManager.CreateAsync(NewUser, "Hanny123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                //Group C
                UserEmail = "Hanrich@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Hanrich",
                        Email = "Hanrich@gmail.com",
                        BootCoin = 88,
                        GroupId = 4,
                        PositionId = 3,
                    };
                    await userManager.CreateAsync(NewUser, "Hanrich123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "James@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "James",
                        Email = "James@gmail.com",
                        BootCoin = 76,
                        GroupId = 4,
                        PositionId = 2,
                    };
                    await userManager.CreateAsync(NewUser, "James123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Jeta@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Jeta",
                        Email = "Jeta@gmail.com",
                        BootCoin = 73,
                        GroupId = 4,
                        PositionId = 2,
                    };
                    await userManager.CreateAsync(NewUser, "Jeta123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Jordan@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Jordan",
                        Email = "Jordan@gmail.com",
                        BootCoin = 85,
                        GroupId = 4,
                        PositionId = 2,
                    };
                    await userManager.CreateAsync(NewUser, "Jordan123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Kenny@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Kenny",
                        Email = "Kenny@gmail.com",
                        BootCoin = 74,
                        GroupId = 4,
                        PositionId = 4,
                    };
                    await userManager.CreateAsync(NewUser, "Kenny123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Lucas@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Lucas",
                        Email = "Lucas@gmail.com",
                        BootCoin = 80,
                        GroupId = 4,
                        PositionId = 4,
                    };
                    await userManager.CreateAsync(NewUser, "Lucas123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Ricky@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Ricky",
                        Email = "Ricky@gmail.com",
                        BootCoin = 74,
                        GroupId = 4,
                        PositionId = 4,
                    };
                    await userManager.CreateAsync(NewUser, "Ricky123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Rio@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Rio",
                        Email = "Rio@gmail.com",
                        BootCoin = 82,
                        GroupId = 4,
                        PositionId = 5,
                    };
                    await userManager.CreateAsync(NewUser, "Rio123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                //Group D
                UserEmail = "Susan@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Susan",
                        Email = "Susan@gmail.com",
                        BootCoin = 86,
                        GroupId = 5,
                        PositionId = 3,
                    };
                    await userManager.CreateAsync(NewUser, "Susan123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Thomas@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Thomas",
                        Email = "Thomas@gmail.com",
                        BootCoin = 84,
                        GroupId = 5,
                        PositionId = 2,
                    };
                    await userManager.CreateAsync(NewUser, "Thomas123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Timotius@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Timotius",
                        Email = "Timotius@gmail.com",
                        BootCoin = 93,
                        GroupId = 5,
                        PositionId = 2,
                    };
                    await userManager.CreateAsync(NewUser, "Timotius123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Vincent@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Vincent",
                        Email = "Vincent@gmail.com",
                        BootCoin = 84,
                        GroupId = 5,
                        PositionId = 4,
                    };
                    await userManager.CreateAsync(NewUser, "Vincent123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Steven@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Steven",
                        Email = "Steven@gmail.com",
                        BootCoin = 81,
                        GroupId = 5,
                        PositionId = 4,
                    };
                    await userManager.CreateAsync(NewUser, "Steven123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Novia@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Novia",
                        Email = "Novia@gmail.com",
                        BootCoin = 73,
                        GroupId = 5,
                        PositionId = 4,
                    };
                    await userManager.CreateAsync(NewUser, "Novia123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }

                UserEmail = "Tengku@gmail.com";

                AppUser = await userManager.FindByEmailAsync(UserEmail);
                if (AppUser == null)
                {
                    var NewUser = new AppUser()
                    {
                        UserName = "Tengku",
                        Email = "Tengku@gmail.com",
                        BootCoin = 70,
                        GroupId = 5,
                        PositionId = 5,
                    };
                    await userManager.CreateAsync(NewUser, "Tengku123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }
            }
        }
    }
}
