import { Component } from '@angular/core';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html'
})
export class OrdersComponent {

  orders = [
    { id: 1, product: 'Charger', price: 1000, date: new Date(), status: 1 },
    { id: 2, product: 'Phone', price: 20000, date: new Date(), status: 2 },
    { id: 3, product: 'Table', price: 1500, date: new Date(), status: 3 }
  ];

}
