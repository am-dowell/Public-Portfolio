export function demo() {
// Do NOT modify the following function.
const updateInnerHTML = function (selector, newValue) {
  document.querySelector(selector).innerHTML = newValue;
}

// TODO: Enter your code below to make use of the function given.


function italic(value){
  return `<i>${value}</i>`;
}

let textToItalics = document.querySelector('span.note').innerHTML;

let textItalicized = italic(textToItalics);
updateInnerHTML('span.note', textItalicized);
}

