import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

export interface LaunchDto {
  id: number;
  launchDate: string;
  rocketName: string;
  flightStatus: string;
  liveStreamUrl?: string;
  launchLocation: string;
  isFeatured: boolean;
  missionTitle: string;
  missionDescription: string;
  missionImageUrl?: string;
  agencyName: string;
}

@Injectable({ providedIn: 'root' })
export class LaunchService {
  private apiUrl = `${environment.apiUrl}/launches`;

  constructor(private http: HttpClient) { }

  getUpcomingLaunches(): Observable<LaunchDto[]> {
    return this.http.get<LaunchDto[]>(this.apiUrl);
  }
}
