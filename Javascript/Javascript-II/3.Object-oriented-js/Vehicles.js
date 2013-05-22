function Vehicle(speed, propunit){
	this.speed = speed;
	this.propulsionUnit = propunit
}

Vehicle.prototype.Accelerate = function(){
	this.speed+=this.propulsionUnit.calculateAcceleration();
}



function LandVehicle(speed){
	this.speed = speed;
	this.propunit = [];
	for(var numOfwheels=0;numOfwheels<=3;numOfwheels++){
		this.propunits.push(new Wheel(10));
	}
}

LandVehicle.inherit(Vehicle);

function AirVehicle(){
	this.propunit = new PropellingNozzle(100,"on");
}

AirVehicle.prototype.switchAfterburner = function(){
	var burnSwitch = this.propunit.afterburnSwitch;

	if(burnSwitch==="on"){
		burnSwitch = "off";
	}else if(burnSwitch==="off"){
		burnSwitch="on";
	}
}

function WaterVehicle(finsCounter,spinDirection){
	this.propunit = new Propeller(finsCounter,spinDirection);
}

WaterVehicle.prototype.changeSpinDirection = function(){
	var spinDirection = this.propunit.spinDirection;

	if(spinDirection==="clockwise"){
		spinDirection = "counter-clockwise";
	}else if(spinDirection==="counter-clockwise"){
		spinDirection="clockwise";
	}
}

function Amphibia(mode){
	this.mode = mode;
	this.propunit = [];
	this.propunit["propeller"] = new Propeller(50,"clockwise");
	this.propunit["wheel"] = [ new Wheel(10), new Wheel(10), new Wheel(10), new Wheel(10)];
}

AirVehicle.prototype.changeVehicleMode = function(mode){

	if(mode==="land"){
		this.mode = "water";
	}else if(mode==="water"){
		this.mode="mode";
	}
}

Amphibia.prototype.Accelerate = function(){
	if(this.mode ==="land"){
		this.speed += 4*this.propunit["wheel"].calculateAcceleration();
	} else if(this.mode ==="water"){
		this.speed += this.propunit["propeller"].calculateAcceleration();
	}
}

Amphibia.inherit(Vehicle);