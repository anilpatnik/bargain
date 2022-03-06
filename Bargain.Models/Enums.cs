namespace Bargain.Models
{
    public enum ActionType
    {
        Saved     = 1,
        Submitted = 2,
        Approved  = 3,
        Rejected  = 4,
    }

    public enum AuthType
    {
        Email =    1,
        Google =   2,
        Facebook = 3,
    }

    public enum DiscountType
    {
        Price      = 1,
        Percentage = 2,
    }

    public enum FileType
    {
        Bmp  = 1,
        Gif  = 2,
        Jpeg = 3,
        Png  = 4,
    }

    public enum RoleType
    {
        Customer   = 1,
        Merchant   = 2,
        SiteAdmin  = 5, 
        DataAdmin  = 10,
    }        

    public enum TimezoneType
    {
        AWST = +16,  // Australian Western Standard Time
        ACST = +19,  // Australian Central Standard Time
        AEST = +20,  // Australian Eastern Standard Time
        NZST = +24,  // New Zealand Standard Time
    }
}
