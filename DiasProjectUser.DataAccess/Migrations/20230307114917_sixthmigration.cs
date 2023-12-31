﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiasProjectUser.DataAccess.Migrations
{
    public partial class sixthmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Users",
               columns: table => new
               {
                   id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   verificationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   dateOfAction = table.Column<DateTime>(type: "datetime2", nullable: false),
                   status = table.Column<string>(type: "nvarchar(max)", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Users", x => x.id);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
              name: "Users");
        }
    }
}
