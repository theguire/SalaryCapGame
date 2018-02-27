using Newtonsoft.Json;
using SalaryCapData.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SalaryCapData.ConsumeJson.Models.PlayerSalary
{

    public class GetPlayerSalaryList
    {
        public IEnumerable<Playersalary> GetSalaries( string fileName )
        {
            try
            {
                Rootobject rootObject = JsonConvert.DeserializeObject<Rootobject>( File.ReadAllText( fileName ) );
                return rootObject.playersalary;

            }
            catch ( Exception ex )
            {
                System.Diagnostics.Debug.Write( "Error reading Json file: " + ex );
                return null;
            }
        }
    }    
}
