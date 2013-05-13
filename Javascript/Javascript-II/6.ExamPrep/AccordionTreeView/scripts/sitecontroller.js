(function(){
	SiteController = function(param){
		
	}

	SiteController.prototype = {
		init: function(){
			this.Accordionooo.init();
		},
		getAccordion: function(selector){
			//this.AccordionContainer = selector;
			this.Accordionooo = new Accordion({
				AccordionContainer: selector
			});
			this.Accordionooo.init();
			return this.Accordionooo;
		},
		buildAccordion: function(selector,data){
			var newAccordion = this.getAccordion(selector);
			
			newAccordion.build(data);
			return newAccordion;
		}
	};

	window.addEventListener("load",function(){
		var siteController = new SiteController({});
	},false);
})();