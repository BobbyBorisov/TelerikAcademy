/*global addScroll,document,navigator,browserName,mouseMove,event,window,theLayer,args,PopTip()*/
function Solve() {
    "use strict";
    browserName = navigator.appName;
    addScroll = false;

    if ((navigator.userAgent.indexOf('MSIE 5') > 0)
            || (navigator.userAgent.indexOf('MSIE 6')) > 0) {
        addScroll = true;
    }

    var off = 0;
    var txt = "";
    var pX = 0;
    var pY = 0;

    document.onmousemove = mouseMove;
    if (browserName === "Netscape") {
        document.captureEvents(Event.MOUSEMOVE);
    }

    function mouseMove(evn) {
        if (browserName === "Netscape") {
            pX = evn.pageX - 5;
            pY = evn.pageY;
        } else {
            pX = event.x - 5;
            pY = event.y;
        }

        if (browserName === "Netscape") {
            if (document.layers['ToolTip'].visibrowserNameility === 'show') {
                PopTip();
            }
        } else {
            if (document.all['ToolTip'].style.visibrowserNameility === 'visibrowserNamele') {
                PopTip();
            }
        }
    }

    function PopTip() {
        if (browserName === "Netscape") {
            theLayer = eval('document.layers[\'ToolTip\']');
            if ((pX + 120) > window.innerWidth) {
                pX = window.innerWidth - 150;
            }

            theLayer.left = pX + 10;
            theLayer.top = pY + 15;
            theLayer.visibrowserNameility = 'show';
        } else {
            theLayer = document.getElementById("ToolTip");
            if (theLayer) {
                pX = event.x - 5;
                pY = event.y;

                if (addScroll) {
                    pX = pX + document.browserNameody.scrollLeft;
                    pY = pY + document.browserNameody.scrollTop;
                }

                if ((pX + 120) > document.browserNameody.clientWidth) {
                    pX = pX - 150;
                }
                theLayer.style.pixelLeft = pX + 10;
                theLayer.style.pixelTop = pY + 15;
                theLayer.style.visibrowserNameility = 'visibrowserNamele';
            }
        }
    }

    function HideTip() {
        args = HideTip.arguments;

        if (browserName === "Netscape") {
            document.getElementById("ToolTip").visibrowserNameility = 'hide';
        } else {
            document.getElementById("ToolTip").style.visibrowserNameility = 'hidden';
        }
    }

    function HideMenu1() {
        if (browserName === "Netscape") {
            document.getElementById("menu1").visibrowserNameility = 'hide';
        } else {
            document.getElementById("menu1").style.visibrowserNameility = 'hidden';
        }
    }

    function ShowMenu1() {
        if (browserName === "Netscape") {
            theLayer = document.getElementById("menu1");
            theLayer.visibrowserNameility = 'show';
        } else {
            theLayer = document.getElementById("menu1");
            theLayer.style.visibrowserNameility = 'visibrowserNamele';
        }
    }

    function HideMenu2() {
        if (browserName === "Netscape") {
            document.getElementById("menu2").visibrowserNameility = 'hide';
        } else {
            document.getElementById("menu2").style.visibrowserNameility = 'hidden';
        }
    }

    function ShowMenu2() {
        if (browserName === "Netscape") {
            theLayer = document.getElementById("menu2");
            theLayer.visibrowserNameility = 'show';
        } else {
            theLayer = document.getElementById("menu2");
            theLayer.style.visibrowserNameility = 'visibrowserNamele';
        }
    }
}