using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simphonis.CvTheque.Migrations
{
    public partial class Add_Candidate_Skill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCandidateSkills",
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
                    table.PrimaryKey("PK_AppCandidateSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidateSkillsCandidates",
                columns: table => new
                {
                    IdCandidate = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCandidateSkill = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CandidateSkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Note = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateSkillsCandidates", x => new { x.IdCandidate, x.IdCandidateSkill });
                    table.ForeignKey(
                        name: "FK_CandidateSkillsCandidates_AppCandidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "AppCandidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidateSkillsCandidates_AppCandidateSkills_CandidateSkillId",
                        column: x => x.CandidateSkillId,
                        principalTable: "AppCandidateSkills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkillsCandidates_CandidateId",
                table: "CandidateSkillsCandidates",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkillsCandidates_CandidateSkillId",
                table: "CandidateSkillsCandidates",
                column: "CandidateSkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateSkillsCandidates");

            migrationBuilder.DropTable(
                name: "AppCandidateSkills");
        }
    }
}
