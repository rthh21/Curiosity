import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

export interface MissionDto {
  id: number;
  title: string;
  payloadDescription: string;
  newsArticleBody?: string;
  imageUrl?: string;
  agencyName: string;
}

@Injectable({
  providedIn: 'root'
})
export class MissionService {
  private apiUrl = `${environment.apiUrl}/missions`;

  constructor(private http: HttpClient) { }

  getMissions(): Observable<MissionDto[]> {
    return this.http.get<MissionDto[]>(this.apiUrl);
  }

  getMissionById(id: number): Observable<MissionDto> {
    return this.http.get<MissionDto>(`${this.apiUrl}/${id}`);
  }

  getFavorites(): Observable<MissionDto[]> {
    return this.http.get<MissionDto[]>(`${environment.apiUrl}/favorites`);
  }

  addToFavorites(missionId: number): Observable<any> {
    return this.http.post(`${environment.apiUrl}/favorites/${missionId}`, {});
  }

  removeFromFavorites(missionId: number): Observable<any> {
    return this.http.delete(`${environment.apiUrl}/favorites/${missionId}`);
  }

  createMission(mission: any): Observable<any> {
    return this.http.post(this.apiUrl, mission);
  }
}
