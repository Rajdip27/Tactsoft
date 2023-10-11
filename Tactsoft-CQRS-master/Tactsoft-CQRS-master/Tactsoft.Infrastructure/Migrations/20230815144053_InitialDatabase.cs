using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tactsoft.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AffectedColumns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ssc = table.Column<bool>(type: "bit", nullable: false),
                    Hsc = table.Column<bool>(type: "bit", nullable: false),
                    Bsc = table.Column<bool>(type: "bit", nullable: false),
                    Msc = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedBy", "CreatedDateUtc", "Description", "Name", "NormalizedName", "StatusId", "UpdatedBy", "UpdatedDateUtc" },
                values: new object[,]
                {
                    { 1L, null, 0L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Administrator", "ADMINISTRATOR", 0, null, null },
                    { 2L, null, 0L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Employee", "EMPLOYEE", 0, null, null },
                    { 3L, null, 0L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Trainer", "TRAINER", 0, null, null },
                    { 4L, null, 0L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Student", "STUDENT", 0, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedBy", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { 1L, 0, "733534be-bc62-4596-b050-044d2a6ab7c9", 0L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEDCboisIAVW5EzxEZVHVSOmVx86SQSEuZSchPLdGww+0fS0YaboJkf8eTEh2J0ef3g==", null, false, "953179b6-40b6-470b-b401-d043816f48e3", false, null, null, "admin@localhost.com" },
                    { 2L, 0, "4d561e2c-2813-43cb-9f0a-c7679ce959a5", 0L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "employee@localhost.com", true, false, null, "EMPLOYEE@LOCALHOST.COM", "EMPLOYEE@LOCALHOST.COM", "AQAAAAIAAYagAAAAEIkBIlDBKQDcwrVvs1SjX7InJSWbM5uwA0kAzv3pB9Yf9aA5SNrn8S8HrkHSq8YEtg==", null, false, "da8fd043-7785-4229-99fa-9e6536de11bd", false, null, null, "employee@localhost.com" },
                    { 3L, 0, "929713f3-8033-4365-be74-bb2ee64e5c0a", 0L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "trainer@localhost.com", true, false, null, "TRAINER@LOCALHOST.COM", "TRAINER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEKIPmIoJX02fUC17VDmBD48HFgwF72RrgVnHwpl2xM/h5pMnUKbY6A7QsQICswsxqQ==", null, false, "1387afc3-cfbf-4676-a8a3-6585d4b05d25", false, null, null, "trainer@localhost.com" },
                    { 4L, 0, "73be8b5f-9c5a-4592-b65d-3365d6d557ad", 0L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "student@localhost.com", true, false, null, "STUDENT@LOCALHOST.COM", "STUDENT@LOCALHOST.COM", "AQAAAAIAAYagAAAAECLA1+v9OartCha5YjutmSdWnpSAVbHPk96yiccnPYQDQBUJEGTFf1XhD8b5E1DV2A==", null, false, "f67870a4-abea-4355-b157-fb4ed6297b78", false, null, null, "student@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "Currency", "Flag", "IsDelete", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, "BD", 1L, new DateTimeOffset(new DateTime(2023, 8, 15, 14, 40, 53, 221, DateTimeKind.Unspecified).AddTicks(5527), new TimeSpan(0, 0, 0, 0, 0)), "BDT", "bd", false, "Bangladesh", null, null },
                    { 2L, "USA", 1L, new DateTimeOffset(new DateTime(2023, 8, 15, 14, 40, 53, 221, DateTimeKind.Unspecified).AddTicks(5529), new TimeSpan(0, 0, 0, 0, 0)), "USD", "us", false, "United States", null, null },
                    { 3L, "UK", 1L, new DateTimeOffset(new DateTime(2023, 8, 15, 14, 40, 53, 221, DateTimeKind.Unspecified).AddTicks(5532), new TimeSpan(0, 0, 0, 0, 0)), "GBP", "gb", false, "United Kingdom", null, null }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "Email", "FirstName", "IsDelete", "LastName", "Phone", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, "12/2, Dhanmondi, Dhaka", 1L, new DateTimeOffset(new DateTime(2023, 8, 15, 14, 40, 53, 223, DateTimeKind.Unspecified).AddTicks(5609), new TimeSpan(0, 0, 0, 0, 0)), "sumon@gmail.com", "Sumon", false, "Mia", "0171225588", null, null },
                    { 2L, "22/2, Mohammadpur, Dhaka", 1L, new DateTimeOffset(new DateTime(2023, 8, 15, 14, 40, 53, 223, DateTimeKind.Unspecified).AddTicks(5613), new TimeSpan(0, 0, 0, 0, 0)), "rubel@gmail.com", "Rubel", false, "Hossain", "01929121212", null, null },
                    { 3L, "12/2, Dhanmondi, Dhaka", 1L, new DateTimeOffset(new DateTime(2023, 8, 15, 14, 40, 53, 223, DateTimeKind.Unspecified).AddTicks(5615), new TimeSpan(0, 0, 0, 0, 0)), "raju@gmail.com", "Raju", false, "Ahmed", "0171225588", null, null },
                    { 4L, "12/2, Dhanmondi, Dhaka", 1L, new DateTimeOffset(new DateTime(2023, 8, 15, 14, 40, 53, 223, DateTimeKind.Unspecified).AddTicks(5617), new TimeSpan(0, 0, 0, 0, 0)), "mithu@gmail.com", "Mithu", false, "Mia", "0171225588", null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 2L },
                    { 3L, 3L },
                    { 4L, 4L }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CountryId", "CreatedBy", "CreatedDate", "IsDelete", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, new DateTimeOffset(new DateTime(2023, 8, 15, 14, 40, 53, 222, DateTimeKind.Unspecified).AddTicks(3946), new TimeSpan(0, 0, 0, 0, 0)), false, "Dhaka", null, null },
                    { 2L, 1L, 1L, new DateTimeOffset(new DateTime(2023, 8, 15, 14, 40, 53, 222, DateTimeKind.Unspecified).AddTicks(3948), new TimeSpan(0, 0, 0, 0, 0)), false, "Rajshahi", null, null },
                    { 3L, 2L, 1L, new DateTimeOffset(new DateTime(2023, 8, 15, 14, 40, 53, 222, DateTimeKind.Unspecified).AddTicks(3951), new TimeSpan(0, 0, 0, 0, 0)), false, "New York", null, null },
                    { 4L, 2L, 1L, new DateTimeOffset(new DateTime(2023, 8, 15, 14, 40, 53, 222, DateTimeKind.Unspecified).AddTicks(3953), new TimeSpan(0, 0, 0, 0, 0)), false, "Alabama", null, null }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "Name", "StateId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTimeOffset(new DateTime(2023, 8, 15, 14, 40, 53, 221, DateTimeKind.Unspecified).AddTicks(375), new TimeSpan(0, 0, 0, 0, 0)), false, "Mohammadpur", 1L, null, null },
                    { 2L, 1L, new DateTimeOffset(new DateTime(2023, 8, 15, 14, 40, 53, 221, DateTimeKind.Unspecified).AddTicks(383), new TimeSpan(0, 0, 0, 0, 0)), false, "Dhanmondi", 1L, null, null },
                    { 3L, 1L, new DateTimeOffset(new DateTime(2023, 8, 15, 14, 40, 53, 221, DateTimeKind.Unspecified).AddTicks(385), new TimeSpan(0, 0, 0, 0, 0)), false, "Nator", 2L, null, null },
                    { 4L, 1L, new DateTimeOffset(new DateTime(2023, 8, 15, 14, 40, 53, 221, DateTimeKind.Unspecified).AddTicks(387), new TimeSpan(0, 0, 0, 0, 0)), false, "Sirajganj", 2L, null, null },
                    { 5L, 1L, new DateTimeOffset(new DateTime(2023, 8, 15, 14, 40, 53, 221, DateTimeKind.Unspecified).AddTicks(389), new TimeSpan(0, 0, 0, 0, 0)), false, "New York City", 3L, null, null },
                    { 6L, 1L, new DateTimeOffset(new DateTime(2023, 8, 15, 14, 40, 53, 221, DateTimeKind.Unspecified).AddTicks(392), new TimeSpan(0, 0, 0, 0, 0)), false, "Buffalo", 3L, null, null },
                    { 7L, 1L, new DateTimeOffset(new DateTime(2023, 8, 15, 14, 40, 53, 221, DateTimeKind.Unspecified).AddTicks(394), new TimeSpan(0, 0, 0, 0, 0)), false, "Huntsville", 4L, null, null },
                    { 8L, 1L, new DateTimeOffset(new DateTime(2023, 8, 15, 14, 40, 53, 221, DateTimeKind.Unspecified).AddTicks(396), new TimeSpan(0, 0, 0, 0, 0)), false, "Montgomery", 4L, null, null }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "Bsc", "CityId", "CountryId", "CreatedBy", "CreatedDate", "DateOfBirth", "Email", "FirstName", "Gender", "Hsc", "IsDelete", "LastName", "Msc", "Phone", "Picture", "Ssc", "StateId", "UpdatedBy", "UpdatedDate", "ZipCode" },
                values: new object[,]
                {
                    { 1L, "12/2, Dhanmondi, Dhaka", true, 1L, 1L, 1L, new DateTimeOffset(new DateTime(2023, 8, 15, 14, 40, 53, 222, DateTimeKind.Unspecified).AddTicks(962), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1996, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sahadat@gmail.com", "Shahadat", "Male", true, false, "Hassain", false, "017xxxxxxxxx", "", true, 1L, null, null, "1234" },
                    { 2L, "12/2, Dhanmondi, Dhaka", true, 1L, 1L, 1L, new DateTimeOffset(new DateTime(2023, 8, 15, 14, 40, 53, 222, DateTimeKind.Unspecified).AddTicks(967), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1999, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "mamun@gmail.com", "Mamun", "Male", true, false, "Rahman", false, "017xxxxxxxxx", "", true, 1L, null, null, "1234" },
                    { 3L, "12/2, Dhanmondi, Dhaka", true, 1L, 1L, 1L, new DateTimeOffset(new DateTime(2023, 8, 15, 14, 40, 53, 222, DateTimeKind.Unspecified).AddTicks(970), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1993, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "rahat@gmail.com", "Rahat", "Male", true, false, "Hasan", false, "017xxxxxxxxx", "", true, 1L, null, null, "1234" },
                    { 4L, "12/2, Dhanmondi, Dhaka", true, 1L, 1L, 1L, new DateTimeOffset(new DateTime(2023, 8, 15, 14, 40, 53, 222, DateTimeKind.Unspecified).AddTicks(987), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1996, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "fara@gmail.com", "Fara", "Female", true, false, "Khan", false, "017xxxxxxxxx", "", true, 1L, null, null, "1234" }
                });

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
                name: "IX_AspNetUserLogins_UsersId",
                table: "AspNetUserLogins",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CityId",
                table: "Employees",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CountryId",
                table: "Employees",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_StateId",
                table: "Employees",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
