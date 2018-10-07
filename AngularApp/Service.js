app.service("myService", function ($http) {
    this.SearchCustomer = function (customer) {
        var response = $http({
            method: "POST",
            url: "/CustomerAng/GetCustomerByName",
            data: JSON.stringify(customer),
            dataType: "json"
        });
        return response;
    }


});