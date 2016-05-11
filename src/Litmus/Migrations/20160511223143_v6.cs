using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Litmus.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayLastChanged",
                table: "Card",
                nullable: true);
            migrationBuilder.AddColumn<DateTime>(
                name: "LastChanged",
                table: "Card",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "DisplayLastChanged", table: "Card");
            migrationBuilder.DropColumn(name: "LastChanged", table: "Card");
        }
    }
}
