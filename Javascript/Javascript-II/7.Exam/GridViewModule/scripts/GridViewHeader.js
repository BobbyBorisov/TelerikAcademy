(function(){
	GridViewHeader = function(data){
		this.RowData = data;
	}

	

	GridViewHeader.prototype = {
		render: function(){
			
			var result = "";
			result+="<tr>";
			for(var i=0;i<this.RowData.length;i+=1){
				result +="<th>"+this.RowData[i]+"</th>";
			}
			result+="<tr>";
			return result;
		},
		serialize: function(){

			var headerData = {
				headerItems: [],
			};
			
				headerData.headerItems.push(this.RowData);

			return headerData;
		},
		
	}
})();