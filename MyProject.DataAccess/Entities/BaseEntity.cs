﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyProject.DataAccess.Entities;

public interface IBaseEntity
{
    public int Id { get; set; }
    public DateTime InsertDate { get; set; }
    public DateTime UpdateTime { get; set; }
    public bool IsDeleted { get; set; }

}
public class BaseEntity : IBaseEntity
{
    public int Id { get; set; }
    public DateTime InsertDate { get; set; } = DateTime.Now;
    public DateTime UpdateTime { get; set; } = DateTime.Now;
    public bool IsDeleted { get; set; } = false;

}

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(p => p.Id);
    }
}
