var Teacher = Class.create({
	init: function(fname,lname,age,speciality){
		this._super= new Person(fname,lname,age);
		this.speciality=speciality;

		return this;
	},
	introduce:function(){
		return this._super.introduce() + " " + this.speciality;
	}
});

Teacher.inherit(Person);