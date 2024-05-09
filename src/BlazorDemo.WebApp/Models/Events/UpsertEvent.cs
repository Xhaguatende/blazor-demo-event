// -------------------------------------------------------------------------------------
//  <copyright file="UpsertEvent.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.WebApp.Models.Events;

using System.ComponentModel.DataAnnotations;

public record UpsertEvent
{
    [Required]
    [StringLength(1000)]
    public string Description { get; set; } = default!;
    public Guid? Id { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; } = default!;
}