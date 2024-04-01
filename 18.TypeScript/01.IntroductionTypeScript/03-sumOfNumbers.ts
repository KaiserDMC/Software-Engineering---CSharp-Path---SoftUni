function sumOfNumbers(nStr: string, mStr: string): void {
    const n: number = parseInt(nStr);
    const m: number = parseInt(mStr);

    let sum: number = 0;
    const min: number = Math.min(n, m);
    const max: number = Math.max(n, m);

    for (let i = min; i <= max; i++) {
        sum += i;
    }

    console.log(sum);
}

sumOfNumbers("1", "5"); // 15
sumOfNumbers("-8", "20"); // 174