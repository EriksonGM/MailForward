﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MailForward.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MailAccounts",
                columns: table => new
                {
                    IdMailAccount = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    Server = table.Column<string>(maxLength: 50, nullable: true),
                    User = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(maxLength: 50, nullable: true),
                    Mail = table.Column<string>(maxLength: 50, nullable: true),
                    UseSSL = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailAccounts", x => x.IdMailAccount);
                });

            migrationBuilder.CreateTable(
                name: "Origin",
                columns: table => new
                {
                    IdOrigin = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IdMailAccount = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origin", x => x.IdOrigin);
                    table.ForeignKey(
                        name: "FK_Origin_MailAccounts_IdMailAccount",
                        column: x => x.IdMailAccount,
                        principalTable: "MailAccounts",
                        principalColumn: "IdMailAccount",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllowedSites",
                columns: table => new
                {
                    IdAllowedSite = table.Column<Guid>(nullable: false),
                    IdOrigin = table.Column<Guid>(nullable: false),
                    Site = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllowedSites", x => x.IdAllowedSite);
                    table.ForeignKey(
                        name: "FK_AllowedSites_Origin_IdOrigin",
                        column: x => x.IdOrigin,
                        principalTable: "Origin",
                        principalColumn: "IdOrigin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Destinies",
                columns: table => new
                {
                    IdDestiny = table.Column<Guid>(nullable: false),
                    IdOrigin = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinies", x => x.IdDestiny);
                    table.ForeignKey(
                        name: "FK_Destinies_Origin_IdOrigin",
                        column: x => x.IdOrigin,
                        principalTable: "Origin",
                        principalColumn: "IdOrigin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllowedSites_IdOrigin",
                table: "AllowedSites",
                column: "IdOrigin");

            migrationBuilder.CreateIndex(
                name: "IX_Destinies_IdOrigin",
                table: "Destinies",
                column: "IdOrigin");

            migrationBuilder.CreateIndex(
                name: "IX_Origin_IdMailAccount",
                table: "Origin",
                column: "IdMailAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllowedSites");

            migrationBuilder.DropTable(
                name: "Destinies");

            migrationBuilder.DropTable(
                name: "Origin");

            migrationBuilder.DropTable(
                name: "MailAccounts");
        }
    }
}
