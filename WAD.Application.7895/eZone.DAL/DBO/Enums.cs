using System.ComponentModel.DataAnnotations;


namespace eZone.DAL.DBO
{
    public enum GroupDays
    {
        [Display(Name="Mon/Wed/Fri")]
        Odd,
        [Display(Name ="Tue/Thu/Sat")]
        Even
    }

    public enum GroupLevel
    {
        L1,
        L2,
        L3
    }

    public enum GroupTime
    {
        [Display(Name ="9:00 - 11:00")]
        _9am,
        [Display(Name ="11:00 - 13:00")]
        _11am,
        [Display(Name ="15:00 - 17:00")]
        _3pm,
        [Display(Name ="17:00 - 19:00")]
        _5pm,
        [Display(Name ="19:00 - 21:00")]
        _7pm
    }

    public enum GroupStatus
    {
        Available,
        Full
    }

    public enum PaymentStatus
    {
        Paid,
        [Display(Name="Not Paid")]
        Not_Paid
    }

    public enum CourseLevel
    {
        IELTS,
        [Display(Name = "General English")]
        GeneralEnglish
    }
}
