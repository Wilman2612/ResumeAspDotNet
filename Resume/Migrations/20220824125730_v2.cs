using Microsoft.EntityFrameworkCore.Migrations;

namespace Resume.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CVModel_I18n");

            migrationBuilder.DropTable(
                name: "Job_I18n");

            migrationBuilder.DropTable(
                name: "JobResponsibility_I18n");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "JobResponsibility",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEs",
                table: "JobResponsibility",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocationEn",
                table: "Job",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocationEs",
                table: "Job",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TittleEn",
                table: "Job",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TittleEs",
                table: "Job",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutMeEn",
                table: "CVModels",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutMeEs",
                table: "CVModels",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "JobResponsibility");

            migrationBuilder.DropColumn(
                name: "DescriptionEs",
                table: "JobResponsibility");

            migrationBuilder.DropColumn(
                name: "LocationEn",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "LocationEs",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "TittleEn",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "TittleEs",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "AboutMeEn",
                table: "CVModels");

            migrationBuilder.DropColumn(
                name: "AboutMeEs",
                table: "CVModels");

            migrationBuilder.CreateTable(
                name: "CVModel_I18n",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVModelId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Language = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Language = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tittle = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "JobResponsibility_I18n",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobResponsibilityId = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Job_I18n_JobId",
                table: "Job_I18n",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobResponsibility_I18n_JobResponsibilityId",
                table: "JobResponsibility_I18n",
                column: "JobResponsibilityId");
        }
    }
}
