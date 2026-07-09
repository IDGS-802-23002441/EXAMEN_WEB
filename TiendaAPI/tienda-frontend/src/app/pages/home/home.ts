import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';

import { Product } from '../../models/product';
import { ProductService } from '../../services/product';
import { ProductCard } from '../../shared/product-card/product-card';

@Component({
  selector: 'app-home',
  imports: [CommonModule, RouterLink, ProductCard],
  templateUrl: './home.html',
  styleUrl: './home.scss',
})
export class Home implements OnInit {
  featuredProducts: Product[] = [];
  loading = true;
  errorMessage = '';

  constructor(private readonly productService: ProductService) {}

  ngOnInit(): void {
    this.productService.getProductos().subscribe({
      next: (products) => {
        this.featuredProducts = products.slice(0, 4);
        this.loading = false;
      },
      error: () => {
        this.errorMessage = 'No fue posible cargar los productos destacados.';
        this.loading = false;
      },
    });
  }
}
