"use strict";
class Courier {
    placesToVisit;
    constructor(customers) {
        this.placesToVisit = {};
        customers.forEach(customer => {
            this.newCustomer(customer.customerName, customer.visited);
        });
    }
    newCustomer(customerName, visited = false) {
        if (this.placesToVisit.hasOwnProperty(customerName)) {
            console.log(`${customerName} is already a customer of yours!`);
            return;
        }
        this.placesToVisit[customerName] = visited;
        console.log(`${customerName} just became your client.`);
    }
    visitCustomer(customerName) {
        if (!this.placesToVisit.hasOwnProperty(customerName)) {
            return `${customerName} is not your customer`;
        }
        this.placesToVisit[customerName] = true;
        return `You have visited ${customerName}.`;
    }
    showCustomers() {
        let customers = "";
        for (const [customerName, visited] of Object.entries(this.placesToVisit)) {
            customers += `${customerName} -> ${visited}\n`;
        }
        return customers;
    }
}
let courier = new Courier([{ customerName: 'DHL', visited: false }]);
courier.newCustomer('Speedy');
courier.newCustomer('MTM');
courier.newCustomer('TipTop');
courier.visitCustomer('DHL');
courier.visitCustomer('MTM');
courier.visitCustomer('MTM');
console.log(courier.showCustomers());
//# sourceMappingURL=02-courier.js.map