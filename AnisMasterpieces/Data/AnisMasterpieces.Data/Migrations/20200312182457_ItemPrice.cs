﻿namespace AnisMasterpieces.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ItemPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Items",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Items");
        }
    }
}
