function solve() {
    const answers = Array.from(document.getElementsByClassName("quiz-answer"));
    const sections = Array.from(document.getElementsByTagName("section"));
    const result = document.getElementById("results");
    const outputText = document.querySelector(".results-inner h1");

    answers[0].classList.add("right-answer");
    answers[3].classList.add("right-answer");
    answers[4].classList.add("right-answer");

    let correctAnswersCount = 0;
    let currentQuestion = 0;

    answers.forEach((answer) => {
        answer.addEventListener('click', (e) => {
            const elementClicked = e.target;
            let ans = elementClicked.parentElement;

            if (!ans.classList.contains('quiz-answer')) {
                ans = ans.parentElement;
            }

            if (ans.classList.contains("right-answer")) {
                correctAnswersCount++;
            }

            if (currentQuestion < 2) {
                sections[currentQuestion].style.display = 'none';
                currentQuestion++;
                sections[currentQuestion].style.display = 'block';
            } else {
                sections[2].style.display = 'none';
                result.style.display = 'block';
                outputText.textContent = correctAnswersCount === 3 ? 'You are recognized as a top JavaScript fan!' : `You have ${correctAnswersCount} right answers`;
            }
        });
    });
}