

app.controller("DepartmentCntr", function ($scope, departmentService, $window) {
    $scope.Department = {
        "Id": 0,
        "DepartmentName": "",
        "DepartmentDesc": ""       
    };
    $scope.Departments = {};
    $scope.msg = "";
    $scope.validateform = false;

    
    $scope.Departmentlist = function () {
        //debugger;
        $scope.loading = false;
        $scope.itemsByPage = 6;
        var deptlist = departmentService.Departments();
        deptlist.then(function (response) {
            $scope.loading = true;
            $scope.Departments = response.data;
        }, function (resposnse) {
            alert('fail to retrieve');
        });
    }
    
    $scope.ClearFields = function () {
        $scope.Department.Id = 0;
        $scope.Department.DepartmentName = "";
        $scope.Department.DepartmentDesc = "";

    }

    $scope.AddUpdateDepartment = function () {        
        var getdata = departmentService.IsDepartmentExist($scope.Department);
        getdata.then(function (response) {
            var dept = response.data;
            if (dept == '0') {
                var adddepart = departmentService.AddDepartment($scope.Department);
                adddepart.then(function (response1) {                    
                    alert('Department added successfully...');
                    hideModal();
                    location.reload();
                   // $scope.Departmentlist();                    
                }, function (response1) {
                    alert("Failed to Add Department!");
                });
            }
            else {
                alert('Department with this name already exists...');
            }
            
        }, function (response) {
            alert("Failed to Check Department!");
        });
    }

    function hideModal() {       
        $("#myModal").removeClass("in");
        $(".modal-backdrop").remove();
        $("#myModal").hide();
    }

    $scope.getdepartById = function (Id)
    {       
        $scope.Department.Id = Id;
        var getdata = departmentService.GetDepartmentById($scope.Department);
        getdata.then(function (response) {
            $scope.Department = response.data;
            $("#myModal").modal('show');
            //$window.location.href = '/Department/Add/id='+$scope.Department.Id;
        }, function (response) {
            alert('Failed to retrieve department...');
        });

    }

    $scope.formValid = false;
    $scope.showmsg=false;    
    //$scope.$watch('depform', function () {
       
    //});
    $scope.isFormValid = function () {      
        if ($scope.formValid == true) {
            $scope.AddUpdateDepartment();
        }
        else
        {           
            $scope.showmsg = true;
        }
    };

   
});