using System;
using MongoDB.Bson;

namespace TimeStamp
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var arr = new BsonArray();
			Console.WriteLine(arr.BsonType);
			Console.ReadLine();
		}
	}
}