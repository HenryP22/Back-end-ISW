using Microsoft.EntityFrameworkCore.Migrations;

namespace TutoFinder.Migrations
{
    public partial class cambinforme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38d94ede-d69b-4bbd-92c8-f4b3b3cbf941");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a85572ae-3e86-421e-8cbe-1c1a847f2b3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e886d425-7e6d-4ac5-997c-ab0bddec2ee0");

            migrationBuilder.AddColumn<string>(
                name: "Recomendaciones",
                table: "Informes",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8dc91d0a-4632-4b7b-aaae-d40eb91a8ab1", "a526c6de-9a5c-4e77-b606-75c662a1268c", "ADMIN", "ADMIN" },
                    { "7d7eba63-89e8-4686-b2b2-21f2061864a7", "51edfcb0-f84d-4b05-948e-7a46b9e0bec8", "PADRE", "PADRE" },
                    { "4eb3739b-0cda-42b7-baca-ff8b1a61b699", "5d3282e4-46a0-4378-8d78-f84a00109407", "DOCENTE", "DOCENTE" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb3739b-0cda-42b7-baca-ff8b1a61b699");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d7eba63-89e8-4686-b2b2-21f2061864a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dc91d0a-4632-4b7b-aaae-d40eb91a8ab1");

            migrationBuilder.DropColumn(
                name: "Recomendaciones",
                table: "Informes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a85572ae-3e86-421e-8cbe-1c1a847f2b3a", "32855740-aaa8-466e-af7c-5f1bcecf5ed5", "ADMIN", "ADMIN" },
                    { "e886d425-7e6d-4ac5-997c-ab0bddec2ee0", "a0546cd6-7f6e-4576-a74a-ed1e3fdf8640", "PADRE", "PADRE" },
                    { "38d94ede-d69b-4bbd-92c8-f4b3b3cbf941", "142e4755-0d10-4c70-9806-1735122f09d9", "DOCENTE", "DOCENTE" }
                });
        }
    }
}
