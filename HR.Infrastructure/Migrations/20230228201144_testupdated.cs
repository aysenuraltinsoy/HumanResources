using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.Infrastructure.Migrations
{
    public partial class testupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e881658-a975-4e9a-896c-85e76a3810a6"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("11482fea-3b0d-43b2-aa27-8425de91690d"), new Guid("0c9aafd8-dbe6-4d4b-a20f-74fd58a5d4c0") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("61389629-0334-4f06-9a5b-b9081d213d47"), new Guid("6140e871-8ff5-4588-a03e-590c9eb1a251") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("11482fea-3b0d-43b2-aa27-8425de91690d"), new Guid("72d306bd-7ccf-4735-b77f-5fcdcf960167") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("61389629-0334-4f06-9a5b-b9081d213d47"), new Guid("8f23799b-b6e5-4a8b-8fdb-e78fadebaf31") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("61389629-0334-4f06-9a5b-b9081d213d47"), new Guid("957e3a7a-a315-4237-82cf-aeee7144b033") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("11482fea-3b0d-43b2-aa27-8425de91690d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("61389629-0334-4f06-9a5b-b9081d213d47"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0c9aafd8-dbe6-4d4b-a20f-74fd58a5d4c0"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6140e871-8ff5-4588-a03e-590c9eb1a251"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("72d306bd-7ccf-4735-b77f-5fcdcf960167"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f23799b-b6e5-4a8b-8fdb-e78fadebaf31"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("957e3a7a-a315-4237-82cf-aeee7144b033"));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ReplyDate",
                table: "AppUserAdvance",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ApprovalDate",
                table: "AppUserAdvance",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("c1f0dda8-6e55-4245-9242-4d84beb324d3"), "ade165cd-43b1-4b8b-8e6c-f1a3da4c6312", "Admin", "ADMIN" },
                    { new Guid("f841fff9-2e31-4de3-a9d3-28d7936d7872"), "bc890c65-47ad-4ecc-ac14-04fa205e46c1", "Manager", "MANAGER" },
                    { new Guid("fe497e96-4eef-4952-8eeb-0436b5a90757"), "fdbbe90b-d673-4ef3-8854-8772d7491bea", "Personnel", "PERSONNEL" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "CompanyId", "ConcurrencyStamp", "CreateDate", "DeleteDate", "Department", "Email", "EmailConfirmed", "EndingDate", "IdentityNumber", "ImagePath", "IsActive", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlaceOfBirth", "Salary", "SecondName", "SecondSurname", "Sector", "SecurityStamp", "StartingDate", "Status", "Surname", "TwoFactorEnabled", "UpdateDate", "UserName" },
                values: new object[,]
                {
                    { new Guid("127f4be8-b872-4d5d-839a-2bb69a7945fa"), 0, "Bostanlı mahallesi Cengiz Kocatoros Sokağı No: 85/A, İzmir/Karşıyaka ", new DateTime(1982, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "c1ed4316-a5ff-4b81-9089-675ed7630bfd", new DateTime(2023, 2, 28, 23, 11, 44, 269, DateTimeKind.Local).AddTicks(9018), null, 3, "aysenur.altınsoy@bilgeadamboost.com", false, null, "78953246782", null, true, false, null, "Ayşenur", "AYSENUR.ALTINSOY@BILGEADAMBOOST.COM", "AYSENURA", "AQAAAAEAACcQAAAAEDjUREKKdBtrGrLNk97gnOP7gWZeYAA4yRbWu1QrDSOSxzh1kR0wSm++ioOh9nKuwA==", 5365867759L, false, "İzmir", 14000m, null, null, 10, "7208ed07-f673-42a5-bbbd-991561488d37", new DateTime(2019, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "ALTINSOY", false, null, "AysenurA" },
                    { new Guid("231ac3ab-570d-483d-a89e-ee419a8e18ce"), 0, "Yalı mahallesi Caher Dudayev Bulvarı No:107 D:B, İzmir/Karşıyaka ", new DateTime(1988, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "d42fd59d-7cb3-478f-ad80-cbf3d9f04084", new DateTime(2023, 2, 28, 23, 11, 44, 269, DateTimeKind.Local).AddTicks(8997), null, 3, "hazel.calkar@bilgeadamboost.com", false, null, "31354697822", null, true, false, null, "Hazel", "HAZEL.CALKAR@BILGEADAMBOOST.COM", "HAZELC", "AQAAAAEAACcQAAAAEFyUyw/oQaZH9UpzUA8WfVAA8yszDXGtCHi39DooU8TrBprkKrNdlqI/Ocj7FRR4IA==", 5365867759L, false, "İzmir", 13000m, null, null, 10, "df3020b9-77be-41c9-9d53-c02fda12d269", new DateTime(2020, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "ÇALKAR", false, null, "HazelC" },
                    { new Guid("26cbb6ca-8b86-414b-92f4-8302b88d2758"), 0, "Caferağa mahallesi Mühürdar Cd. No:76 kat:5, İstanbul/Sarıyer", new DateTime(1995, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "bc5186a1-7d92-4826-ab2a-faf25ac13c1d", new DateTime(2023, 2, 28, 23, 11, 44, 269, DateTimeKind.Local).AddTicks(9040), null, 2, "serkan.temiz@bilgeadamboost.com", false, null, "19637426548", null, true, false, null, "Serkan", "SERKAN.TEMIZ@BILGEADAMBOOST.COM", "SERKANT", "AQAAAAEAACcQAAAAEEiJHR5MGFdam2hIAqjGjMwT7Pd0KxCtYG58wa5T1Vet4dMLQPq//Bl1IHY4ytCA8g==", 5425324892L, false, "İstanbul", 14000m, null, null, 8, "4806a10a-df48-41e2-92db-396fe7bcf82d", new DateTime(2020, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TEMİZ", false, null, "SerkanT" },
                    { new Guid("b649b347-ac6f-4ae8-995a-531bace246ac"), 0, "Yanişehir mah. 18 sok no:41 daire:4, Denizli/Merkezefendi", new DateTime(1997, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "37b0116f-9105-47a7-9375-cac2a750b944", new DateTime(2023, 2, 28, 23, 11, 44, 269, DateTimeKind.Local).AddTicks(8853), null, 2, "ramazan.yaylali@bilgeadamboost.com", false, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "41485012455", "/img/userspic/Ramazan.jpg", false, false, null, "Ramazan", "RAMAZAN.YAYLALI@BILGEADAMBOOST.COM", "RAMAZANY", "AQAAAAEAACcQAAAAEJ2fDo20QukLEU9kt/RLYXqZb3pgSTzqiZRqlHC8FL+DmFZPp0A0gtWTs8juFJwR7Q==", 5365867759L, false, "Acıpayam", 10000m, null, null, 10, "cd3778cf-b7fa-4bd4-b028-05a2fbd72cda", new DateTime(2022, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "YAYLALI", false, null, "RamazanY" },
                    { new Guid("d3715a73-a2bd-40dc-8988-794bf20da1a0"), 0, "Cumhuriyet mah. 5034 sok no:2 daire:3,Denizli/Pamukkale", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "70e1c794-4d1e-43eb-8181-ee1810615d0f", new DateTime(2023, 2, 28, 23, 11, 44, 269, DateTimeKind.Local).AddTicks(9057), null, 2, "fatih.bag@bilgeadamboost.com", false, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "12312345678", null, false, false, null, "Fatih", "FATIH.BAG@BILGEADAMBOOST.COM", "FATIHB", "AQAAAAEAACcQAAAAENPrPT0XvmOr7NgjL55u0TQH3utgMiq72PYeSxneaMEkv/oSRp0aV1pt0QXb6MltlA==", 5318700685L, false, "Denizli", 13000m, null, null, 7, "3ec9d99b-1604-441a-9a12-8778a38f244d", new DateTime(2021, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BAG", false, null, "FatihB" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("fe497e96-4eef-4952-8eeb-0436b5a90757"), new Guid("127f4be8-b872-4d5d-839a-2bb69a7945fa") },
                    { new Guid("fe497e96-4eef-4952-8eeb-0436b5a90757"), new Guid("231ac3ab-570d-483d-a89e-ee419a8e18ce") },
                    { new Guid("c1f0dda8-6e55-4245-9242-4d84beb324d3"), new Guid("26cbb6ca-8b86-414b-92f4-8302b88d2758") },
                    { new Guid("fe497e96-4eef-4952-8eeb-0436b5a90757"), new Guid("b649b347-ac6f-4ae8-995a-531bace246ac") },
                    { new Guid("c1f0dda8-6e55-4245-9242-4d84beb324d3"), new Guid("d3715a73-a2bd-40dc-8988-794bf20da1a0") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f841fff9-2e31-4de3-a9d3-28d7936d7872"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("fe497e96-4eef-4952-8eeb-0436b5a90757"), new Guid("127f4be8-b872-4d5d-839a-2bb69a7945fa") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("fe497e96-4eef-4952-8eeb-0436b5a90757"), new Guid("231ac3ab-570d-483d-a89e-ee419a8e18ce") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c1f0dda8-6e55-4245-9242-4d84beb324d3"), new Guid("26cbb6ca-8b86-414b-92f4-8302b88d2758") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("fe497e96-4eef-4952-8eeb-0436b5a90757"), new Guid("b649b347-ac6f-4ae8-995a-531bace246ac") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c1f0dda8-6e55-4245-9242-4d84beb324d3"), new Guid("d3715a73-a2bd-40dc-8988-794bf20da1a0") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c1f0dda8-6e55-4245-9242-4d84beb324d3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fe497e96-4eef-4952-8eeb-0436b5a90757"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("127f4be8-b872-4d5d-839a-2bb69a7945fa"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("231ac3ab-570d-483d-a89e-ee419a8e18ce"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("26cbb6ca-8b86-414b-92f4-8302b88d2758"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b649b347-ac6f-4ae8-995a-531bace246ac"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d3715a73-a2bd-40dc-8988-794bf20da1a0"));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ReplyDate",
                table: "AppUserAdvance",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ApprovalDate",
                table: "AppUserAdvance",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

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
        }
    }
}
