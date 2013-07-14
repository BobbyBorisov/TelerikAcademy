var SiteBarUrl = Class.create({

    init: function siteBarUrlInit(title, url) {

        this.title = title;
        this.url = url;
    },

    render: function renderUrl() {

        return String.format("<a href='{0}' target='_blank'>{1}</a>", this.url, this.title);
    }
});