var School = {
	init: function(name,town,setOfClasses){
		this.name= name;
		this.town = town;
		if(!setOfClasses){
			this.setOfClasses = [];
		}else{
			this.setOfClasses = setOfClasses;
		}
	},
	addClass: function(newClass){
		this.setOfClasses.push(newClass);
	},
	toString: function(){
		var result = "";
		result+= "Name:"+this.name + " ;Town:" + this.town + "\n";
		for(var i=0;i<this.setOfClasses.length;i+=1){
			result += this.setOfClasses[i].toString();
		}

		return result;
	}
}