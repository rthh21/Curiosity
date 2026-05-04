import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MissionService, MissionDto } from '../../../services/mission';

@Component({
  selector: 'app-latest',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './latest.html',
  styleUrl: './latest.scss'
})
export class Latest implements OnInit {
  missions: MissionDto[] = [];

  constructor(private missionService: MissionService) {}

  ngOnInit(): void {
    this.missionService.getMissions().subscribe({
      next: (data) => {
        // Take the latest 3 missions
        this.missions = data.slice(0, 3);
      },
      error: (err) => console.error('Error fetching missions', err)
    });
  }
}
