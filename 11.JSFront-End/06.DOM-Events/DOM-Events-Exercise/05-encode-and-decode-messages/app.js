function encodeAndDecodeMessages() {
    const encodeBtn = document.querySelectorAll('button')[0];
    const decodeBtn = document.querySelectorAll('button')[1];

    encodeBtn.addEventListener("click", (e) => {
        const message = document.querySelectorAll('textarea')[0].value;
        const encodedMessage = encode(message);
        
        document.querySelectorAll('textarea')[0].value = "";
        document.querySelectorAll('textarea')[1].value = encodedMessage;
    });
    
    decodeBtn.addEventListener("click", (e) => {
        const message = document.querySelectorAll('textarea')[1].value;
        const decodedMessage = decode(message);
        
        document.querySelectorAll('textarea')[1].value = decodedMessage;
    });

    function encode(message) {
        return message.split('').map(x => String.fromCharCode(x.charCodeAt(0) + 1)).join('');
    }

    function decode(message) {
        return message.split('').map(x => String.fromCharCode(x.charCodeAt(0) - 1)).join('');
    }
}