import { Injectable, PLATFORM_ID, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable, BehaviorSubject, tap } from 'rxjs';
import { isPlatformBrowser } from '@angular/common';

export interface AuthResponse {
  token?: string;
  message?: string;
  username?: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = `${environment.apiUrl}/auth`;
  
  private currentUserSubject = new BehaviorSubject<string | null>(null);
  public currentUser$ = this.currentUserSubject.asObservable();

  private userRoleSubject = new BehaviorSubject<string | null>(null);
  public userRole$ = this.userRoleSubject.asObservable();

  constructor(private http: HttpClient, @Inject(PLATFORM_ID) private platformId: Object) {
    if (isPlatformBrowser(this.platformId)) {
      const storedUser = localStorage.getItem('username');
      const token = localStorage.getItem('token');
      if (storedUser) {
        this.currentUserSubject.next(storedUser);
      }
      if (token) {
        this.userRoleSubject.next(this.getRoleFromToken(token));
      }
    }
  }

  private getRoleFromToken(token: string): string | null {
    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      return payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] || payload.role || null;
    } catch {
      return null;
    }
  }

  login(credentials: any): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.apiUrl}/login`, credentials).pipe(
      tap(res => this.handleAuthSuccess(res, credentials.email))
    );
  }

  register(credentials: any): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.apiUrl}/register`, credentials).pipe(
      tap(res => this.handleAuthSuccess(res, credentials.username || credentials.name))
    );
  }

  private handleAuthSuccess(res: AuthResponse, fallbackName: string) {
    if (isPlatformBrowser(this.platformId)) {
      if (res.token) {
        localStorage.setItem('token', res.token);
        this.userRoleSubject.next(this.getRoleFromToken(res.token));
      }
      const username = res.username || fallbackName || 'Explorer';
      localStorage.setItem('username', username);
      this.currentUserSubject.next(username);
    }
  }

  logout() {
    if (isPlatformBrowser(this.platformId)) {
      localStorage.removeItem('token');
      localStorage.removeItem('username');
      this.currentUserSubject.next(null);
      this.userRoleSubject.next(null);
    }
  }

  getProfile(username: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/profile/${username}`);
  }

  updateProfile(profileData: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/profile`, profileData).pipe(
      tap((res: any) => {
        if (res && res.username) {
          if (isPlatformBrowser(this.platformId)) {
            localStorage.setItem('username', res.username);
            this.currentUserSubject.next(res.username);
          }
        }
      })
    );
  }
}
