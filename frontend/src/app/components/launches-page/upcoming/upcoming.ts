import { Component, OnInit, OnDestroy } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { RouterModule } from '@angular/router';
import { LaunchService, LaunchDto } from '../../../services/launch';

interface Countdown {
  days: number;
  hours: number;
  minutes: number;
  seconds: number;
}

interface WeatherData {
  id: number;
  location: string;
  temp: string;
  condition: string;
  wind: string;
  icon: 'sun' | 'cloud';
}

const WEATHER_DATA: WeatherData[] = [
  { id: 1, location: 'Kennedy Space Center, FL', temp: '78°F', condition: 'Partly Cloudy', wind: '12 mph', icon: 'cloud' },
  { id: 2, location: 'Starbase, TX', temp: '85°F', condition: 'Sunny', wind: '15 mph', icon: 'sun' },
  { id: 3, location: 'Vandenberg SFB, CA', temp: '62°F', condition: 'Coastal Fog', wind: '8 mph', icon: 'cloud' },
  { id: 4, location: 'Cape Canaveral, FL', temp: '77°F', condition: 'Clear', wind: '10 mph', icon: 'sun' },
];

@Component({
  selector: 'app-upcoming',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './upcoming.html',
  styleUrl: './upcoming.scss',
})
export class Upcoming implements OnInit, OnDestroy {
  launches: LaunchDto[] = [];
  featuredLaunch: LaunchDto | null = null;
  scheduledLaunches: LaunchDto[] = [];
  weatherData = WEATHER_DATA;

  countdowns: Map<number, Countdown> = new Map();
  private timer: ReturnType<typeof setInterval> | null = null;

  constructor(private launchService: LaunchService) { }

  ngOnInit(): void {
    this.launchService.getUpcomingLaunches().subscribe({
      next: (data) => {
        this.launches = data;
        this.featuredLaunch = data.find(l => l.isFeatured) ?? data[0] ?? null;
        this.scheduledLaunches = data.filter(l => !l.isFeatured);
        this.recalcCountdowns();
        this.timer = setInterval(() => this.recalcCountdowns(), 1000);
      }
    });
  }

  ngOnDestroy(): void {
    if (this.timer) clearInterval(this.timer);
  }

  private recalcCountdowns(): void {
    for (const launch of this.launches) {
      this.countdowns.set(launch.id, this.calcCountdown(new Date(launch.launchDate)));
    }
  }

  calcCountdown(target: Date): Countdown {
    const diff = target.getTime() - Date.now();
    if (diff <= 0) return { days: 0, hours: 0, minutes: 0, seconds: 0 };
    return {
      days: Math.floor(diff / (1000 * 60 * 60 * 24)),
      hours: Math.floor((diff / (1000 * 60 * 60)) % 24),
      minutes: Math.floor((diff / 1000 / 60) % 60),
      seconds: Math.floor((diff / 1000) % 60),
    };
  }

  getFeaturedCountdown(): Countdown {
    if (!this.featuredLaunch) return { days: 0, hours: 0, minutes: 0, seconds: 0 };
    return this.countdowns.get(this.featuredLaunch.id) ?? { days: 0, hours: 0, minutes: 0, seconds: 0 };
  }

  getCountdown(id: number): Countdown {
    return this.countdowns.get(id) ?? { days: 0, hours: 0, minutes: 0, seconds: 0 };
  }

  pad(n: number): string {
    return n.toString().padStart(2, '0');
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
