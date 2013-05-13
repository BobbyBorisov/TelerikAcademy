(function(){
	Item = function(title){
		this.title = title;
		this.SubItemsCollection = [];
	}

	

	Item.prototype = {
		add: function(data){
			var subElement = new Item(data);
			this.SubItemsCollection.push(subElement);

			return subElement;
		},
		render: function(){
			var itemNode=document.createElement("li");
			itemNode.innerHTML="<a href='#'>"+this.title+"</a>";

			if(this.SubItemsCollection.length>0){
				var subList = document.createElement("ul");

				for(var i=0;i<this.SubItemsCollection.length;i+=1){
					var subItem	= this.SubItemsCollection[i].render();
					subList.appendChild(subItem);
				}

				itemNode.appendChild(subList);
			}
			return itemNode;
		},
		serialize: function(){

			var itemData = {
				title: this.title,
				subItems: []
				};


			for(var i=0;i<this.SubItemsCollection.length;i+=1){
				itemData.subItems.push(this.SubItemsCollection[i].serialize());
			}

			return itemData;
		},
		buildInnerData: function(data){
			var i=0;
			while(data.subItems[i]){
				var subitem = this.add(data.subItems[i].title);
				subitem.buildInnerData(data.subItems[i]);
				i++;
			}
		}
	}
})();