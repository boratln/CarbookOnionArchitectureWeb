using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carbook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BlogTableAddColumnBlogDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
          name: "BlogDescription",          
          table: "Blogs",         
          type: "nvarchar(max)",   
          nullable: true);         
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
       name: "BlogDescription",
       table: "Blogs");
            migrationBuilder.DropTable(
                name: "Blogs");

         
        }
    }
}
