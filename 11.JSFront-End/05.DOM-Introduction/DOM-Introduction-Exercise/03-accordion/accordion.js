function toggle() {
    const currentState = document.getElementsByClassName("button")[0];
    const extraText = document.getElementById("extra");

    if (currentState.textContent === "More") {
        extraText.style.display = "block";
        currentState.textContent = "Less";
    } else {
        extraText.style.display = "none";
        currentState.textContent = "More";
    }
}