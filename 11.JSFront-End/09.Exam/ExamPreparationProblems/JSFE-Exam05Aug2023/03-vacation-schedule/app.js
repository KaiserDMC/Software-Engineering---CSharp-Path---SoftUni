function solve() {
    const loadVacationsBtn = document.getElementById('load-vacations');
    const containerList = document.getElementById('list');
    const addButton = document.getElementById('add-vacation');
    const editButton = document.getElementById('edit-vacation');


    loadVacationsBtn.addEventListener('click', loadVacations);
    addButton.addEventListener('click', addVacation);

    async function loadVacations() {
        try {
            const response = await fetch('http://localhost:3030/jsonstore/tasks');
            if (!response.ok) {
                throw new Error(`Failed to fetch vacations: ${response.status} - ${response.statusText}`);
            }

            const data = await response.json();

            containerList.innerHTML = '';

            Object.values(data).forEach(vacation => {
                const divContainer = document.createElement('div');
                divContainer.classList.add('container');

                const h2 = document.createElement('h2');
                h2.textContent = vacation.name;
                divContainer.appendChild(h2);

                const h3 = document.createElement('h3');
                h3.textContent = vacation.date;
                divContainer.appendChild(h3);

                const h3Days = document.createElement('h3');
                h3Days.textContent = vacation.days;
                divContainer.appendChild(h3Days);

                const id = vacation._id;

                const changeBtn = document.createElement('button');
                changeBtn.classList.add('change-btn');
                changeBtn.textContent = 'Change';

                const doneBtn = document.createElement('button');
                doneBtn.classList.add('done-btn');
                doneBtn.textContent = 'Done';

                divContainer.appendChild(changeBtn);
                divContainer.appendChild(doneBtn);
                containerList.appendChild(divContainer);

                changeBtn.addEventListener('click', () => changeVacation(h2, h3, h3Days, id));

                doneBtn.addEventListener('click', async () => {
                    try {
                        await deleteVacation(id);
                        await loadVacations();
                    } catch (error) {
                        console.error('Error handling delete and load:', error);
                    }
                });
            });
        } catch (error) {
            console.error('Error loading vacations:', error);
        }
    }

    async function addVacation() {
        const name = document.querySelector('input[name="name"]');
        const date = document.querySelector('input[name="from-date"]');
        const days = document.querySelector('input[name="num-days"]');

        if (name.value !== '' && date.value !== '' && days.value !== '') {
            try {
                const response = await fetch('http://localhost:3030/jsonstore/tasks', {
                    method: 'POST',
                    headers: {'Content-Type': 'application/json'},
                    credentials: 'include',
                    body: JSON.stringify({name: name.value, date: date.value, days: days.value})
                });

                if (!response.ok) {
                    throw new Error(`Failed to add vacation: ${response.status} - ${response.statusText}`);
                }

                const data = await response.json();
                await loadVacations();
                name.value = '';
                date.value = '';
                days.value = '';
            } catch (error) {
                console.error('Error adding vacation:', error);
            }
        }
    }

    async function changeVacation(name, date, days, id) {
        addButton.disabled = true;
        editButton.disabled = false;

        const nameAdd = document.querySelector('input[name="name"]');
        const dateAdd = document.querySelector('input[name="from-date"]');
        const daysAdd = document.querySelector('input[name="num-days"]');

        nameAdd.value = name.textContent;
        dateAdd.value = date.textContent;
        daysAdd.value = days.textContent;

        editButton.addEventListener('click', async () => {
            try {
                const url = `http://localhost:3030/jsonstore/tasks/${id}`;
                const response = await fetch(url, {
                    method: 'PUT',
                    headers: {'Content-Type': 'application/json'},
                    body: JSON.stringify({name: nameAdd.value, date: dateAdd.value, days: daysAdd.value})
                });

                if (!response.ok) {
                    throw new Error(`Failed to edit vacation: ${response.status} - ${response.statusText}`);
                }

                const data = await response.json();
                await loadVacations();
                nameAdd.value = '';
                dateAdd.value = '';
                daysAdd.value = '';
                addButton.disabled = false;
                editButton.disabled = true;
            } catch (error) {
                console.error('Error editing vacation:', error);
                console.error(error.message);
                console.error(error.stack);
            }
        });
    }

    async function deleteVacation(id) {
        try {
            await fetch(`http://localhost:3030/jsonstore/tasks/${id}`, {
                method: 'DELETE',
                headers: { 'Content-Type': 'application/json' },
            })
            .then(loadVacations);
        } catch (error) {
            console.error('Error deleting vacation:', error);
            throw error;
        }
    }
}

solve();