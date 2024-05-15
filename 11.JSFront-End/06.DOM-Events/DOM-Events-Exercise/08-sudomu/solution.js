function solve() {
    const checkBtn = document.getElementsByTagName("button")[0];
    const clearBtn = document.getElementsByTagName("button")[1];
    const table = document.getElementsByTagName("table")[0];
    const result = document.querySelector("#check p");

    const rowSum = 6;
    const sudokuSolver = (x1, x2, x3, solvedCorrectly) => x1 + x2 + x3 === rowSum;

    checkBtn.addEventListener("click", (e) => {
        const inputNumbers = Array.from(document.querySelectorAll("input")).map((el) => Number(el.value));
        let solvedCorrectly = true;

        // Check rows
        for (let i = 0; i < 9; i += 3) {
            const rowValues = inputNumbers.slice(i, i + 3);
            solvedCorrectly = solvedCorrectly && sudokuSolver(...rowValues);
        }

        // Check columns
        for (let i = 0; i < 3; i++) {
            const colValues = [inputNumbers[i], inputNumbers[i + 3], inputNumbers[i + 6]];
            solvedCorrectly = solvedCorrectly && sudokuSolver(...colValues);
        }

        if (solvedCorrectly) {
            table.style.border = "2px solid green";
            result.style.color = "green";
            result.textContent = "You solve it! Congratulations!";
        } else {
            table.style.border = "2px solid red";
            result.style.color = "red";
            result.textContent = "NOP! You are not done yet...";
        }
    });

    clearBtn.addEventListener("click", (e) => {
        table.style.border = "none";
        result.style.color = "";
        result.textContent = "";

        const cellsToClear = Array.from(document.querySelectorAll("input"));
        for (const cell of cellsToClear) {
            cell.value = "";
        }
    });
}