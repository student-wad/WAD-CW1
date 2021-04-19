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
        [Display(Name = "L1")]
        L1,
        [Display(Name = "L2")]
        L2,
        [Display(Name = "L3")]
        L3
    }

    public enum GroupTime
    {
        [Display(Name ="9:00-11:00")]
        _9am,
        [Display(Name ="11:00-13:00")]
        _11am,
        [Display(Name ="15:00-17:00")]
        _3pm,
        [Display(Name ="17:00-19:00")]
        _5pm,
        [Display(Name ="19:00-21:00")]
        _7pm
    }

    public enum GroupStatus
    {
        [Display(Name = "Not Full")]
        NotFull,
        [Display(Name = "Full")]
        Full
    }

    public enum PaymentStatus
    {
        [Display(Name ="Paid")]
        Paid,
        [Display(Name="Not Paid")]
        Not_Paid
    }

    public enum CourseLevel
    {
        [Display(Name = "IELTS")]
        IELTS,
        [Display(Name = "General English")]
        GeneralEnglish
    }
}
