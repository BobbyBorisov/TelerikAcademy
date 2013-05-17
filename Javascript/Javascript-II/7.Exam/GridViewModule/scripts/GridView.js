(function(){
	 GridView = function(param){
	 	if(param)
		this.GridViewContainer = document.querySelector(param);
		
		this.RowsCollection = [];
		this.selector = param;
	}

	
	
	GridView.prototype = {
		init: function(){
			this.initEvents();
		},
		addHeader: function(args){
			var data = [];

			for(var i=0;i<arguments.length;i+=1){
				data.push(arguments[i]);
			}
			this.GridHeader = new GridViewHeader(data);

			return this.GridHeader;
		},
		addRow: function(args){
			var data = [];

			for(var i=0;i<arguments.length;i+=1){
				data.push(arguments[i]);
			}
			var rowElement = new GridViewRow(data);
			this.RowsCollection.push(rowElement);

			return rowElement;
		},
		initEvents: function(){
			this.GridViewContainer.addEventListener("click",function(ev){
				if (!ev) {
	                ev = window.event;
	            }
            ev.stopPropagation();
            ev.preventDfault;

            var clickedItem = ev.target.parentElement;
            if (!(clickedItem instanceof HTMLTableRowElement)) {
                return;
            }

            var nextSibling = clickedItem.nextElementSibling;
            if (nextSibling && nextSibling.className === 'nested') {
                if (nextSibling.style.display === 'none') {
                    nextSibling.style.display = '';
                } else {
                    nextSibling.style.display = 'none';
                }
            }
			},false);
		},
		render: function(){

			
			var sublist = [];
			var result = "";
			result+="<table>";
			
			

			if(this.GridHeader){
				result+= this.GridHeader.render();
			}
			
			for(var i=0;i<this.RowsCollection.length;i+=1){
				result  += this.RowsCollection[i].render();
			}
			
			result+="</table>";

			if(this.GridViewContainer){
				this.GridViewContainer.innerHTML = result;
			}

			return result;
		},
		serialize: function(){
			var arr = [];
			if(this.GridHeader){
				var serializedHeader = this.GridHeader.serialize();
				arr.push(serializedHeader);
			}

			for(var i=0;i<this.RowsCollection.length;i+=1){
				var serializedItem = this.RowsCollection[i].serialize();
				arr.push(serializedItem);
			}

			return arr;
		},
		build: function(data){
			
			if(!data){
				return;
			}
			var i=0;

			if(data.headerItems){
				this.GridHeader = new GridHeader(data.headerItems);
			}

			while(data.length>0){
				var item = new GridViewRow(data);
			}
			return this;
		},


	}
})();