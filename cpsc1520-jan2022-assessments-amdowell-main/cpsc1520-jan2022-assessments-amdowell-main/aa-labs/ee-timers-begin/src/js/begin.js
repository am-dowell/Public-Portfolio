function Begin(){

  let images = ['mountain1.jpg', 'mountain2.jpg', 'mountain3.jpg'];
	let currentImage = 0;
	let slideshowInterval;
	let carouselImg = document.querySelector('.carousel>img');
	
	carouselImg.src = `./img/${images[currentImage]}`; 
	
	document.querySelector('.carousel').addEventListener('click', function (evt){
			if (evt.target.className == 'control prev') {
					moveSlide(-1);
			} else if (evt.target.className == 'control next'){
					moveSlide(+1);
			}   
	});
	
	function moveSlide(dir) {
		currentImage += dir;
		if (currentImage < 0) {
			currentImage = images.length - 1;
		} else if (currentImage === images.length) {
			currentImage = 0;
		}
		carouselImg.src = `./img/${images[currentImage]}`;
	}
	
	slideshowInterval = setInterval(function () {
			moveSlide(+1);
	}, 3000);
	
	//Add your code here as per specs.

	// mouseover
	document.querySelector('.carousel').addEventListener("mouseover", function(){ clearInterval(slideshowInterval)});

	// mouse out
	document.querySelector('.carousel').addEventListener("mouseout", function(){ slideshowInterval = setInterval(moveSlide, dir);});

}

export default Begin;