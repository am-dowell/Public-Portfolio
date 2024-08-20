    export function demo() {

    //This code has been provided for you. Do not change it.
    const refFeatureLink = document.querySelector('a.feature.link')
    refFeatureLink.addEventListener('click', ClickHandler);
    function ClickHandler(evt) {
        var imgFeature = document.querySelector('img.feature');
        imgFeature.src = evt.target.href;
        imgFeature.alt = evt.target.title;
        imgFeature.classList.remove('hidden');
        evt.preventDefault();
    }

///TODO: Add your code below this comment
// ON MOUSE OVER
const imgFeature = document.querySelector('img.feature')
        imgFeature.addEventListener('mouseover', MouseOnHandler);
    function MouseOnHandler(evt) {
        let pFeature = document.querySelector('p.feature.title');
        pFeature.innerHTML = imgFeature.alt;
        }

// ON MOUSE OUT
imgFeature.addEventListener('mouseout', MouseOutHandler);
    function MouseOutHandler(evt) {
        let pFeature = document.querySelector('p.feature.title');
        pFeature.innerHTML = '';
    }
}