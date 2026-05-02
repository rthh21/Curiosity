import { Routes } from '@angular/router';
import { Auth } from './components/auth/auth';

export const routes: Routes = [
  { path: 'auth', component: Auth },
  { path: 'home', children: [] },
  { path: 'launches', children: [] },
  { path: 'launches/upcoming', children: [] },
  { path: 'launches/archive', children: [] },
  { path: 'missions', children: [] },
  { path: 'missions/iss', children: [] },
  { path: 'missions/satellites', children: [] },
  { path: 'missions/deep-space', children: [] },
  { path: 'vehicles', children: [] },
  { path: 'vehicles/agencies', children: [] },
  { path: 'vehicles/rockets', children: [] },
  { path: 'news', children: [] },
  { path: '', redirectTo: 'home', pathMatch: 'full' }
];
