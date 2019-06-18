using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToolRenterCore.Database.Entities.Equipment;
using ToolRenterCore.Database.Entities.EquipmentType;
using ToolRenterCore.Database.Entities.People;
using ToolRenterCore.Database.Entities.Request;
using ToolRenterCore.Database.Entities.Roles;
using ToolRenterCore.Database.Entities.UserProfile;

namespace ToolRenterCore.Database.Contexts
{
    public class ToolRenterContext : IdentityDbContext
        <UserEntity,
        RoleEntity,
        int,
        IdentityUserClaim<int>,
        UserRoleEntity,
        IdentityUserLogin<int>,
        IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        public ToolRenterContext(DbContextOptions<ToolRenterContext> options)
            : base(options) { }

        public DbSet<UserEntity> UserTableAccess { get; set; }
        public DbSet<EquipmentEntity> EquipmentTableAccess { get; set; }
        public DbSet<EquipmentTypeEntity> EquipmentTypeTableAccess { get; set; }
        public DbSet<RequestEntity> RequestTableAccess { get; set; }
        public DbSet<UserProfileEntity> UserProfileTableAccess { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRoleEntity>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<EquipmentTypeEntity>().HasData(
                new { EquipmentTypeEntityId = 1, EquipmentTypeString = "Water Animal" },
                new { EquipmentTypeEntityId = 2, EquipmentTypeString = "Land Animal" });
        }
    }
}
