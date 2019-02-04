using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//Collections to work with
			List<Artist> Artists = MusicStore.GetData().AllArtists;
			List<Group> Groups = MusicStore.GetData().AllGroups;

			//========================================================
			//Solve all of the prompts below using various LINQ queries
			//========================================================

			//There is only one artist in this collection from Mount Vernon, what is their name and age?
			Artist a1 = Artists.FirstOrDefault(art => art.Hometown == "Mount Vernon");
			Console.WriteLine(a1.ArtistName + " : " + a1.Age);

			//Who is the youngest artist in our collection of artists?
			Artist a2 = (Artist)Artists.OrderBy(art => art.Age).First();
			Console.WriteLine(a2.ArtistName + " : " + a2.Age);

			//Display all artists with 'William' somewhere in their real name
			List<Artist> a3 = Artists.Where(art => art.ArtistName.Contains("William") || art.RealName.Contains("William")).ToList();
			foreach(Artist afor in a3)
			{
				Console.WriteLine(afor.ArtistName + " : " + afor.Age);
			}
			//Display the 3 oldest artist from Atlanta
			List<Artist> a4 = Artists
				.OrderBy(art => art.Age)
				.Where(art => art.Hometown == "Atlanta")
				.Take(3).ToList();
			foreach(Artist afor in a4)
			{
				Console.WriteLine(afor.ArtistName + " : " + afor.Age);
			}

			//(Optional) Display the Group Name of all groups that have members that are not from New York City

			//(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
			Console.WriteLine(Groups.Count);
		}
	}
}
