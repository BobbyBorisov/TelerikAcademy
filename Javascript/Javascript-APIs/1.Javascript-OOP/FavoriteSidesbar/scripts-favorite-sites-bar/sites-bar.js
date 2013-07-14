var SitesBar = Class.create({

    init : function initSiteBar(parentSelector) {
    
        this.parent = document.querySelector(parentSelector);
        this.container = document.createElement('div');
        this.container.className = 'sites-bar';
        this.parent.appendChild(this.container);

        this.rootFolder = new SiteBarFolder('Favorite Site Bars');

        return this;
    },

    initEvents: function initEvents() {

        attachEventHandler(this.container, 'click', function changeDispalyOnClick(ev) {

            if (!ev) {

                ev = window.event;
            }

            if (!(ev.target instanceof HTMLAnchorElement)) {
                ev.stopPropagation();
                ev.preventDefault();
            }
            
            if (!(ev.target instanceof HTMLParagraphElement)) {

                return;
            }

            var nextSibling = ev.target.nextSibling;
            while (nextSibling) {

                if (nextSibling.style.display === 'none') {
                    nextSibling.style.display = '';
                }
                else {
                    nextSibling.style.display = 'none';
                }
                
                nextSibling = nextSibling.nextSibling;
            }
        });
    
        return this;
    },

    render: function renderSiteBar() {

        this.container.innerHTML = this.rootFolder.render();
        return this;
    },

    addUrl: function addUrl(title, url) {

        this.rootFolder.addUrl(title, url);
        return this.rootFolder.setOfUrls[this.rootFolder.setOfUrls.length - 1];
    },

    addFolder: function addFolder(title) {

        this.rootFolder.addFolder(title);

        return this.rootFolder.setOfFolders[this.rootFolder.setOfFolders.length - 1];
    }
});