using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomScheduler.Data.Migrations
{
    public partial class AddEntityCreator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "TimeSlots",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Rooms",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_CreatorId",
                table: "TimeSlots",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CreatorId",
                table: "Rooms",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_AspNetUsers_CreatorId",
                table: "Rooms",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_AspNetUsers_CreatorId",
                table: "TimeSlots",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_AspNetUsers_CreatorId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_AspNetUsers_CreatorId",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_CreatorId",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_CreatorId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Rooms");
        }
    }
}
