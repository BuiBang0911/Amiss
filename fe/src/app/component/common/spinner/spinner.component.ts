import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  imports: [
    CommonModule
  ]
})
export class SpinnerComponent {
  @Input() isLoading = false;
}
