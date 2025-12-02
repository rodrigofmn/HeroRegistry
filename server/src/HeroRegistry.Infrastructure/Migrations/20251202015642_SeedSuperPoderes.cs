using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HeroRegistry.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedSuperPoderes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SuperPoderes",
                columns: new[] { "Id", "Descricao", "SuperPoder" },
                values: new object[,]
                {
                    { 1, "Capacidade de exercer força além dos limites humanos.", "Super Força" },
                    { 2, "Permite ao herói voar a grandes altitudes e velocidades.", "Voo" },
                    { 3, "Movimenta-se em velocidades extremamente altas.", "Velocidade Sobrenatural" },
                    { 4, "Resistência extrema a danos físicos.", "Invulnerabilidade" },
                    { 5, "Capacidade de mover objetos com a mente.", "Telecinese" },
                    { 6, "Fica completamente invisível ao olho humano.", "Invisibilidade" },
                    { 7, "Consegue se curar rapidamente de ferimentos.", "Regeneração" },
                    { 8, "Manipula elementos naturais como fogo, água, ar e terra.", "Controle de Elementos" },
                    { 9, "Permite enxergar através de objetos.", "Visão de Raios-X" },
                    { 10, "Cria, controla e absorve diversos tipos de energia.", "Manipulação de Energia" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SuperPoderes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SuperPoderes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SuperPoderes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SuperPoderes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SuperPoderes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SuperPoderes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SuperPoderes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SuperPoderes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SuperPoderes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SuperPoderes",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
