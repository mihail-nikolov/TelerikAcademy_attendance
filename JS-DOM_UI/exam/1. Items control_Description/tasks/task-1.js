function solve() {
    return function (selector, isCaseSensitive) {
        var theSelector = document.querySelector(selector);

        if (!theSelector) {
            throw new Error();
        }
        if (theSelector === null) {
            theSelector = document.getElementById(theSelector.id)
        };

        var label = document.createElement('label');

        var div = document.createElement('div');
        var mainFrameDiv = div.cloneNode(true);
        mainFrameDiv.style.border = "1px solid #000"
        mainFrameDiv.style.width = '400px';
        mainFrameDiv.style.height = '800px';

        var addingDiv = div.cloneNode(true);
        addingDiv.className += " add-controls";
        addingDiv.style.display = 'inline-block';
        addingDiv.style.float = 'top';
        addingDiv.style.border = "1px solid #000";
        addingDiv.style.width = '400px';
        addingDiv.style.height = '70px';
        var addLabel = label.cloneNode(true);
        addLabel.innerHTML = "Enter Text:";
        addingDiv.appendChild(addLabel);
        var inputBox = document.createElement('input');
        addingDiv.appendChild(inputBox);

        var newPar = document.createElement("p");
        var button = document.createElement('button');
        button.className += ' button';
        button.value = 'Add';
        button.innerHTML = 'Add';
        button.style.width = '200px';
        //button.stye.backgroundColor = 'grey';
        //button.style.textAlign = 'center';
        newPar.appendChild(button);
        addingDiv.appendChild(newPar);

        var searchingDiv = div.cloneNode(true);
        searchingDiv.className += " search-controls";
        searchingDiv.style.display = 'inline-block';
        searchingDiv.style.float = 'top';
        searchingDiv.style.border = "1px solid #000";
        searchingDiv.style.width = '400px';
        searchingDiv.style.height = '70px';
        var searchLabel = label.cloneNode(true);
        searchLabel.innerHTML = "Search";
        searchingDiv.appendChild(searchLabel);
        var inputBoxSearch = document.createElement('input');
        searchingDiv.appendChild(inputBoxSearch);

        var resultElements = div.cloneNode(true);
        resultElements.className += " result-controls";
        resultElements.style.display = 'inline-block';
        resultElements.style.float = 'top';
        resultElements.style.border = "1px solid #000";
        resultElements.style.width = '400px';
        resultElements.style.height = '600px';
        resultElements.style.overflowY = "scroll";

        var items_list = div.cloneNode(true);
        items_list.className += " items-list";
        
        var xButton = button.cloneNode(true);
        xButton.className += ' button';
        xButton.value = 'X';
        xButton.innerHTML = 'X';
        xButton.style.width = '50px';
        xButton.style.height = '50px';

        button.addEventListener('click', function (ev) {
            var text = inputBox.value;
            if (text === "") {
                throw new Error();
            }
            var divToAdd = div.cloneNode(true);
            var buttonToAdd = xButton.cloneNode(true);
            divToAdd.appendChild(buttonToAdd);
            var textDiv = div.cloneNode(true);
            textDiv.innerHTML = text;
            textDiv.className += " elementName";
            divToAdd.appendChild(textDiv);
            divToAdd.style.display = 'block';
            divToAdd.style.float = 'top';
            divToAdd.className += ' list-item';
            items_list.appendChild(divToAdd);
        }, false);

        resultElements.appendChild(items_list);

        inputBoxSearch.addEventListener('keyup', function (ev) {
            var text = ev.target.value;
            var elements = document.getElementsByClassName("elementName");

            for (var k = 0; k < elements.length; k++) {
                var elementText = elements[k];
                if (isCaseSensitive === false) {
                    elementText = elementText.toLowerCase();
                    text = text.toLowerCase();
                }
                if (elementText.innerHTML.indexOf(text) >= 0) {
                    elementText.parentNode.style.display = 'block';

                }
                else {
                    elementText.parentNode.style.display = 'none';
                }
            }
        }, false)

        var allXButtons = items_list.getElementsByClassName('button');
        
        resultElements.addEventListener('mouseover', function (ev) {
            for (var i = 0; i < allXButtons.length; i++) {
                var aXButton = allXButtons[i];
                aXButton.addEventListener('click', function (ev) {
                    var elToRemove = ev.target.parentNode;
                    //var parent = document.getElementsByClassName("items-list")[0];
                    if (typeof elToRemove !== 'undefined') {
                        elToRemove.remove();
                        return;
                    }
                }, false)
            };
        },false)

        mainFrameDiv.appendChild(addingDiv);
        mainFrameDiv.appendChild(searchingDiv);
        mainFrameDiv.appendChild(resultElements);
        theSelector.appendChild(mainFrameDiv);
    };
}

module.exports = solve;