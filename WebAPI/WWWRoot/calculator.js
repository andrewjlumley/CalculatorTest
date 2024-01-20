const display = document.getElementById("display");

var start = ""
var operator = "";
var amount = "";
Clear();

const modal = document.querySelector("[data-modal]");
modal.showModal();

async function RefreshDisplay() {
    display.value = start + operator + amount;
    console.log(`Start=${start}, Operator=${operator}, Amount=${amount}`);
}

function Clear() {
    SetStart("0");
    RefreshDisplay();
}

async function SetStart(value) {
    start = value;
    operator = "";
    amount = "";
}

async function Capture(key) {

    // Remove leading zero
    if (start == "0") {
        start = "";
    }

    // If user pressed equals then calculate
    if (key == "=") {

        // Only calculate if everything available
        if (operator != "" && start != "" && amount != "") {
            SetStart(await Calculate());
        }
    }

    // Did user pressed plus or minus?
    else if (key == "+" || key == "-") {

        // If start not set then move amount into start
        if (start == "" && amount != "") {
            start = amount;
            amount = "";
        }

        // This must be the operator if start set
        if (start != "" && operator == "") {
            operator = key;
        }

        // If everything set then calculate
        if (operator != "" && start != "" && amount != "") {
            SetStart(await Calculate());
            operator = key;
        }

        // Otherwise is this a sign?
        else if (amount == "" && operator != key) {
            amount += key;
        }
    }

    // Otherwise, concatenate  to amount
    else {
        amount += key;
    }

    RefreshDisplay();
}

async function Calculate() {
    var method = operator == "-" ? "subtract" : "add";
    return await fetch(("https://localhost:7159/api/simplecalculator/" + method), {
        method: 'POST',
        headers: {
            'Accept': 'text/plain',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ 'start': start, 'amount': amount })
    })
        .then(response => response.text())
        .then(response => JSON.parse(response))
        .then(response => {
            return response['result'];
        });
};