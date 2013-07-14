/*var Student = Person.extend({
	init: function(fname,lname,age,grade){
		this._super=Object.create(this._super);
		this._super.init(fname,lname,age);
		this.grade=grade;
		return this;
	},
	introduce:function(){
		return this._super.introduce() + " " + this.grade;
	}
});
*/
var Student = Person.extend({
	init: function(fname,lname,age,grade){
		this._super.init.apply(this,arguments);
		this.grade=grade;
		return this;
	},
	introduce:function(){
		return this._super.introduce.apply(this) + " " + this.grade;
	}
});





