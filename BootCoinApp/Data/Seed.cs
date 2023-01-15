using BootCoinApp.Models;
using Microsoft.AspNetCore.Builder;
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
                        new Position()
                        {
                            PositionName = "ERP Specialist"
                        },
                        new Position()
                        {
                            PositionName = "Product Manager"
                        },
                    });
                    context.SaveChanges();
                }
                if (!context.Activenesses.Any())
                {
                    context.Activenesses.AddRange(new List<Activeness>()
                    {
                        new Activeness()
                        {
                            ActivenessName = "Active"
                        },
                        new Activeness()
                        {
                            ActivenessName = "Barely Active"
                        },
                        new Activeness()
                        {
                            ActivenessName = "Not Active"
                        },
                    });
                    context.SaveChanges();
                }
                if (!context.Events.Any())
                {
                    context.Events.AddRange(new List<Event>()
                    {
                        new Event()
                        {
                            EventName = "Pre Mission"
                        },
                        new Event()
                        {
                            EventName = "Mission 1"
                        },
                        new Event()
                        {
                            EventName = "Mission 2"
                        },
                        new Event()
                        {
                            EventName = "Offline Gathering"
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
                        FullName = "Admin1",
                        UserName = "adminBootcoin@gmail.com",
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
                        FullName = "Nur",
                        UserName = "Nur@gmail.com",
                        Email = "Nur@gmail.com",
                        BootCoin = 78,
                        GroupId = 2,
                        PositionId = 2,
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
                        FullName = "Mega",
                        UserName = "Mega@gmail.com",
                        Email = "Mega@gmail.com",
                        BootCoin = 94,
                        GroupId = 2,
                        PositionId = 6,
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
                        FullName = "Widya",
                        UserName = "Widya@gmail.com",
                        Email = "Widya@gmail.com",
                        BootCoin = 92,
                        GroupId = 2,
                        PositionId = 5,
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
                        FullName = "Yuda",
                        UserName = "Yuda@gmail.com",
                        Email = "Yuda@gmail.com",
                        BootCoin = 93,
                        GroupId = 2,
                        PositionId = 5,
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
                        FullName = "Danial",
                        UserName = "Danial@gmail.com",
                        Email = "Danial@gmail.com",
                        BootCoin = 73,
                        GroupId = 2,
                        PositionId = 3,
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
                        FullName = "Bima",
                        UserName = "Bima@gmail.com",
                        Email = "Bima@gmail.com",
                        BootCoin = 83,
                        GroupId = 2,
                        PositionId = 3,
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
                        FullName = "Adi",
                        UserName = "Adi@gmail.com",
                        Email = "Adi@gmail.com",
                        BootCoin = 79,
                        GroupId = 2,
                        PositionId = 3,
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
                        FullName = "Surya",
                        UserName = "Surya@gmail.com",
                        Email = "Surya@gmail.com",
                        BootCoin = 83,
                        GroupId = 2,
                        PositionId = 4,
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
                        FullName = "Adriel",
                        UserName = "Adriel@gmail.com",
                        Email = "Adriel@gmail.com",
                        BootCoin = 74,
                        GroupId = 3,
                        PositionId = 2,
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
                        FullName = "Angie",
                        UserName = "Angie@gmail.com",
                        Email = "Angie@gmail.com",
                        BootCoin = 71,
                        GroupId = 3,
                        PositionId = 6,
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
                        FullName = "Arya",
                        UserName = "Arya@gmail.com",
                        Email = "Arya@gmail.com",
                        BootCoin = 88,
                        GroupId = 3,
                        PositionId = 5,
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
                        FullName = "Andreas",
                        UserName = "Andreas@gmail.com",
                        Email = "Andreas@gmail.com",
                        BootCoin = 72,
                        GroupId = 3,
                        PositionId = 3,
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
                        FullName = "Dylan",
                        UserName = "Dylan@gmail.com",
                        Email = "Dylan@gmail.com",
                        BootCoin = 85,
                        GroupId = 3,
                        PositionId = 3,
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
                        FullName = "Excel",
                        UserName = "Excel@gmail.com",
                        Email = "Excel@gmail.com",
                        BootCoin = 84,
                        GroupId = 3,
                        PositionId = 3,
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
                        FullName = "Hanny",
                        UserName = "Hanny@gmail.com",
                        Email = "Hanny@gmail.com",
                        BootCoin = 94,
                        GroupId = 3,
                        PositionId = 4,
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
                        FullName = "Hanrich",
                        UserName = "Hanrich@gmail.com",
                        Email = "Hanrich@gmail.com",
                        BootCoin = 88,
                        GroupId = 4,
                        PositionId = 2,
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
                        FullName = "James",
                        UserName = "James@gmail.com",
                        Email = "James@gmail.com",
                        BootCoin = 76,
                        GroupId = 4,
                        PositionId = 6,
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
                        FullName = "Jeta",
                        UserName = "Jeta@gmail.com",
                        Email = "Jeta@gmail.com",
                        BootCoin = 73,
                        GroupId = 4,
                        PositionId = 5,
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
                        FullName = "Jordan",
                        UserName = "Jordan@gmail.com",
                        Email = "Jordan@gmail.com",
                        BootCoin = 85,
                        GroupId = 4,
                        PositionId = 5,
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
                        FullName = "Kenny",
                        UserName = "Kenny@gmail.com",
                        Email = "Kenny@gmail.com",
                        BootCoin = 74,
                        GroupId = 4,
                        PositionId = 3,
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
                        FullName = "Lucas",
                        UserName = "Lucas@gmail.com",
                        Email = "Lucas@gmail.com",
                        BootCoin = 80,
                        GroupId = 4,
                        PositionId = 3,
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
                        FullName = "Ricky",
                        UserName = "Ricky@gmail.com",
                        Email = "Ricky@gmail.com",
                        BootCoin = 74,
                        GroupId = 4,
                        PositionId = 3,
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
                        FullName = "Rio",
                        UserName = "Rio@gmail.com",
                        Email = "Rio@gmail.com",
                        BootCoin = 82,
                        GroupId = 4,
                        PositionId = 4,
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
                        FullName = "Susan",
                        UserName = "Susan@gmail.com",
                        Email = "Susan@gmail.com",
                        BootCoin = 86,
                        GroupId = 5,
                        PositionId = 2,
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
                        FullName = "Thomas",
                        UserName = "Thomas@gmail.com",
                        Email = "Thomas@gmail.com",
                        BootCoin = 84,
                        GroupId = 5,
                        PositionId = 6,
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
                        FullName = "Timotius",
                        UserName = "Timotius@gmail.com",
                        Email = "Timotius@gmail.com",
                        BootCoin = 93,
                        GroupId = 5,
                        PositionId = 5,
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
                        FullName = "Vincent",
                        UserName = "Vincent@gmail.com",
                        Email = "Vincent@gmail.com",
                        BootCoin = 84,
                        GroupId = 5,
                        PositionId = 3,
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
                        FullName = "Steven",
                        UserName = "Steven@gmail.com",
                        Email = "Steven@gmail.com",
                        BootCoin = 81,
                        GroupId = 5,
                        PositionId = 3,
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
                        FullName = "Novia",
                        UserName = "Novia@gmail.com",
                        Email = "Novia@gmail.com",
                        BootCoin = 73,
                        GroupId = 5,
                        PositionId = 3,
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
                        FullName = "Tengku",
                        UserName = "Tengku@gmail.com",
                        Email = "Tengku@gmail.com",
                        BootCoin = 70,
                        GroupId = 5,
                        PositionId = 4,
                    };
                    await userManager.CreateAsync(NewUser, "Tengku123");
                    await userManager.AddToRoleAsync(NewUser, UserRoles.user);
                }
            }
        }

        public static async Task seedTransaction(IApplicationBuilder applicationBuilder)
        {
            using (var ServiceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = ServiceScope.ServiceProvider.GetService<ApplicationDbContext>();
                var userManager = ServiceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                context.Database.EnsureCreated();

                var admin = await userManager.FindByEmailAsync("adminBootcoin@gmail.com");

                if (!context.Transactions.Any())
                {
                    var receiver = await userManager.FindByEmailAsync("Nur@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 20,
                            EventId = 1,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 18,
                            EventId = 2,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 17,
                            EventId = 3,
                            ActivenessId = 3,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 23,
                            EventId = 4,
                            ActivenessId = 1,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Mega@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 24,
                            EventId = 1,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 21,
                            EventId = 2,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 24,
                            EventId = 3,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 25,
                            EventId = 4,
                            ActivenessId = 1,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Widya@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 22,
                            EventId = 1,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 21,
                            EventId = 2,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 24,
                            EventId = 3,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 25,
                            EventId = 4,
                            ActivenessId = 1,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Yuda@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 21,
                            EventId = 1,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 24,
                            EventId = 2,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 23,
                            EventId = 3,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 25,
                            EventId = 4,
                            ActivenessId = 1,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Danial@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 22,
                            EventId = 1,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 16,
                            EventId = 2,
                            ActivenessId = 3,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 18,
                            EventId = 3,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 17,
                            EventId = 4,
                            ActivenessId = 3,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Bima@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 20,
                            EventId = 1,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 22,
                            EventId = 2,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 21,
                            EventId = 3,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 20,
                            EventId = 4,
                            ActivenessId = 1,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Adi@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 20,
                            EventId = 1,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 21,
                            EventId = 2,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 19,
                            EventId = 3,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 19,
                            EventId = 4,
                            ActivenessId = 2,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Surya@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 24,
                            EventId = 1,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 18,
                            EventId = 2,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 20,
                            EventId = 3,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 21,
                            EventId = 4,
                            ActivenessId = 1,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Adriel@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 18,
                            EventId = 1,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 20,
                            EventId = 2,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 18,
                            EventId = 3,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 18,
                            EventId = 4,
                            ActivenessId = 2,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Angie@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 20,
                            EventId = 1,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 16,
                            EventId = 2,
                            ActivenessId = 3,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 18,
                            EventId = 3,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 17,
                            EventId = 4,
                            ActivenessId = 2,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Arya@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 23,
                            EventId = 1,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 24,
                            EventId = 2,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 21,
                            EventId = 3,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 20,
                            EventId = 4,
                            ActivenessId = 1,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Andreas@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 18,
                            EventId = 1,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 19,
                            EventId = 2,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 17,
                            EventId = 3,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 18,
                            EventId = 4,
                            ActivenessId = 2,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Dylan@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 21,
                            EventId = 1,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 21,
                            EventId = 2,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 22,
                            EventId = 3,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 21,
                            EventId = 4,
                            ActivenessId = 1,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Excel@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 23,
                            EventId = 1,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 16,
                            EventId = 2,
                            ActivenessId = 3,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 23,
                            EventId = 3,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 22,
                            EventId = 4,
                            ActivenessId = 1,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Hanny@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 22,
                            EventId = 1,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 23,
                            EventId = 2,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 24,
                            EventId = 3,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 25,
                            EventId = 4,
                            ActivenessId = 1,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Hanrich@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 24,
                            EventId = 1,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 21,
                            EventId = 2,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 20,
                            EventId = 3,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 23,
                            EventId = 4,
                            ActivenessId = 1,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("James@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 19,
                            EventId = 1,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 20,
                            EventId = 2,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 18,
                            EventId = 3,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 19,
                            EventId = 4,
                            ActivenessId = 2,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Jeta@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 19,
                            EventId = 1,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 18,
                            EventId = 2,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 17,
                            EventId = 3,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 19,
                            EventId = 4,
                            ActivenessId = 2,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Jordan@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 20,
                            EventId = 1,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 21,
                            EventId = 2,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 22,
                            EventId = 3,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 22,
                            EventId = 4,
                            ActivenessId = 1,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Kenny@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 19,
                            EventId = 1,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 18,
                            EventId = 2,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 17,
                            EventId = 3,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 20,
                            EventId = 4,
                            ActivenessId = 1,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("lucas@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 19,
                            EventId = 1,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 20,
                            EventId = 2,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 21,
                            EventId = 3,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 20,
                            EventId = 4,
                            ActivenessId = 1,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Ricky@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 18,
                            EventId = 1,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 18,
                            EventId = 2,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 20,
                            EventId = 3,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 18,
                            EventId = 4,
                            ActivenessId = 2,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Rio@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 24,
                            EventId = 1,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 16,
                            EventId = 2,
                            ActivenessId = 3,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 22,
                            EventId = 3,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 20,
                            EventId = 4,
                            ActivenessId = 1,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Susan@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 21,
                            EventId = 1,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 23,
                            EventId = 2,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 21,
                            EventId = 3,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 21,
                            EventId = 4,
                            ActivenessId = 1,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Thomas@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 21,
                            EventId = 1,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 22,
                            EventId = 2,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 22,
                            EventId = 3,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 19,
                            EventId = 4,
                            ActivenessId = 2,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Timotius@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 24,
                            EventId = 1,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 22,
                            EventId = 2,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 23,
                            EventId = 3,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 24,
                            EventId = 4,
                            ActivenessId = 1,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Vincent@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 20,
                            EventId = 1,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 20,
                            EventId = 2,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 21,
                            EventId = 3,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 23,
                            EventId = 4,
                            ActivenessId = 1,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Steven@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 20,
                            EventId = 1,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 21,
                            EventId = 2,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 21,
                            EventId = 3,
                            ActivenessId = 1,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 19,
                            EventId = 4,
                            ActivenessId = 2,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Novia@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 18,
                            EventId = 1,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 17,
                            EventId = 2,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 19,
                            EventId = 3,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 19,
                            EventId = 4,
                            ActivenessId = 2,
                        },
                    });
                    receiver = await userManager.FindByEmailAsync("Tengku@gmail.com");
                    context.AddRange(new List<Transaction>()
                    {
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("02/12/2022", "dd/MM/yyyy", null),
                            amount = 17,
                            EventId = 1,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("11/12/2022", "dd/MM/yyyy", null),
                            amount = 17,
                            EventId = 2,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("23/12/2022", "dd/MM/yyyy", null),
                            amount = 19,
                            EventId = 3,
                            ActivenessId = 2,
                        },
                        new Transaction()
                        {
                            UserId = admin.Id,
                            ReceiverId = receiver.Id,
                            Date = DateTime.ParseExact("27/12/2022", "dd/MM/yyyy", null),
                            amount = 17,
                            EventId = 4,
                            ActivenessId = 2,
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }   
}
