using System.ComponentModel.DataAnnotations;
using Domain.Repositories;

namespace Domain.Entities;

public class Todo: BaseEntity
{
    [MaxLength(255)]
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}