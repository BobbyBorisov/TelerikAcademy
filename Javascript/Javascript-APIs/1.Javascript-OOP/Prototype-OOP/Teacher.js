var Teacher = Person.extend({     
	init: function(fname,lname,age,speciality){
		this._super.init.apply(this,arguments);
		this.speciality=speciality;
		return this;
	},
	introduce:function(){
		return this._super.introduce.apply(this) + " " + this.speciality;
	}
});