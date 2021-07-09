using Microsoft.EntityFrameworkCore.Migrations;

namespace Tiko_WebAPI.Migrations
{
    public partial class entitiesUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Cities_CityId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Agents_AgentId",
                table: "Houses");

            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Cities_CityId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_AgentId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_CityId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Agents_CityId",
                table: "Agents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Houses_AgentId",
                table: "Houses",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_CityId",
                table: "Houses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_CityId",
                table: "Agents",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Cities_CityId",
                table: "Agents",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Agents_AgentId",
                table: "Houses",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Cities_CityId",
                table: "Houses",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}