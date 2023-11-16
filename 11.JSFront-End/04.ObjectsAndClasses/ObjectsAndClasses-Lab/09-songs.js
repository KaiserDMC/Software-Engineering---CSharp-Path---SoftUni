function songPrint(inputArr) {
    class Song {
        constructor(typeList, name, time) {
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    let songs = [];
    for (let i = 0; i < inputArr[0]; i++) {
        let currentSong = [typeList, name, time] = inputArr[i + 1].split("_");
        songs.push(new Song(typeList, name, time));
    }

    if (inputArr[inputArr.length - 1] !== "all") {
        for (const song of songs.filter(s => s.typeList === inputArr[inputArr.length - 1])) {
            console.log(`${song.name}`);
        }
    } else {
        for (const song of songs) {
            console.log(`${song.name}`);
        }
    }
}

songPrint([3, 'favourite_DownTown_3:14', 'favourite_Kiss_4:16', 'favourite_Smooth Criminal_4:01', 'favourite']);
songPrint([4, 'favourite_DownTown_3:14', 'listenLater_Andalouse_3:24', 'favourite_In To The Night_3:58', 'favourite_Live It Up_3:48', 'listenLater']);
songPrint([2, 'like_Replay_3:15', 'ban_Photoshop_3:48', 'all']);