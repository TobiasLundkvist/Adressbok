namespace Adressbok_ConsoleApp.Interfaces;

internal interface IContact
{
    Guid Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    string PhoneNumber { get; set; }
    string Address { get; set; }
    string PostalCode { get; set; }
    string City { get; set; }

}
