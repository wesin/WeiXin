//var canvas = document.getElementById("canvas");
//var context = canvas.getContext('2d');

/*jquery对象和DOM对象之间的转换*/
var canvas = $("#canvas")[0];
var context = canvas.getContext('2d');

var margin = 35;
var Radius = canvas.width / 2 - margin;
var Number_Spacing = 20;
var Hand_Radius = Radius + Number_Spacing;
var Font_Height = 15;
var Hand_Truncation =  canvas.width/25;
var Hour_Hand_Truncation = canvas.width/10;
var HandType = { SendHand: 0, MinuteHand: 1, HourHand: 2 }
var minuteLength= 10,minuteWidth=1;
var hourLength = 15,hourWidth = 3;

function drawCircle() {
    context.beginPath();
    context.lineWidth = 2;
    context.arc(canvas.width / 2, canvas.height / 2, Radius, 0, Math.PI * 2, true);
    context.stroke();
    for (var i = 1; i <= 60; ++i) {
        angle = Math.PI / 30 * i;
        var linewidth = i % 5 == 0 ? hourWidth : minuteWidth;
        var length = i % 5 == 0 ? hourLength : minuteLength;
        context.beginPath();
        context.lineWidth = linewidth;
        context.moveTo(canvas.width / 2 + Math.cos(angle) * (Radius - length), canvas.height / 2 + Math.sin(angle) * (Radius - length));
        context.lineTo(canvas.width / 2 + Math.cos(angle) * Radius, canvas.height / 2 + Math.sin(angle) * Radius);
        context.stroke();
    }
}

function drawNumber() {
    var angle = 0, numberalWidth=0;
    for(var i=1;i<=12;++i)
    {
        angle = Math.PI/6*(i-3);
        numberalWidth = context.measureText(i).width;
        context.fillText(i,canvas.width/2 + Math.cos(angle) * Hand_Radius - numberalWidth/2, canvas.height/2 + Math.sin(angle)*Hand_Radius + Font_Height/2);
    }
}

function drawCenter() {
    context.beginPath();
    context.arc(canvas.width / 2, canvas.height / 2, 5, 0, Math.PI * 2, true);
    context.fill();
}


function drawHand(loc, handtye,lineWidth) {
    var angle = Math.PI * 2 * loc / 60 - Math.PI / 2;
    var handRadius = Radius - Hand_Truncation;
    switch (handtye)
    {
        case HandType.HourHand:
            handRadius = Radius - Hour_Hand_Truncation - Hand_Truncation;
            break;
        case HandType.MinuteHand:
            handRadius = Radius - 2 * Hand_Truncation;
            break;
        case HandType.SendHand:
            handRadius = Radius - Hand_Truncation;
            break;
    }
    context.lineWidth = lineWidth;
    context.moveTo(canvas.width / 2, canvas.height / 2);
    context.lineTo(canvas.width / 2 + Math.cos(angle) * handRadius, canvas.height/2 + Math.sin(angle) * handRadius);
    context.stroke();
}

function drawHands(){
    var date = new Date;
    $("#time").html("It's time: " + date.toLocaleTimeString());
    var hour = date.getHours();
    hour = hour > 12 ? hour - 12 : hour;
    drawHand(hour*5+date.getMinutes()/60*5,HandType.HourHand,0.6);
    drawHand(date.getMinutes() + date.getSeconds()/60, HandType.MinuteHand, 0.4);
    drawHand(date.getSeconds(), HandType.SendHand, 0.2);
}

function drawClock() {
    context.clearRect(0, 0, canvas.width, canvas.height);
    drawCircle();
    drawNumber();
    drawCenter();
    drawHands();
}


context.font = Font_Height + 'px Arial';
loop = setInterval(drawClock, 1000);