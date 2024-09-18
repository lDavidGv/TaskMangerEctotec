app.controller("myCntrl", function ($scope, TareaService) {
    GetAll();
    //To Get All Records 
    function GetAll() {
        debugger;
        var getData = TareaService.getTasks();
        debugger;
        getData.then(function (msg) {
            $scope.tasks = msg.data;
        }, function () {
            var toastElList = [].slice.call(document.querySelectorAll('.toastError'))
            var toastList = toastElList.map(function (toastEl) {
                return new bootstrap.Toast(toastEl)
            })
            toastList.forEach(toast => toast.show())
            $scope.message = msg.data.successMessage;
        });
    }

    $scope.edit = function (tarea) {
        debugger;
        var getData = TareaService.getTask(tarea.Id);
        getData.then(function (msg) {
            $scope.tarea = msg.data;
            $scope.idTarea = tarea.Id;
            $scope.TituloTarea = tarea.Titulo;
            $scope.DesacripcionTarea = tarea.Descripcion;
            $scope.EstatusTarea = tarea.Estado;
            $scope.Action = "Actualizar";
        },
            function (msg) {
                var toastElList = [].slice.call(document.querySelectorAll('.toastError'))
                var toastList = toastElList.map(function (toastEl) {
                    return new bootstrap.Toast(toastEl)
                })
                toastList.forEach(toast => toast.show())
                $scope.message = msg.data.ErrorMessage;
            });
    }

    $scope.AddUpdate = function () {

        debugger;
        var tarea = {
            Descripcion: $scope.DesacripcionTarea,
            Estado: $scope.EstatusTarea,
            Titulo: $scope.TituloTarea
        };
        var getAction = $scope.Action;

        if (getAction == "Actualizar") {
            tarea.Id = $scope.idTarea;
            var getData = TareaService.updateTarea(tarea);
            getData.then(function (msg) {
                GetAll();
                $("#AddTaskModal").modal("hide");

                var toastElList = [].slice.call(document.querySelectorAll('.toastSuccess'))
                    var toastList = toastElList.map(function (toastEl) {
                        return new bootstrap.Toast(toastEl)
                    })
                toastList.forEach(toast => toast.show())
                $scope.message = msg.data.successMessage;
            }, function (msg) {

                var toastElList = [].slice.call(document.querySelectorAll('.toastError'))
                var toastList = toastElList.map(function (toastEl) {
                    return new bootstrap.Toast(toastEl)
                })
                toastList.forEach(toast => toast.show())
                $scope.message = msg.data.ErrorMessage;
            });
        } else {
            var getData = TareaService.AddTask(tarea);
            getData.then(function (msg) {
                GetAll();
                $("#AddTaskModal").modal("hide");

                var toastElList = [].slice.call(document.querySelectorAll('.toastSuccess'))
                var toastList = toastElList.map(function (toastEl) {
                    return new bootstrap.Toast(toastEl)
                })
                toastList.forEach(toast => toast.show())
                $scope.message = 'Se Agrego correctamente la tarea: '+msg.data.Titulo;

            }, function (msg) {
                console.log(msg);

                var toastElList = [].slice.call(document.querySelectorAll('.toastError'))
                var toastList = toastElList.map(function (toastEl) {
                    return new bootstrap.Toast(toastEl)
                })
                toastList.forEach(toast => toast.show())
                $scope.message = msg.data.ErrorMessage;
            });
        }
    }

    $scope.AddTaskModalS = function () {
        ClearFields();
        $scope.Action = "Agregar";

    }

    $scope.deleteAsk = function (tarea) {
        $('#deleteModal').modal('show');
        $scope.task = tarea;
        $scope.Action = "Borrar";
    }

    $scope.delete = function (tarea) {
        var getData = TareaService.Deletetask(tarea.Id);
        getData.then(function (msg) {
            GetAll();
            $("#AddTaskModal").modal("hide");

            var toastElList = [].slice.call(document.querySelectorAll('.toastSuccess'))
            var toastList = toastElList.map(function (toastEl) {
                return new bootstrap.Toast(toastEl)
            })
            toastList.forEach(toast => toast.show())
            $scope.message = 'Se elimino correctamente la tarea : ' + msg.data.Titulo;
            $('#deleteModal').modal('hide');


        }, function (msg) {

            var toastElList = [].slice.call(document.querySelectorAll('.toastError'))
            var toastList = toastElList.map(function (toastEl) {
                return new bootstrap.Toast(toastEl)
            })
            toastList.forEach(toast => toast.show())
            $scope.message = msg.data.ErrorMessage;
            $('#deleteModal').modal('hide');
        });

    }



    function ClearFields() {
        $scope.idTarea = "";
        $scope.TituloTarea = null;
        $scope.DesacripcionTarea = "";
        $scope.EstatusTarea = false;


    }


});