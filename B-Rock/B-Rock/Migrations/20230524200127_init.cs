﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B_Rock.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Instruments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstrumentId = table.Column<int>(type: "int", nullable: false),
                    UniqueURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artists_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Instruments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bassoon" },
                    { 2, "Cello" },
                    { 3, "Clarinet" },
                    { 4, "Concertmaster" },
                    { 5, "Double bass" },
                    { 6, "Guitar" },
                    { 7, "Oboe" },
                    { 8, "Horn" },
                    { 9, "Piano" },
                    { 10, "Timpani" },
                    { 11, "Traverso" },
                    { 12, "Viola" },
                    { 13, "Violin" }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber", "Role", "UniqueURL" },
                values: new object[,]
                {
                    { 1, "aglaja@b-rock.org", "Aglaja", "Thiesen", "+32 471 69 52 19", "General Direction", "Aglaja-Thiesen.jpg" },
                    { 2, "albert@b-rock.org", "Albert", "Edelman", "+32 499 93 48 23", "Artistic Direction", "Albert-Edelman.jpg" },
                    { 3, "davina@b-rock.org", "Davina", "Van Belle", "+32 477 98 04 28", "Business Direction", "Davina-VanBelle.jpg" },
                    { 4, "claire@b-rock.org", "Claire", "Desmedt", "+32 494 48 79 62", "Administration & Participation", "Claire-Desmedt.jpg" },
                    { 5, "tom@b-rock.org", "Tom", "Devaere", null, "Casting Coordination & Music Libary", "Tom-Devaere.jpg" },
                    { 6, "sharon@b-rock.org", "Sharon", "Buffel", "+32 491 25 22 33", "Communication, Planning & Production", "Sharon-Buffel.jpg" },
                    { 7, "toon@b-rock.org", "Toon", "Vannieuwenhuyse", "+32 476 41 79 05", "Production & Libary", "Toon-Vannieuwenhuyse.jpg" },
                    { 8, "laurent@b-rock.org", "Laurent", "Langlois", "+33 610 27 11 38", "International Relations", "Laurent-Langlois.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "FirstName", "InstrumentId", "LastName", "Role", "UniqueURL" },
                values: new object[,]
                {
                    { 1, "Benny", 1, "Aghassi", "Shared principal", "Benny-Aghassi.jpg" },
                    { 2, "Tomasz", 1, "Wesolowski", "Shared principal", "Tomasz-Aghassi.jpg" },
                    { 3, "Julien", 2, "Barre", "Shared principal", "Julien-Barre.jpg" },
                    { 4, "Rebecca", 2, "Rosen", "Shared principal", "Rebecca-Rosen.jpg" },
                    { 5, "Vincenzo", 3, "Casale", "Shared principal", "Vincenzo-Casale.jpg" },
                    { 6, "Jean-Philippe", 3, "Ponchin", null, "Jean-Philippe-Ponchin.jpg" },
                    { 7, "Cecilia", 4, "Bernardini", "Acting concertmaster", null },
                    { 8, "Evgeny", 4, "Sviridov", "Acting concertmaster", "Evgeny-Sviridov.jpg" },
                    { 9, "Tom", 5, "Devaere", "Principal", "Tom-Devaere.jpg" },
                    { 10, "Elise", 5, "Christiaens", null, "Elise-Christiaens.jpg" },
                    { 11, "Karl", 6, "Nyhlin", null, "Karl-Nyhlin.jpg" },
                    { 12, "Jean-Marc", 7, "Philippe", "Acting principal", "Jean-Marc-Philippe.jpg" },
                    { 13, "Stefaan", 7, "Verdegem", null, "Stefaan-Verdegem.jpg" },
                    { 14, "Bart", 8, "Aerbeydt", "Shared principal", "Bart-Aerbeydt.jpg" },
                    { 15, "Jeroen", 8, "Billiet", "Shared principal", null },
                    { 16, "Mark", 8, "De Merlier", null, "Mark-De-Merlier.jpg" },
                    { 17, "Andreas", 9, "Küppers", null, "Andres-Küppers.jpg" },
                    { 18, "Jan", 10, "Huylebroeck", "Shared principal", "Jan-Huylebroeck.jpg" },
                    { 19, "Koen", 10, "Plaetinck", "Shared principal", null },
                    { 20, "Tami", 11, "Krausz", "Principal", "Tami-Krausz.jpg" },
                    { 21, "Sien", 11, "Huybrechts", null, "Sien-Huybrechts.jpg" },
                    { 22, "Raquel", 12, "Massadas", "Principal", "Raquel-Massadas.jpg" },
                    { 23, "Luc", 12, "Gysbregts", null, "Luc-Gysbregts.jpg" },
                    { 24, "Manuela", 12, "Bucher", null, "Manuela-Bucher.jpg" },
                    { 25, "David", 13, "Wish", null, "David-Wish.jpg" },
                    { 26, "Sara", 13, "Decorso", null, "Sara-Decorso.jpg" },
                    { 27, "Ellie", 13, "Nimeroski", null, "Ellie-Nimeroski.jpg" },
                    { 28, "Jivka", 13, "Kaltcheva", null, "Jivka-Kaltcheva.jpg" },
                    { 29, "Liesbeth", 13, "Nijs", null, "Liesbeth-Nijs.jpg" },
                    { 30, "Madoka", 13, "Nakamaru", null, "Madoka-Nakamaru.jpg" },
                    { 31, "Ortwin", 13, "Lowyck", null, "Ortwin-Lowyck.jpg" },
                    { 32, "Shiho", 13, "Ono", null, "Shiho-Ono.jpg" },
                    { 33, "Rebecca", 13, "Huber", null, "Rebecca-Huber.jpg" },
                    { 34, "Yukie", 13, "Yamaguchi", null, "Yukie-Yamaguchi.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artists_InstrumentId",
                table: "Artists",
                column: "InstrumentId");

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artists");

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
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
