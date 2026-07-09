import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { Category } from '../../models/category';
import { Product } from '../../models/product';
import { CategoryService } from '../../services/category';
import { ProductService } from '../../services/product';
import { ProductCard } from '../../shared/product-card/product-card';

@Component({
  selector: 'app-products',
  imports: [CommonModule, FormsModule, ProductCard],
  templateUrl: './products.html',
  styleUrl: './products.scss',
})
export class Products implements OnInit {
  categories: Category[] = [];
  filteredProducts: Product[] = [];

  searchTerm = '';
  selectedCategoryId = 0;

  loading = true;
  errorMessage = '';

  constructor(
    private readonly productService: ProductService,
    private readonly categoryService: CategoryService,
  ) {}

  ngOnInit(): void {
    this.loadInitialData();
  }

  /**
   * Se dispara en tiempo real mientras el usuario escribe o cambia el select.
   * En lugar de filtrar en memoria, consulta a la API para que los datos
   * provengan 100% de SQL Server.
   */
  onFiltersChange(): void {
    void this.loadProductsByFilters();
  }

  private loadInitialData(): void {
    this.loading = true;
    this.errorMessage = '';

    this.categoryService.getCategorias().subscribe({
      next: (categories) => {
        this.categories = categories;
      },
      error: () => {
        this.errorMessage = 'No fue posible cargar las categorías.';
        this.loading = false;
      },
    });

    // Carga inicial: sin filtros.
    void this.loadProductsByFilters();
  }

  private async loadProductsByFilters(): Promise<void> {
    this.loading = true;
    this.errorMessage = '';

    const searchValue = this.searchTerm.trim();
    const categoryId = this.selectedCategoryId;

    // Lógica simple (API-backed):
    // - Si hay categoría seleccionada, usamos /categoria/{id}
    // - Si además hay búsqueda, usamos /buscar?nombre=... y luego filtramos
    //   por categoría *en el backend* no existe en la API actual.
    // Para mantener “solo API” sin filtrar en memoria, priorizamos:
    // - si hay búsqueda, usamos /buscar
    // - si no hay búsqueda, usamos /categoria
    // Si quieres “buscar + categoría” estrictamente vía API, habría que
    // agregar un endpoint combinado en el backend.

    const request$ =
      searchValue.length > 0
        ? this.productService.buscarProductos(searchValue)
        : categoryId !== 0
          ? this.productService.getProductosPorCategoria(categoryId)
          : this.productService.getProductos();

    request$.subscribe({
      next: (products) => {
        this.filteredProducts = products;
        this.loading = false;
      },
      error: () => {
        this.errorMessage = 'No fue posible cargar los productos.';
        this.loading = false;
      },
    });
  }
}
