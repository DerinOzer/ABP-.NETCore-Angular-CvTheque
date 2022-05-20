using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simphonis.CvTheque.Migrations
{
    public partial class Add_Skill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppCandidateSkills",
                columns: table => new
                {
                    IdCandidate = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSkill = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Note = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCandidateSkills", x => new { x.IdCandidate, x.IdSkill });
                    table.ForeignKey(
                        name: "FK_AppCandidateSkills_AppCandidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "AppCandidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppCandidateSkills_AppCandidates_IdCandidate",
                        column: x => x.IdCandidate,
                        principalTable: "AppCandidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppCandidateSkills_AppSkills_IdSkill",
                        column: x => x.IdSkill,
                        principalTable: "AppSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppCandidateSkills_AppSkills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "AppSkills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppCandidateSkills_CandidateId",
                table: "AppCandidateSkills",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCandidateSkills_IdCandidate_IdSkill",
                table: "AppCandidateSkills",
                columns: new[] { "IdCandidate", "IdSkill" });

            migrationBuilder.CreateIndex(
                name: "IX_AppCandidateSkills_IdSkill",
                table: "AppCandidateSkills",
                column: "IdSkill");

            migrationBuilder.CreateIndex(
                name: "IX_AppCandidateSkills_SkillId",
                table: "AppCandidateSkills",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppCandidateSkills");

            migrationBuilder.DropTable(
                name: "AppSkills");
        }
    }
}
