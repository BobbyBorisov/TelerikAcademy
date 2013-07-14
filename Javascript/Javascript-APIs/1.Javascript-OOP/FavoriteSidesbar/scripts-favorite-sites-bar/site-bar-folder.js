var SiteBarFolder = Class.create({

    init: function siteBarFolderInit(title) {
        this.title = title;
        this.setOfUrls = [];
        this.setOfFolders = [];

        return this;
    },
    
    render: function renderFolder() {

        var result = "<div><p>" + this.title + "</p>";
        var hasUrls = this.setOfUrls.length > 0;
        var i;

        if (hasUrls) {

            result += '<ul>';
        }

        for (i = 0; i < this.setOfUrls.length; i += 1) {

            result += '<li>'  + this.setOfUrls[i].render() + '</li>';
        }

        if (hasUrls) {

            result += '</ul>';
        }

        for (i = 0; i < this.setOfFolders.length; i += 1) {

            result += this.setOfFolders[i].render();
        }

        result += '</div>';

        return result;
    },

    addUrl: function addUrl(title, url) {

        var newUrl = new SiteBarUrl(title, url);
        this.setOfUrls.push(newUrl);

        return newUrl;
    },

    addFolder: function addFolder(title) {

        var newFolder = new SiteBarFolder(title);
        this.setOfFolders.push(newFolder);
        return newFolder;
    }
});