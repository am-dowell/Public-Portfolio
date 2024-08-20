import 'bootstrap/dist/css/bootstrap.min.css'
import '../css/main.css';

import HTTPServices from './http.js';
import UI from './ui.js';

const httpServices = new HTTPServices();
const ui = new UI();

const dictionaryForm = document.querySelector("#dictionary-search");
const searchedWords = document.querySelector("#searched-words");
const favoriteWords = document.querySelector("#favorite-words");

const url = `https://api.dictionaryapi.dev/api/v2/entries/en`;

dictionaryForm.addEventListener('submit', e => {
	//TODO:
	//Prevent the default action of a submit.
	//Get the text entered by the user from the <input type=text> element.
	//Call httpServices.get() with the provided url and the text entered by the user.
	//To the .get() chain a .then(), which calls ui.renderItem() with the data returned
	//from the .get().
	//Add the <li> structure returned by ui.RenderItem() to the searchedWords list.
	//Clear the text in the <input type=text> element.

	//Put your code here.
	e.preventDefault();
    httpServices.get(url)

    .then(data => {
        ui.renderItem(data);
    })

    .catch(err => console.log(err));
    console.log(`keep running asyncronously`);

});

searchedWords.addEventListener("click", e => {
	//TODO:
	//Check if the e.target is a button with class="favorite-word".
	//If so reference the parentNode of the button, 
	//then remove the referenced element from the e.target list,
	//and add it to the favoriteWords list.

	//Put your code here.
	if(e.target.classList.contains('favorite-word')) {
		let {errorMessage, dataIsValid} = ui.renderItem(url, favoriteWords);
		if(dataIsValid) {
		  httpServices.post(url, wordData)
		} 
		else
		{
		  ui.showAlert(errorMessage, 'error-message');
		}
	  }
});
