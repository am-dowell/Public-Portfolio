class UI {

/*
HTML Structure 

<li class="list-group-item d-flex justify-content-between align-items-start">
	<div class="ms-2 me-auto definition">
		<div class="fw-bold">WORD-HERE</div>
		<p>WORD-DEFINITION-HERE</p>
	</div>
	<audio controls>
		<source src="AUDIO-LINK-HERE">
			Your browser does not support this audio element
		</source>
	</audio>
	<button class="m-2 btn btn-primary favorite-word">Add To Favorites</button>
</li>

*/

renderItem = (wordData) => {
	//TODO:
	//From the wordData parameter, retrieve the word, meaning, and audioUrl.
	//Build the DOM <li> structure using this retrieved data.
	//Use the above HTML Structure comment as a guide to building the DOM <li> structure.
	//Return the new DOM <li> structure to the code that called this method.
	
	//Put your code here.

	let output =
	`
	<li class="list-group-item d-flex justify-content-between align-items-start">
	<div class="ms-2 me-auto definition">
		<div class="fw-bold">${wordData.word}</div>
		<p>WORD-DEFINITION-HERE</p>
	</div>
	<audio controls>
		<source src="${wordData.phonetics[0].audio}">
			Your browser does not support this audio element
		</source>
	</audio>
	<button class="m-2 btn btn-primary favorite-word">Add To Favorites</button>
	</li>
	`;
	this.wordData.innerHTML = output;
}

}

export default UI;