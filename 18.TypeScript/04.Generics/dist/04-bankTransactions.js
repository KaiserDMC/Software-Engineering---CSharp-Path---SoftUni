"use strict";
class CreateAccount {
    bankName;
    bankID;
    constructor(bankName, bankID) {
        this.bankName = bankName;
        this.bankID = bankID;
    }
}
class PersonalAccount extends CreateAccount {
    ownerName;
    money = 0;
    recentTransactions = {};
    constructor(bankName, bankID, ownerName) {
        super(bankName, bankID);
        this.ownerName = ownerName;
    }
    deposit(amount) {
        this.money += amount;
    }
    expense(amount, expenseType) {
        if (this.money < amount) {
            console.log(`You can't make ${expenseType} transaction`);
            return;
        }
        this.money -= amount;
        if (!this.recentTransactions.hasOwnProperty(expenseType)) {
            this.recentTransactions[expenseType] = 0;
        }
        this.recentTransactions[expenseType] += amount;
    }
    showDetails() {
        let totalMoneySpentOnExpenses = 0;
        for (const transaction in this.recentTransactions) {
            totalMoneySpentOnExpenses += this.recentTransactions[transaction];
        }
        let details = `Bank name: ${this.bankName}\n`;
        details += `Bank ID: ${this.bankID}\n`;
        details += `Owner name: ${this.ownerName}\n`;
        details += `Money: ${this.money}\n`;
        details += `Money spent: ${totalMoneySpentOnExpenses}\n`;
        return details;
    }
}
// let account = new PersonalAccount('DSK', 101240, 'Ivan Ivanov');
//
// account.deposit(1000);
// account.deposit(1000);
// account.expense(700, 'Buy new phone');
// account.expense(400, 'Book a vacation');
// account.expense(400, 'Book a vacation');
// account.expense(100, 'Buy food');
// console.log(account.showDetails());
let account2 = new PersonalAccount('Fibank', 100000, 'Petar Petrol');
account2.deposit(10000);
account2.deposit(7000);
account2.expense(1200, 'Buy a new car');
account2.expense(200, 'Go to a fancy restaurant');
account2.expense(100, 'Go to a bar');
account2.expense(30, 'Go to the movies');
console.log(account2.showDetails());
//# sourceMappingURL=04-bankTransactions.js.map