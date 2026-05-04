import { Component, OnInit, OnDestroy, signal, computed } from '@angular/core';
import { CommonModule } from '@angular/common';
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
  // State using Signals
  launches = signal<LaunchDto[]>([]);
  weatherData = signal(WEATHER_DATA);
  currentTime = signal(Date.now());

  // Computed state
  featuredLaunch = computed(() => {
    const data = this.launches();
    return data.find(l => l.isFeatured) ?? data[0] ?? null;
  });

  scheduledLaunches = computed(() => {
    return this.launches().filter(l => !l.isFeatured);
  });

  countdowns = computed(() => {
    const now = this.currentTime();
    const map = new Map<number, Countdown>();
    for (const launch of this.launches()) {
      map.set(launch.id, this.calcCountdown(new Date(launch.launchDate), now));
    }
    return map;
  });

  private timer: ReturnType<typeof setInterval> | null = null;

  constructor(private launchService: LaunchService) { }

  ngOnInit(): void {
    this.launchService.getUpcomingLaunches().subscribe({
      next: (data) => {
        this.launches.set(data);
      }
    });

    // Update current time every second to drive the countdowns
    this.timer = setInterval(() => {
      this.currentTime.set(Date.now());
    }, 1000);
  }

  ngOnDestroy(): void {
    if (this.timer) clearInterval(this.timer);
  }

  calcCountdown(target: Date, now: number): Countdown {
    const diff = target.getTime() - now;
    if (diff <= 0) return { days: 0, hours: 0, minutes: 0, seconds: 0 };
    return {
      days: Math.floor(diff / (1000 * 60 * 60 * 24)),
      hours: Math.floor((diff / (1000 * 60 * 60)) % 24),
      minutes: Math.floor((diff / 1000 / 60) % 60),
      seconds: Math.floor((diff / 1000) % 60),
    };
  }

  getFeaturedCountdown(): Countdown {
    const featured = this.featuredLaunch();
    if (!featured) return { days: 0, hours: 0, minutes: 0, seconds: 0 };
    return this.countdowns().get(featured.id) ?? { days: 0, hours: 0, minutes: 0, seconds: 0 };
  }

  getCountdown(id: number): Countdown {
    return this.countdowns().get(id) ?? { days: 0, hours: 0, minutes: 0, seconds: 0 };
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

