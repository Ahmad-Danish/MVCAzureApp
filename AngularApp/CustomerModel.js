function CustomerModel($scope, $http) {

    $scope.Customer = {
        "CustomerCode": "",
        "CustomerName": "",
        "CustomerAmount": "",
        "CustomerAmountColor": ""
    };
    $scope.Customers = {};
    $scope.msg = "";

    // Add Customer
    $scope.Add = function () {

        $http({
            method: "POST",
            data: $scope.Customer,
            url: "CustomerAng/AddCust"
        }).then(function (response) {
            //Load the grid data  
            //clear the controls on success                    
            $scope.Customer = {
                "CustomerCode": "",
                "CustomerName": "",
                "CustomerAmount": "",
                "CustomerAmountColor": ""
            };
            //$("#msg").text("Record saved successfully!");
            alert('Record saved successfully');
            $scope.Customers = response.data;
        });
    }

    $scope.SearchCustomer = function () {
        
        
        $http({
            method: "POST",            
            url: "/CustomerAng/GetCustomerByName",
            data: JSON.stringify($scope.Customer),
            dataType: "json"
        }).then(function (response) {
            $scope.Customers = response.data;
        });
    }

    $scope.$watch("Customers", function () {
        for (var i = 0; i < $scope.Customers.length; i++) {
            var cust = $scope.Customers[i];
            cust.CustomerAmountColor = $scope.getColor(cust.CustomerAmount);
        }
    });

    $scope.$watch("Customer.CustomerAmount", function () {
        $scope.Customer.CustomerAmountColor = $scope.getColor($scope.Customer.CustomerAmount);

    });
    

    //Retrieve Customer
    $scope.LoadCustomers = function () {
        $http({
            method: "GET",
            url: "GetCustomers"
        }).then(function (response) {
            $scope.Customers = response.data;
        });
    }
    $scope.LoadCustomers();

    $scope.getColor = function (Amount) {
        if (Amount == 0) {
            return "";
        }
        else if (Amount > 100) {
            return "Blue";
        }
        else {
            return "Red";
        }
    };

    

   

}