class OrderDetail {
    private orderDetailId: number;
    private productNo: string;
    private productName: string;
    private quantity: number;
    private price: number;
    private total: number;

    get OrderDetailId(): number {
        return this.orderDetailId;
    }

    set OrderDetailId(orderDetailId: number) {
        this.orderDetailId = orderDetailId;
    }

    get ProductNo(): string {
        return this.productNo;
    }

    set ProductNo(productNo: string) {
        this.productNo = productNo;
    }

    get ProductName(): string {
        return this.productName;
    }

    set ProductName(productName: string) {
        this.productName = productName;
    }

    get Quantity(): number {
        return this.quantity;
    }

    set Quantity(quantity: number) {
        this.quantity = quantity;
    }

    get Price(): number {
        return this.price;
    }

    set Price(price: number) {
        this.price = price;
    }

    get Total(): number {
        return this.total;
    }

    set Total(total: number) {
        this.total = total;
    }
} 