using ObligatoriskHotelDBOpgave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskHotelDBConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ManageFacilities manageFacilities = new ManageFacilities();
            #region Read
            manageFacilities.ReadFacilities();
            Console.ReadLine();
            #endregion

            #region Create
            //manageFacilities.CreateFacility(new Facility() { Facility_Id = 8, Name = "Sauna" });
            #endregion

            #region Delete
            //manageFacilities.DeleteFaciltiy(8);

            #endregion

            #region Update
            //Facility facilityObject = new Facility() { Facility_Id = 4, Name = "McDonalds" };
            //manageFacilities.UpdateFacility(facilityObject.Facility_Id, facilityObject);
            //manageFacilities.ReadFacilities();
            #endregion

        }
    }
}
