mapboxgl.accessToken = 'pk.eyJ1Ijoic21pY2tpZSIsImEiOiJjaWtiM2JkdW0wMDJudnRseTY0NWdrbjFnIn0.WxGYL18BJjWUiNIu-r3MSA';
var map = new mapboxgl.Map({
    container: 'map',
    style: 'mapbox://styles/mapbox/light-v8',
    center: [0, 37.8],
    zoom: 2,
    interactive: true
});
var featureList = [];

var source = {
    "type": "geojson",
    "data": {
        "type": "FeatureCollection",
        "features": featureList
    }
};

map.on('style.load', function (e) {
    map.addSource('markers', source);
});



var Shape = {
    Circle: 0,
    Triangle: 1,
    Square: 2,
    Rectangle: 3
};


$(document).on('keydown', function (e) {
    //83 square
    //67 circle
    //82 rectangle
    //69 ellipse
    //84 triangle
    
    if (e.which === 67) {
        e.preventDefault();
        GenerateShape(Shape.Circle);
    }
    else if (e.which === 84) {
        e.preventDefault();
        GenerateShape(Shape.Triangle);
    }
    else if (e.which === 83) {
        e.preventDefault();
        GenerateShape(Shape.Square);
    }
    else if (e.which === 82) {
        e.preventDefault();
        GenerateShape(Shape.Rectangle);
    }
});

function GenerateShape(shapeType) {
    if (shapeType >= 0 && shapeType <= 3) {
        $.post({
            url: "/Home/CreateShape",
            data: {
                shapeType: shapeType
            },
            success: function (result) {

                var coordinateArr = new Array();
                for (var i = 0; i < result.Coordinates.length; i++) {
                    coordinateArr.push([result.Coordinates[i].Latitude, result.Coordinates[i].Longitude]);
                }



                if (!result.GeoType) {
                    source.data.features.push({
                        "type": "Feature",
                        "geometry": {
                            "type": result.GeoType ? "Point" : "Polygon",
                            "coordinates": [coordinateArr]

                        },
                        "properties": {
                            "modelId": result.UId
                        }
                    });

                    map.removeSource("markers");
                    map.addSource('markers', source);

                    map.addLayer({
                        "id": result.UId,
                        "source": "markers",
                        "type":  "fill",
                        "paint": {
                            "fill-color": result.FillColor,
                            "fill-outline-color": result.BorderColor
                        },
                        "filter": ["==", "modelId", result.UId]
                    });
                }
                else {

                    source.data.features.push({
                        "type": "Feature",
                        "geometry": {
                            "type": result.GeoType ? "Point" : "Polygon",
                            "coordinates": [result.Coordinates[0].Latitude, result.Coordinates[0].Longitude]

                        },
                        "properties": {
                            "modelId": result.UId
                        }
                    });

                    map.removeSource("markers");
                    map.addSource('markers', source);

                    map.addLayer({
                        "id": result.UId,
                        "source": "markers",
                        "type": "circle",
                        "paint": {
                            "circle-radius": result.Radius,
                            "circle-color": result.FillColor,
                            "circle-stroke-width": 1,
                            "circle-stroke-color": result.BorderColor
                        },
                        "filter": ["==", "modelId", result.UId]
                    });
                }
            }
        });
    }
}