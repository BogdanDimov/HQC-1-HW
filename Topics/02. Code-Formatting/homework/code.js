(function () {
	var browser = navigator.appName;
	var addScroll = false;
	var off = 0;
	var text = "";
	var xCoord = 0;
	var yCoord = 0;

	if ((navigator.userAgent.indexOf('MSIE 5') > 0) ||
		(navigator.userAgent.indexOf('MSIE 6')) > 0) {
		addScroll = true;
	}

	document.onmousemove = mouseMove;

	if (browser === 'Netscape') {
		document.captureEvents(Event.MOUSEMOVE);
	}

	function mouseMove(event) {
		if (browser === 'Netscape') {
			xCoord = event.pageX - 5;
			yCoord = event.pageY;

			if (document.layers['ToolTip'].visibility === 'show') {
				PopTip();
			}
		} else {
			xCoord = event.x - 5;
			yCoord = event.y;

			if (document.all['ToolTip'].style.visibility === 'visible') {
				PopTip();
			}
		}
	}

	function PopTip() {
		var theLayer;

		if (browser === 'Netscape') {
			theLayer = eval('document.layers[\'ToolTip\']');

			if ((xCoord + 120) > window.innerWidth) {
				xCoord = window.innerWidth - 150;
			}

			theLayer.left = xCoord + 10;
			theLayer.top = yCoord + 15;
			theLayer.visibility = 'show';
		} else {
			theLayer = eval('document.all[\'ToolTip\']');

			if (theLayer) {
				xCoord = event.x - 5;
				yCoord = event.y;

				if (addScroll) {
					xCoord = xCoord + document.body.scrollLeft;
					yCoord = yCoord + document.body.scrollTop;
				}

				if ((xCoord + 120) > document.body.clientWidth) {
					xCoord = xCoord - 150;
				}

				theLayer.style.pixelLeft = xCoord + 10;
				theLayer.style.pixelTop = yCoord + 15;
				theLayer.style.visibility = 'visible';
			}
		}
	}

	function HideTip() {
		var args = HideTip.arguments;

		if (browser === 'Netscape') {
			document.layers['ToolTip'].visibility = 'hide';
		} else {
			document.all['ToolTip'].style.visibility = 'hidden';
		}
	}

	function HideMenu1() {
		if (browser === 'Netscape') {
			document.layers['menu1'].visibility = 'hide';
		} else {
			document.all['menu1'].style.visibility = 'hidden';
		}
	}

	function ShowMenu1() {
		var theLayer;

		if (browser === 'Netscape') {
			theLayer = eval('document.layers[\'menu1\']');
			theLayer.visibility = 'show';
		} else {
			theLayer = eval('document.all[\'menu1\']');
			theLayer.style.visibility = 'visible';
		}
	}

	function HideMenu2() {
		if (browser === 'Netscape') {
			document.layers['menu2'].visibility = 'hide';
		} else {
			document.all['menu2'].style.visibility = 'hidden';
		}
	}

	function ShowMenu2() {
		var theLayer;

		if (browser === 'Netscape') {
			theLayer = eval('document.layers[\'menu2\']');
			theLayer.visibility = 'show';
		} else {
			theLayer = eval('document.all[\'menu2\']');
			theLayer.style.visibility = 'visible';
		}
	}
})();