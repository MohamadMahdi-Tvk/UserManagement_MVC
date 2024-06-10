using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyProject.DataAccess.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public ICollection<Users_Roles> Users_Roles { get; set; }

}

public class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(p => p.FirstName).HasMaxLength(20);
        builder.Property(p => p.LastName).HasMaxLength(30);
    }
}
