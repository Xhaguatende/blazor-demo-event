// -------------------------------------------------------------------------------------
//  <copyright file="SignInRequest.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.WebApp.Models.Accounts;

using System.ComponentModel.DataAnnotations;

public class SignInRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}