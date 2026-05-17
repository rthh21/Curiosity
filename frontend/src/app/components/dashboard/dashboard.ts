import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MissionService, MissionDto } from '../../services/mission';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss',
})
export class Dashboard implements OnInit {
  private missionService = inject(MissionService);
  
  favorites = signal<MissionDto[]>([]);

  ngOnInit() {
    this.missionService.getFavorites().subscribe(data => {
      this.favorites.set(data);
    });
  }

  removeFromFavorites(id: number) {
    this.missionService.removeFromFavorites(id).subscribe(() => {
      this.favorites.update(favs => favs.filter(f => f.id !== id));
    });
  }
}
