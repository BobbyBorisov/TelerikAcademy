(function(){
	 Accordion = function(param){
		this.AccordionContainer = document.querySelector(param.AccordionContainer);
		this.ItemsCollection = [];
	}

	
	
	Accordion.prototype = {
		

		init: function(){
			this.initEvents();
		},
		initEvents: function(){
			var that = this;
			this.AccordionContainer.addEventListener("click",function(evt){
				evt.preventDefault();
				if(!(evt.target instanceof HTMLAnchorElement)){
					return;
				}
				
				var selected_ul = evt.target.parentNode.querySelector("ul");

				childLiNodes = evt.target.parentNode.parentNode.childNodes;

				for(var currentLiNode=0;currentLiNode<childLiNodes.length;currentLiNode+=1){
				
					currentUL = childLiNodes[currentLiNode].querySelector("ul");
					if(currentUL){
						
						if(currentUL.className=="selected" && currentUL==selected_ul){
							continue;
						}

						currentUL.style.display="none";
					}
				}

				selected_ul.className = "selected";

                var ulelement = evt.target.parentNode.querySelector(".selected");
				if(ulelement.style.display=="none" || ulelement.style.display=="" ){
					ulelement.style.display="block";
				} else {
					ulelement.style.display="none";
				}
			},false);
			/*this.AccordionContainer.addDelegateListener('click', 'a', function (evt) {
				evt.stopPropagation();
      			evt.preventDefault();
                var ulelement = evt.target.parentNode.querySelector("ul");
				if(ulelement.style.display=="none" || ulelement.style.display=="" ){
					ulelement.style.display="block";
				} else {
					ulelement.style.display="none";
				}
            },false);*/
		},
		add: function(data){
			var element = new Item(data);
			this.ItemsCollection.push(element);

			return element;
		},
		render: function(){
			
			while(this.AccordionContainer.firstChild){
				this.AccordionContainer.removeChild(this.AccordionContainer.firstChild);
			}
			
			var itemsList = document.createElement("ul");

			for(var i=0;i<this.ItemsCollection.length;i+=1){
				var item = this.ItemsCollection[i].render();
				itemsList.appendChild(item);

			}
			this.AccordionContainer.appendChild(itemsList);
			return this;
		},
		serialize: function(){
			var arr = [];
			for(var i=0;i<this.ItemsCollection.length;i+=1){
				var serializedItem = this.ItemsCollection[i].serialize();
				arr.push(serializedItem);
			}

			return arr;
		},
		build: function(data){
			
			if(!data){
				return;
			}
			var i=0;
			while(data[i]){
				var item = this.add(data[i].title)
				item.buildInnerData(data[i]);
				i++;
			}
			return this;
		},
	}
})();