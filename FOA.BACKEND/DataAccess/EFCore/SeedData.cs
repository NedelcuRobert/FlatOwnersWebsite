using FOA.BACKEND.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FOA.BACKEND.DataAccess.EFCore
{
    public static class SeedData
    {
        public static void SeedAccounts(this ModelBuilder builder)
        {
            var hasher = new PasswordHasher<User>();
            builder
                .Entity<User>()
                .HasData(
                    new User
                    {
                        Id = "8e445865-a24d-4543-a6c6-9443d048cdb7",
                        UserName = "NoRole",
                        FirstName = "Andrei",
                        LastName = "Popescu",
                        NormalizedUserName = "NOROLE",
                        Email = "norole@gmail.com",
                        NormalizedEmail = "NOROLE@GMAIL.COM",
                        PasswordHash = hasher.HashPassword(null, "Pass_2002"),
                        LockoutEnabled = true,
                        EmailConfirmed = true,
                        Token = "12121212",
                        AddressId = 1,
                        ProfilePicture = "1"
                    },
                    new User
                    {
                        Id = "9c44780-a24d-4543-9cc6-0993d048aacu7",
                        UserName = "Atmin",
                        FirstName = "Andrei",
                        LastName = "Popescu",
                        NormalizedUserName = "ATMIN",
                        Email = "atmin@gmail.com",
                        NormalizedEmail = "ATMIN@GMAIL.COM",
                        PasswordHash = hasher.HashPassword(null, "Pass_2002"),
                        LockoutEnabled = true,
                        EmailConfirmed = true,
                        Token = "12121212",
                        AddressId = 2,
                        ProfilePicture = "1"
                    },
                    new User
                    {
                        Id = "9a27620-a44f-4543-9dk6-0993d048sia7",
                        UserName = "BTO",
                        FirstName = "Andrei",
                        LastName = "Popescu",
                        NormalizedUserName = "BTO",
                        Email = "bto@gmail.com",
                        NormalizedEmail = "BTO@GMAIL.COM",
                        PasswordHash = hasher.HashPassword(null, "Pass_2002"),
                        LockoutEnabled = true,
                        EmailConfirmed = true,
                        Token = "12121212",
                        AddressId = 3,
                        ProfilePicture = "1"
                    }
                );
        }
        public static void SeedAddress(this ModelBuilder builder)
        {
            builder
                .Entity<Address>()
                .HasData(
                    new Address
                    {
                        Id = 1,
                        City = "Craiova",
                        Building = "6 Scara 2",
                        Street = "Florilor",
                        ApartmentNumber = 1,
                    },
                   new Address
                   {
                       Id = 2,
                       City = "Craiova",
                       Building = "6 Scara 2",
                       Street = "Florilor",
                       ApartmentNumber = 1,
                   },
                    new Address
                    {
                        Id = 3,
                        City = "Craiova",
                        Building = "6 Scara 2",
                        Street = "Florilor",
                        ApartmentNumber = 1,
                    }
                );
        }
    }
}
