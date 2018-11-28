using Microsoft.EntityFrameworkCore.Migrations;

namespace Lessplastic.Data.Migrations
{
    public partial class MinorChangeInUserEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersEvents_Events_EventId",
                table: "UsersEvents");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersEvents_Events_EventId",
                table: "UsersEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersEvents_Events_EventId",
                table: "UsersEvents");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersEvents_Events_EventId",
                table: "UsersEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
