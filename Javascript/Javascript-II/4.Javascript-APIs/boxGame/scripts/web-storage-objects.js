(function() {



    if (!Storage.prototype.setObject) {
        Storage.prototype.setObject = function setObject(key, obj) {
            var jsonObj = JSON.stringify(obj);
            this.setItem(key, jsonObj);
        };

    }

    if (!Storage.prototype.setValue) {
        Storage.prototype.setValue = function setValue(obj,key,value) {
            //var jsonObj = JSON.stringify(obj);
            var oldValue = this.getObject(obj)[key];
            var jsonObj = this.getItem(obj);
            
            var indexStart=0;
                indexStart=jsonObj.indexOf(key+'":');
                var subText = jsonObj.substring(indexStart,indexStart + key.length + 2 + oldValue.toString().length);
                var newValue = oldValue + value;
                var temp = subText.replace(oldValue, newValue);
                jsonObj=jsonObj.replace(subText,temp);
            this.setItem(obj,jsonObj);
        };
    }
    
    if (!Storage.prototype.getObject) {
        Storage.prototype.getObject = function getObject(key) {
            var jsonObj = this.getItem(key);
            var obj = JSON.parse(jsonObj);
            return obj;
        };
    }
})();