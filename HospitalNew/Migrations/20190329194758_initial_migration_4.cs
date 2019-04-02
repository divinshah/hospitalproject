using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HospitalNew.Migrations
{
    public partial class initial_migration_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Schedule_scheduleLocationId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Schedule_scheduleLocationId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Stuff_Stuff_StuffId1",
                table: "Stuff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_scheduleLocationId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Locations_scheduleLocationId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Stuff_StuffId1",
                table: "Stuff");

            migrationBuilder.DropColumn(
                name: "scheduleLocationId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "scheduleLocationId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "StuffId1",
                table: "Stuff");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Schedule",
                newName: "locationId");

            migrationBuilder.RenameColumn(
                name: "StuffPosition",
                table: "Stuff",
                newName: "StaffPosition");

            migrationBuilder.RenameColumn(
                name: "StuffLastName",
                table: "Stuff",
                newName: "StaffLastName");

            migrationBuilder.RenameColumn(
                name: "StuffFirstName",
                table: "Stuff",
                newName: "StaffFirstName");

            migrationBuilder.RenameColumn(
                name: "StuffDepartment",
                table: "Stuff",
                newName: "StaffDepartment");

            migrationBuilder.RenameColumn(
                name: "StuffId",
                table: "Stuff",
                newName: "StaffId");

            migrationBuilder.AlterColumn<int>(
                name: "locationId",
                table: "Schedule",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Schedule",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Schedule",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Schedule",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule",
                column: "ScheduleId");

            migrationBuilder.CreateTable(
                name: "Alert",
                columns: table => new
                {
                    AlertId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    alertContent = table.Column<string>(maxLength: 255, nullable: false),
                    alertDate = table.Column<string>(maxLength: 255, nullable: false),
                    alertTopic = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alert", x => x.AlertId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_StaffId",
                table: "Schedule",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_locationId",
                table: "Schedule",
                column: "locationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Stuff_StaffId",
                table: "Schedule",
                column: "StaffId",
                principalTable: "Stuff",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Locations_locationId",
                table: "Schedule",
                column: "locationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Stuff_StaffId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Locations_locationId",
                table: "Schedule");

            migrationBuilder.DropTable(
                name: "Alert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_StaffId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_locationId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Schedule");

            migrationBuilder.RenameColumn(
                name: "locationId",
                table: "Schedule",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "StaffPosition",
                table: "Stuff",
                newName: "StuffPosition");

            migrationBuilder.RenameColumn(
                name: "StaffLastName",
                table: "Stuff",
                newName: "StuffLastName");

            migrationBuilder.RenameColumn(
                name: "StaffFirstName",
                table: "Stuff",
                newName: "StuffFirstName");

            migrationBuilder.RenameColumn(
                name: "StaffDepartment",
                table: "Stuff",
                newName: "StuffDepartment");

            migrationBuilder.RenameColumn(
                name: "StaffId",
                table: "Stuff",
                newName: "StuffId");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Schedule",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "scheduleLocationId",
                table: "Schedule",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "scheduleLocationId",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StuffId1",
                table: "Stuff",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_scheduleLocationId",
                table: "Schedule",
                column: "scheduleLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_scheduleLocationId",
                table: "Locations",
                column: "scheduleLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Stuff_StuffId1",
                table: "Stuff",
                column: "StuffId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Schedule_scheduleLocationId",
                table: "Locations",
                column: "scheduleLocationId",
                principalTable: "Schedule",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Schedule_scheduleLocationId",
                table: "Schedule",
                column: "scheduleLocationId",
                principalTable: "Schedule",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stuff_Stuff_StuffId1",
                table: "Stuff",
                column: "StuffId1",
                principalTable: "Stuff",
                principalColumn: "StuffId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
