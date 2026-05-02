import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
// Creăm o interfață (DTO) în TypeScript ca să se potrivească cu ce trimite .NET-ul
export interface MissionDto {
  id: number;
  title: string;
  payloadDescription: string;
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
}