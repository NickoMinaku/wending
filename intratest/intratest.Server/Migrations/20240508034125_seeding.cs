using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace intratest.Server.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cost", "Name", "Quantity" },
                values: new object[] { 150, "Кола", 5 });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "Cost", "Name", "Path", "Quantity" },
                values: new object[,]
                {
                    { 2, 100, "Спрайт", "./drinks/2.png", 7 },
                    { 3, 130, "Фанта", "./drinks/3.png", 0 },
                    { 4, 60, "Милкис", "./drinks/4.png", 7 },
                    { 5, 110, "Квас", "./drinks/5.png", 20 },
                    { 6, 200, "Яблочный сок", "./drinks/6.png", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cost", "Name", "Quantity" },
                values: new object[] { 412, "Tom", 1 });
        }
    }
}
