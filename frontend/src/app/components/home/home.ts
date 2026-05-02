import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Hero } from './hero/hero';
import { Latest } from './latest/latest';

@Component({
  selector: 'app-home',
  imports: [CommonModule, Hero, Latest],
  templateUrl: './home.html',
  styleUrl: './home.scss'
})
export class Home {}
