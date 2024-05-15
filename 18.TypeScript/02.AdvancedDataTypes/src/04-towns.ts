type Town = {
    town: string;
    latitude: number;
    longitude: number;
}

function townInfo(arr: string[]) : void{
    let towns: Town[] = [];
    
    for(let i = 0; i < arr.length; i++){
        let [town, latitude, longitude] = arr[i].split(' | ');
        towns.push({town, latitude: Number(latitude), longitude: Number(longitude)});
    }
    
    console.log(towns.map(t => `{ town: '${t.town}', latitude: '${t.latitude.toFixed(2)}', longitude: '${t.longitude.toFixed(2)}' }`).join('\n'));
}

townInfo(["Sofia | 42.696552 | 23.32601", "Beijing | 39.913818 | 116.363625"]); 
townInfo(['Plovdiv | 136.45 | 812.575']);
