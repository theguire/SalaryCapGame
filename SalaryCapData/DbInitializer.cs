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
                    ImageUrl = "images/Owners/14untitled.png",
                },
                new Owner
                {
                    FirstName = "Hippy",
                    LastName = "Dippy",
                    Email = "dumbo@gmail.com",
                    ImageUrl = "images/Owners/14untitled.png",
                },
                new Owner
                {
                    FirstName = "Jimbo",
                    LastName = "Jumbo",
                    Email = "dumbo@gmail.com",
                    ImageUrl = "images/Owners/14untitled.png",
                },
                new Owner
                {
                    FirstName = "Dingy",
                    LastName = "Wingie",
                    Email = "dumbo@gmail.com",
                    ImageUrl = "images/Owners/14untitled.png",
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
                },
                new League
                {
                    Name = "Dopy League",
                    CommissionerId = owners.Single( o => o.LastName == "Jumbo" ).Id,
                },
                new League
                {
                    Name = "Goofy League",
                    CommissionerId = owners.Single( o => o.LastName == "Wingie" ).Id,
                },
                new League
                {
                    Name = "Sleepy League",
                    CommissionerId = owners.Single( o => o.LastName == "Jenkins" ).Id,
                },
                new League
                {
                    Name = "Sneezy League",
                    CommissionerId = owners.Single( o => o.LastName == "Jenkins" ).Id,
                },
                new League
                {
                    Name = "Stupid League",
                    CommissionerId = owners.Single( o => o.LastName == "Wingie" ).Id,
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
                    ImageUrl = "images/Owners/19thY8RLKX9M.jpg",
                    LeagueId = leagues.Single( l => l.Name == "Sneezy League" ).Id,
                    OwnerId = owners.Single( o => o.LastName == "Wingie" ).Id,
                    Points = 10201,
                    Value = 75911,
                    NumberOfTrades = 1
                },
                new Franchise
                {
                    Name = "Franchise Wingie Two",
                    ImageUrl = "images/Owners/19thY8RLKX9M.jpg",
                    LeagueId = leagues.Single( l => l.Name == "Sneezy League" ).Id,
                    OwnerId = owners.Single( o => o.LastName == "Wingie" ).Id,
                    Points = 7201,
                    Value = 76000,
                    NumberOfTrades = 9
                },
                new Franchise
                {
                    Name = "Franchise Wingie Three",
                    ImageUrl = "images/Owners/19thY8RLKX9M.jpg",
                    LeagueId = leagues.Single( l => l.Name == "Sneezy League" ).Id,
                    OwnerId = owners.Single( o => o.LastName == "Wingie" ).Id,
                    Points = 15350,
                    Value = 70900,
                    NumberOfTrades = 2
                },
                new Franchise
                {
                    Name = "Franchise Jumbo One",
                    ImageUrl = "images/Owners/19thY8RLKX9M.jpg",
                    LeagueId = leagues.Single( l => l.Name == "Sneezy League" ).Id,
                    OwnerId = owners.Single( o => o.LastName == "Jumbo" ).Id,
                    Points = 11000,
                    Value = 76770,
                    NumberOfTrades= 6
                },
                new Franchise
                {
                    Name = "Franchise Dippy One",
                    ImageUrl = "images/Owners/19thY8RLKX9M.jpg",
                    LeagueId = leagues.Single( l => l.Name == "Sneezy League" ).Id,
                    OwnerId = owners.Single( o => o.LastName == "Dippy" ).Id,
                    Points = 60321,
                    Value = 55550,
                    NumberOfTrades = 0
                },
                new Franchise
                {
                    Name = "Franchise Jenkins One",
                    ImageUrl = "images/Owners/19thY8RLKX9M.jpg",
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
