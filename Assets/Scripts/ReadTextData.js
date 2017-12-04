#pragma strict

var theSourceFile : TextAsset;
var marker : Transform;
var xColumn : float;
var yColumn : float;
var zColumn : float;
var labelColumn: float;

var xMinMax : Vector2 = Vector2(0,100);
var yMinMax : Vector2 = Vector2(0,100);
var zMinMax : Vector2 = Vector2(0,100);

var axesMinMax : Vector2 = Vector2(0,100);


function Start () {

	var myText = theSourceFile.text;
	var myList = myText.Split("#"[0]);
	for (var i=1; i< myList.length; i++) {
		var dataList = myList[i].Split("\t"[0]);
		if (dataList.length > 1){
			var x = parseFloat( dataList[xColumn] );
			var y = parseFloat( dataList[yColumn] );
			var z = parseFloat( dataList[zColumn] );
			var myLabel : String = dataList[labelColumn];

			var xPct : float = (x-xMinMax[0]) / (xMinMax[1] - xMinMax[0]);
			x = (xPct * (axesMinMax[1] - axesMinMax[0])) + axesMinMax[0];
			print(y); print (yMinMax[1] - yMinMax[0]);
			var yPct : float = (y-yMinMax[0]) / (yMinMax[1] - yMinMax[0]);
			y = (yPct * (axesMinMax[1] - axesMinMax[0])) + axesMinMax[0];
			print(yPct);
			var zPct : float = (z-zMinMax[0]) / (zMinMax[1] - zMinMax[0]);
			z = (zPct * (axesMinMax[1] - axesMinMax[0])) + axesMinMax[0];

			var myMarker : Transform = Instantiate( marker, Vector3(x,y,z), Quaternion.identity);
			myMarker.SendMessage("SetText", myLabel, SendMessageOptions.DontRequireReceiver );

		}
	}

}

//function Update () {
//
//}