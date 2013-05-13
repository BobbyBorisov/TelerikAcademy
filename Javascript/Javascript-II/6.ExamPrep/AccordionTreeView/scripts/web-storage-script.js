(function() {
    var div = document.createElement("div");
    var prefix = ["moz", "webkit", "ms", "o"].filter(function (prefix) {
        return prefix + "MatchesSelector" in div;
    })[0] + "MatchesSelector";
    
    Element.prototype.addDelegateListener = function (type, selector, fn) {

        this.addEventListener(type, function (e) {
            var target = e.target;

            while (target && target !== this && !target[prefix](selector)) {
                target = target.parentNode;
            }

            if (target && target !== this) {
                return fn.call(target, e);
            }

        }, false);
    };


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