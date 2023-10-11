namespace TIMS.Inventory.SharedKernel.Exceptions;

public class CMSException : Exception
{
    public CMSException()
    {
    }

    public CMSException(string message)
        : base(message)
    {
    }

    public CMSException(string message, Exception inner)
        : base(message, inner)
    {
    }

    public string ExtraErrorInfo { get; set; } = string.Empty;
}