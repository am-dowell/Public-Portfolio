class HTTPServices {

	async get(url, wordToLookUp) {
		//TODO: 
		//Use the fetch() function
		//with a GET request to get information about the
		//wordToLookUp from the url site.
		//The data will be an array.
		//Return the first element of the data array to the code that called this method.
		
	  //Put your code here
	  const response = await fetch(url, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(wordToLookUp)
      });

      console.log(`response: ${response}`);
      const responseData = await response.json();
      console.log(`responseData: ${responseData}`);
      return responseData;
	}
}

export default HTTPServices;