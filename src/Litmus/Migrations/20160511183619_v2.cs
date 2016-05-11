using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Litmus.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayDateChanged",
                table: "Log",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "DisplayDateChanged", table: "Log");
        }
    }
}
