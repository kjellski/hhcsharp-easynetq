$(function () {
    // coordinates helper
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

    // ------------------------------------------------------------------------------------
    // SignalR connection setup
    // ------------------------------------------------------------------------------------
    var pointHub = $.connection.pointHub;

    // get all canvas elements
    var canvasIdEndings = ["", "1", "2", "3", "4"];
    var allCanvasElemens = _.map(canvasIdEndings, function (nameEnd) { return document.getElementById("canvas" + nameEnd); });
    var canvas = allCanvasElemens.shift(); // removes first and returns it
    var quadrants = allCanvasElemens;

    // functions to be called by server
    pointHub.client.updatePoint = function (point) {
        console.log("Point(" + point.X + ", " + point.Y + ")");
        drawPoint(point, canvas);
    };

    // hackety hack ;)
    var createUpdateFunction = function (quadrantCanvas, quadrantCanvasId) {
        return function (point) {
            var thisCanvas = quadrantCanvas;
            var thisId = quadrantCanvasId;
            var canvasNumber = thisId.slice(-1);

            if (canvasNumber === "1")
                point.X = point.X - 250;
            if (canvasNumber === "3")
                point.Y = point.Y - 250;
            if (canvasNumber === "4")
            {
                point.X = point.X - 250;
                point.Y = point.Y - 250;
            }

            console.log("Point(" + point.X + ", " + point.Y + ") in quadrant " + thisId);
            drawPoint(point, thisCanvas);
        };
    };

    for (var i = 0; i < quadrants.length; i++) {
        var quadrant = quadrants[i];
        var quadrantId = quadrant.id;
        pointHub.client["updatePoint" + quadrantId.slice(-1)] = createUpdateFunction(quadrant, quadrantId);
    }

    // draw the point on the canvas
    var drawPoint = function (point, canvasElement) {
        var ctx = canvasElement.getContext("2d");
        ctx.fillRect(point.X, point.Y, 5, 5);
    };

    $.connection.hub.start().done(function () {
        console.debug('hub started.');
        canvas.addEventListener('click', function (event) {
            var coordinates = canvas.relMouseCoords(event);
            // implicit method on server
            pointHub.server.publishPoint({ X: coordinates.x, Y: coordinates.y });
        });
    });

    window.pointHub = pointHub;
});