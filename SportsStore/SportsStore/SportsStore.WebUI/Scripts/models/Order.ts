module app {
    'use strict'
    export class Order {
        orderId: number;
        orderNo: string;
        customerId: number;
        customerName: number;
        email: string;
        address: string;
        phone: string;
        comment: string;
        orderDetails: OrderDetail[];
        total: number;
        orderDate: Date;
        status: number;

        constructor() {
        }
    }
}