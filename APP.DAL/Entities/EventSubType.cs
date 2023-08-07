using System;
using System.Collections.Generic;

namespace APP.DAL.Entities;

public partial class EventSubType
{
    public int Id { get; set; }

    public int EventTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual EventType EventType { get; set; } = null!;
}
