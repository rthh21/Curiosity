import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MissionService, MissionDto } from '../../services/mission';

@Component({
  selector: 'app-news',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './news.html',
  styleUrl: './news.scss'
})
export class News implements OnInit {
  isLoading: boolean = true;
  missions: MissionDto[] = [];
  filteredMissions: MissionDto[] = [];

  searchTerm: string = '';
  agencyFilter: string = '';

  uniqueAgencies: string[] = []

  constructor(
    private missionService: MissionService,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.missionService.getMissions().subscribe({
      next: (data) => {
        this.isLoading = false;
        this.missions = data;
        const agencies = this.missions.map(m => m.agencyName).filter(name => !!name);
        this.uniqueAgencies = [...new Set(agencies)];
        this.applyFilters();
        this.cdr.detectChanges();
      },
      error: (err) => console.error('Error fetching missions', err)
    });
  }

  applyFilters(): void {
    this.filteredMissions = this.missions.filter(m => {
      const matchesSearch = this.searchTerm ?
        (m.title?.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
          m.payloadDescription?.toLowerCase().includes(this.searchTerm.toLowerCase())) : true;

      const matchesAgency = this.agencyFilter ?
        m.agencyName === this.agencyFilter : true;

      return matchesSearch && matchesAgency;
    });
  }
}
