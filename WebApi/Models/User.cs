using System.Text.Json.Serialization;

namespace WebApiRouteResponses.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public DateTime? CreationDate { get; set; } = DateTime.Now;
    public int Age { get; set; }
    public string? Phone { get; set; }
    public bool Active { get; set; } = true;
    public virtual ICollection<UserRole>? UserRoles { get; set; }
}
