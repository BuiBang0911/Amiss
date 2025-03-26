import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

type ToastType = 'success' | 'warning' | 'error';

@Injectable({
  providedIn: 'root',
})
export class ToastService {
  private messageSubject = new BehaviorSubject<{ message: string | null; type: ToastType } | null>(null);
  message$ = this.messageSubject.asObservable();
  private timeoutId: any;

  showMessage(message: string, type: ToastType = 'success', duration: number = 5000) {
    this.messageSubject.next(null);
    clearTimeout(this.timeoutId);

    setTimeout(() => {
        this.messageSubject.next({ message, type });
  
        this.timeoutId = setTimeout(() => this.messageSubject.next(null), duration);
      }, 300);
  }

  closeMessage() {
    this.messageSubject.next(null);
  }
}
