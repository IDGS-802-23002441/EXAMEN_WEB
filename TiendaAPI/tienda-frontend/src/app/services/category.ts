import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { API_BASE_URL } from '../config/api.config';
import { Category } from '../models/category';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${API_BASE_URL}/categorias`;

  /**
   * Obtiene todas las categorías disponibles.
   * Endpoint: GET /api/categorias
   */
  getCategorias(): Observable<Category[]> {
    return this.http.get<Category[]>(this.apiUrl);
  }
}
