namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cad9bc45-d07b-47f3-9c16-347bcf1b5f9e', N'admin@vidly.com', 0, N'ANeP51vKuMz7a1g+bl48MMF52Mtps7n2DqSHRBEWaufPCsf2puTatlmh4NttA5DInA==', N'8539b4f4-267d-4bbd-ad61-bc1bc3a391fb', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f3ed49dd-553a-472c-844f-3e905fd174e4', N'guest@vildy.com', 0, N'AIy96NCrz3+T66DQL78oCsb0n2UCjzl2lACnGNXJFL+vmCih9UAaMUkv124bHNJdbQ==', N'c1f96c6a-85f7-4c52-b7c1-511eda28f269', NULL, 0, 0, NULL, 1, 0, N'guest@vildy.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9c072ca2-80d8-44c1-8c7b-03aeb1ceb2e0', N'CanManageMovies')


INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cad9bc45-d07b-47f3-9c16-347bcf1b5f9e', N'9c072ca2-80d8-44c1-8c7b-03aeb1ceb2e0')

");
        }
        
        public override void Down()
        {
        }
    }
}
