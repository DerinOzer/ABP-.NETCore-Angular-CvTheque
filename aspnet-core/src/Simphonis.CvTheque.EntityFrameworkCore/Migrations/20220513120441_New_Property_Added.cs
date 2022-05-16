using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simphonis.CvTheque.Migrations
{
    public partial class New_Property_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "AppCandidates",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "AppCandidates");
        }
    }
}
