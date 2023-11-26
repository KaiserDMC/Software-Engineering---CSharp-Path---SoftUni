function subtract() {
    const firstNumber = document.getElementById("firstNumber").value;
    const secondNumber = document.getElementById("secondNumber").value;
    
    document.getElementById("result").textContent = Number(firstNumber) - Number(secondNumber);
}