using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyProject.DataAccess.Entities;

public class Role : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public ICollection<Users_Roles> Users_Roles { get; set; }

}

public class RoleConfiguration: BaseEntityConfiguration<Role>
{
    public override void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(new Role { Id = 1, Title = UserRole.Admin });
        builder.HasData(new Role { Id = 2, Title = UserRole.Operator });
    }
}

public static class UserRole
{
    public const string Admin = "Admin";
    public const string Operator = "Operator";
}