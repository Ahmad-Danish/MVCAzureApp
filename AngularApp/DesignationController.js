

app.controller("DesignationCntr", function ($scope, designationService) {
    $scope.Designation = {
        "DesigId": 0,
        "DesignationName": "",
        "Desigdesc":""
    };

    $scope.Designations = {};

    $scope.Designationlist = function () {
        //debugger;
        $scope.loading = false;
        $scope.itemsByPage = 6;
        var deptlist = designationService.Designations();
        deptlist.then(function (response) {
            $scope.loading = true;
            $scope.Designations = response.data;
        }, function (resposnse) {
            alert('fail to retrieve');
        });
    }

    $scope.AddUpdateDesignation = function () {
        debugger;
        var getdata = designationService.IsDesignationExist($scope.Designation);
        getdata.then(function (response) {
            var dept = response.data;
            if (dept == '0') {
                var adddepart = designationService.AddDesignation($scope.Designation);
                adddepart.then(function (response1) {
                    alert('Designation added successfully...');
                    $scope.ClearFields();
                    hideModal();
                    location.reload();
                    // $scope.Departmentlist();                    
                }, function (response1) {
                    alert("Failed to Add Designation!");
                });
            }
            else {
                alert('Designation with this name already exists...');
            }

        }, function (response) {
            alert("Failed to Check Designation!");
        });
    }

    $scope.getdesigById = function (Id) {

        $scope.Designation.DesigId = Id;
        var getdata = designationService.GetDesignationById($scope.Designation);
        getdata.then(function (response) {
            $scope.Designation = response.data;
            $("#myModal").modal('show');
            //$window.location.href = '/Department/Add/id='+$scope.Department.Id;
        }, function (response) {
            alert('Failed to retrieve designation...');
        });
    }


    $scope.ClearFields = function () {
        $scope.Designation.DesigId = 0;
        $scope.Designation.DesignationName = "";
        $scope.Designation.Desigdesc = "";
    }

    function hideModal() {
        $("#myModal").removeClass("in");
        $(".modal-backdrop").remove();
        $("#myModal").hide();
    }

    $scope.formValid = false;
    $scope.showmsg = false;

    $scope.isFormValid = function () {        
        if ($scope.formValid == true) {
            $scope.AddUpdateDesignation();
        }
        else {
            $scope.showmsg = true;
        }
    };

});