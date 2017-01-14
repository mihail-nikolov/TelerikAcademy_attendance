
function createImagesPreviewer(selector, items) {
    var theSelector = document.querySelector(selector);

    var header = document.createElement('h1');
    var img = document.createElement('img');
    var li = document.createElement('li');

    var right = document.createElement('div');
    right.style.display = "inline-block";
    right.style.float = 'right';
    right.style.width = "28%";
    right.style.height = "600px";
    right.style.overflowY = "scroll";
    var filterLabel = document.createElement('label');
    filterLabel.innerHTML = "filter";
    filterLabel.style.textAlign = "center";
    right.appendChild(filterLabel);
    var filterBox = document.createElement('input');
    right.appendChild(filterBox);

    var left = document.createElement('div');
    left.style.display = "inline-block";
    left.style.float = 'right';
    left.style.width = "70%";
    left.className = 'image-preview';
    var mainPicHeader = header.cloneNode(true);
    mainPicHeader.innerHTML = items[0].title;
    mainPicHeader.style.textAlign = "center";
    left.appendChild(mainPicHeader);
    var mainPic = img.cloneNode(true);
    mainPic.style.borderRadius = "3%";
    mainPic.style.width = "100%"
    mainPic.src = items[0].url;
    left.appendChild(mainPic);

    var ul = document.createElement('ul');
    ul.style.listStyleType = 'none';
    ul.className += " image-container";

    for (var i = 0; i < items.length; i++) {
        var newLi = li.cloneNode(true);
        var picToAdd = img.cloneNode(true);
        picToAdd.src = items[i].url;
        picToAdd.style.borderRadius = "3%";
        picToAdd.style.width = "100%";
        var picH = header.cloneNode(true);
        picH.innerHTML = items[i].title;
        picH.style.textAlign = "center";
        newLi.appendChild(picH);
        newLi.appendChild(picToAdd);
        ul.appendChild(newLi);
    }
    right.appendChild(ul);

    ul.addEventListener('click', function (ev) {
        var target = ev.target;
        var theHeader = target.previousSibling;
        mainPicHeader.innerText = theHeader.innerText;
        mainPic.src = target.src;
    }, false);

    ul.addEventListener('mouseover', function (ev) {
        var target = ev.target;
        if (target.tagName === 'IMG') {
            target.parentElement.style.background = "grey";
        }
        
    }, false);

    ul.addEventListener('mouseout', function (ev) {
        var target = ev.target;
        if (target.nodeName === 'IMG') {
            target.parentElement.style.background = "";
        }

    }, false);

    filterBox.addEventListener('keyup', function(ev){
        var text = ev.target.value;
        
        var liArr = ul.getElementsByTagName("LI");
        
        for (var k = 0; k < liArr.length; k++) {
            var theLI = liArr[k];
            if (theLI.firstChild.innerText.toLowerCase().indexOf(text.toLowerCase()) >= 0) {
                theLI.style.display = 'block';

            }
            else {
                theLI.style.display = 'none';
            }
        }
    }, false)


    theSelector.appendChild(right);
    theSelector.appendChild(left);
   // document.appendChild(theSelector)

};