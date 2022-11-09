using System;
using System.Collections;
using System.Collections.Generic;

namespace MidtermProj
{
    interface IDonation
    {
        //Truck Truck { get; set; }
        Truck Donations { get; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Donation
    {
        //List<string> DonationName = new List<string>();
        //List<string> Donor = new List<string>();
        string DonationName { get; set; }
        string Donor { get; set; }

        Donation():this("No Donor")
        {

        }
        Donation(string Donor) : this(Donor, "No donation name")
        {

        }

        Donation(string donationName, string donor)
        {
            DonationName = donationName;
            Donor = donor;
        }

    }

    class Truck
    {
        List<string> Donations = new List<string>();
        //Donations.Add();

        /**Truck()
        {
            donations = new List<Truck>();
        }
        private List<Truck> donations;
        */
        public void AddDonations(Donations)
        {
            donations.Add(Donations);
        }
    }

    class Donor
    {
       

    }
    class Route
    {
        List<Route> objects = new List<Route>();
    }
}
