import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { MissionService, MissionDto } from '../../services/mission';

@Component({
  selector: 'app-article',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './article.html',
  styleUrl: './article.scss'
})
export class Article implements OnInit {
  mission: MissionDto | null = null;
  loading: boolean = true;
  error: string | null = null;

  constructor(
    private route: ActivatedRoute,
    private missionService: MissionService,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    // Subscribe to route changes instead of using a single snapshot
    this.route.paramMap.subscribe(params => {
      const idParam = params.get('id');

      if (idParam) {
        this.loading = true; // Always reset loading state when route changes
        this.error = null;   // Clear previous errors
        const id = parseInt(idParam, 10);

        this.missionService.getMissionById(id).subscribe({
          next: (data) => {
            this.mission = data;
            this.loading = false;
            this.cdr.detectChanges();
          },
          error: (err) => {
            console.error('Error fetching mission', err);
            this.error = 'Failed to load the article.';
            this.loading = false;
          }
        });
      } else {
        this.error = 'Invalid article ID.';
        this.loading = false;
      }
    });
  }
}
