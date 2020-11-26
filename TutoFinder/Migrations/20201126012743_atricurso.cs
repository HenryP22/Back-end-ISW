using Microsoft.EntityFrameworkCore.Migrations;

namespace TutoFinder.Migrations
{
    public partial class atricurso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Temario",
                table: "Cursos",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "dd6f7428-f60b-4935-8ccd-0835b197a0eb", "12b5e00e-c783-40cd-a7c7-dff58ebd38c1", "ADMIN", "ADMIN" },
                    { "3e1061df-c33e-4fe2-a2d0-a95c82abc443", "c7756115-a86b-47f1-95ce-a4bd51bf9eba", "PADRE", "PADRE" },
                    { "7bc67dda-d6c0-47af-a45c-54606f40c1a0", "564c5069-2c53-4cb1-b288-4e6f3a510cdb", "DOCENTE", "DOCENTE" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e1061df-c33e-4fe2-a2d0-a95c82abc443");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bc67dda-d6c0-47af-a45c-54606f40c1a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd6f7428-f60b-4935-8ccd-0835b197a0eb");

            migrationBuilder.DropColumn(
                name: "Temario",
                table: "Cursos");

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
    }
}
