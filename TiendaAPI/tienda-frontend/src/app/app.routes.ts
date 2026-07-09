import { Routes } from '@angular/router';

import { Home } from './pages/home/home';
import { Products } from './pages/products/products';

export const routes: Routes = [
	{ path: '', pathMatch: 'full', component: Home },
	{ path: 'productos', component: Products },
	{ path: '**', redirectTo: '' },
];
