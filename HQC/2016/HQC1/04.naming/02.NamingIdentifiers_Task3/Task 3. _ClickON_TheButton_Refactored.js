// Task 3. _ClickON_TheButton in JavaScript

// Refactor the following examples to produce code with well-named identifiers in JavaScript


function alertForBrowser(event, arguments) {
    var myWindow = window,
        currentBrowser = myWindow.navigator.appCodeName,
        browser = currentBrowser == "Mozilla";
    if (browser) {
        alert("Yes");
    } else {
        alert("No");
    }
}
