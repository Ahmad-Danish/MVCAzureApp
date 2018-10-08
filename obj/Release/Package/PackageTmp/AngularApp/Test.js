var app = angular.module("myApp", ['smart-table']);

app.controller("Testctr", function ($scope, departmentService) {
    
    $scope.departments = {};
    $scope.list = function () {
        $scope.loading = false;
        $scope.itemsByPage = 4;

       // debugger;
        var deptlist = departmentService.Departments();
        deptlist.then(function (response) {         

            $scope.departments = response.data;
            
        }, function (resposnse) {
            alert('fail to retrieve');
        });
    }
    //$scope.itemsByPage = 15; 
});