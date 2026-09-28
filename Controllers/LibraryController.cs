namespace LibraryManagementMVC.Controllers;

public class LibraryController : Controller
{
    // In-memory static storage for sample/demonstration purposes
    private static readonly List<Book> _books = new()
    {
        new Book { BookId = 101, Title = "Clean Code", Author = "Robert C. Martin", Category = "Software Engineering", Price = 599.00m, AvailableCopies = 5 },
        new Book { BookId = 102, Title = "Design Patterns", Author = "Erich Gamma et al.", Category = "Software Architecture", Price = 750.00m, AvailableCopies = 3 },
        new Book { BookId = 103, Title = "ASP.NET Core in Action", Author = "Andrew Lock", Category = "Web Development", Price = 899.00m, AvailableCopies = 4 },
        new Book { BookId = 104, Title = "Introduction to Algorithms", Author = "Thomas H. Cormen", Category = "Computer Science", Price = 1200.00m, AvailableCopies = 2 },
        new Book { BookId = 105, Title = "Modern Operating Systems", Author = "Andrew S. Tanenbaum", Category = "Systems", Price = 650.00m, AvailableCopies = 6 },
        new Book { BookId = 106, Title = "Artificial Intelligence: A Modern Approach", Author = "Stuart Russell", Category = "AI & ML", Price = 1150.00m, AvailableCopies = 4 },
        new Book { BookId = 107, Title = "Database System Concepts", Author = "Abraham Silberschatz", Category = "Databases", Price = 820.00m, AvailableCopies = 5 },
        new Book { BookId = 108, Title = "Computer Networking: A Top-Down Approach", Author = "James Kurose", Category = "Networking", Price = 790.00m, AvailableCopies = 3 },
        new Book { BookId = 109, Title = "Head First Java", Author = "Kathy Sierra", Category = "Programming", Price = 499.00m, AvailableCopies = 7 },
        new Book { BookId = 110, Title = "Python Crash Course", Author = "Eric Matthes", Category = "Programming", Price = 450.00m, AvailableCopies = 8 }
    };

