using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace Litmus.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    BirthYear = table.Column<int>(nullable: false),
                    DisplayLastChanged = table.Column<string>(nullable: true),
                    Expiration = table.Column<string>(nullable: true),
                    HasBarcode = table.Column<bool>(nullable: false),
                    HasMagstripe = table.Column<bool>(nullable: false),
                    IdNumber = table.Column<string>(nullable: true),
                    IsDamaged = table.Column<bool>(nullable: false),
                    IsPaper = table.Column<bool>(nullable: false),
                    LastChanged = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Orientation = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardId = table.Column<int>(nullable: false),
                    CardIdNumber = table.Column<string>(nullable: true),
                    DateChanged = table.Column<DateTime>(nullable: false),
                    DisplayDateChanged = table.Column<string>(nullable: true),
                    NewCard = table.Column<string>(nullable: true),
                    OldCard = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Card");
            migrationBuilder.DropTable("Location");
            migrationBuilder.DropTable("Log");
        }
    }
}
