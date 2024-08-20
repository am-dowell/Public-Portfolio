function Begin(){

	const form = document.querySelector("#form")
	
	form.addEventListener("submit", e => {
		e.preventDefault();    
		let text = getUserValues(e);
		text = text.trim();
		//TODO: Add code here to convert the entered text to lower case.
		text = text.toLowerCase();

		let {message, isNotValid} = validateUserValues(text);
		if(isNotValid){
			showAlert(message, 'error');
		} else {
			AddItemToList(text);
			showAlert('Tag Added to List!', 'success');
			clearUserValues(e);
		}
	});
	
	function getUserValues(e){
		let text = e.target.elements["textName"].value;
		return text;
	}
	
	function validateUserValues(text){
		let message = '';
		let isNotValid = true;
		if(text === '')
			message += `| Text Empty |`;
		if(text.length > 10)
			message += `| Text > 10 |`;
		//TODO: Add code here to validate the entered text
		//as per the specs.
		if (text.indexOf(' ') >= 0)
			message += `| Text Contains Spaces |`;
		if(message != '')
			message = `Invalid Data: ` + message;
		else isNotValid = false;
		return {message, isNotValid};
	}
	
	function showAlert(message, className) {
		const parentDiv = document.querySelector('#alert');
		const alertElement = 
		`
		<div class='${className} form-control'>
			${message}
		</div>
		`
		parentDiv.innerHTML = alertElement;
	}
	
	function AddItemToList(text) {
		let list = document.querySelector("#list")
		let newItem = 
		`
			<p>#${text}</p>
		`
		list.innerHTML =  newItem + list.innerHTML;
	}
	
	function clearUserValues(e) {
		e.target.elements["textName"].value = '';
	}
	
	}
	
	export default Begin;