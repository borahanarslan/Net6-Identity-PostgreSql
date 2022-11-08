using Microsoft.AspNetCore.Identity;

namespace PostgreSql.Models
{
    public partial class ApplicationUser : IdentityUser<Guid>
    {
        public override Guid Id { get; set; } = Guid.NewGuid();
    }
}
