app.controller("EmployeeCntr", function ($scope, $window, employeeService, $routeParams) {
    $scope.Emp = {
        "Id": 0,
        "Name": "",
        "DOB": "",
        "Gender": "",
        "Email": "",
        "Mobile": "",
        "Address": "",
        "JoiningDate": "",
        "DepartmentID":"",
        "DesignationID": "",
        "Department": "",   
        "Designation": ""   
    };

    $scope.ClearFields = function () {
        $scope.Emp.Id = 0;
        $scope.Emp.Name = "";
        $scope.Emp.DOB = "";
        $scope.Emp.Gender = "";
        $scope.Emp.Email = "";
        $scope.Emp.Address = "";
        $scope.Emp.Mobile = "";
        $scope.Emp.JoiningDate = "";
        $scope.Emp.DepartmentID = "";
        $scope.Emp.DesignationID = "";
        $scope.Gender = "";
    }


    $scope.ddldepartments = {};
    $scope.ddldesignations = {};
    $scope.employees = {};
    $scope.errors = {};
    $scope.ddlgender = [
        { Gen: "Male" },
        { Gen: "Female" }
    ];
    $scope.msg = "";   

    $scope.Departments = function () {        
        var deptlist = employeeService.DDLdepartments();
        deptlist.then(function (response) {
            $scope.ddldepartments = response.data;
        }, function (response) {
            alert('Failed to fetch department list');
        });
    }

    $scope.Designations = function () {
        var desiglist = employeeService.DDLdesignations();
        desiglist.then(function (response) {
            $scope.ddldesignations = response.data;
        }, function (response) {
            alert('Failed to fetch designation list');
        });
    }

    $scope.Addemployee = function () {        
        var addemp = employeeService.InsertUpdateEmployee($scope.Emp);
        addemp.then(function (response) {

            var status = response.data.Status;
            if (status == "success")
            {
                alert('Employee added successfully...');                
                $scope.ClearFields();
                $window.location.href = '#!/Employeelist';
            }
            else if (status == "fail")
            {
                $scope.errors = response.data.errors;
                $("#myModal").modal('show');                
            }           
        }, function (response) {            
            alert('Failed to add employee');
        });
    }

    $scope.getEmployees = function ()
    {
        $scope.loading = true;
        $scope.itemsByPage = 6;
        var emplist = employeeService.GetEmployees($scope.Emp);
        emplist.then(function (response) {
            $scope.employees = response.data;
            $scope.loading = true;
        }, function (response) {
            alert('Failed to retrieve employees');
        });

    }

    $scope.getEmpById = function () {
        //debugger;
        $scope.Emp.Id = $routeParams.empid;       
        if ($scope.Emp.Id != null)
        {
            var getdata = employeeService.GetEmpById($scope.Emp);
            getdata.then(function (response) {
                $scope.Emp = response.data;
            }, function (response) {
                alert('fail to retrieve employee');
            }
            );
        }       
        
    }
    $scope.Designations();
    $scope.Departments();
   
    $scope.formValid = false;
    $scope.showmsg = false;    
    $scope.isFormValid = function () {       
        if ($scope.formValid == true) {
            
            $scope.Addemployee();
        }
        else {
            $scope.showmsg = true;
        }
    }


    


});