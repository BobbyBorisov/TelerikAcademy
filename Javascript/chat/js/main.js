var controllers = (function(){
	var ChatController = Class.create({

		init: function(){
			this.initPubNub();
			this.subsribeForMessage();
			//this.attachEventHandlers();
		},

		initPubNub: function () {
            this.pubnub = PUBNUB.init({
                publish_key: 'pub-c-fc712db2-1e95-44ef-a3e5-7eac63eaa02f',
                subscribe_key: 'sub-c-a5c6e20a-07f1-11e3-8f37-02ee2ddab7fe'
            });
            this.subsribeForMessage();
        },
        subsribeForMessage: function(){
        	var self = this;

            this.pubnub.subscribe({
                channel: "common-channel",
                callback: function (message){
                	console.log(message);
                    $("#messages-list").append("<li>"+message+"</li>")
                }
            });
        },
        attachEventHandlers: function(){
        	var self = this;

        	$("#chatbox").on("click","#btn-send-message",function(){
        		var text = $("#message-text").val();
        		var channel = "common-channel";
        		
        		self.pubnub.publish({
                    channel: channel,
                    message: text
                });

                $("#message-text").val("");
        	})
        }


	});

	return {
		get: function(){
			return new ChatController();
		}
	}
})();

$(function () {
    var controller = controllers.get();
});