var Slider = {
	init: function(sliderContainer){
		this.currentImageIndex=0;
		this.parentContainer = document.querySelector(sliderContainer);
		this.ImageContainer = document.createElement("div");
		this.ImagesSlider = this.ImageContainer.cloneNode(true);
		this.ImagesSlider.id="slider-container";
		this.ImageContainer.className="image-container";
		this.parentContainer.appendChild(this.ImagesSlider);
		

		this.btnLeft = document.createElement("a");
		this.btnLeft.className="button";

		this.btnRight = this.btnLeft.cloneNode(true);
		this.btnLeft.id="left";
		this.btnLeft.innerHTML="<";
		this.btnRight.id="right";
		this.btnRight.innerHTML=">";

		this.parentContainer.appendChild(this.btnLeft);
		this.parentContainer.appendChild(this.ImageContainer);
		this.parentContainer.appendChild(this.btnRight);
		this.currentImageIndex=0;

		this._setOfImages = [];
		
		return this;
	},
	addImage: function(title, src){
		this._setOfImages.push(Object.create(Image).init(title,src));
	},
	initEvents: function(){
		var that = this;
			this.btnLeft.addEventListener("click", function(ev){
			//console.log(currentImageIndex)
			var old = that.ImagesSlider.getElementsByClassName("selected");
            if(old.length>0){
            old[0].className="";
        }
			that.currentImageIndex--;

			if (that.currentImageIndex == -1) {
				that.currentImageIndex = that._setOfImages.length-1;
			}

			
			that.ImageContainer.innerHTML="";
			var image = document.createElement("img");
			image.src=that._setOfImages[that.currentImageIndex].src;
			image.setAttribute("index",that.currentImageIndex);
			image.height=200;
			image.width=200;
			//var imageHTML="<img id='"+that.currentImageIndex+"' src='"+that._setOfImages[that.currentImageIndex].src+"' title='"+that._setOfImages[that.currentImageIndex].title+"'>"; 
			//that.ImageContainer.innerHTML = imageHTML;
			that.ImageContainer.appendChild(image);
			var xa = that.ImagesSlider.querySelector("img[index='"+image.getAttribute("index")+"']");
			xa.className="selected";
			}, false);

		that.btnRight.addEventListener("click", function(ev){
		var old = that.ImagesSlider.getElementsByClassName("selected");
            if(old.length>0){
            old[0].className="";
        }
		that.currentImageIndex++;

		if (that.currentImageIndex == that._setOfImages.length) {
			that.currentImageIndex = 0;
		}

		
		that.ImageContainer.innerHTML="";
		var image = document.createElement("img");
			image.src=that._setOfImages[that.currentImageIndex].src;
			image.id=that.currentImageIndex;
			image.height=200;
			image.width=200;
		
		//var imageHTML="<img id='"+that.currentImageIndex+"' src='"+that._setOfImages[that.currentImageIndex].src+"' title='"+that._setOfImages[that.currentImageIndex].title+"'>"; 
		//	that.ImageContainer.innerHTML = imageHTML;
		that.ImageContainer.appendChild(image);
		var xa = that.ImagesSlider.querySelector("img[index='"+image.id+"']");
			xa.className="selected";
		}, false);

		this.ImagesSlider.addEventListener("click",function(ev){
			if (!ev) {

                ev = window.event;
            }

            if (!(ev.target instanceof HTMLImageElement)) {

                return;
            }

			ev.stopPropagation();
            ev.preventDefault();

            var old = that.ImagesSlider.getElementsByClassName("selected");
            if(old.length>0){
            old[0].className="";
        }
            that.ImageContainer.innerHTML="";
            var currentImage = ev.target.cloneNode(true);
            currentImage.width=200;
            currentImage.height=200;
            ev.target.className="selected";
            that.ImageContainer.appendChild(currentImage);
            that.currentImageIndex=ev.target.getAttribute("index");


		},false);
		return this;
	},
	FuckYeah: function(){
		var output = "";

		if(this._setOfImages.length>0){
			output+="<img class='selected' index='"+0+"' src='"+this._setOfImages[0].src+"' title='"+this._setOfImages[0].title+"'>"; 
			for(var i=1;i<this._setOfImages.length;i+=1){
				output+="<img index='"+i+"' src='"+this._setOfImages[i].src+"' title='"+this._setOfImages[i].title+"'>"; 
			}

			this.ImagesSlider.innerHTML=output;

			if(this._setOfImages.length>0){
			this.ImageContainer.innerHTML="<img index='"+this.currentImageIndex+"' src='"+this._setOfImages[this.currentImageIndex].src+"' width='200' width='200' title='"+this._setOfImages[this.currentImageIndex].title+"'>"; 
			}
		}

	}
};