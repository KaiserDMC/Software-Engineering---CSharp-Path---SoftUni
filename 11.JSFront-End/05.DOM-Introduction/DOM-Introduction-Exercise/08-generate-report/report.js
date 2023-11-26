function generateReport() {
    const headerCheckboxes = document.querySelectorAll('table thead tr th input[type="checkbox"]');
    const tableRows = document.querySelectorAll('table tbody tr');
    const selectedData = [];

    for (const row of tableRows) {
        let rowData = {};
        let rowCells = row.querySelectorAll('td');

        for (let i = 0; i < headerCheckboxes.length; i++) {
            if (headerCheckboxes[i].checked){
                const headerText = headerCheckboxes[i].parentNode.textContent.toLowerCase().trim();
                const cellText = rowCells[i].textContent;
                
                rowData[headerText] = cellText;
            }
        }
        
        if (Object.keys(rowData).length > 0){
            selectedData.push(rowData);
        }
    }
    
    document.getElementById("output").textContent = JSON.stringify(selectedData, null, 2);
}