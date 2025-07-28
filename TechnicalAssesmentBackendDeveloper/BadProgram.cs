namespace TechnicalAssesmentBackendDeveloper;

class Booking
{
    public string? GuestName { get; private set; }
    public string? RoomNumber { get; private set; }
    public DateTime CheckInDate { get; private set; }
    public DateTime CheckOutDate { get; private set; }
    public int TotalDays { get; private set; }
    public double RatePerDay { get; private set; }
    public double DiscountRate { get; private set; }
    public double TotalAmount { get; private set; }

    public void BookRoom(
        string guestName,
        string roomNumber,
        DateTime checkInDate,
        DateTime checkOutDate,
        double ratePerDay,
        double discountRate)
    {
        ValidateBookingInput(
            guestName,
            roomNumber,
            checkInDate,
            checkOutDate,
            ratePerDay,
            discountRate);

        GuestName = guestName;
        RoomNumber = roomNumber;
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        RatePerDay = ratePerDay;
        DiscountRate = discountRate;

        CalculateBookingDetails();

        LogBookingDetailsAsync();

        DisplayBookingDetails();
    }

    public async Task LogBookingDetailsAsync()
    {
        // Simulate writing to a log file or remote system
        await Task.Delay(1000);
        Console.WriteLine("Booking log saved.");
    }

    private void ValidateBookingInput(
        string guestName,
        string roomNumber,
        DateTime checkInDate,
        DateTime checkOutDate,
        double ratePerDay,
        double discountRate)
    {
        if (string.IsNullOrWhiteSpace(guestName))
            throw new ArgumentException("Guest name cannot be empty.", nameof(guestName));

        if (string.IsNullOrWhiteSpace(roomNumber))
            throw new ArgumentException("Room number cannot be empty.", nameof(roomNumber));

        if (checkInDate >= checkOutDate)
            throw new ArgumentException("Check-out date must be after check-in date.");

        if (checkInDate.Date < DateTime.Now.Date)
            throw new ArgumentException("Check-in date cannot be in the past.");

        if (ratePerDay <= 0)
            throw new ArgumentException("Rate per day must be positive.", nameof(ratePerDay));

        if (discountRate < 0 || discountRate > 100)
            throw new ArgumentException("Discount rate must be between 0 and 100.", nameof(discountRate));
    }

    private void CalculateBookingDetails()
    {
        double discountAmount = 0;

        TotalDays = (CheckOutDate - CheckInDate).Days;
        TotalAmount = TotalDays * RatePerDay;
        discountAmount = TotalAmount * (DiscountRate / 100);
        TotalAmount = TotalAmount - discountAmount;
    }

    public void DisplayBookingDetails()
    {
        Console.WriteLine("Booking Details:");
        Console.WriteLine($"Guest Name: {GuestName}");
        Console.WriteLine($"Room Number: {RoomNumber}");
        Console.WriteLine($"Check-In: {CheckInDate:yyyy-MM-dd}");
        Console.WriteLine($"Check-Out: {CheckOutDate:yyyy-MM-dd}");
        Console.WriteLine($"Total Days: {TotalDays}");
        Console.WriteLine($"Rate Per Day: RM {RatePerDay:F2}");
        Console.WriteLine($"Discount Rate: {DiscountRate}%");
        Console.WriteLine($"Total Amount: RM {TotalAmount:F2}");
    }

    public void CancelBooking()
    {
        Console.WriteLine($"Cancelling booking for {GuestName}.");

        GuestName = null;
        RoomNumber = null;
        CheckInDate = DateTime.MinValue;
        CheckOutDate = DateTime.MinValue;
        RatePerDay = 0;
        DiscountRate = 0;
        TotalAmount = 0;

        Console.WriteLine("Booking cancelled successfully.");
    }
}

public static class AppHost
{
    static void Run(string[] args)
    {
        Booking booking = new Booking();

        booking.BookRoom(
            guestName: "Alice",
            roomNumber: "101",
            checkInDate: DateTime.Now,
            checkOutDate: DateTime.Now.AddDays(3),
            ratePerDay: 150.5,
            discountRate: 10);

        booking.CancelBooking();
    }
}