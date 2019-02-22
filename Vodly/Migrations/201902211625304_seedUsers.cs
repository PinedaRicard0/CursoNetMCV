namespace Vodly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ba1bc633-4d90-4926-89cf-2461e2533e14', N'guest@vidly.com', 0, N'AKctrc9RUSPao1XpvX8ybCEohykAK4pTTfCulnbwTcoIZOKNq96Q9xvgyd/L5k3rkg==', N'c6a5a157-5b74-4dd8-ac4b-d5b909704fa0', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f49e402b-73ce-4853-aa6e-a9c8017f5925', N'admin@vidly.com', 0, N'AGWu0lI4ngb5dYgv6efxjhBtRTiybthMlfUOxT3Rp6cS08FtgstHDtknqJ5DesjI2Q==', N'6890d4f8-b80c-48cb-8fc6-fe0da13b6cce', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'fad384ae-0bbd-4a1b-983c-e13c02acb5f5', N'CanManageMovies')

                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f49e402b-73ce-4853-aa6e-a9c8017f5925', N'fad384ae-0bbd-4a1b-983c-e13c02acb5f5')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
