using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Resume.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CVModels",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CompanyName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CVModel_I18n",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language = table.Column<int>(nullable: false),
                    About = table.Column<string>(nullable: false),
                    CVModelId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVModel_I18n", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CVModel_I18n_CVModels_CVModelId",
                        column: x => x.CVModelId,
                        principalTable: "CVModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Job_I18n",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Language = table.Column<int>(nullable: false),
                    Tittle = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    JobId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job_I18n", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Job_I18n_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobResponsibility",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobResponsibility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobResponsibility_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CVModel_JobResp",
                columns: table => new
                {
                    CVModelId = table.Column<string>(nullable: false),
                    JobResponsibilityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVModel_JobResp", x => new { x.CVModelId, x.JobResponsibilityId });
                    table.ForeignKey(
                        name: "FK_CVModel_JobResp_CVModels_CVModelId",
                        column: x => x.CVModelId,
                        principalTable: "CVModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CVModel_JobResp_JobResponsibility_JobResponsibilityId",
                        column: x => x.JobResponsibilityId,
                        principalTable: "JobResponsibility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobResponsibility_I18n",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    JobResponsibilityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobResponsibility_I18n", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobResponsibility_I18n_JobResponsibility_JobResponsibilityId",
                        column: x => x.JobResponsibilityId,
                        principalTable: "JobResponsibility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CVModel_I18n_CVModelId",
                table: "CVModel_I18n",
                column: "CVModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CVModel_JobResp_JobResponsibilityId",
                table: "CVModel_JobResp",
                column: "JobResponsibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_I18n_JobId",
                table: "Job_I18n",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobResponsibility_JobId",
                table: "JobResponsibility",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobResponsibility_I18n_JobResponsibilityId",
                table: "JobResponsibility_I18n",
                column: "JobResponsibilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CVModel_I18n");

            migrationBuilder.DropTable(
                name: "CVModel_JobResp");

            migrationBuilder.DropTable(
                name: "Job_I18n");

            migrationBuilder.DropTable(
                name: "JobResponsibility_I18n");

            migrationBuilder.DropTable(
                name: "PersonalInfo");

            migrationBuilder.DropTable(
                name: "CVModels");

            migrationBuilder.DropTable(
                name: "JobResponsibility");

            migrationBuilder.DropTable(
                name: "Job");
        }
    }
}
