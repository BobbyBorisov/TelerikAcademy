var Student = Class.create({
	init: function(fname,lname,age,grade){
		this._super= new Person(fname,lname,age);
		this.grade=grade;

		return this;
	},
	introduce:function(){
		return this._super.introduce() + " " + this.grade;
	}
});

Student.inherit(Person);
