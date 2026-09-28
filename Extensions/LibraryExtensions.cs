namespace LibraryManagementMVC.Extensions;

public static class LibraryExtensions
{
    public static string GetDueStatus(this LibraryMember member)
    {
        if (member == null) return "Issued";
        return GetDueStatus(member.ReturnDate, member.IsReturned);
    }

    public static string GetDueStatus(this DateTime? returnDate, bool isReturned = false)
    {
        if (isReturned)
        {
            return "Returned";
        }

        if (!returnDate.HasValue)
        {
            return "Issued";
        }

        DateTime today = DateTime.Today;
        DateTime date = returnDate.Value.Date;

        if (date < today)
        {
            return "Overdue";
        }
        else if (date >= today && date <= today.AddDays(3))
        {
            return "Due Soon";
        }
        else
        {
            return "Issued";
        }
    }

    public static decimal CalculateFine(this LibraryMember member)
    {
        if (member == null) return 0m;
        return CalculateFine(member.ReturnDate, member.IsReturned);
    }

    public static decimal CalculateFine(this DateTime? returnDate, bool isReturned = false)
    {
        if (!isReturned && returnDate.HasValue)
        {
            DateTime today = DateTime.Today;
            DateTime date = returnDate.Value.Date;

            if (date < today)
            {
                int overdueDays = (today - date).Days;
                return overdueDays * 10m;
            }
        }

        return 0m;
    }
}
