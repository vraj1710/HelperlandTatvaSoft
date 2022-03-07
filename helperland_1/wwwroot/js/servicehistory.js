var s = 0, t = 0, p = 0;

$(document).ready(function () {
    $("#s1").click(function () {
        $("#s1").attr('src', '/images/star1.png');
        $("#s2,#s3,#s4,#s5").attr('src', '/images/star2.png');
        s = 1;
    });
    $("#s2").click(function () {
        $("#s1,#s2").attr('src', '/images/star1.png');
        $("#s3,#s4,#s5").attr('src', '/images/star2.png');
        s = 2;
    });
    $("#s3").click(function () {
        $("#s1,#s2,#s3").attr('src', '/images/star1.png');
        $("#s4,#s5").attr('src', '/images/star2.png');
        s = 3;
    });
    $("#s4").click(function () {
        $("#s1,#s2,#s3,#s4").attr('src', '/images/star1.png');
        $("#s5").attr('src', '/images/star2.png');
        s = 4;
    });
    $("#s5").click(function () {
        $("#s1,#s2,#s3,#s4,#s5").attr('src', '/images/star1.png');
        s = 5;
    });




    $("#t1").click(function () {
        $("#t1").attr('src', '~/images/star1.png');
        $("#t2,#t3,#t4,#t5").attr('src', '/images/star2.png');
        t = 1;
    });
    $("#t2").click(function () {
        $("#t1,#t2").attr('src', '/images/star1.png');
        $("#t3,#t4,#t5").attr('src', '/images/star2.png');
        t = 2;
    });
    $("#t3").click(function () {
        $("#t1,#t2,#t3").attr('src', '/images/star1.png');
        $("#t4,#t5").attr('src', '/images/star2.png');
        t = 3;
    });
    $("#t4").click(function () {
        $("#t1,#t2,#t3,#t4").attr('src', '/images/star1.png');
        $("#t5").attr('src', '/images/star2.png');
        t = 4;
    });
    $("#t5").click(function () {
        $("#t1,#t2,#t3,#t4,#t5").attr('src', '/images/star1.png');
        t = 5;
    });




    $("#p1").click(function () {
        $("#p1").attr('src', '/images/star1.png');
        $("#p2,#p3,#p4,#p5").attr('src', '/images/star2.png');
        p = 1;
    });
    $("#p2").click(function () {
        $("#p1,#p2").attr('src', '/images/star1.png');
        $("#p3,#p4,#p5").attr('src', '~/images/star2.png');
        p = 2;
    });
    $("#p3").click(function () {
        $("#p1,#p2,#p3").attr('src', '/images/star1.png');
        $("#p4,#p5").attr('src', '/images/star2.png');
        p = 3;
    });
    $("#p4").click(function () {
        $("#p1,#p2,#p3,#p4").attr('src', '/images/star1.png');
        $("#p5").attr('src', '/images/star2.png');
        p = 4;
    });
    $("#p5").click(function () {
        $("#p1,#p2,#p3,#p4,#p5").attr('src', '/images/star1.png');
        p = 5;
    });

    $(".rate").on('click', function () {
        var ratesp = (s + t + p) / 3;
        console.log(ratesp);


        console.log("p " + p);
        console.log("t" + t);
        console.log("s" + s);
        // x = Math.floor(ratesp)
        // console.log("math fllorr " + x);
        x = ratesp.toFixed(0);
        console.log("fixed value" + x);
        $("#rateavg").html(x);

        switch (x) {
            case '0':
                $("#v1,#v2,#v3,#v4,#v5").attr('src', '/images/star2.png');
                break;
            case '1':
                $("#v1").attr('src', '/images/star1.png');
                $("#v2,#v3,#v4,#v5").attr('src', '/images/star2.png');
                break;
            case '2':
                $("#v1,#v2").attr('src', '/images/star1.png');
                $("#v3,#v4,#v5").attr('src', '/images/star2.png');
                break;
            case '3':
                $("#v1,#v2,#v3").attr('src', '/images/star1.png');
                $("#v4,#v5").attr('src', '/images/star2.png');
                break;
            case '4':
                $("#v1,#v2,#v3,#v4").attr('src', '/images/star1.png');
                $("#v5").attr('src', '/images/star2.png');
                break;
            case '5':
                $("#v1,#v2,#v3,#v4,#v5").attr('src', '/images/star1.png');
                break;
            default:
                alert('Nobody Wins!');
        }

    })


});

