import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-profile',
  imports: [CommonModule, FormsModule],
  templateUrl: './profile.html',
  styleUrl: './profile.scss',
})
export class Profile implements OnInit {
  isLoading = false;
  isSaving = false;
  errorMessage = '';
  successMessage = '';
  
  currentUsername = '';

  profileData = {
    username: '',
    email: '',
    phoneNumber: '',
    firstName: '',
    lastName: ''
  };

  constructor(
    private authService: AuthService, 
    private router: Router,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit() {
    this.authService.currentUser$.subscribe(username => {
      if (!username) {
        this.router.navigate(['/auth']);
      } else {
        this.currentUsername = username;
        this.loadProfile();
      }
    });
  }

  loadProfile() {
    this.isLoading = true;
    this.cdr.detectChanges();

    this.authService.getProfile(this.currentUsername).subscribe({
      next: (data) => {
        this.profileData = {
          username: data.username,
          email: data.email,
          phoneNumber: data.phoneNumber || '',
          firstName: data.firstName || '',
          lastName: data.lastName || ''
        };
        this.isLoading = false;
        this.cdr.detectChanges();
      },
      error: (err) => {
        console.error('Profile Load Error:', err);
        this.errorMessage = 'Failed to load profile. Please make sure your session is valid.';
        this.isLoading = false;
        this.cdr.detectChanges();
      }
    });
  }

  onSave() {
    if (!this.profileData.username) {
      this.errorMessage = 'Username is required.';
      return;
    }

    this.isSaving = true;
    this.errorMessage = '';
    this.successMessage = '';

    const updatePayload = {
      currentUsername: this.currentUsername,
      newUsername: this.profileData.username,
      phoneNumber: this.profileData.phoneNumber,
      firstName: this.profileData.firstName,
      lastName: this.profileData.lastName
    };

    this.authService.updateProfile(updatePayload).subscribe({
      next: (res) => {
        this.isSaving = false;
        this.successMessage = 'Profile updated successfully!';
        this.currentUsername = res.username;
        this.cdr.detectChanges();
        setTimeout(() => {
          this.successMessage = '';
          this.cdr.detectChanges();
        }, 3000);
      },
      error: (err) => {
        this.isSaving = false;
        this.errorMessage = err.error?.message || 'Failed to update profile.';
        this.cdr.detectChanges();
      }
    });
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/auth']);
  }
}
