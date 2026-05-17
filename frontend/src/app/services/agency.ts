import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

export interface AgencyDto {
  id: number;
  name: string;
  country: string;
  description?: string;
  logoUrl?: string;
}

@Injectable({ providedIn: 'root' })
export class AgencyService {
  private apiUrl = `${environment.apiUrl}/agencies`;

  constructor(private http: HttpClient) { }

  getAgencies(): Observable<AgencyDto[]> {
    return this.http.get<AgencyDto[]>(this.apiUrl);
  }
}
