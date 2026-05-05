import { Component, OnInit, signal, computed } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { LaunchService, LaunchDto } from '../../../services/launch';

@Component({
  selector: 'app-archive',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './archive.html',
  styleUrl: './archive.scss',
})
export class Archive implements OnInit {
  launches = signal<LaunchDto[]>([]);
  isLoading = signal(true);

  // Computed state
  latestPastLaunch = computed(() => {
    const data = this.launches();
    return data[0] ?? null;
  });

  olderLaunches = computed(() => {
    return this.launches().slice(1);
  });

  constructor(private launchService: LaunchService) { }

  ngOnInit(): void {
    this.launchService.getPastLaunches().subscribe({
      next: (data) => {
        this.launches.set(data);
        this.isLoading.set(false);
      },
      error: () => {
        this.isLoading.set(false);
      }
    });
  }

  formatDate(dateStr: string): string {
    const d = new Date(dateStr);
    return d.toLocaleDateString('en-US', {
      weekday: 'short', year: 'numeric', month: 'long',
      day: 'numeric', hour: '2-digit', minute: '2-digit',
      timeZoneName: 'short'
    });
  }

  getFallbackImage(): string {
    return 'https://images.unsplash.com/photo-1517976487492-5750f3195933?q=80&w=1200&auto=format&fit=crop';
  }
}
