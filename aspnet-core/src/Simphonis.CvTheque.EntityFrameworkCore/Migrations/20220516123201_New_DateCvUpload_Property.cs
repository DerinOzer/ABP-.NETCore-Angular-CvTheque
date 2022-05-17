using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simphonis.CvTheque.Migrations
{
    public partial class New_DateCvUpload_Property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCvUpload",
                table: "AppCandidates",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCvUpload",
                table: "AppCandidates");
        }
    }
}
