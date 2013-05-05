var Timer = (function(){
	this.ms = 0;
	this.sec = 0;
	this.min = 0;
	var that = this;

	function updateTime(){

		totalTime = ((min<=9) ? "0" + min : min) + " : " + ((sec<=9) ? "0" + sec : sec) + " : 0" + ms;
		document.getElementById("timer").innerHTML = totalTime;
	}

	function setTimer(min,sec,ms){
		that.min = min;
		that.sec = sec;
		that.ms = ms;
	}

	function startwatch() {
			ms++;
			if (ms == 10) {
				ms = 0;
				sec += 1;
			}
			if (sec == 60) {
				sec = 0;
				min += 1;
			}
			
			updateTime();
		}

	return{
		startwatch: startwatch,
		cleartimer: function(){
			 setTimer(0,0,0);
			 updateTime();
		},
		getTime: function(){
			return that.min+":"+that.sec+":"+that.ms;
		}
	}	

})();