import { Component, ChangeDetectionStrategy, signal, computed, OnInit, OnDestroy, inject, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MissionService, MissionDto } from '../../services/mission';
import { AuthService } from '../../services/auth';
import { AgencyService, AgencyDto } from '../../services/agency';

interface MissionPresentation {
  id: number;
  title: string;
  agency: string;
  type: string;
  status: string;
  target: string;
  description: string;
  image: string;
  isFavorite: boolean;
}

@Component({
  selector: 'app-missions',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule],
  templateUrl: './missions.html',
  styleUrl: './missions.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class Missions implements OnInit, OnDestroy {
  private missionService = inject(MissionService);
  private authService = inject(AuthService);
  private agencyService = inject(AgencyService);
  private cdr = inject(ChangeDetectorRef);
  
  // State
  allMissions = signal<MissionPresentation[]>([]);
  agencies = signal<AgencyDto[]>([]);
  activeIndex = signal(0);
  isPlaying = signal(true);
  isAdmin = signal(false);
  showAddModal = signal(false);

  newMission = {
    title: '',
    agencyId: 1,
    payloadDescription: '',
    newsArticleBody: '',
    imageUrl: ''
  };
  
  private slideTimer: any;

  // Split missions: 4 for presentation, the rest for archive
  presentationMissions = computed(() => this.allMissions().slice(0, 4));
  archiveMissions = computed(() => this.allMissions().slice(4));

  // Computed signal for the next slide preview
  nextMissionData = computed(() => {
    const list = this.presentationMissions();
    if (list.length === 0) return null;
    const nextIdx = (this.activeIndex() + 1) % list.length;
    return list[nextIdx];
  });

  ngOnInit() {
    this.authService.userRole$.subscribe(role => {
      this.isAdmin.set(role === 'Admin');
    });
    this.loadMissions();
    this.loadAgencies();
    this.startTimer();
  }

  loadAgencies() {
    this.agencyService.getAgencies().subscribe(data => {
      this.agencies.set(data);
      if (data.length > 0) {
        this.newMission.agencyId = data[0].id;
      }
    });
  }

  ngOnDestroy() {
    this.clearTimer();
  }

  loadMissions() {
    this.missionService.getMissions().subscribe(data => {
      this.missionService.getFavorites().subscribe(favorites => {
        const favoriteIds = new Set(favorites.map(f => f.id));
        const mapped = data.map(m => ({
          id: m.id,
          title: m.title,
          agency: m.agencyName || 'International Space Partnership',
          type: this.inferType(m.payloadDescription),
          status: 'Active (Mission Ongoing)',
          target: this.inferTarget(m.payloadDescription),
          description: m.payloadDescription,
          image: m.imageUrl || 'https://images.unsplash.com/photo-1451187580459-43490279c0fa?auto=format&fit=crop&w=1200&q=80',
          isFavorite: favoriteIds.has(m.id)
        }));
        this.allMissions.set(mapped);
        this.cdr.detectChanges();
      });
    });
  }

  toggleFavorite(mission: MissionPresentation) {
    if (mission.isFavorite) {
      this.missionService.removeFromFavorites(mission.id).subscribe(() => {
        this.updateFavoriteState(mission.id, false);
      });
    } else {
      this.missionService.addToFavorites(mission.id).subscribe(() => {
        this.updateFavoriteState(mission.id, true);
      });
    }
  }

  private updateFavoriteState(id: number, state: boolean) {
    this.allMissions.update(missions => 
      missions.map(m => m.id === id ? { ...m, isFavorite: state } : m)
    );
    this.cdr.detectChanges();
  }

  toggleAddModal() {
    this.showAddModal.update(v => !v);
  }

  onSubmitMission() {
    this.missionService.createMission(this.newMission).subscribe({
      next: () => {
        this.showAddModal.set(false);
        this.loadMissions();
        this.newMission = { title: '', agencyId: 1, payloadDescription: '', newsArticleBody: '', imageUrl: '' };
      },
      error: (err) => console.error('Failed to create mission', err)
    });
  }

  private inferType(desc: string): string {
    if (!desc) return 'Space Exploration';
    if (desc.toLowerCase().includes('rover')) return 'Surface Rover';
    if (desc.toLowerCase().includes('telescope')) return 'Space Observatory';
    if (desc.toLowerCase().includes('station')) return 'Orbital Laboratory';
    return 'Deep Space Probe';
  }

  private inferTarget(desc: string): string {
    if (!desc) return 'Various';
    if (desc.toLowerCase().includes('moon') || desc.toLowerCase().includes('lunar')) return 'The Moon';
    if (desc.toLowerCase().includes('mars')) return 'Mars';
    if (desc.toLowerCase().includes('sun') || desc.toLowerCase().includes('solar')) return 'The Sun';
    return 'Outer Space';
  }

  startTimer() {
    this.clearTimer();
    if (this.isPlaying()) {
      this.slideTimer = setInterval(() => {
        this.nextMission();
      }, 8000);
    }
  }

  clearTimer() {
    if (this.slideTimer) {
      clearInterval(this.slideTimer);
    }
  }

  togglePlay() {
    this.isPlaying.update(val => !val);
    this.startTimer();
  }

  nextMission() {
    const list = this.presentationMissions();
    if (list.length === 0) return;
    this.activeIndex.update(idx => (idx + 1) % list.length);
    this.startTimer();
  }

  prevMission() {
    const list = this.presentationMissions();
    if (list.length === 0) return;
    this.activeIndex.update(idx => idx === 0 ? list.length - 1 : idx - 1);
    this.startTimer();
  }

  setActive(idx: number) {
    this.activeIndex.set(idx);
    this.startTimer();
  }

  scrollToArchive() {
    const element = document.getElementById('mission-archive');
    if (element) {
      element.scrollIntoView({ behavior: 'smooth' });
    }
  }
}
