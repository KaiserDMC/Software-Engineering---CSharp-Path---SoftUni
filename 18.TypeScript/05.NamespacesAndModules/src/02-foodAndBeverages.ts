namespace FoodAndBeverages {
    export interface Delivery {
        newCustomer(customerName: string, visited: boolean): void;

        visitCustomer(customerName: string): string;

        showCustomers(): string;
    }
}