namespace TIMS.Inventory.SharedKernel.Common;

// source: https://github.com/jhewlett/ValueObject
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class IgnoreMemberAttribute : Attribute
//ignore member
{
}