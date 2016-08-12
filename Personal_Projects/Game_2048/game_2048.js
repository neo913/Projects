var score = 0;
var hi_score = 0;

window.addEventListener('keydown', move, false);
window.addEventListener("touchmove", move, false);
window.addEventListener("onscroll", move, false);
window.onload = function(){
	init();
}
function init(){ //Initialize
	var base = document.getElementById("base_16");
	base.innerHTML = "";
	for(var i=0; i<4; i++){
		for(var j=0; j<4; j++){
			base.innerHTML += "<div class='sm' id="+i+j+'></div>';
		}
	}
	setScore();
}
function newGame(){ //init()+put()
	init();
	score = 0;
	setScore();
	document.getElementById(random_pos()).innerHTML = ""+ gen();
	put();
}
function setScore(){
	document.getElementById("cur_score").innerHTML = ""+score;
	if(score >= hi_score){
		hi_score = score;
		document.getElementById("hi_score").innerHTML = ""+hi_score;
	}
}
function getScore(obj){
	//
	score = parseInt(score)+parseInt(obj.innerHTML);
}
function put(){	//put a random number(2 or 4) into a random empty cell
	if(!isFull() && !done()) {
		var random = random_pos();
		var target = document.getElementById(random_pos());
		while(!isEmpty(target)){
			target = document.getElementById(random_pos());
		}
		target.innerHTML = gen();
		colorF();
	}
	if(done()){
		alert("You lost!");
	}
}
function done(){	//There is no more available play
	for(var x=0; x<4; x++){
		for(var y=0; y<4; y++){
			var ori  = document.getElementById(get_pos(x,y)).innerHTML;
			var up   = (x>0)?
			(document.getElementById(get_pos(x-1,y)).innerHTML): "";
			var down = (x<3)?
			(document.getElementById(get_pos(x+1,y)).innerHTML): "";
			var left = (y>0)?
			(document.getElementById(get_pos(x,y-1)).innerHTML): "";
			var right= (y<3)?
			(document.getElementById(get_pos(x,y+1)).innerHTML): "";

			var compare_arr = new Array();
			compare_arr.push(ori, up, down, left, right);

			for(var i=1; i<5; i++){
				if(compare_arr[0] == compare_arr[i]){
					return false;
				}
			}
		}
	}
	return true;
}
function isFull(){	//If all full
	for(var i=0; i<4; i++){
		for(var j=0; j<4; j++){
			if(isEmpty(document.getElementById(get_pos(i,j)))){
				return false;
			}
		}
	}
}
function gen(){	//Generate 2 or 4
	//
	return 2 *(Math.floor((Math.random()*2)+1));
}
function random_pos(){	//get a random position
	var x = Math.floor((Math.random()*4)+1)-1;
	var y = Math.floor((Math.random()*4)+1)-1;
	return get_pos(x,y);
}
function get_pos(x, y){	//return 00 type
	if(x <= 0) return "0"+y;
	else return (x*10)+y;
}
function isEmpty(obj){// the position (00 type) is empty or not
	if(obj.innerHTML == "") return true;
	else return false;
}
function isSame(a, b){
	if(parseInt(a) == parseInt(b)){
		return true;
	}else{
		return false;
	}
}
function get_all(){
	var result = new Array();
	for(var i=0; i<4; i++){
		for(var j=0; j<4; j++){
			result.push(document.getElementById(get_pos(i,j)).innerHTML);
		}
	}
	return result;
}
function arr_equal(ori, cur){
	if(Array.isArray(ori) && Array.isArray(cur) && ori.length == cur.length){
		for(var i=0; i<ori.length; i++){
			if(ori[i] != cur[i]){
				return false;
			}
		}
	}
	return true;
}
function colorF(){
	for(var i=0; i<4; i++){
		for(var j=0; j<4; j++){
			cell = document.getElementById(get_pos(i,j));
			setColor(cell);
		}
	}
}
function setColor(cell){
	if(cell.innerHTML == ""){
		cell.style.background = "#F9FFA9";
	}else if(cell.innerHTML == "2"){
		cell.style.background = "#F9FFA9";
	}else if(cell.innerHTML == "4"){
		cell.style.background = "#F9FFA9";
	}else if(cell.innerHTML == "8"){
		cell.style.background = "#F6FF77";
	}else if(cell.innerHTML == "16"){
		cell.style.background = "#F1FF3D";
	}else if(cell.innerHTML == "32"){
		cell.style.background = "#FFC400";
	}else if(cell.innerHTML == "64"){
		cell.style.background = "#FF9300";
	}else if(cell.innerHTML == "128"){
		cell.style.background = "#FF937C";
	}else if(cell.innerHTML == "256"){
		cell.style.background = "#FF5733";
	}else if(cell.innerHTML == "512"){
		cell.style.background = "#C70039";
	}else if(cell.innerHTML == "1024"){
		cell.style.background = "#900C3F";
	}else if(cell.innerHTML == "2048"){
		cell.style.background = "#581845";
	}else if(cell.innerHTML == "4096"){
		cell.style.background = "#000000";
		cell.style.color = "#FAFAFA";
	}
}
function up(x, y){
	if(x != 0){
		var ori = document.getElementById(get_pos(x,y));
		var tar = document.getElementById(get_pos(x-1,y));
		if(isEmpty(tar)){
			tar.innerHTML = ori.innerHTML;
			ori.innerHTML = "";
			up(x-1,y);
		}else{
			if(isSame(tar.innerHTML,ori.innerHTML)){
				tar.innerHTML=parseInt(tar.innerHTML)+parseInt(ori.innerHTML);
				getScore(tar);
				ori.innerHTML = "";
			}
		}
	}
}
function down(x, y){
	if(x != 3){
		var ori = document.getElementById(get_pos(x,y));
		var tar = document.getElementById(get_pos(x+1,y));
		if(isEmpty(tar)){
			tar.innerHTML = ori.innerHTML;
			ori.innerHTML = "";
			down(x+1,y);
		}else{
			if(isSame(tar.innerHTML,ori.innerHTML)){
				tar.innerHTML=parseInt(tar.innerHTML)+parseInt(ori.innerHTML);
				getScore(tar);
				ori.innerHTML = "";
			}
		}
	}
}
function left(x,y){
	if(y != 0){
		var ori = document.getElementById(get_pos(x,y));
		var tar = document.getElementById(get_pos(x,y-1));
		if(isEmpty(tar)){
			tar.innerHTML = ori.innerHTML;
			ori.innerHTML = "";
			left(x,y-1);
		}else{
			if(isSame(tar.innerHTML,ori.innerHTML)){
				tar.innerHTML=parseInt(tar.innerHTML)+parseInt(ori.innerHTML);
				getScore(tar);
				ori.innerHTML = "";
			}
		}
	}
}
function right(x,y){
	if(y != 3){
		var ori = document.getElementById(get_pos(x,y));
		var tar = document.getElementById(get_pos(x,y+1));
		if(isEmpty(tar)){
			tar.innerHTML = ori.innerHTML;
			ori.innerHTML = "";
			right(x,y+1);
		}else{
			if(isSame(tar.innerHTML,ori.innerHTML)){
				tar.innerHTML=parseInt(tar.innerHTML)+parseInt(ori.innerHTML);
				getScore(tar);
				ori.innerHTML = "";
			}
		}
	}
}
function upF(){
	var ori = get_all();
	for(var i=0; i<4; i++){
		for(var j=0; j<4; j++){
			up(i,j);
		}
	}
	var cur = get_all();
	if(!arr_equal(ori, cur)){
		put();
	}
	setScore();
}
function downF(){
	var ori = get_all();
	for(var i=3; i>=0; i--){
		for(var j=3; j>=0; j--){
			down(i,j);
		}
	}
	var cur = get_all();
	if(!arr_equal(ori, cur)){
		put();
	}
	setScore();
}
function leftF(){
	var ori = get_all();
	for(var i=0; i<4; i++){
		for(var j=0; j<4; j++){
			left(i,j);
		}
	}
	var cur = get_all();
	if(!arr_equal(ori, cur)){
		put();
	}
	setScore();
}
function rightF(){
	var ori = get_all();
	for(var i=3; i>=0; i--){
		for(var j=3; j>=0; j--){
			right(i,j);
		}
	}
	var cur = get_all();
	if(!arr_equal(ori, cur)){
		put();
	}
	setScore();
}
function move(event){
	if(event.keyCode == 37){ // left
		leftF();
	}
	if(event.keyCode == 38){ // up
		upF();
	}
	if(event.keyCode == 39){ // right
		rightF();
	}
	if(event.keyCode == 40){ // down
		downF();
	}
}
