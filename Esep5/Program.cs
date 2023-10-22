using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Esep5
{

    class Train
    {
        public int TrainID { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public decimal Fare { get; set; }

        public Train(int trainID, string departure, string arrival, decimal fare)
        {
            TrainID = trainID;
            Departure = departure;
            Arrival = arrival;
            Fare = fare;
        }
    }

    class Ticket
    {
        public int TicketID { get; set; }
        public Train ChosenTrain { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public decimal TotalFare { get; set; }

        public Ticket(int ticketID, Train chosenTrain, DateTime departureDateTime, decimal totalFare)
        {
            TicketID = ticketID;
            ChosenTrain = chosenTrain;
            DepartureDateTime = departureDateTime;
            TotalFare = totalFare;
        }
    }

    class BookingRequest
    {
        public string Destination { get; set; }
        public DateTime DepartureDateTime { get; set; }

        public BookingRequest(string destination, DateTime departureDateTime)
        {
            Destination = destination;
            DepartureDateTime = departureDateTime;
        }
    }

    class Passenger
    {
        public string FullName { get; set; }
        public List<BookingRequest> BookingRequests { get; set; }

        public Passenger(string fullName)
        {
            FullName = fullName;
            BookingRequests = new List<BookingRequest>();
        }

        public Ticket MakeReservation(BookingRequest bookingRequest, Train chosenTrain)
        {
            decimal totalFare = chosenTrain.Fare;
            Ticket ticket = new Ticket(GetNextTicketID(), chosenTrain, bookingRequest.DepartureDateTime, totalFare);
            return ticket;
        }

        private static int ticketIDCounter = 1;

        private int GetNextTicketID()
        {
            return ticketIDCounter++;
        }
    }

    class TicketingAgent
    {
        public Ticket GenerateTicket(Passenger passenger, BookingRequest bookingRequest, Train chosenTrain)
        {
            Ticket ticket = passenger.MakeReservation(bookingRequest, chosenTrain);
            return ticket;
        }
    }

    class Program
    {
        static void Main()
        {
            Train trainA = new Train(1, "Станция А", "Станция Б", 50.0m);
            Train trainB = new Train(2, "Станция В", "Станция Г", 75.0m);

            Passenger passenger = new Passenger("Иванов Иван");
            BookingRequest bookingRequest = new BookingRequest("Станция Б", DateTime.Now);
            TicketingAgent ticketingAgent = new TicketingAgent();

            Ticket ticket = ticketingAgent.GenerateTicket(passenger, bookingRequest, trainA);

            Console.WriteLine($"Пассажир: {passenger.FullName}");
            Console.WriteLine($"Пункт назначения: {bookingRequest.Destination}");
            Console.WriteLine($"Дата и время отправления: {bookingRequest.DepartureDateTime}");
            Console.WriteLine($"Выбранный поезд: {ticket.ChosenTrain.TrainID}");
            Console.WriteLine($"Общая стоимость: {ticket.TotalFare:C}");
            Console.ReadLine();
        }
    }
}