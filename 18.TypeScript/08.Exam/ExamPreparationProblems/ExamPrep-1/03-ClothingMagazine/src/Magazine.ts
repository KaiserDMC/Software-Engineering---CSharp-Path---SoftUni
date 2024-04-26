import {Cloth} from "./Cloth";

export class Magazine {
    private readonly type: string;
    private readonly capacity: number;
    private clothes: Cloth[];

    constructor(type: string, capacity: number) {
        this.type = type;
        this.capacity = capacity;
        this.clothes = [];
    }

    private getClothIndex(color: string): number {
        return this.clothes.findIndex((c) => c.color === color);
    }

    private sortClothes(): Cloth[] {
        return this.clothes.sort((a, b) => a.size - b.size);
    }

    addCloth(cloth: Cloth): void {
        if (this.clothes.length < this.capacity) {
            this.clothes.push(cloth);
        } else {
            console.log('The magazine is full');
        }
    }

    removeCloth(color: string): boolean {
        let index = this.getClothIndex(color);

        if (index !== -1) {
            this.clothes.splice(index, 1);
            return true;
        }

        return false;
    }

    getSmallestCloth(): Cloth {
        return this.clothes.reduce((prev, current) => prev.size < current.size ? prev : current);
    }

    getCloth(color: string): Cloth {
        // @ts-ignore
        return this.clothes.find((c) => c.color === color);
    }

    getClothCount(): number {
        return this.clothes.length;
    }

    report(): string {
        const sorted = this.sortClothes();
        const clothesForReport = sorted.map((c) => c.toString()).join("\n");

        return `${this.type} magazine contains:\n${clothesForReport}`;
    }
}