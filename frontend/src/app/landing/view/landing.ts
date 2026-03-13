import { Component } from '@angular/core';
import { Hero } from '../sections/hero/hero';
import { Problem } from '../sections/problem/problem';
import { Navbar } from '../sections/navbar/navbar';
import { Footer } from '../../shared/components/footer/footer';

@Component({
  selector: 'app-landing',
  standalone: true,
  imports: [
    Navbar,
    Footer,
    Hero,
    Problem,

  ],
  templateUrl: './landing.html',
  styleUrl: './landing.css',
})
export class Landing {}
