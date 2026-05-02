import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-auth',
  imports: [CommonModule, FormsModule],
  templateUrl: './auth.html',
  styleUrl: './auth.scss',
})
export class Auth {
  isLoginMode = true;
  isLoading = false;
  errorMessage = '';

  credentials = {
    name: '',
    username: '',
    phone: '',
    email: '',
    password: '',
    confirmPassword: ''
  };

  constructor(private authService: AuthService, private router: Router) {}

  toggleMode() {
    this.isLoginMode = !this.isLoginMode;
    this.errorMessage = '';
  }

  onSubmit() {
    if (this.isLoginMode) {
      if (!this.credentials.email || !this.credentials.password) {
        this.errorMessage = 'Please fill in all fields.';
        return;
      }
    } else {
      if (!this.credentials.name || !this.credentials.username || !this.credentials.phone || !this.credentials.email || !this.credentials.password || !this.credentials.confirmPassword) {
        this.errorMessage = 'Please fill in all fields to register.';
        return;
      }
      if (this.credentials.password !== this.credentials.confirmPassword) {
        this.errorMessage = 'Passwords do not match.';
        return;
      }
    }

    this.isLoading = true;
    this.errorMessage = '';

    const payload = this.isLoginMode ? {
      email: this.credentials.email,
      password: this.credentials.password
    } : {
      name: this.credentials.name,
      username: this.credentials.username,
      phoneNumber: this.credentials.phone,
      email: this.credentials.email,
      password: this.credentials.password
    };

    const request = this.isLoginMode 
      ? this.authService.login(payload)
      : this.authService.register(payload);

    request.subscribe({
      next: (res) => {
        this.isLoading = false;
        this.router.navigate(['/home']);
      },
      error: (err) => {
        this.isLoading = false;
        this.errorMessage = err.error?.message || 'Authentication failed. Please check your credentials.';
      }
    });
  }
}
