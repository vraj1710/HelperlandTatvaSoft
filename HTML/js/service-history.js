function dash(){
	var p = document.getElementById("DashboardTable");
	var aa =document.getElementById("ServiceHistoryTable");
	var ab =document.getElementById("FavouriteProsTable");
	var ac = document.getElementById("NotificationsTable");
  var m = document.getElementById("custSettings");
	// var aa = document.getElementById("Dif (x.style.display === "block") {
    document.getElementById("custSettings").style.display="none";
    p.style.display = "block";
   
    aa.style.display = "none";
    ab.style.display = "none";
    ac.style.display = "none";
    m.style.display="none";
    
  	
}

function history(){
	var y = document.getElementById("ServiceHistoryTable");
	var aa = document.getElementById("DashboardTable");
	var ab =document.getElementById("FavouriteProsTable");
	var ac = document.getElementById("NotificationsTable");
  var m = document.getElementById("custSettings");
	document.getElementById("custSettings").style.display="none";
    y.style.display = "block";
    aa.style.display = "none";
    ab.style.display = "none";
    ac.style.display = "none";
    m.style.display="none";
  	
  
}

function pros(){
	var z = document.getElementById("FavouriteProsTable");
	var aa = document.getElementById("DashboardTable");
	var ab = document.getElementById("ServiceHistoryTable");
	var ac = document.getElementById("NotificationsTable");
  var m = document.getElementById("custSettings");
	document.getElementById("custSettings").style.display="none";
    z.style.display = "block";
    aa.style.display = "none";
    ab.style.display = "none";
    ac.style.display = "none";
    m.style.display="none";
  	
   
}
function settings(){
  var m = document.getElementById("custSettings");
  var p = document.getElementById("DashboardTable");
  var aa =document.getElementById("ServiceHistoryTable");
  var ab =document.getElementById("FavouriteProsTable");
  var ac = document.getElementById("NotificationsTable");
 
    m.style.display= "block";
    p.style.display ="none";
    aa.style.display = "none";
    ab.style.display = "none";
    ac.style.display = "none";
 
}

// .......sidenav...........

function openNav() {
  document.getElementById("mySidenav").style.width = "250px";
}

function closeNav() {
  document.getElementById("mySidenav").style.width = "0";
}

// for sticky navbar
