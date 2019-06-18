using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolRenterCore.Database.Migrations
{
    public partial class AddedUserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfileTableAccess",
                columns: table => new
                {
                    UserProfileEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OwnerId = table.Column<int>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false),
                    ProfilePicture = table.Column<string>(nullable: false),
                    CreatedUtc = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedUtc = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileTableAccess", x => x.UserProfileEntityId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfileTableAccess");
        }
    }
}
