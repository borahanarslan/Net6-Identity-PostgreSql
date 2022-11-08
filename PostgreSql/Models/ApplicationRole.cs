using Microsoft.AspNetCore.Identity;

namespace PostgreSql.Models
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public override Guid Id { get; set; } = Guid.NewGuid();
    }
}
