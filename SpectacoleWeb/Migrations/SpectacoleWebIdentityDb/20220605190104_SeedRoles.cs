using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpectacoleWeb.Migrations.SpectacoleWebIdentityDb
{
    public partial class SeedRoles : Migration
    {
        private string AdminRoleId = Guid.NewGuid().ToString();
        private string ClientRoleId = Guid.NewGuid().ToString();

        private string User1Id = Guid.NewGuid().ToString();
        private string User2Id = Guid.NewGuid().ToString();

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRolesSQL(migrationBuilder);
            SeedUser(migrationBuilder);
            SeedUserRoles(migrationBuilder);
        }

        private void SeedRolesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"INSERT INTO [Identity].[Role] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{AdminRoleId}', 'Administrator', 'ADMINISTRATOR', null);");
            migrationBuilder.Sql(@$"INSERT INTO [Identity].[Role] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{ClientRoleId}', 'Client', 'CLIENT', null);");
        }

        private void SeedUser(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"INSERT [Identity].[User] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], 
            [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], 
            [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name]) VAlUES (N'{User1Id}', N'Test2', N'TEST2', N'test2@test.com', 
            N'TEST2@TEST.COM', 0, N'AQAAAAEAACcQAAAAEKqq0zt4Stnt//hNliMAggaKy3IVKgVJ+dUUAmL2/6fegkI10tLLu10cRqwzNld2Lw==',
            N'JLCWVKYV36XLBL7KSE6LOVM3G2B6Y4LU', N'26e4a235-5a73-4bc1-b5b7-35d3cf61ba46', NULL, 0, 0, NULL, 1, 0, N'Costel')");
            migrationBuilder.Sql(@$"INSERT [Identity].[User] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], 
            [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], 
            [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name]) VAlUES (N'{User2Id}', N'Test3', N'TEST3', N'test3@test.com', 
            N'TEST3@TEST.COM', 0, N'AQAAAAEAACcQAAAAEKqq0zt4Stnt//hNliMAggaKy3IVKgVJ+dUUAmL2/6fegkI10tLLu10cRqwzNld2Lw==',
            N'JLCWVKYV36XLBL7KSE6LOVM3G2B6Y4LU', N'26e4a235-5a73-4bc1-b5b7-35d3cf61ba46', NULL, 0, 0, NULL, 1, 0, N'Marian')");
        }

        private void SeedUserRoles(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
            INSERT INTO [Identity].[UserRoles]
                ([UserId],
                 [RoleId])
            VALUES
                ('{User1Id}', '{AdminRoleId}');");

            migrationBuilder.Sql($@"
            INSERT INTO [Identity].[UserRoles]
                ([UserId],
                 [RoleId])
            VALUES
                ('{User2Id}', '{AdminRoleId}');");

            migrationBuilder.Sql($@"
            INSERT INTO [Identity].[UserRoles]
                ([UserId],
                 [RoleId])
            VALUES
                ('171b83e7-15b0-4c71-954f-785f7799db24', '{ClientRoleId}');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
