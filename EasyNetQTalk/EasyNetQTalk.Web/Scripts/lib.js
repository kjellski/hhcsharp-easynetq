$(function () {
    var relMouseCoords = function (event) {
        var totalOffsetX = 0;
        var totalOffsetY = 0;
        var canvasX = 0;
        var canvasY = 0;
        var currentElement = this;

        do {
            totalOffsetX += currentElement.offsetLeft - currentElement.scrollLeft;
            totalOffsetY += currentElement.offsetTop - currentElement.scrollTop;
        }
        while (currentElement = currentElement.offsetParent)

        canvasX = event.pageX - totalOffsetX;
        canvasY = event.pageY - totalOffsetY;

        return { x: canvasX, y: canvasY }
    }
    HTMLCanvasElement.prototype.relMouseCoords = relMouseCoords;

    var pointHub = $.connection.pointHub;
    var canvas = document.getElementById("canvas");

    var canvas1 = document.getElementById("canvas-1");
    var canvas2 = document.getElementById("canvas-2");
    var canvas3 = document.getElementById("canvas-3");
    var canvas4 = document.getElementById("canvas-4");

    // function to be called by server
    pointHub.client.updatePoint = function (point) {
        console.log("Point(" + point.X + ", " + point.Y + ")");
        drawPoint(point);
    };

    canvas.addEventListener('click', function (event) {
        var coordinates = canvas.relMouseCoords(event);
        // implicit method on server
        pointHub.server.publishPoint({ X: coordinates.x, Y: coordinates.y });
    });

    // draw the point on the canvas
    var ctx = canvas.getContext("2d");
    var drawPoint = function (point) {
        ctx.fillRect(point.X, point.Y, 5, 5);
    };


    $.connection.hub.start().done(function () {
        console.debug('hub started.');
    });
});