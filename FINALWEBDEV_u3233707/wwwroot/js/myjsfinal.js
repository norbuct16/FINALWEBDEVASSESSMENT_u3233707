

//////////////////////////
// Get width and height of the viewport
const viewportWidth = window.innerWidth;
const viewportHeight = window.innerHeight;

// Function to check if the difference between 
// the height of the viewport and the top of the elem element 
// is 200 pixels or greater 
function isElementEnteringViewport(elem) {
    var rect = elem.getBoundingClientRect();
    return (// true if the difference >= 200
        (viewportHeight - rect.top) >= 200
    );
}
// Write the scroll event handler function
// Your code to be executed when scrolling happens
function onScroll() {
    var sections = document.getElementsByClassName("gen");
    for (var i = 0; i < sections.length; i++) {
        if (isElementEnteringViewport(sections[i])) {
            sections[i].style.opacity = "1"
            sections[i].style.transition = "opacity 3.0s"
        } else {
            sections[i].style.opacity = "0"
            sections[i].style.transition = "opacity 0s"
        }

    }
}
// Add the handScroll function as event handler for
// the scroll event on the viewport
window.addEventListener("scroll", onScroll);







