using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Data.Migrations
{
    public partial class _001_EmailModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    ApplicationUserId = table.Column<int>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    ContentSample = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    From = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailHeaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    AccountId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAddresses_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailContents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Content = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    EmailHeaderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailContents_EmailHeaders_EmailHeaderId",
                        column: x => x.EmailHeaderId,
                        principalTable: "EmailHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AccountId",
                table: "AspNetUsers",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Email",
                table: "Accounts",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddresses_AccountId",
                table: "EmailAddresses",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddresses_Address",
                table: "EmailAddresses",
                column: "Address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailContents_EmailHeaderId",
                table: "EmailContents",
                column: "EmailHeaderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Accounts_AccountId",
                table: "AspNetUsers",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Accounts_AccountId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AccountId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "EmailAddresses");

            migrationBuilder.DropTable(
                name: "EmailContents");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "EmailHeaders");
        }
    }
}
