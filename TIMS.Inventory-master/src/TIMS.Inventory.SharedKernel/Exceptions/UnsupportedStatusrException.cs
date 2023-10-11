namespace TIMS.Inventory.SharedKernel.Exceptions;

public class UnsupportedStatusrException : CMSException
{
    public UnsupportedStatusrException(string code)
        : base($"Status \"{code}\" is unsupported.")
    {
    }
}