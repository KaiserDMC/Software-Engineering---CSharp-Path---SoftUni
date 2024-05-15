function solve() {
    const generateBtn = document.querySelector('#exercise button');
    const buyBtn = document.querySelector('#exercise button:last-of-type');
    const inputArea = document.querySelector('#exercise textarea');

    generateBtn.addEventListener("click", (e) => {
        let input = JSON.parse(inputArea.value);
        for (let i = 0; i < input.length; i++) {
            let furniture = input[i];

            let row = document.createElement('tr');
            row.innerHTML = `<td><img src="${furniture.img}"></td>
            <td><p>${furniture.name}</p></td>
            <td><p>${furniture.price}</p></td>
            <td><p>${furniture.decFactor}</p></td>
            <td><input type="checkbox"/></td>`;
            document.querySelector('#exercise table tbody').appendChild(row);
        }
    });

    buyBtn.addEventListener("click", (e) => {
        let furniture = Array.from(document.querySelectorAll('#exercise table tbody tr'))
            .filter(r => r.querySelector('input').checked)
            .map(r => r.querySelector('p').textContent)
            .join(', ');

        let totalPrice = Array.from(document.querySelectorAll('#exercise table tbody tr'))
            .filter(r => r.querySelector('input').checked)
            .map(r => Number(r.querySelectorAll('p')[1].textContent))
            .reduce((a, b) => a + b, 0);

        let avgDecFactor = Array.from(document.querySelectorAll('#exercise table tbody tr'))
            .filter(r => r.querySelector('input').checked)
            .map(r => Number(r.querySelectorAll('p')[2].textContent))
            .reduce((a, b) => a + b, 0) / Array.from(document.querySelectorAll('#exercise table tbody tr'))
            .filter(r => r.querySelector('input').checked).length;

        document.querySelector('#exercise textarea:last-of-type').value = `Bought furniture: ${furniture}\nTotal price: ${totalPrice.toFixed(2)}\nAverage decoration factor: ${avgDecFactor}`;
    });
}