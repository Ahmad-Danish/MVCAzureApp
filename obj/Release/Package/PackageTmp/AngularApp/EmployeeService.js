app.service("employeeService", function ($http) {



    this.GetEmployees = function (employee) {
        var response = $http({
            method: "POST",
            data: JSON.stringify(employee),
            url: "/Employee/getEmployees",
            dataType: "json"
        });
        return response;

    };

    this.DDLdepartments = function () {
        var response = $http({
            method: "POST",
            url: "/Employee/DDLDepartments",
            dataType: "json"
        });
        return response;
    };

    this.DDLdesignations = function () {
        var response = $http({
            method: "POST",
            url: "/Employee/DDLDesignation",
            dataType: "json"
        });
        return response;
    };

    this.InsertUpdateEmployee = function (employee) {
        var response = $http({
            method: "POST",
            url: "/Employee/AddEmployee",
            data:JSON.stringify(employee),
            dataType: "json"
        });
        return response;
    };

    this.GetEmpById = function (employee) {
        var response = $http({
            method: "POST",
            url: "/Employee/getEmployees",
            data: JSON.stringify(employee),
            dataType: "json"
        });
        return response;

    }

});