$(function () {

    var indexViewModel = {
        parentList :  ko.observableArray(),
        childrenList : ko.observableArray(),
        parentItem: ko.observable(),
        showImageProcessing: ko.observable("block"),

        preInitialize : function () {
            // Set page dropdowns etc...
            console.log("pre");
        },

        initialize : function () {
            console.log("init");
            indexViewModel.getParents();
        },

        getParents : function () {

            var response = WebApp.AjaxHelper({ Url: "/api/BusinessModule/GetAllParents", VerbType: "GET", ContentType: "application/json;charset=utf-8" });

            response.success($.proxy(function (data) {
                indexViewModel.parentList(data);
                console.log(indexViewModel.parentList);
                indexViewModel.showImageProcessing("none");
            }, this));

            response.fail(function (jqXHR, textStatus) {
                // TODO: notify user
                console.log(jqXHR);
                console.log(textStatus);
                alert("Error!");
            });
            
        },

        onClick: function () {

            var response = WebApp.AjaxHelper({ Url: "/api/BusinessModule/GetChildren?parentId=" + indexViewModel.parentItem().Id, VerbType: "GET", ContentType: "application/json;charset=utf-8" });

            response.success($.proxy(function (data) {
                indexViewModel.childrenList.removeAll();
                indexViewModel.childrenList(data);

                console.log(indexViewModel.parentList);
            }, this));

            response.fail(function (jqXHR, textStatus) {
                // TODO: notify user
                console.log(jqXHR);
                console.log(textStatus);
                alert("Error!");
            });
        },

        onMouseOver: function () {
            indexViewModel.parentItem(this);
            console.log(indexViewModel.parentItem());
        },

        onMouseOut: function () {
            indexViewModel.parentItem(null);
        }
        
    };
    ko.applyBindings(indexViewModel);

    indexViewModel.initialize();
});