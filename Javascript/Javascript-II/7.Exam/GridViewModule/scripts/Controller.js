(function(){
	Controller = function(){

	}

	Controller.prototype = {
		getGridView: function(selector){
			
			//this.GridView = document.querySelector(selector);

			/*this.GridView = new GridView({
				GridViewContainer: selector
			});*/

			this.GridView = new GridView(selector);
			this.GridView.init();
			return this.GridView;
		},
		buildGridView: function(selector,data){
			var newGridView = this.getGridView(selector);
			
			newGridView.build(data);
			return newGridView;
		}
	};

	controller = new Controller();
})();