(function(){

  var TodoModule = function(param){
  	this.Container = document.getElementById(param.Container);
  	this.CheckBoxesName = document.getElementsByClassName(param.CheckBoxesName);
  	this.txtData = document.getElementById(param.Data);
  	this.HiddenCheckBoxes = document.getElementById(param.HiddenCheckBoxes);
  	this.btnAddItem = document.getElementById(param.btnAddItem);
  	this.btnHideItem = document.getElementById(param.btnHideItem);
  	this.btnShowItem = document.getElementById(param.btnHideItem);
  	this.btnRemoveItem = document.getElementById(param.btnRemoveItem);
  	this.ItemsCount = 0;
	}


  	TodoModule.prototype = {
  		init: function(){
  			this.initEvents();
  		},
  		Add:function(data){
  			this.Container.innerHTML+='<li><input id="'+this.ItemsCount+'" type="checkbox" value="Bike" class="mycheckboxes">'+data+'</li>';
  			this.ItemsCount+=1;
  		},
  		Hide: function(){
  			var checkBoxes = this.GetCheckedBoxes();
  				for(var i=0;i<checkBoxes.length;i+=1){
  					var parent = checkBoxes[i].parentNode;
  					parent.style.display = "none";
  					parent.className = "hidden";
        }, 
        Remove: function(){        
            for(var i=0;i<checkedBoxes.length;i++){    
				var parent = checkedBoxes[i].parentNode;
				this.Container.removeChild(parent);
			}
  		},
  		ShowAll: function(){
  			var checkedBoxes = this.HiddenCheckBoxes;
  			for(var i=0;checkedBoxes.length;i+=1){
  					var parent = this.checkedBoxes[i].style.display = "";
  				}
  		},
  		GetCheckedBoxes: function(){
  			  var checkboxes = this.CheckBoxesName;
			  var checkboxesChecked = [];

			  for (var i=0; i<checkboxes.length; i++) {
			     if (checkboxes[i].checked) {
			        checkboxesChecked.push(checkboxes[i]);
			     }
			  }

			  return checkboxesChecked.length > 0 ? checkboxesChecked : null;
			
  		},
  		initEvents: function(){
  			//Add button logic 
  			this.btnAddItem.addEventListener("click",function(ev){
  				ev.preventDefault();
  				var itemData = this.txtData.value;
  				this.Add(itemData);
  			},false);

  			//Hide button logic 
  			this.btnHideItem.addEventListener("click",function(ev){
  				ev.preventDefault();
  				
  				this.Hide();
  				
  			},false);

  			//Show button logic 
  			this.btnShowItem.addEventListener("click",function(ev){
  				this.ShowAll();
  			},false);

  			//Remove button logic 
  			this.btnRemove.addEventListener("click",function(ev){
  				var checkBoxesToRemove = this.GetCheckedBoxes();
  				this.Remove(checkBoxesToRemove);
  			},false);
  		},
  	};
  
  	window.addEventListener('load', function () {
        var TodoModule = new TodoModule({
            Container: "todo-container",
            CheckBoxesName: "mycheckboxes",
            txtData: "txtData",
            HiddenCheckBoxes: "hidden",
            btnAddItem: "btnAddItem",
            btnHideItem: "btnHideItem",
            btnShowItem: "btnShowItem",
            btnRemoveItem: "btnRemoveItem"
        });
        TodoModule.init();
    }, false);
})();