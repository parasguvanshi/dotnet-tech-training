using System.ComponentModel.DataAnnotations;

namespace SportsManagementApp.DTOs;

public class CreateSportDto
{
    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;
}

