//Base class for PropulsionUnits
function PropulsionUnit(){
	this.acceleration = 0;
}

function Wheel(radius){
	this.radius=radius;
}

Wheel.prototype.calculateAcceleration = function(){
	this.acceleration = 2*Math.PI*this.radius;

}

function PropellingNozzle(power,afterburnSwitch){
	this.power = power;
	this.afterburnSwitch = afterburnSwitch;
}

PropellingNozzle.prototype.calculateAcceleration = function(){
	if(this.afterburnSwitch==="on"){
		this.acceleration = this.power*2;
	} else {
		this.acceleration = this.power;
	}
}

function Propeller(finsCounter,spinDirection){
	this.finsCounter = finsCounter;
	this.spinDirection = spinDirection; 
}

Propeller.prototype.calculateAcceleration = function(){

	if(this.spinDirection === "clockwise"){
		this.acceleration = this.finsCounter;
	} else if(this.spinDirection === "counter-clockwise"){
		this.acceleration = -this.finsCounter;
	}
}

Wheel.inherit(PropulsionUnit);
PropellingNozzle.inherit(PropulsionUnit);
Propeller.inherit(PropulsionUnit);