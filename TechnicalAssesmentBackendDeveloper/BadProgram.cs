namespace TechnicalAssesmentBackendDeveloper;

class Booking
{
    public string guestname;
    public string roomnumber;
    public DateTime checkindate;
    public DateTime checkoutdate;
    public int totaldays;
    public double rateperday;
    public double discount;
    public double totalamount;

    public void BookRoom(string name, string room, DateTime checkin, DateTime checkout, double rate, double discountRate)
    {
        guestname = name;
        roomnumber = room;
        checkindate = checkin;
        checkoutdate = checkout;
        rateperday = rate;
        discount = discountRate;

        totaldays = (checkout - checkin).Days;
        totalamount = totaldays * rateperday;
        totalamount = totalamount - (totalamount * discount / 100);

        LogBookingDetailsAsync();

        Console.WriteLine("Room Booked for " + guestname);
        Console.WriteLine("Room No: " + roomnumber);
        Console.WriteLine("Check-In: " + checkindate.ToString());
        Console.WriteLine("Check-Out: " + checkoutdate.ToString());
        Console.WriteLine("Total Days: " + totaldays);
        Console.WriteLine("Amount: " + totalamount);
    }

    public async Task LogBookingDetailsAsync()
    {
        // Simulate writing to a log file or remote system
        await Task.Delay(1000);
        Console.WriteLine("Booking log saved.");
    }

    public void Cancel()
    {
        guestname = null;
        roomnumber = null;
        checkindate = DateTime.MinValue;
        checkoutdate = DateTime.MinValue;
        rateperday = 0;
        discount = 0;
        totalamount = 0;

        Console.WriteLine("Booking cancelled");
    }
}

public static class AppHost
{
    static void Run(string[] args)
    {
        Booking b = new Booking();
        b.BookRoom("Alice", "101", DateTime.Now, DateTime.Now.AddDays(3), 150.5, 10);
        b.Cancel();
    }
}