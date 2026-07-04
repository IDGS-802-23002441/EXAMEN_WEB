using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TiendaAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Tecnología" },
                    { 2, "Hogar" },
                    { 3, "Deportes" },
                    { 4, "Accesorios" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "Descripcion", "Imagen", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, 1, "Laptop ligera con procesador de alto rendimiento para trabajo y estudio.", "https://placehold.co/600x400/png?text=Laptop+Pro+14", "Laptop Pro 14", 18999.00m },
                    { 2, 1, "Teléfono con cámara avanzada, gran pantalla y batería de larga duración.", "https://placehold.co/600x400/png?text=Smartphone+X", "Smartphone X", 14999.00m },
                    { 3, 4, "Sonido envolvente, cancelación de ruido y estuche de carga compacta.", "https://placehold.co/600x400/png?text=Audifonos", "Audífonos inalámbricos", 1999.00m },
                    { 4, 2, "Pantalla 4K con sistema inteligente y conexión para streaming.", "https://placehold.co/600x400/png?text=Smart+TV", "Smart TV 55 pulgadas", 12999.00m },
                    { 5, 2, "Prepara café en pocos minutos con control de intensidad y temporizador.", "https://placehold.co/600x400/png?text=Cafetera", "Cafetera automática", 3299.00m },
                    { 6, 3, "Calzado deportivo cómodo y resistente para entrenamiento diario.", "https://placehold.co/600x400/png?text=Tenis+Running", "Tenis Running", 2499.00m },
                    { 7, 4, "Mochila resistente con compartimento acolchado para laptop.", "https://placehold.co/600x400/png?text=Mochila", "Mochila urbana", 1199.00m },
                    { 8, 3, "Bicicleta lista para rutas urbanas y senderos ligeros.", "https://placehold.co/600x400/png?text=Bicicleta", "Bicicleta de montaña", 8999.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
