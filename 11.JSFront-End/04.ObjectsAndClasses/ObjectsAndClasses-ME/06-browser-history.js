function browserHistory(inputObj, commands) {
    for (const log of commands) {
        let [action, ...restTokens] = log.split(" ");
        let target = restTokens.join(" ");

        if (action === "Open") {
            if (!inputObj["Open Tabs"].includes(target)) {
                inputObj["Open Tabs"].push(target);

                inputObj["Browser Logs"].push(log); //Log
            }
        } else if (action === "Close") {
            if (inputObj["Open Tabs"].includes(target)) {
                inputObj["Recently Closed"].push(target);
                let indexToClose = inputObj["Open Tabs"].indexOf(target);
                inputObj["Open Tabs"].splice(indexToClose, 1);

                inputObj["Browser Logs"].push(log); //Log
            }
        } else if (action === "Clear") {
                inputObj["Open Tabs"] = [];
                inputObj["Recently Closed"] = [];
                inputObj["Browser Logs"] = [];
        }
    }

    console.log(`${inputObj["Browser Name"]}`);
    console.log(`Open Tabs: ${inputObj["Open Tabs"].join(", ")}`);
    console.log(`Recently Closed: ${inputObj["Recently Closed"].join(", ")}`);
    console.log(`Browser Logs: ${inputObj["Browser Logs"].join(", ")}`);
}

browserHistory({
        "Browser Name": "Google Chrome", "Open Tabs": ["Facebook", "YouTube", "Google Translate"],
        "Recently Closed": ["Yahoo", "Gmail"],
        "Browser Logs": ["Open YouTube", "Open Yahoo", "Open Google Translate", "Close Yahoo", "Open Gmail", "Close Gmail", "Open Facebook"]
    },
    ["Close Facebook", "Open StackOverFlow", "Open Google"]);

browserHistory({
        "Browser Name": "Mozilla Firefox",
        "Open Tabs": ["YouTube"],
        "Recently Closed": ["Gmail", "Dropbox"],
        "Browser Logs": ["Open Gmail", "Close Gmail", "Open Dropbox", "Open YouTube", "Close Dropbox"]
    },
    ["Open Wikipedia", "Clear History and Cache", "Open Twitter"]);

