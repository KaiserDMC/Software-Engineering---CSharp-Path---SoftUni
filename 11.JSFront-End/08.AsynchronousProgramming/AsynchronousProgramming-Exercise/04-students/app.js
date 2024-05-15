function attachEvents() {
    const baseUrl = "http://localhost:3030/jsonstore/collections/students";
    const table = document.querySelector("#results tbody");
    const [firstNameInput, lastNameInput, facultyNumber, grade] = document.querySelectorAll(".inputs input");
    const submitBtn = document.querySelector("#form button");

    const inputFields = Array.from(document.getElementsByTagName("input"));
    
    loadStudents();
    
    function addStudent() {
        if (!firstNameInput || !lastNameInput || !facultyNumber || !grade) {
            return;
        }

        for (const input of inputFields) {
            if (!input.value.trim()) {  // Check if the trimmed value is empty
                return;
            }
        }
       
        const student = {
            firstName: firstNameInput.value,
            lastName: lastNameInput.value,
            facultyNumber: facultyNumber.value,
            grade: grade.value
        }
        
        fetch(baseUrl, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(student)
        })
            .then(res => res.json())
            .then(data => {
                function createRow(data) {
                    const row = document.createElement("tr");
                    const firstName = document.createElement("td");
                    const lastName = document.createElement("td");
                    const facultyNumber = document.createElement("td");
                    const grade = document.createElement("td");

                    firstName.textContent = data.firstName;
                    lastName.textContent = data.lastName;
                    facultyNumber.textContent = data.facultyNumber;
                    grade.textContent = Number(data.grade).toFixed(2);

                    row.appendChild(firstName);
                    row.appendChild(lastName);
                    row.appendChild(facultyNumber);
                    row.appendChild(grade);

                    return row;
                }

                const row = createRow(data);
                
                table.appendChild(row);
            })
            .catch(err => console.log(err));

        firstNameInput.value = "";
        lastNameInput.value = "";
        facultyNumber.value = "";
        grade.value = "";
        
        loadStudents();
    }

    submitBtn.addEventListener("click", addStudent);
    
    function loadStudents() {
        table.innerHTML = "";
        
        fetch(baseUrl)
            .then(res => res.json())
            .then(data => {
                function createRow(data) {
                    const row = document.createElement("tr");
                    const firstName = document.createElement("td");
                    const lastName = document.createElement("td");
                    const facultyNumber = document.createElement("td");
                    const grade = document.createElement("td");

                    firstName.textContent = data.firstName;
                    lastName.textContent = data.lastName;
                    facultyNumber.textContent = data.facultyNumber;
                    grade.textContent = Number(data.grade).toFixed(2);

                    row.appendChild(firstName);
                    row.appendChild(lastName);
                    row.appendChild(facultyNumber);
                    row.appendChild(grade);

                    return row;
                }

                const rows = Object.values(data).map(createRow);

                rows.forEach(row => table.appendChild(row));
            })
            .catch(err => console.log(err));
    }
}

attachEvents();