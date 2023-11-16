using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Screen.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedScrollSpeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarqueeSpeed",
                table: "Configurations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarqueeSpeed",
                table: "Configurations");
        }
    }
}
