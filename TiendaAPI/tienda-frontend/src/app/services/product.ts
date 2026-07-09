import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { API_BASE_URL } from '../config/api.config';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${API_BASE_URL}/productos`;

  getProductos(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiUrl);
  }

  getProductoById(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.apiUrl}/${id}`);
  }

  /**
   * Busca productos por nombre (endpoint: GET /api/productos/buscar?nombre=...)
   */
  buscarProductos(nombre: string): Observable<Product[]> {
    const params = new HttpParams().set('nombre', nombre);
    return this.http.get<Product[]>(`${this.apiUrl}/buscar`, { params });
  }

  /**
   * Obtiene productos por categoría (endpoint: GET /api/productos/categoria/{id})
   */
  getProductosPorCategoria(categoriaId: number): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.apiUrl}/categoria/${categoriaId}`);
  }
}
