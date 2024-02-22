using System;
using System.Collections.Generic;

namespace DataAcces.ModelsDbAWS;

public partial class User
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? UserEmail { get; set; }

    public string? UserRol { get; set; }

    public string? AddressUser { get; set; }

    public string? UserType { get; set; }

    public string? Names { get; set; }

    public string? LastNames { get; set; }

    public string? Document { get; set; }

    public string? Password { get; set; }
}
