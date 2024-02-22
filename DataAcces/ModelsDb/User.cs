using System;
using System.Collections.Generic;

namespace DataAcces.ModelsDb;

public partial class User
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? UserEmail { get; set; }
    public string? UserRol { get; set; }
    public string? AddressUser { get; set; }
    public string password {get; set;}
    public string? UserType { get; set; }
}
