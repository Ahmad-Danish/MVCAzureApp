

    var app = angular.module("myApp", ['ngRoute', 'smart-table'])
        .config(function ($routeProvider, $locationProvider) {
            $locationProvider.hashPrefix('');
            $routeProvider.
            when('/Adddepartment', {
                templateUrl: 'Department/Add',
                controller: 'DepartmentCntr'
            }).
            when('/Departmentlist', {
                templateUrl: 'Department/Departmentlist',
                controller: 'DepartmentCntr'
            }).
            when('/Adddesignation', {
                templateUrl: 'Designation/Add',
                controller: 'DesignationCntr'
            }).
             when('/Designationlist', {
                 templateUrl: 'Designation/DesignationList',
                 controller: 'DesignationCntr'
             }).
             when('/AddEmployee', {
                 templateUrl: 'Employee/Add',
                 controller: 'EmployeeCntr'
             }).
            when('/Employeelist', {
                templateUrl: 'Employee/List',
                controller: 'EmployeeCntr'
            }).
            when('/AddEmployee/:empid', {
                 templateUrl: 'Employee/Add',
                 controller: 'EmployeeCntr'
             })

            $locationProvider.html5Mode(false).hashPrefix('!');

        })



