app.service("TareaService", function ($http) {

    //get All Tasks
    this.getTasks = function () {
        debugger;
        return $http.get("api/Tareas");
    };

    // get Tasks By Id
    this.getTask = function (id) {
        var response = $http({
            method: "get",
            url: "/api/Tareas",
            params: {
                id: JSON.stringify(id)
            }
        });
        return response;
    }

    // Update Task
    this.updateTarea = function (tarea) {
        var response = $http({
            method: "put",
            url: "/api/Tareas",
            params: {
                id: JSON.stringify(tarea.Id)
            },
            data: JSON.stringify(tarea),
            dataType: "json"
        });
        return response;
    }

    // Add Task
    this.AddTask = function (tarea) {
        var response = $http({
            method: "post",
            url: "/api/Tareas",
            data: JSON.stringify(tarea),
            dataType: "json"
        });
        return response;
    }

    //Delete Task
    this.Deletetask = function (tareaId) {
        var response = $http({
            method: "delete",
            url: "/api/Tareas",
            params: {
                id: JSON.stringify(tareaId)
            }
        });
        return response;
    }

    //$scope.showModal = function () {
    //    $scope.nuevoMiembro = {};
    //    var modalI = $modal.open({
    //        templateUrl: 'views/addTask.html'
    //    })
    //}

});

    