using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Dwk.Api.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attribute");

            migrationBuilder.AddColumn<string>(
                name: "attributes",
                table: "Deseases",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "attributes",
                table: "Deseases");

            migrationBuilder.CreateTable(
                name: "Attribute",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    DeseaseId = table.Column<int>(nullable: true),
                    content = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Attribute_Deseases_DeseaseId",
                        column: x => x.DeseaseId,
                        principalTable: "Deseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attribute_DeseaseId",
                table: "Attribute",
                column: "DeseaseId");
        }
    }
}
