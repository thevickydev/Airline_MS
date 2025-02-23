using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARS.Models
{
    [Table("AdminLoginTable")]
    public class AdminPanel
    {
        [Key]
        public int AdminId { get; set; }

        [Required(ErrorMessage = "User Name Required")]
        [Display(Name = "User Name")]
        public string? AdName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Min 5 Char Required"), MaxLength(10, ErrorMessage = "Max 10 Char Required")]
        public string? Password { get; set; }
    }

    [Table("UserLoginTable")]
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is Required")]
        [MinLength(5, ErrorMessage = "Min 5 Char Required"), MaxLength(20, ErrorMessage = "Max 20 Char Required")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        [MinLength(5, ErrorMessage = "Min 5 Char Required"), MaxLength(20, ErrorMessage = "Max 20 Char Required")]
        public string? LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Format")]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is Required")]
        [MinLength(6, ErrorMessage = "Min 6 Char Required"), MaxLength(20, ErrorMessage = "Max 20 Char Required")]
        public string? Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password not matched")]
        public string? CPassword { get; set; }

        [Required(ErrorMessage = "Age Required")]
        [Range(18, 90, ErrorMessage = "Min 18 years to book the flight")]
        public int Age { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is Required")]
        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Phone No is not Valid")]
        [StringLength(11)]
        public string? PhoneNo { get; set; }

        [Display(Name = "CNIC Number")]
        [Required(ErrorMessage = "CNIC Number is Required")]
        [RegularExpression(@"^([0-9]{13})$", ErrorMessage = "CNIC No is not Valid")]
        [StringLength(13)]
        public string? CNo { get; set; }

        public List<Flight>? FlightBookings { get; set; }
    }

    public class AeroPlaneInfo
    {
        [Key]
        public int PlaneId { get; set; }

        [Display(Name = "AirPlane")]
        [Required(ErrorMessage = "AirPlane Name is Required")]
        [MinLength(5, ErrorMessage = "Min 5 Char Required"), MaxLength(20, ErrorMessage = "Max 20 Char Required")]
        public string? APlaneName { get; set; }

        [Required(ErrorMessage = "Capacity is Required")]
        [Display(Name = "Seating Capacity")]
        public int SeatingCapacity { get; set; }

        [Required(ErrorMessage = "Price is Required")]
        public float Price { get; set; }

        public virtual ICollection<TicketReserve_tbl>? TicketReserve_tbls { get; set; }
    }

    [Table("FlightBookTable")]
    public class FlightBooking
    {
        [Key]
        public int bid { get; set; }

        [Required, Display(Name = "Customer Name")]
        public string? CusName { get; set; }

        [Display(Name = "Customer Address")]
        public string? CusAddress { get; set; }

        [Required, Display(Name = "Customer Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Format")]
        public string? CusEmail { get; set; }

        [Required, Display(Name = "No. of Seats")]
        public string? CusSeat { get; set; }

        [Required, Display(Name = "Phone Number")]
        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Invalid Phone Number")]
        public string? CusPhone { get; set; }

        [Required, Display(Name = "CNIC Number")]
        [RegularExpression(@"^([0-9]{13})$", ErrorMessage = "Invalid CNIC Number")]
        public string? CusCnic { get; set; }

        public int ResId { get; set; }
        public string? bCusName { get; set; }

        [Required, Display(Name = "Departure Time")]
        public string? DTime { get; set; }

        
        public int Price { get; set; }

        public int Planeid { get; set; }
        public virtual AeroPlaneInfo? PlaneInfo { get; set; }

        [Display(Name = "Seat Type")]
        [StringLength(25)]
        public string? SeatType { get; set; }

        public virtual TicketReserve_tbl? TicketReserve_tbls { get; set; }
    }

    public class TicketReserve_tbl
    {
        [Key]
        public int ResId { get; set; }

        [Required(ErrorMessage = "From Location Required")]
        public string? From { get; set; }

        [Display(Name = "To")]
        [Required(ErrorMessage = "Destination Required")]
        [StringLength(40, ErrorMessage = "Max 40 Char Allowed")]
        public string? To { get; set; }

        [Display(Name = "Departure Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Departure Date Required")]
        public string? ResDate { get; set; }

        [Display(Name = "Flight Time")]
        [Required(ErrorMessage = "Flight Time Required")]
        public string? ResFtime { get; set; }

       
        [Required, Display(Name = "Plane No")]
        public int PlaneId { get; set; }

        public virtual AeroPlaneInfo? plane_tbls { get; set; }

        [Required, Display(Name = "Available Seats")]
        public int PlaneSeat { get; set; }

        [Required, Display(Name = "Price")]
        public float ResTicketPrice { get; set; }

        [Required, Display(Name = "Plane Type")]
        public int ResPlaneType { get; set; }

        public virtual ICollection<FlightBooking>? FlightBookings { get; set; }
    }

    public class Flight
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        public string? CusName { get; set; }

        [Required, EmailAddress]
        public string? CusEmail { get; set; }

        [Required]
        public string? CusPhone { get; set; }

        [Required]
        public string? CusCnic { get; set; }

        [Required]
        public string? From { get; set; }

        [Required]
        public string? To { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public int PlaneId { get; set; }

        [Required]
        public string? PlaneSeat { get; set; }

        [Required]
        public double TicketPrice { get; set; }

        public string? SeatType { get; set; }

        // Foreign Key for User
        [ForeignKey("UserAccount")]
        public int UserID { get; set; }
        public UserAccount? UserAccount { get; set; }
    }
}
