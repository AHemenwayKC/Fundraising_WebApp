using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CS451R_Fundraiser.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                //Id = table.Column<int>(type: "int", nullable: false)
                //        .Annotation("SqlServer:Identity", "1, 1"),
                email = table.Column<string>(type: "string", nullable: false),
                name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                card = table.Column<decimal>(type: "string", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_User", x => x.email);
            });


            migrationBuilder.CreateTable(
                name: "Fundraisers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Goal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserEmail = table.Column<string>(type: "string", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fundraiser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fundraisers_Users_UserEmail",
                        column: x => x.UserEmail,
                        principalTable: "Users",
                        principalColumn: "email");
                });


            migrationBuilder.CreateIndex(
                name: "IX_Fundraisers_UserEmail",
                table: "Fundraisers",
                column: "UserEmail");


            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<string>(type: "int", nullable: false),
                    donateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userName = table.Column<string>(type: "string", nullable: true),
                    fundraiserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donation", x => x.Id);
                    //table.ForeignKey(
                    //    name: "FK_Donations_Fundraisers_fundraiserId",
                    //    column: x => x.fundraiserId,
                    //    principalTable: "Fundraisers",
                    //    principalColumn: "Id");
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fundraiser");
        }
    }
}
