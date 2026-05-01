import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

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
  // ATENȚIE: Verifică în terminalul de .NET pe ce port rulează aplicația ta (ex: 5000, 5234, 7123)
  private apiUrl = 'http://localhost:5171/api/missions';

  constructor(private http: HttpClient) { }

  getMissions(): Observable<MissionDto[]> {
    return this.http.get<MissionDto[]>(this.apiUrl);
  }
}