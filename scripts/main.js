

document.addEventListener( "click", function toggleWords ( event ) {
    // A few variables to help us track important values/references
    var target = event.target, values = [], placed;
    // If the clicked element has multiple values
    if ( target.hasAttribute( "data-values" ) ) {
        // Split those values out into an array
        values = target.getAttribute( "data-values" ).split( "," );
        // Find the location of its current value in the array
        placed = values.indexOf( target.textContent );
        // Set its text to be the next value in the array
        target.textContent = values[ ++placed % values.length ];   
    }
});