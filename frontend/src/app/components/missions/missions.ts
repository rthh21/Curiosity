import { Component, ChangeDetectionStrategy, signal, computed, OnInit, OnDestroy, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MissionService, MissionDto } from '../../services/mission';

interface MissionPresentation {
  id: number;
  title: string;
  agency: string;
  type: string;
  status: string;
  target: string;
  description: string;
  image: string;
}

@Component({
  selector: 'app-missions',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './missions.html',
  styleUrl: './missions.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class Missions implements OnInit, OnDestroy {
  private missionService = inject(MissionService);
  
  // State
  allMissions = signal<MissionPresentation[]>([]);
  activeIndex = signal(0);
  isPlaying = signal(true);
  
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
    this.loadMissions();
    this.startTimer();
  }

  ngOnDestroy() {
    this.clearTimer();
  }

  loadMissions() {
    this.missionService.getMissions().subscribe(data => {
      const mapped = data.map(m => ({
        id: m.id,
        title: m.title,
        agency: m.agencyName || 'International Space Partnership',
        type: this.inferType(m.payloadDescription),
        status: 'Active (Mission Ongoing)',
        target: this.inferTarget(m.payloadDescription),
        description: m.payloadDescription,
        image: m.imageUrl || 'https://images.unsplash.com/photo-1451187580459-43490279c0fa?auto=format&fit=crop&w=1200&q=80'
      }));
      this.allMissions.set(mapped);
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
