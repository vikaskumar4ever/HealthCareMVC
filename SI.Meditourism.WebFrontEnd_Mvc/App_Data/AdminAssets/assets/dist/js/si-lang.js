var mySIObject = (function () {

    return {
        CallGoogleLoad: function () {
            google.setOnLoadCallback(onLoad);
        }
    }

})(mySIObject || {});