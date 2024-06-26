using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementTool.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedPlanPoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlanPoints",
                table: "Tasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlanPoints",
                table: "Tasks",
                type: "TEXT",
                nullable: true);
        }
    }
}
