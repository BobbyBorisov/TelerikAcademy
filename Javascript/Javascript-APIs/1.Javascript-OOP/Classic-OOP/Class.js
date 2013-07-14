var Class = {
	init: function(cName,capacity, formTeacher, setOfStudents){
		this.cName = cName;
		this.capacity = capacity;
		if(!setOfStudents){
			this.setOfStudents= [];
		}else{
			this.setOfStudents = setOfStudents;
		}
		this.formTeacher = formTeacher;

		return this;
	},
	addStudent: function(student){
		if(this.setOfStudents.length>this.capacity){
			throw new Error("The capacity e dostignat");
		}
		this.setOfStudents.push(student);

		return student;
	},
	toString: function(){
		var result = "";
		result = "ClassName:"+this.cName+"; "
		result+= this.formTeacher.introduce() + "\n";
		for(var i=0;i<this.setOfStudents.length;i+=1){
			result+= this.setOfStudents[i].introduce()+"\n";
		}

		return result;
	}
}