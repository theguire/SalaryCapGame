using SalaryCapData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalaryCapData
{
    public static class DbInitializer
    {
        public static void Initialize( GameDBContext context )
        {
            if ( context.Owners.Any() )
            {
                return;
            }

            var owners = OwnersSeed(  context );
            var leagues = LeagueSeed( context, owners );
            var franchises = FranchiseSeed( context, owners, leagues );
        }
        
        private static Owner[] OwnersSeed( GameDBContext context )
        {
            var owners = new Owner[]
            {
                new Owner
                {
                    FirstName = "Dumbo",
                    LastName = "Jenkins",
                    Email = "dumbo@gmail.com",
                    ImageUrl = "images/a.jpg",
                },
                new Owner
                {
                    FirstName = "Hippy",
                    LastName = "Dippy",
                    Email = "dumbo@gmail.com",
                    ImageUrl = "images/b.png",
                },
                new Owner
                {
                    FirstName = "Jimbo",
                    LastName = "Jumbo",
                    Email = "dumbo@gmail.com",
                    ImageUrl = "images/b2.png",
                },
                new Owner
                {
                    FirstName = "Dingy",
                    LastName = "Wingie",
                    Email = "dumbo@gmail.com",
                    ImageUrl = "images/b3.png",
                }};
            foreach( Owner o in owners )
            {
                context.Owners.Add( o );
            }
            context.SaveChanges();

            return ( owners );
        }

        private static League[] LeagueSeed( GameDBContext context, Owner[] owners )
        {
            var leagues = new League[]
            {
                new League
                {
                    Name = "Fun League",
                    CommissionerId = owners.Single( o => o.LastName == "Wingie" ).Id,
                    MaxNumberFranchises = 10,
                    IsPrivate = false,
                },
                new League
                {
                    Name = "Dopy League",
                    CommissionerId = owners.Single( o => o.LastName == "Jumbo" ).Id,
                    MaxNumberFranchises = 20,
                    IsPrivate = false,
                },
                new League
                {
                    Name = "Goofy League",
                    CommissionerId = owners.Single( o => o.LastName == "Wingie" ).Id,
                    MaxNumberFranchises = 15,
                    IsPrivate = false,
                },
                new League
                {
                    Name = "Sleepy League",
                    CommissionerId = owners.Single( o => o.LastName == "Jenkins" ).Id,
                    MaxNumberFranchises = 10,
                    IsPrivate = true,
                },
                new League
                {
                    Name = "Sneezy League",
                    CommissionerId = owners.Single( o => o.LastName == "Jenkins" ).Id,
                    MaxNumberFranchises = 15,
                    IsPrivate = false,
                },
                new League
                {
                    Name = "Stupid League",
                    CommissionerId = owners.Single( o => o.LastName == "Wingie" ).Id,
                    MaxNumberFranchises = 12,
                    IsPrivate = false,
                },
            };

            foreach( League l in leagues )
            {
                context.Leagues.Add( l );
            }
            context.SaveChanges();

            return leagues;
        }

        private static Franchise[] FranchiseSeed( GameDBContext context, Owner[] owners, League[] leagues )
        {
            var franchises = new Franchise[]
            {
                new Franchise
                {
                    Name = "Franchise Wingie One",
                    ImageUrl = "images/b5.png",
                    LeagueId = leagues.Single( l => l.Name == "Sneezy League" ).Id,
                    OwnerId = owners.Single( o => o.LastName == "Wingie" ).Id,
                    Points = 10201,
                    Value = 75911,
                    NumberOfTrades = 1
                },
                new Franchise
                {
                    Name = "Franchise Wingie Two",
                    ImageUrl = "images/pi-1.jpg",
                    LeagueId = leagues.Single( l => l.Name == "Sneezy League" ).Id,
                    OwnerId = owners.Single( o => o.LastName == "Wingie" ).Id,
                    Points = 7201,
                    Value = 76000,
                    NumberOfTrades = 9
                },
                new Franchise
                {
                    Name = "Franchise Wingie Three",
                    ImageUrl = "images/t.png",
                    LeagueId = leagues.Single( l => l.Name == "Sneezy League" ).Id,
                    OwnerId = owners.Single( o => o.LastName == "Wingie" ).Id,
                    Points = 15350,
                    Value = 70900,
                    NumberOfTrades = 2
                },
                new Franchise
                {
                    Name = "Franchise Jumbo One",
                    ImageUrl = "images/theta4.png",
                    LeagueId = leagues.Single( l => l.Name == "Sneezy League" ).Id,
                    OwnerId = owners.Single( o => o.LastName == "Jumbo" ).Id,
                    Points = 11000,
                    Value = 76770,
                    NumberOfTrades= 6
                },
                new Franchise
                {
                    Name = "Franchise Dippy One",
                    ImageUrl = "images/tt.png",
                    LeagueId = leagues.Single( l => l.Name == "Sneezy League" ).Id,
                    OwnerId = owners.Single( o => o.LastName == "Dippy" ).Id,
                    Points = 60321,
                    Value = 55550,
                    NumberOfTrades = 0
                },
                new Franchise
                {
                    Name = "Franchise Jenkins One",
                    ImageUrl = "images/theta-3.png",
                    LeagueId = leagues.Single( l => l.Name == "Sneezy League" ).Id,
                    OwnerId = owners.Single( o => o.LastName == "Jenkins" ).Id,
                    Points = 9000,
                    Value = 78200,
                    NumberOfTrades = 4
                },
            };
            foreach( Franchise f in franchises )
            {
                context.Add( f );
            }
            context.SaveChanges();

            return franchises;
        }
    }
}
