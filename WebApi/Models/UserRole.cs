using System.Text.Json.Serialization;

namespace WebApiRouteResponses.Models;

public class UserRole
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Role { get; set; }
    public bool Active { get; set; } = true;
    public Guid UserId { get; set; }
    public string? Description { get; set; }
    public virtual User? User { get; set; }

}
