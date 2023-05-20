﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleProjects.Server.Migrations
{
    /// <inheritdoc />
    public partial class guidRecordinProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GuidRecord",
                table: "Products",
                type: "uniqueidentifier",
                maxLength: 10,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuidRecord",
                table: "Products");
        }
    }
}
