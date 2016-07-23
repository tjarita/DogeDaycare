var App = App || {};
(function () {

    var appLocalizationSource = abp.localization.getSource('DogeDaycare');
    App.localize = function () {
        return appLocalizationSource.apply(this, arguments);
    };

})(App);