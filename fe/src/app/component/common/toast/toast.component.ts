import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ToastService } from '../../../services/toast.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-toast',
  templateUrl: './toast.component.html',
  imports:[
    CommonModule
  ]
})
export class ToastComponent implements OnDestroy {
  message: string | null = null;
  type: 'success' | 'warning' | 'error' = 'success'; // Mặc định là success
  private subscription!: Subscription;

  constructor(private toastService: ToastService) {
    console.log('✅ ToastComponent đã khởi tạo');
    this.subscription = this.toastService.message$.subscribe(toast => {
      console.log('Component nhận message:', toast);
      if (toast) {
        this.message = toast.message;
        console.log('111111111111', this.message)
        this.type = toast.type;
      } else {
        this.message = null;
      }
    });
  }

  // ngOnInit() {
  //   console.log('Test gọi showMessage');
  //   this.toastService.showMessage('Test thông báo!', 'success');
  // }

  closeMessage() {
    this.toastService.closeMessage();
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
