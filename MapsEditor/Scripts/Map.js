function initMap() {
    var Minsk = { lat: 53.8978071, lng: 27.5544037 };
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 3,
        center: Minsk
    });
    var drawingManager = new google.maps.drawing.DrawingManager({
        drawingMode: google.maps.drawing.OverlayType.MARKER,
        drawingControl: true,
        drawingControlOptions: {
            position: google.maps.ControlPosition.TOP_CENTER,
            drawingModes: ['marker', 'circle', 'polygon', 'polyline', 'rectangle']
        },


    });
    drawingManager.setMap(map);


   
        

}