    private static readonly List<LibraryMember> _issuedBooks = new()
    {
        new LibraryMember { MemberId = 1, MemberName = "Rahul Sharma", Department = "Computer Science", Email = "rahul.sharma@college.edu", BookId = 101, IssueDate = DateTime.Today.AddDays(-10), ReturnDate = DateTime.Today.AddDays(-2), IsReturned = false },
        new LibraryMember { MemberId = 2, MemberName = "Priya Patel", Department = "Information Technology", Email = "priya.patel@college.edu", BookId = 103, IssueDate = DateTime.Today.AddDays(-5), ReturnDate = DateTime.Today.AddDays(1), IsReturned = false },
        new LibraryMember { MemberId = 3, MemberName = "Ankit Verma", Department = "Electronics", Email = "ankit.verma@college.edu", BookId = 102, IssueDate = DateTime.Today.AddDays(-15), ReturnDate = DateTime.Today.AddDays(-5), IsReturned = true },
        new LibraryMember { MemberId = 4, MemberName = "Sneha Gupta", Department = "Computer Science", Email = "sneha.gupta@college.edu", BookId = 104, IssueDate = DateTime.Today.AddDays(-1), ReturnDate = null, IsReturned = false },
        new LibraryMember { MemberId = 5, MemberName = "Aarav Mehta", Department = "Mechanical", Email = "aarav.mehta@college.edu", BookId = 105, IssueDate = DateTime.Today.AddDays(-12), ReturnDate = DateTime.Today.AddDays(-4), IsReturned = false },
        new LibraryMember { MemberId = 6, MemberName = "Kavya Singh", Department = "Civil", Email = "kavya.singh@college.edu", BookId = 106, IssueDate = DateTime.Today.AddDays(-6), ReturnDate = DateTime.Today.AddDays(2), IsReturned = false },
        new LibraryMember { MemberId = 7, MemberName = "Rohan Das", Department = "Information Technology", Email = "rohan.das@college.edu", BookId = 107, IssueDate = DateTime.Today.AddDays(-20), ReturnDate = DateTime.Today.AddDays(-8), IsReturned = true },
        new LibraryMember { MemberId = 8, MemberName = "Isha Nair", Department = "Electronics", Email = "isha.nair@college.edu", BookId = 108, IssueDate = DateTime.Today.AddDays(-3), ReturnDate = DateTime.Today.AddDays(3), IsReturned = false },
        new LibraryMember { MemberId = 9, MemberName = "Vikram Joshi", Department = "Computer Science", Email = "vikram.joshi@college.edu", BookId = 109, IssueDate = DateTime.Today.AddDays(-8), ReturnDate = DateTime.Today.AddDays(-1), IsReturned = false },
        new LibraryMember { MemberId = 10, MemberName = "Neha Kulkarni", Department = "Mechanical", Email = "neha.kulkarni@college.edu", BookId = 110, IssueDate = DateTime.Today.AddDays(-2), ReturnDate = DateTime.Today.AddDays(5), IsReturned = false },
        new LibraryMember { MemberId = 11, MemberName = "Aditya Rao", Department = "Civil", Email = "aditya.rao@college.edu", BookId = 101, IssueDate = DateTime.Today.AddDays(-14), ReturnDate = DateTime.Today.AddDays(-3), IsReturned = false },
        new LibraryMember { MemberId = 12, MemberName = "Pooja Reddy", Department = "Information Technology", Email = "pooja.reddy@college.edu", BookId = 102, IssueDate = DateTime.Today.AddDays(-7), ReturnDate = DateTime.Today.AddDays(0), IsReturned = false },
        new LibraryMember { MemberId = 13, MemberName = "Siddharth Malhotra", Department = "Computer Science", Email = "siddharth.m@college.edu", BookId = 103, IssueDate = DateTime.Today.AddDays(-18), ReturnDate = DateTime.Today.AddDays(-6), IsReturned = true },
        new LibraryMember { MemberId = 14, MemberName = "Divya Saxena", Department = "Electronics", Email = "divya.saxena@college.edu", BookId = 104, IssueDate = DateTime.Today.AddDays(-4), ReturnDate = DateTime.Today.AddDays(2), IsReturned = false },
        new LibraryMember { MemberId = 15, MemberName = "Karan Kapoor", Department = "Mechanical", Email = "karan.kapoor@college.edu", BookId = 105, IssueDate = DateTime.Today.AddDays(-11), ReturnDate = DateTime.Today.AddDays(-1), IsReturned = false },
        new LibraryMember { MemberId = 16, MemberName = "Meera Deshmukh", Department = "Civil", Email = "meera.d@college.edu", BookId = 106, IssueDate = DateTime.Today.AddDays(-2), ReturnDate = null, IsReturned = false },
        new LibraryMember { MemberId = 17, MemberName = "Varun Sen", Department = "Information Technology", Email = "varun.sen@college.edu", BookId = 107, IssueDate = DateTime.Today.AddDays(-9), ReturnDate = DateTime.Today.AddDays(-2), IsReturned = false },
        new LibraryMember { MemberId = 18, MemberName = "Ritu Agarwal", Department = "Computer Science", Email = "ritu.agarwal@college.edu", BookId = 108, IssueDate = DateTime.Today.AddDays(-16), ReturnDate = DateTime.Today.AddDays(-4), IsReturned = true },
        new LibraryMember { MemberId = 19, MemberName = "Harsh Vardhan", Department = "Electronics", Email = "harsh.v@college.edu", BookId = 109, IssueDate = DateTime.Today.AddDays(-5), ReturnDate = DateTime.Today.AddDays(1), IsReturned = false },
        new LibraryMember { MemberId = 20, MemberName = "Ananya Iyer", Department = "Mechanical", Email = "ananya.iyer@college.edu", BookId = 110, IssueDate = DateTime.Today.AddDays(-13), ReturnDate = DateTime.Today.AddDays(-5), IsReturned = false },
        new LibraryMember { MemberId = 21, MemberName = "Tushar Bhatia", Department = "Civil", Email = "tushar.bhatia@college.edu", BookId = 101, IssueDate = DateTime.Today.AddDays(-3), ReturnDate = DateTime.Today.AddDays(4), IsReturned = false },
        new LibraryMember { MemberId = 22, MemberName = "Shruti Roy", Department = "Computer Science", Email = "shruti.roy@college.edu", BookId = 102, IssueDate = DateTime.Today.AddDays(-22), ReturnDate = DateTime.Today.AddDays(-10), IsReturned = true },
        new LibraryMember { MemberId = 23, MemberName = "Manish Pandey", Department = "Information Technology", Email = "manish.p@college.edu", BookId = 103, IssueDate = DateTime.Today.AddDays(-7), ReturnDate = DateTime.Today.AddDays(-1), IsReturned = false },
        new LibraryMember { MemberId = 24, MemberName = "Simran Kaur", Department = "Electronics", Email = "simran.kaur@college.edu", BookId = 104, IssueDate = DateTime.Today.AddDays(-1), ReturnDate = DateTime.Today.AddDays(6), IsReturned = false },
        new LibraryMember { MemberId = 25, MemberName = "Alok Tripathi", Department = "Mechanical", Email = "alok.tripathi@college.edu", BookId = 105, IssueDate = DateTime.Today.AddDays(-10), ReturnDate = DateTime.Today.AddDays(0), IsReturned = false }
    };

