
app.service("departmentService", function ($http) {

    this.Departments = function () {
        var response = $http({
            method: "POST",
            url: "/Department/DeptList",
            dataType: "json"
        });
        return response;
    };


    this.AddDepartment = function (department) {
        var response = $http({
            method: "POST",
            url: "/Department/AddDepartment",
            data: JSON.stringify(department),
            dataType: "json"
        });
        return response;
    };

    this.IsDepartmentExist = function (department) {
        var response = $http({
            method: "POST",
            url: "/Department/IsDepartmentExists",
            data: JSON.stringify(department),
            dataType: "json"
        });
        return response;
    }

    this.GetDepartmentById = function (department) {
        var response = $http({
            method: "POST",
            url: "/Department/GetDepartmentById",
            data: JSON.stringify(department),
            dataType: "json"
        });
        return response;

    }



});