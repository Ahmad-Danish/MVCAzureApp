app.service("designationService", function ($http) {

    this.Designations = function () {
        var response = $http({
            method: "POST",
            url: "/Designation/DesgList",
            dataType: "json"
        });
        return response;
    };

    this.IsDesignationExist = function (designation) {
        var response = $http({
            method: "POST",
            url: "/Designation/IsDesignationExist",
            data: JSON.stringify(designation),
            dataType: "json"
        });
        return response;
    }

    this.AddDesignation = function (designation) {
        var response = $http({
            method: "POST",
            url: "/Designation/AddDesignation",
            data: JSON.stringify(designation),
            dataType: "json"
        });
        return response;
    };

    this.GetDesignationById = function (designation) {
        var response = $http({
            method: "POST",
            url: "/Designation/GetDesignationById",
            data: JSON.stringify(designation),
            dataType: "json"
        });
        return response;
    };


});