﻿using System;
using System.Collections.Generic;

namespace APP.DAL.Entities;

public partial class UserModel
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? AccessToken { get; set; }
    public string? NewPassword { get; set; }
}
