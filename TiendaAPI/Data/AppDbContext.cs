using Microsoft.EntityFrameworkCore;
using TiendaAPI.Models;

namespace TiendaAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories => Set<Category>();

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Categorias");
            entity.HasKey(category => category.Id);
            entity.Property(category => category.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasData(
                new Category { Id = 1, Nombre = "Tecnología" },
                new Category { Id = 2, Nombre = "Hogar" },
                new Category { Id = 3, Nombre = "Deportes" },
                new Category { Id = 4, Nombre = "Accesorios" }
            );
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Productos");
            entity.HasKey(product => product.Id);
            entity.Property(product => product.Nombre)
                .IsRequired()
                .HasMaxLength(150);
            entity.Property(product => product.Descripcion)
                .IsRequired()
                .HasMaxLength(500);
            entity.Property(product => product.Precio)
                .HasPrecision(18, 2);
            entity.Property(product => product.Imagen)
                .IsRequired()
                .HasMaxLength(300);

            entity.HasOne(product => product.Categoria)
                .WithMany(category => category.Products)
                .HasForeignKey(product => product.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasData(
                new Product
                {
                    Id = 1,
                    Nombre = "Laptop Pro 14",
                    Descripcion = "Laptop ligera con procesador de alto rendimiento para trabajo y estudio.",
                    Precio = 18999.00m,
                    Imagen = "https://placehold.co/600x400/png?text=Laptop+Pro+14",
                    CategoriaId = 1
                },
                new Product
                {
                    Id = 2,
                    Nombre = "Smartphone X",
                    Descripcion = "Teléfono con cámara avanzada, gran pantalla y batería de larga duración.",
                    Precio = 14999.00m,
                    Imagen = "https://placehold.co/600x400/png?text=Smartphone+X",
                    CategoriaId = 1
                },
                new Product
                {
                    Id = 3,
                    Nombre = "Audífonos inalámbricos",
                    Descripcion = "Sonido envolvente, cancelación de ruido y estuche de carga compacta.",
                    Precio = 1999.00m,
                    Imagen = "https://placehold.co/600x400/png?text=Audifonos",
                    CategoriaId = 4
                },
                new Product
                {
                    Id = 4,
                    Nombre = "Smart TV 55 pulgadas",
                    Descripcion = "Pantalla 4K con sistema inteligente y conexión para streaming.",
                    Precio = 12999.00m,
                    Imagen = "https://placehold.co/600x400/png?text=Smart+TV",
                    CategoriaId = 2
                },
                new Product
                {
                    Id = 5,
                    Nombre = "Cafetera automática",
                    Descripcion = "Prepara café en pocos minutos con control de intensidad y temporizador.",
                    Precio = 3299.00m,
                    Imagen = "https://placehold.co/600x400/png?text=Cafetera",
                    CategoriaId = 2
                },
                new Product
                {
                    Id = 6,
                    Nombre = "Tenis Running",
                    Descripcion = "Calzado deportivo cómodo y resistente para entrenamiento diario.",
                    Precio = 2499.00m,
                    Imagen = "https://placehold.co/600x400/png?text=Tenis+Running",
                    CategoriaId = 3
                },
                new Product
                {
                    Id = 7,
                    Nombre = "Mochila urbana",
                    Descripcion = "Mochila resistente con compartimento acolchado para laptop.",
                    Precio = 1199.00m,
                    Imagen = "https://placehold.co/600x400/png?text=Mochila",
                    CategoriaId = 4
                },
                new Product
                {
                    Id = 8,
                    Nombre = "Bicicleta de montaña",
                    Descripcion = "Bicicleta lista para rutas urbanas y senderos ligeros.",
                    Precio = 8999.00m,
                    Imagen = "https://placehold.co/600x400/png?text=Bicicleta",
                    CategoriaId = 3
                }
            );
        });
    }
}