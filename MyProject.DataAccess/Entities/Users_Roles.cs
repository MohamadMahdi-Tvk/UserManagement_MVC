using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyProject.DataAccess.Entities;

public class Users_Roles : BaseEntity
{

    public int RoleId { get; set; }
    public Role Role { get; set; }


    public int UserId { get; set; }
    public User User { get; set; }
}

public class User_RolesConfiguration : BaseEntityConfiguration<Users_Roles>
{
    public override void Configure(EntityTypeBuilder<Users_Roles> builder)
    {
        builder.HasOne(p => p.Role)
            .WithMany(p => p.Users_Roles)
            .HasForeignKey(p => p.RoleId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.User)
            .WithMany(p => p.Users_Roles)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