    // GET: /Library/Index or /
    public IActionResult Index()
    {
        // Ensure Book navigation property is linked for display
        foreach (var member in _issuedBooks)
        {
            if (member.Book == null)
            {
                member.Book = _books.FirstOrDefault(b => b.BookId == member.BookId);
            }
        }
        return View(_issuedBooks);
    }

    // GET: /Library/IssueBook
    public IActionResult IssueBook()
    {
        ViewBag.Books = _books;
        var model = new LibraryMember
        {
            IssueDate = DateTime.Today,
            ReturnDate = DateTime.Today.AddDays(7)
        };
        return View(model);
    }

    // POST: /Library/IssueBook
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult IssueBook(LibraryMember member)
    {
        var selectedBook = _books.FirstOrDefault(b => b.BookId == member.BookId);
        if (selectedBook == null)
        {
            ModelState.AddModelError("BookId", "Invalid book selected.");
        }
        else if (selectedBook.AvailableCopies <= 0)
        {
            ModelState.AddModelError("BookId", "No copies available for this book.");
        }

        if (!ModelState.IsValid)
        {
            ViewBag.Books = _books;
            return View(member);
        }

        member.MemberId = _issuedBooks.Any() ? _issuedBooks.Max(m => m.MemberId) + 1 : 1;
        member.Book = selectedBook;
        if (selectedBook != null && selectedBook.AvailableCopies > 0)
        {
            selectedBook.AvailableCopies--;
        }

        _issuedBooks.Add(member);
        TempData["SuccessMessage"] = $"Book '{selectedBook?.Title}' successfully issued to {member.MemberName}!";

        return RedirectToAction(nameof(Index));
    }

    // GET: /Library/BookDetails/1
    public IActionResult BookDetails(int id)
    {
        var member = _issuedBooks.FirstOrDefault(m => m.MemberId == id);
        if (member == null)
        {
            return NotFound();
        }

        if (member.Book == null)
        {
            member.Book = _books.FirstOrDefault(b => b.BookId == member.BookId);
        }

        return View(member);
    }

    // POST: /Library/ReturnBook/1
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ReturnBook(int id)
    {
        var member = _issuedBooks.FirstOrDefault(m => m.MemberId == id);
        if (member != null)
        {
            member.IsReturned = true;
            if (!member.ReturnDate.HasValue)
            {
                member.ReturnDate = DateTime.Today;
            }
            TempData["SuccessMessage"] = $"Book '{member.Book?.Title}' issued to {member.MemberName} has been marked as returned.";
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: /Library/About
    public IActionResult About()
    {
        ViewBag.TotalBooks = _books.Count;
        ViewBag.TotalIssued = _issuedBooks.Count;
        ViewBag.TotalReturned = _issuedBooks.Count(m => m.IsReturned);
        return View();
    }
}
