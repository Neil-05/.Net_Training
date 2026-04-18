import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'orderStatus'
})
export class OrderStatusPipe implements PipeTransform {

  transform(value: number): string {
    switch (value) {
      case 1: return 'Pending';
      case 2: return 'Shipped';
      case 3: return 'Delivered';
      default: return 'Unknown';
    }
  }

}
