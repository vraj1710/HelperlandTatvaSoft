var a;
function show_hide() {
//    if (a == 1) {
//        document.getElementById("image").style.display = "none";
//        return a = 0;
//    }

//    else {
        document.getElementById("image").style.display = "block";
    //    return a = 1;
    //}
}
function hide() {
    document.getElementById("image").style.display = "none";
}


var b, ic = 3, price = 54;
function add() {

    if (b == 1) {
        document.getElementById("extra").innerHTML = "";
        document.getElementById("img1").setAttribute("src", "/images/3.png");
        ic = ic - 0.5;
        $("#cabinets").attr("target", "0");
      
        price = price - 9;
        return b = 0;
    }


    else {
        document.getElementById("extra").innerHTML = "<p>inside cabinet</p><p>30 mins</p>";
        document.getElementById("img1").setAttribute("src", "/images/3-green.png");
        ic = ic + 0.5;
        $("#cabinets").attr("target", "1");
        price = price + 9;
        return b = 1;
    }



}

var c, fri;
function add1() {

    if (c == 1) {
        document.getElementById("extra1").innerHTML = "";
        document.getElementById("img2").setAttribute("src", "/images/5.png");
        $("#fridge").attr("target", "0");
        ic = ic - 0.5;
        price = price - 9;
        return c = 0;
    }


    else {
        document.getElementById("extra1").innerHTML = "<p>inside fridge</p><p>30 mins</p>";
        document.getElementById("img2").setAttribute("src", "/images/5-green.png");
        $("#fridge").attr("target", "2");
        ic = ic + 0.5;
        price = price + 9;
        return c = 1;
    }

}

var d, io;
function add2() {
    if (d == 1) {
        document.getElementById("extra2").innerHTML = "";
        document.getElementById("img3").setAttribute("src", "/images/4.png");
        $("#oven").attr("target", "0");
        ic = ic - 0.5;
        price = price - 9;
        return d = 0;
    }


    else {
        document.getElementById("extra2").innerHTML = "<p>inside oven</p><p>30 mins</p>";
        document.getElementById("img3").setAttribute("src", "/images/4-green.png");
        $("#oven").attr("target", "3");
        ic = ic + 0.5;
        price = price + 9;
        return d = 1;
    }

}

var e, lw;
function add3() {
    if (e == 1) {
        document.getElementById("extra3").innerHTML = "";
        document.getElementById("img4").setAttribute("src", "/images/2.png");
        $("#wash").attr("target", "0");
        ic = ic - 0.5;
        price = price - 9;
        return e = 0;
    }


    else {
        document.getElementById("extra3").innerHTML = "<p>Laundry wash</p><p>30 mins</p>";
        document.getElementById("img4").setAttribute("src", "/images/2-green.png");
        $("#wash").attr("target", "4");
        ic = ic + 0.5;
        price = price + 9;
        return e = 1;
    }

}
var f, iw;
function add4() {
    if (f == 1) {
        document.getElementById("extra4").innerHTML = "";
        document.getElementById("img5").setAttribute("src", "/images/1.png");
        $("#windows").attr("target", "0");
        ic = ic - 0.5;
        price = price - 9;
        return f = 0;
    }


    else {
        document.getElementById("extra4").innerHTML = "<p>Interior windows</p><p>30 mins</p>";
        document.getElementById("img5").setAttribute("src", "/images/1-green.png");
        $("#windows").attr("target", "5");
        ic = ic + 0.5;
        price = price + 9;
        return f = 1;

    }


}

function total() {
    document.getElementById("total_time").innerHTML = ic;
}

function total_p() {
    document.getElementById("total_price_1").innerHTML = price;
}
function total_pr() {
  //  document.getElementById("total_price_2").innerHTML = price;
    $("#total_price_2").html(price);
}







