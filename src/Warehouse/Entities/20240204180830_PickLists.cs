using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.Entities
{
    /// <inheritdoc />
    public partial class PickLists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PickLists",
                columns: table => new
                {
                    PickListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsPicked = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    WhenPicked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WhenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WhenUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickLists", x => x.PickListId);
                });

            migrationBuilder.CreateTable(
                name: "PickListItems",
                columns: table => new
                {
                    PickListItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sku = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    PickListId = table.Column<int>(type: "int", nullable: true),
                    WhenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WhenUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickListItems", x => x.PickListItemId);
                    table.ForeignKey(
                        name: "FK_PickListItems_PickLists_PickListId",
                        column: x => x.PickListId,
                        principalTable: "PickLists",
                        principalColumn: "PickListId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PickListItems_PickListId",
                table: "PickListItems",
                column: "PickListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PickListItems");

            migrationBuilder.DropTable(
                name: "PickLists");
        }
    }
}
