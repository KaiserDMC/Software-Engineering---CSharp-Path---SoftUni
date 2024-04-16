abstract class CreateAccount<T, V> {
    bankName: T;
    bankID: V;

    protected constructor(bankName: T, bankID: V) {
        this.bankName = bankName;
        this.bankID = bankID;
    }
}

class PersonalAccount<T, V> extends CreateAccount<T, V> {
    readonly ownerName: string;
    money: number = 0;
    recentTransactions: { [key: string]: number } = {};

    constructor(bankName: T, bankID: V, ownerName: string) {
        super(bankName, bankID);
        this.ownerName = ownerName;
    }

    deposit(amount: number): void {
        this.money += amount;
    }

    expense(amount: number, expenseType: string): void {
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

    showDetails(): string {
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

let account = new PersonalAccount('DSK', 101240, 'Ivan Ivanov');

account.deposit(1000);
account.deposit(1000);
account.expense(700, 'Buy new phone');
account.expense(400, 'Book a vacation');
account.expense(400, 'Book a vacation');
account.expense(100, 'Buy food');
console.log(account.showDetails());


let account2 = new PersonalAccount('Fibank', 100000, 'Petar Petrol');

account2.deposit(10000);
account2.deposit(7000);
account2.expense(1200, 'Buy a new car');
account2.expense(200, 'Go to a fancy restaurant');
account2.expense(100, 'Go to a bar');
account2.expense(30, 'Go to the movies');
console.log(account2.showDetails());
