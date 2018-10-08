app.controller("mycntr", function ($scope, myService) {
    $scope.Customer = {
        "CustomerCode": "",
        "CustomerName": "",
        "CustomerAmount": "",
        "CustomerAmountColor": ""
    };
    $scope.Customers = {};
    $scope.msg = "";

    $scope.SearchCustomer= function () {
        console.log('Called me');
        var getdata = myService.SearchCustomer($scope.Customer);
        getdata.then(function (response) {
            $scope.Customers = response.data;
        }, function (response) {
            alert("Records gathering failed!");
        });

    }

});