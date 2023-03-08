using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.Infrastructure.Migrations
{
    public partial class test6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCompany",
                columns: table => new
                {
                    AppCompanyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MersisNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxAdministration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyFounded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DealStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DealEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumberOfEmployees = table.Column<int>(type: "int", nullable: false),
                    CompanyPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sector = table.Column<int>(type: "int", nullable: false),
                    CompanyTitle = table.Column<int>(type: "int", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCompany", x => x.AppCompanyID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sector = table.Column<int>(type: "int", nullable: false),
                    Department = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AppCompany_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "AppCompany",
                        principalColumn: "AppCompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserAdvance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ReplyDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ApprovalDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    AdvanceType = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserAdvance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserAdvance_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0e881658-a975-4e9a-896c-85e76a3810a6"), "1122e9ed-250d-4ef5-8223-c1beea73d7ee", "Manager", "MANAGER" },
                    { new Guid("11482fea-3b0d-43b2-aa27-8425de91690d"), "3e182a2c-bbfb-41d7-9f28-c18dfb39ea35", "Admin", "ADMIN" },
                    { new Guid("61389629-0334-4f06-9a5b-b9081d213d47"), "33350ddf-978c-425c-bb9e-f5e557fc28d0", "Personnel", "PERSONNEL" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "CompanyId", "ConcurrencyStamp", "CreateDate", "DeleteDate", "Department", "Email", "EmailConfirmed", "EndingDate", "IdentityNumber", "ImagePath", "IsActive", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlaceOfBirth", "Salary", "SecondName", "SecondSurname", "Sector", "SecurityStamp", "StartingDate", "Status", "Surname", "TwoFactorEnabled", "UpdateDate", "UserName" },
                values: new object[,]
                {
                    { new Guid("0c9aafd8-dbe6-4d4b-a20f-74fd58a5d4c0"), 0, "Caferağa mahallesi Mühürdar Cd. No:76 kat:5, İstanbul/Sarıyer", new DateTime(1995, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "f21308a5-c9c5-4c01-a866-8f2a364b714b", new DateTime(2023, 2, 21, 2, 52, 37, 411, DateTimeKind.Local).AddTicks(4230), null, 2, "serkan.temiz@bilgeadamboost.com", false, null, "19637426548", null, true, false, null, "Serkan", "SERKAN.TEMIZ@BILGEADAMBOOST.COM", "SERKANT", "AQAAAAEAACcQAAAAEHRQwfcZjk+LGlzP7hf0uHdJIj0XeWdOOXtREDdXwBmqEUP+garEDbMbHOG1To/6oQ==", 5425324892L, false, "İstanbul", 14000m, null, null, 8, "08784d77-0919-4c0c-b6a3-8dd4ea7727f8", new DateTime(2020, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TEMİZ", false, null, "SerkanT" },
                    { new Guid("6140e871-8ff5-4588-a03e-590c9eb1a251"), 0, "Bostanlı mahallesi Cengiz Kocatoros Sokağı No: 85/A, İzmir/Karşıyaka ", new DateTime(1982, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "a614d588-c48a-4f86-b1b1-bbe9b56a62f9", new DateTime(2023, 2, 21, 2, 52, 37, 411, DateTimeKind.Local).AddTicks(4217), null, 3, "aysenur.altınsoy@bilgeadamboost.com", false, null, "78953246782", null, true, false, null, "Ayşenur", "AYSENUR.ALTINSOY@BILGEADAMBOOST.COM", "AYSENURA", "AQAAAAEAACcQAAAAENh7YteSR339TVB8lLaWEpN/zePZSzIy6FPsR0ClgOR55wiom9lD96sv1RIay9w6fA==", 5365867759L, false, "İzmir", 14000m, null, null, 10, "d92d844c-bd4b-4e04-b269-159b0285950a", new DateTime(2019, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "ALTINSOY", false, null, "AysenurA" },
                    { new Guid("72d306bd-7ccf-4735-b77f-5fcdcf960167"), 0, "Cumhuriyet mah. 5034 sok no:2 daire:3,Denizli/Pamukkale", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "fe11ee69-358e-4788-a91f-d2ab78ebb807", new DateTime(2023, 2, 21, 2, 52, 37, 411, DateTimeKind.Local).AddTicks(4303), null, 2, "fatih.bag@bilgeadamboost.com", false, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "12312345678", null, false, false, null, "Fatih", "FATIH.BAG@BILGEADAMBOOST.COM", "FATIHB", "AQAAAAEAACcQAAAAEPS/eeBZIi9JVtlpJ61r3Dx6sMMA1skiWQhctoHjvHZIUTMh5VDtJQ+NZnNfdNWNFQ==", 5318700685L, false, "Denizli", 13000m, null, null, 7, "e7107006-5069-4e6c-8fe3-3119eaf865cd", new DateTime(2021, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BAG", false, null, "FatihB" },
                    { new Guid("8f23799b-b6e5-4a8b-8fdb-e78fadebaf31"), 0, "Yanişehir mah. 18 sok no:41 daire:4, Denizli/Merkezefendi", new DateTime(1997, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "71410032-18aa-43d3-9316-573ac70c1260", new DateTime(2023, 2, 21, 2, 52, 37, 411, DateTimeKind.Local).AddTicks(4119), null, 2, "ramazan.yaylali@bilgeadamboost.com", false, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "41485012455", "/img/userspic/Ramazan.jpg", false, false, null, "Ramazan", "RAMAZAN.YAYLALI@BILGEADAMBOOST.COM", "RAMAZANY", "AQAAAAEAACcQAAAAEGBGHoMCzzOPK/iFw+ErutyOAXHarpjcXAGjCXZnawxCBMDpU59bLPyLDVpq8M6o8g==", 5365867759L, false, "Acıpayam", 10000m, null, null, 10, "1e13aa31-bc3a-43de-b59f-bd8e48128ec8", new DateTime(2022, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "YAYLALI", false, null, "RamazanY" },
                    { new Guid("957e3a7a-a315-4237-82cf-aeee7144b033"), 0, "Yalı mahallesi Caher Dudayev Bulvarı No:107 D:B, İzmir/Karşıyaka ", new DateTime(1988, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "f3b3f885-f566-48fa-8bfb-3fe0c6099819", new DateTime(2023, 2, 21, 2, 52, 37, 411, DateTimeKind.Local).AddTicks(4197), null, 3, "hazel.calkar@bilgeadamboost.com", false, null, "31354697822", null, true, false, null, "Hazel", "HAZEL.CALKAR@BILGEADAMBOOST.COM", "HAZELC", "AQAAAAEAACcQAAAAECDG7VG7l1wBeY3MYz1B2+YPloMvCd3QC6FrOxiz/qvA3tUOwXtWzFeGYGwK4x+PZA==", 5365867759L, false, "İzmir", 13000m, null, null, 10, "c000ceed-d6df-418e-b5ca-b28c1e8cc7d9", new DateTime(2020, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "ÇALKAR", false, null, "HazelC" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("11482fea-3b0d-43b2-aa27-8425de91690d"), new Guid("0c9aafd8-dbe6-4d4b-a20f-74fd58a5d4c0") },
                    { new Guid("61389629-0334-4f06-9a5b-b9081d213d47"), new Guid("6140e871-8ff5-4588-a03e-590c9eb1a251") },
                    { new Guid("11482fea-3b0d-43b2-aa27-8425de91690d"), new Guid("72d306bd-7ccf-4735-b77f-5fcdcf960167") },
                    { new Guid("61389629-0334-4f06-9a5b-b9081d213d47"), new Guid("8f23799b-b6e5-4a8b-8fdb-e78fadebaf31") },
                    { new Guid("61389629-0334-4f06-9a5b-b9081d213d47"), new Guid("957e3a7a-a315-4237-82cf-aeee7144b033") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserAdvance_AppUserId",
                table: "AppUserAdvance",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserAdvance");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AppCompany");
        }
    }
}
