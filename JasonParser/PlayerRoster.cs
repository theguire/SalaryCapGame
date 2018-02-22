using System;
using System.Collections.Generic;
using System.Text;

namespace JasonParser

{
    public class PlayerRoster
    {

        public class Rootobject
        {
            public Rosterplayers rosterplayers { get; set; }
        }

        public class Rosterplayers
        {
            public string lastUpdatedOn { get; set; }
            public Playerentry[] playerentry { get; set; }
        }

        public class Playerentry
        {
            public Player player { get; set; }
            public Team team { get; set; }
        }

        public class Player
        {
            public string ID { get; set; }
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string JerseyNumber { get; set; }
            public string Position { get; set; }
            public string Height { get; set; }
            public string Weight { get; set; }
            public string BirthDate { get; set; }
            public string Age { get; set; }
            public string BirthCity { get; set; }
            public string BirthCountry { get; set; }
            public string IsRookie { get; set; }
        }

        public class Team
        {
            public string ID { get; set; }
            public string City { get; set; }
            public string Name { get; set; }
            public string Abbreviation { get; set; }
        }

    }
}

