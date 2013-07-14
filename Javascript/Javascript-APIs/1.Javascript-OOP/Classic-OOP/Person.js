var Person = {
	init: function(fname,lname,age){
		this.fname = fname;
		this.lname = lname;
		this.age = age;

	},
	introduce: function(){
		return this.fname+" "+this.lname+" "+this.age;
	}
}