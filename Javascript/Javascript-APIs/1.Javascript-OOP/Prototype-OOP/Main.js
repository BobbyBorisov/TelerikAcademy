var TUES = Object.create(School);
TUES.init("TUES","Sofia");


for(var i=0;i<3;i+=1){

	var teacher = Object.create(Teacher).init("Pesho#"+i,"Petrov",i+30,"IT");
	var newClass = Object.create(Class).init("class#"+i,30,teacher);

		for(var j=1;j<9;j+=1){
			var student = Object.create(Student).init("Gosho#"+i+j,"Ivanov",j,6);
			newClass.addStudent(student);
		}
	
	TUES.addClass(newClass);
}

console.log(TUES.toString());
