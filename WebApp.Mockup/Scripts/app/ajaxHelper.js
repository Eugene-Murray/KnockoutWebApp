var WebApp = window.WebApp = window.WebApp || {};

console.log("WebApp.AjaxHelper");

    WebApp.AjaxHelper = function (ajaxConfig) {
        return $.ajax({
            url: ajaxConfig.Url,
            type: ajaxConfig.VerbType,
            contentType: ajaxConfig.ContentType
        });
    };
