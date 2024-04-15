"use strict";
class BankAccount {
    static _nextId = 1;
    static interestRate = 0.02;
    _id;
    _balance;
    constructor() {
        this._id = BankAccount._nextId++;
        this._balance = 0;
    }
    getAccountId() {
        return this._id;
    }
    getInterest() {
        return BankAccount.interestRate;
    }
    static setInterestRate(rate) {
        BankAccount.interestRate = rate;
    }
    deposit(amount) {
        this._balance += amount;
    }
    calculateInterest(years) {
        return this._balance * Math.pow(1 + BankAccount.interestRate, years) - this._balance;
    }
}
function client() {
    const accounts = {};
    //const command: string [] = ["Create", "Deposit 1 20", "GetInterest 1 10", "End"];
    const command = ["Create", "Create", "Deposit 1 20", "Deposit 3 20", "Deposit 2 10", "SetInterest 1.5", "GetInterest 1 1", "GetInterest 2 1", "GetInterest 3 1", "End"];
    let line;
    while ((line = command.shift()) !== undefined) {
        const tokens = line.split(' ');
        if (tokens[0] === 'Create') {
            const account = new BankAccount();
            accounts[account.getAccountId()] = account;
            console.log(`Account ID${account.getAccountId()} created`);
        }
        else if (tokens[0] === 'Deposit') {
            const accountId = parseInt(tokens[1]);
            const amount = parseFloat(tokens[2]);
            if (accounts[accountId]) {
                accounts[accountId].deposit(amount);
                console.log(`Deposited ${amount} to account ID${accountId}`);
            }
            else {
                console.log(`Account does not exist`);
            }
        }
        else if (tokens[0] === 'SetInterest') {
            const interestRate = parseFloat(tokens[1]);
            BankAccount.setInterestRate(interestRate);
            console.log(`Interest rate set to ${interestRate}`);
        }
        else if (tokens[0] === 'GetInterest') {
            const accountId = parseInt(tokens[1]);
            const years = parseFloat(tokens[2]);
            if (accounts[accountId]) {
                const interest = accounts[accountId].calculateInterest(years);
                console.log(`Interest on account ID${accountId} after ${years} years: ${interest.toFixed(2)}`);
            }
            else {
                console.log("Account does not exist");
            }
        }
        else if (tokens[0] === "End") {
            console.log("Exiting program.");
            break;
        }
        else {
            console.log("Invalid command.");
        }
    }
}
client();
//# sourceMappingURL=03-bankAccount.js.map