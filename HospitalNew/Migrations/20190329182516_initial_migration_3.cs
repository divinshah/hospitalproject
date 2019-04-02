using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HospitalNew.Migrations
{
    public partial class initial_migration_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    scheduleLocationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Schedule_Schedule_scheduleLocationId",
                        column: x => x.scheduleLocationId,
                        principalTable: "Schedule",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationAddress = table.Column<string>(maxLength: 255, nullable: false),
                    LocationName = table.Column<string>(maxLength: 255, nullable: false),
                    scheduleLocationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_Schedule_scheduleLocationId",
                        column: x => x.scheduleLocationId,
                        principalTable: "Schedule",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_scheduleLocationId",
                table: "Locations",
                column: "scheduleLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_scheduleLocationId",
                table: "Schedule",
                column: "scheduleLocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Schedule");
        }
    }
}
