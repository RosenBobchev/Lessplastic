using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lessplastic.Data.Migrations
{
    public partial class pollsentitiesupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoolsAnswers");

            migrationBuilder.DropTable(
                name: "PoolsUsers");

            migrationBuilder.DropTable(
                name: "Pools");

            migrationBuilder.AddColumn<int>(
                name: "PollId",
                table: "Answers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Voters",
                table: "Answers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Polls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PollsUsers",
                columns: table => new
                {
                    LessplasticUserId = table.Column<string>(nullable: false),
                    PollId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollsUsers", x => new { x.LessplasticUserId, x.PollId });
                    table.ForeignKey(
                        name: "FK_PollsUsers_AspNetUsers_LessplasticUserId",
                        column: x => x.LessplasticUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PollsUsers_Polls_PollId",
                        column: x => x.PollId,
                        principalTable: "Polls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_PollId",
                table: "Answers",
                column: "PollId");

            migrationBuilder.CreateIndex(
                name: "IX_PollsUsers_PollId",
                table: "PollsUsers",
                column: "PollId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Polls_PollId",
                table: "Answers",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Polls_PollId",
                table: "Answers");

            migrationBuilder.DropTable(
                name: "PollsUsers");

            migrationBuilder.DropTable(
                name: "Polls");

            migrationBuilder.DropIndex(
                name: "IX_Answers_PollId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "PollId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "Voters",
                table: "Answers");

            migrationBuilder.CreateTable(
                name: "Pools",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PoolsAnswers",
                columns: table => new
                {
                    AnswerId = table.Column<int>(nullable: false),
                    PoolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoolsAnswers", x => new { x.AnswerId, x.PoolId });
                    table.ForeignKey(
                        name: "FK_PoolsAnswers_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoolsAnswers_Pools_PoolId",
                        column: x => x.PoolId,
                        principalTable: "Pools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoolsUsers",
                columns: table => new
                {
                    LessplasticUserId = table.Column<string>(nullable: false),
                    PoolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoolsUsers", x => new { x.LessplasticUserId, x.PoolId });
                    table.ForeignKey(
                        name: "FK_PoolsUsers_AspNetUsers_LessplasticUserId",
                        column: x => x.LessplasticUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoolsUsers_Pools_PoolId",
                        column: x => x.PoolId,
                        principalTable: "Pools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PoolsAnswers_PoolId",
                table: "PoolsAnswers",
                column: "PoolId");

            migrationBuilder.CreateIndex(
                name: "IX_PoolsUsers_PoolId",
                table: "PoolsUsers",
                column: "PoolId");
        }
    }
}
