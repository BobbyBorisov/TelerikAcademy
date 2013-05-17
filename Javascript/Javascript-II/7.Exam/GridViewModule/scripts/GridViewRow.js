(function(){
	GridViewRow = function(data){
		this.RowData = data;
		//this.SubGridViewRowsCollection = [];
	}

	

	GridViewRow.prototype = {
		
		getNestedGridView: function(){
			var subGridView = new GridView();
			this.NestedGridView = subGridView;

			return this.NestedGridView;
		},
		render: function(){
			

			var result = "";
			result += "<tr>";

			for(var i=0;i<this.RowData.length;i+=1){
				
				
				result += "<td>"+this.RowData[i]+"</td>";
			}

			result +="</tr>";

			if(this.NestedGridView){
					result+="<tr class='nested' style='display:none'><td colspan='100'>";
					result+= this.NestedGridView.render();
					result+="</td></tr>";
				}


			return result;
		},
		serialize: function(){

			var itemData = {
				dataItems: [],
				subGrid: []
			};
			
				itemData.dataItems.push(this.RowData);
			
			if(this.NestedGridView){
				itemData.subGrid.push(this.NestedGridView.serialize());
			}


			return itemData;
		},
		buildInnerData: function(data){
			var i=0;
			this.RowData = [];
			while(data.dataItems[i]){

				this.RowData[i] = data.dataItems[i];
				i++;
			}

			

			if(data.subGrid.length>0){
				while(data.subGrid[i]){
					this.NestedGridView = new GridView();
					this.NestedGridView.buildInnerData(data.subGrid[i]);
				}
			}
		}
		
	}
})();