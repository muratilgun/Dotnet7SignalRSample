using System.ComponentModel.DataAnnotations;

namespace Dotnet7SignalRSample.Models;

public class ChatRoom
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}