using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace APP.DAL.Entities;

public partial class EventSubType
{
    [NotMapped]
    public string? EventTypeName { get; set; }
}
