using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HospitalNew.Migrations
{
    public partial class initial_migration_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stuff",
                columns: table => new
                {
                    StuffId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StuffDepartment = table.Column<string>(maxLength: 255, nullable: false),
                    StuffFirstName = table.Column<string>(maxLength: 255, nullable: false),
                    StuffId1 = table.Column<int>(nullable: true),
                    StuffLastName = table.Column<string>(maxLength: 255, nullable: false),
                    StuffPosition = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stuff", x => x.StuffId);
                    table.ForeignKey(
                        name: "FK_Stuff_Stuff_StuffId1",
                        column: x => x.StuffId1,
                        principalTable: "Stuff",
                        principalColumn: "StuffId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stuff_StuffId1",
                table: "Stuff",
                column: "StuffId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stuff");
        }
    }
}
