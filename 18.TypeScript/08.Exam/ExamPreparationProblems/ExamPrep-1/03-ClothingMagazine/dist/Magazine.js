"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Magazine = void 0;
class Magazine {
    type;
    capacity;
    clothes;
    constructor(type, capacity) {
        this.type = type;
        this.capacity = capacity;
        this.clothes = [];
    }
    getClothIndex(color) {
        return this.clothes.findIndex((c) => c.color === color);
    }
    sortClothes() {
        return this.clothes.sort((a, b) => a.size - b.size);
    }
    addCloth(cloth) {
        if (this.clothes.length < this.capacity) {
            this.clothes.push(cloth);
        }
        else {
            console.log('The magazine is full');
        }
    }
    removeCloth(color) {
        let index = this.getClothIndex(color);
        if (index !== -1) {
            this.clothes.splice(index, 1);
            return true;
        }
        return false;
    }
    getSmallestCloth() {
        return this.clothes.reduce((prev, current) => prev.size < current.size ? prev : current);
    }
    getCloth(color) {
        // @ts-ignore
        return this.clothes.find((c) => c.color === color);
    }
    getClothCount() {
        return this.clothes.length;
    }
    report() {
        const sorted = this.sortClothes();
        const clothesForReport = sorted.map((c) => c.toString()).join("\n");
        return `${this.type} magazine contains:\n${clothesForReport}`;
    }
}
exports.Magazine = Magazine;
//# sourceMappingURL=Magazine.js.map