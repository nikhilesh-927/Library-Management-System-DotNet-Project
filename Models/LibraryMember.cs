using System.ComponentModel.DataAnnotations;

namespace LibraryManagementMVC.Models;

public class LibraryMember
{
    public int MemberId { get; set; }

    [Required(ErrorMessage = "Member Name is required")]
    [Display(Name = "Member Name")]
    public string MemberName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Department is required")]
    public string Department { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please select a Book")]
    [Display(Name = "Book ID")]
    public int BookId { get; set; }

    [Required(ErrorMessage = "Issue Date is required")]
    [DataType(DataType.Date)]
    [Display(Name = "Issue Date")]
    public DateTime IssueDate { get; set; } = DateTime.Today;

    [DataType(DataType.Date)]
    [Display(Name = "Return Date")]
    public DateTime? ReturnDate { get; set; }

    public bool IsReturned { get; set; } = false;

    // Navigation property or referenced book title helper
    public Book? Book { get; set; }
}
