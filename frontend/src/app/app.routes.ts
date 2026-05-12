import { Routes } from '@angular/router';
import { Auth } from './components/auth/auth';
import { Profile } from './components/profile/profile';
import { Home } from './components/home/home';
import { News } from './components/news/news';
import { Article } from './components/article/article';
import { Main as LaunchesMain } from './components/launches-page/main/main';
import { Upcoming } from './components/launches-page/upcoming/upcoming';
import { Archive } from './components/launches-page/archive/archive';
import { Dashboard } from './components/dashboard/dashboard';
import { Missions } from './components/missions/missions';

import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
  { path: 'auth', component: Auth },
  { path: 'profile', component: Profile, canActivate: [authGuard] },
  { path: 'home', component: Home },
  { path: 'dashboard', component: Dashboard, canActivate: [authGuard] },
  { path: 'launches', component: Upcoming },
  { path: 'launches/upcoming', component: Upcoming },
  { path: 'launches/past-archive', component: Archive },
  { path: 'missions', component: Missions },
  { path: 'missions/iss', children: [] },
  { path: 'missions/satellites', children: [] },
  { path: 'missions/deep-space', children: [] },
  { path: 'vehicles', children: [] },
  { path: 'vehicles/agencies', children: [] },
  { path: 'vehicles/rockets', children: [] },
  { path: 'news', component: News },
  { path: 'news/:id', component: Article },
  { path: '', redirectTo: 'home', pathMatch: 'full' }
];
