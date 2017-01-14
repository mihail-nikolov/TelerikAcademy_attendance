/* globals $ */

/* 

Create a function that takes an id or DOM element and an array of contents

* if an id is provided, select the element
* Add divs to the element
  * Each div's content must be one of the items from the contents array
* The function must remove all previous content from the DOM element provided
* Throws if:
  * The provided first parameter is neither string or existing DOM element
  * The provided id does not select anything (there is no element that has such an id)
  * Any of the function params is missing
  * Any of the function params is not as described
  * Any of the contents is neight `string` or `number`
    * In that case, the content of the element **must not be** changed   
*/

module.exports = function () {

    return function (element, contents) {

        function isContentsValid(contents) {
            var len = contents.length;
            for (var i = 0; i < len; i = i + 1) {
                if (typeof (contents[i]) !== 'number' && typeof (contents[i]) !== 'string') {
                    return false;
                };
            };
            return true;
        }

        var theElement = document.getElementById(element);
        if (arguments.length != 2) {
            throw new Error("the arguments must be 2");
        };
        if (!element) {
            throw new Error();
        }
        if (!(arguments[1] instanceof Array)) {
            throw new Error("must be array");
        };
        if (!isContentsValid(contents)) {
            throw new Error("content not valid")
        };
        if (theElement === null) {
            theElement = document.getElementById(element.id)
        }
        theElement.innerHTML = '';
        var divElement = document.createElement('div');
        var docFrag = document.createDocumentFragment();
        for (var i = 0; i < contents.length; i++) {
            var clonedDiv = divElement.cloneNode(true);
            clonedDiv.innerHTML = contents[i];
            docFrag.appendChild(clonedDiv);
        }
        theElement.appendChild(docFrag);
    };
};



//function() {

//    return function(element, contents) {
//        function isContentsValid(contents) {
//            var len = contents.length;
//            for (var i = 0; i < len; i = i + 1) {
//                if (typeof(contents[i]) !== 'number' && typeof(contents[i]) !== 'string') {
//                    return false;
//                };
//            };
//            return true;
//        }
//        if (!arguments) {
//            throw new Error('Invalid arguments!')
//        };
//        if (!element) {
//            throw new Error('Invalid element!');
//        };

//        if (!contents) {
//            throw new Error('Invalid contents!');
//        };

//        if (!isContentsValid(contents)) {
//            throw new Error('Contents is not valid!');
//        };


//        var selectedElement = document.getElementById(element);
//        if (selectedElement === null) {
//            //console.log(element.id);
//            selectedElement = document.getElementById(element.id);
//        };

//        selectedElement.innerHTML = '';
//        var len = contents.length;

//        for (var i = 0; i < len; i = i + 1) {
//            var newDiv = document.createElement("div");
//            var newContent = document.createTextNode(contents[i]);
//            newDiv.appendChild(newContent);
//            selectedElement.appendChild(newDiv);
//        };
//        //console.log(selectedElement);
//    };
//}