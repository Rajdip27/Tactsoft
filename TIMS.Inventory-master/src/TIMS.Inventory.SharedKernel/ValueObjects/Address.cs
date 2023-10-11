using Microsoft.EntityFrameworkCore;
using TIMS.Inventory.SharedKernel.Common;

namespace TIMS.Inventory.SharedKernel.ValueObjects;

[Owned]
public class Address : ValueObject
{
    public Address()
    {
    }

    public Address(string street, string city, string state, string country, string zipCode)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
    }

    public string City { get; } = string.Empty;
    public string Country { get; } = string.Empty;
    public string State { get; } = string.Empty;
    public string Street { get; } = string.Empty;
    public string ZipCode { get; } = string.Empty;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        // Using a yield return statement to return each element one at a time
        yield return Street;
        yield return City;
        yield return State;
        yield return Country;
        yield return ZipCode;
    }
}