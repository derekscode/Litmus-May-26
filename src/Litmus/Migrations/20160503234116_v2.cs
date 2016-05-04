using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace Litmus.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BirthYear = table.Column<int>(nullable: false),
                    CardId = table.Column<string>(nullable: true),
                    Expiration = table.Column<string>(nullable: true),
                    HasBarcode = table.Column<bool>(nullable: false),
                    HasMagStripe = table.Column<bool>(nullable: false),
                    IsDamaged = table.Column<bool>(nullable: false),
                    IsPaper = table.Column<bool>(nullable: false),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Card");
        }
    }
}
