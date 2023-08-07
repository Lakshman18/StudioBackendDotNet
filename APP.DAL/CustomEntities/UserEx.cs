using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace APP.DAL.Entities;

public partial class User
{
    //public int Id { get; set; }
    //public string Email { get; set; }
    //public string Password { get; set; }
    [NotMapped]
    public string? AccessToken { get; set; }
    [NotMapped]
    public string? NewPassword { get; set; }
}
