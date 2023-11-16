using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Screen.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedMarqueeToggle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MarqueeScroll",
                table: "Configurations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarqueeScroll",
                table: "Configurations");
        }
    }
}
