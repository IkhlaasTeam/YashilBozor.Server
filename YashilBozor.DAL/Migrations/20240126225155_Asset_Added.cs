﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YashilBozor.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Asset_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEmailAddressVerified",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEmailAddressVerified",
                table: "Users");
        }
    }
}
