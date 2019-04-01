using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HospitalNew.Migrations
{
    public partial class donooormodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donor",
                columns: table => new
                {
                    DonorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DonorMessage = table.Column<string>(maxLength: 2000, nullable: false),
                    DonorName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donor", x => x.DonorID);
                });

            migrationBuilder.CreateTable(
                name: "Parking",
                columns: table => new
                {
                    ParkingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParkingPurpose = table.Column<string>(maxLength: 255, nullable: false),
                    VisitoCarNo = table.Column<string>(maxLength: 255, nullable: false),
                    VisitorName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parking", x => x.ParkingID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donor");

            migrationBuilder.DropTable(
                name: "Parking");
        }
    }
}
