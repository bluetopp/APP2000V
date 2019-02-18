using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellBestilling
{
    //Dette lille nedenforher er en datastruktur
    //Det er bare variabler

	public struct TypeCount {
		public string type;
		public int count;

		public TypeCount(string type, int count) {
			this.type = type;
			this.count = count;
		}

	}

	public class BookingData
	{
        //Denne metoden er ansvarlig for å hente data om booking i databasen
		//Henter alle registrerte bookinger i databasen som ikke har utgått
        //Hvis result er tom, så skal den ikke gjøre noe
		public List<Booking> GetData()
		{
			DataSet result = DatabaseManager.Query("SELECT * FROM booking WHERE tildato >= CURDATE();");

			if (result == null)
			{
				Console.WriteLine("BookingData.GetData: Datasettet er tomt");
				return null;
			}

            //Hvis vi får noe tilbake, så looper vi det vi
            //finner og legger det i listen

			List<Booking> bookings = new List<Booking>();
			int bookingID;
			int roomID;
			int orderID;
			string fromDate;
			string toDate;

			foreach (DataRow row in result.Tables["result"].Rows)
			{
				bookingID = (int)row["bookingID"];
				roomID = (int)row["romID"];
				orderID = (int)row["bestillingID"];
				fromDate = ((DateTime)row["fradato"]).ToShortDateString();
				toDate = ((DateTime)row["tildato"]).ToShortDateString();
				bookings.Add(new Booking(bookingID, roomID, orderID, fromDate, toDate));
			}

			return bookings;
		}

		public static bool IsRoomOccupiedForPeriod(int roomID, string fromDate, string toDate)
		{
            //Denne metoden sjekker om rommet er okkupert
            //for en viss periode.

			DataSet result = DatabaseManager.Query
				(
				"SELECT romID FROM booking WHERE tildato >= CURDATE() AND romID = " + roomID + " AND (fradato <= '" + toDate + "') AND ('" + fromDate + "' <= tildato);"
				);

			if (result == null)
			{
				Console.WriteLine("BookingData.IsRoomOccupiedForPeriod: Datasettet er tomt");
				return true;
			}

			return (result.Tables[0].Rows.Count == 0) ? false : true;
		}

        //Metoden under blir blant annet brukt på hovedsiden
        //for å sjekke om rommet er tilgjengelig innenfor en viss
        //periode. Vi sender en spørring til databasen og får
        //returnert dette tilbake i en liste
		public static List<TypeCount> GetAvailableRoomsForPeriod(string fromDate, string toDate, int personer)
		{
            DataSet romtype = DatabaseManager.Query
                (
                "SELECT romtype FROM romtyper WHERE personer =" + personer + ";"
                );

			DataSet result = DatabaseManager.Query
				(
                "SELECT romtype, COUNT(romtype) AS telling FROM rom WHERE romtype IN (SELECT romtype FROM romtyper WHERE personer >=" + personer + ") AND romID NOT IN(SELECT romID FROM booking WHERE tildato >= CURDATE() AND(fradato <= '" + toDate + "') AND('" + fromDate + "' <= tildato)) GROUP BY romtype; "
                );

			if (result == null)
			{
				Console.WriteLine("BookingData.GetAvailableRoomsForPeriod: Datasettet er tomt");
				return new List<TypeCount>();
			}

			List<Room> availableRooms = new List<Room>();
            //int roomID;
            string roomType;
            int numberOfRooms;

			// Lista inneholder noe jeg har kalt TypeCount, for å inneholde romtype og antall av dem
			// TypeCount blir definert på toppen av denne fila, er noe som heter struct
			// struct er nesten det samme som en klasse/objekt, kan bare ikke inneholder funksjoner og sånt
			// hadde ikke trengt å bruke det men du får leve med det nå
			List<TypeCount> typeCountList = new List<TypeCount>(); 

			foreach (DataRow row in result.Tables["result"].Rows)
			{
                //roomID = (int)row["romID"];
                roomType = (string)row["romtype"];
                numberOfRooms = Convert.ToInt32(row["telling"]);
                typeCountList.Add(new TypeCount(roomType, numberOfRooms));
				//availableRooms.Add(new Room(roomId, roomType, false));
			}

			return typeCountList;
		}

	}

}
