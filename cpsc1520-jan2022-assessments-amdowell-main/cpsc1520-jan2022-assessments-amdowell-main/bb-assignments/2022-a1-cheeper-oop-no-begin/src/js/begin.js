function Begin(){

const form = document.querySelector("#form")
form.elements["text"].focus()

form.addEventListener("submit", e => {
	//TODO: Add code here to make use of the
	//given functions to create a working app
	//as per the specs.
	e.preventDefault();    
		let {text, gif} = getUserValues(e);
		text = text.trim();
		//TODO: Add code here to convert the entered text to lower case.
		text = text.toLowerCase();
		
		let {message, isNotValid} = validateUserValues(text, gif);
		if(isNotValid){
			showAlert(message, 'error');
		} else {
			AddItemToList(text, gif);
			showAlert('Item Added to List!', 'success');
			clearUserValues(e);
		}
});

function getUserValues(e){
	let text = e.target.elements["text"].value;
	let gif = e.target.elements["gif"].value;
	return {text, gif}
}

function validateUserValues(text, gif){
	let message = '';
	let isNotValid = true;
	//TODO: Put code here to validate both
	//the text and gif as per the specs.
	if(text.length > 50)
		message += `Text > 50`;
	if(text === '')
		message += `| Text Empty |`;
	if (gif === '')
		message += '| GIF |';
	if(message != '')
		message = `Missing Data: ` + message;
	else isNotValid = false;
	return {message, isNotValid};
}

function showAlert(message, className) {
	const parentDiv = document.querySelector('#alert');
	//TODO: Add code here to display an alert.
	const alertElement = 
        `
        <div class='${className} form-control'>
            ${message}
        </div>
        `
        parentDiv.innerHTML = alertElement;
}

function AddItemToList(text, gif) {
	let list = document.querySelector("#list");
	//TODO: Add code here to add an item to
	//the list.
		let newItem = 
		`
		<div class="d-flex mb-3">
			<img class="rounded-start mx-3" src="./img/${gif}" alt="${gif}">
			<h5 class='mx-3'>${text}</h5>
			<a class='delete-item' href="#">X</a>
		</div>
		`
		list.innerHTML =  newItem + list.innerHTML;
	
}

function clearUserValues(e) {
	e.target.elements["text"].value = '';
	e.target.elements["gif"].value = '';
}

}

export default Begin;