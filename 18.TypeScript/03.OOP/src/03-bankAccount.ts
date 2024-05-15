class BankAccount {
    private static _nextId: number = 1;
    private static interestRate: number = 0.02;

    private _id: number;
    private _balance: number;

    constructor() {
        this._id = BankAccount._nextId++;
        this._balance = 0;
    }

    public getAccountId(): number {
        return this._id;
    }

    public getInterest(): number {
        return BankAccount.interestRate
    }

    public static setInterestRate(rate: number): void {
        BankAccount.interestRate = rate;
    }

    public deposit(amount: number): void {
        this._balance += amount;
    }

    calculateInterest(years: number): number {
        return this._balance * Math.pow(1 + BankAccount.interestRate, years) - this._balance;
    }
}

function client(): void {
    const accounts: { [id: number]: BankAccount } = {};
    //const command: string [] = ["Create", "Deposit 1 20", "GetInterest 1 10", "End"];
    const command: string [] = ["Create", "Create", "Deposit 1 20", "Deposit 3 20", "Deposit 2 10", "SetInterest 1.5", "GetInterest 1 1", "GetInterest 2 1", "GetInterest 3 1", "End"];
    let line: string | undefined;

    while ((line = command.shift()) !== undefined) {
        const tokens = line.split(' ');

        if (tokens[0] === 'Create') {
            const account = new BankAccount();
            accounts[account.getAccountId()] = account;
            console.log(`Account ID${account.getAccountId()} created`);

        } else if (tokens[0] === 'Deposit') {
            const accountId = parseInt(tokens[1]);
            const amount = parseFloat(tokens[2]);

            if (accounts[accountId]) {
                accounts[accountId].deposit(amount);
                console.log(`Deposited ${amount} to account ID${accountId}`);
            } else {
                console.log(`Account does not exist`);
            }
        } else if (tokens[0] === 'SetInterest') {
            const interestRate: number = parseFloat(tokens[1]);
            BankAccount.setInterestRate(interestRate);
            console.log(`Interest rate set to ${interestRate}`);
        } else if (tokens[0] === 'GetInterest') {
            const accountId: number = parseInt(tokens[1]);
            const years: number = parseFloat(tokens[2]);
            if (accounts[accountId]) {
                const interest: number = accounts[accountId].calculateInterest(years);
                console.log(`Interest on account ID${accountId} after ${years} years: ${interest.toFixed(2)}`);
            } else {
                console.log("Account does not exist");
            }
        } else if (tokens[0] === "End") {
            console.log("Exiting program.");
            break;
        } else {
            console.log("Invalid command.");
        }

    }
}

client();