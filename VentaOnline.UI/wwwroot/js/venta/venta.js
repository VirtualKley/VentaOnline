class Venta {
    constructor() {
        
    }

    obtenerVentas(url) {
        $.ajax({
            url: url,
            type: 'GET',
            success: function (result) {
                $('#ListaVenta').html(result);
            }
        });
    }

    obtenerFormVenta(url) {
        $.ajax({
            url: url,
            type: 'GET',
            success: function (result) {
                $('#RegistrarVenta').html(result);
            }
        });
    }

    obtenerTotalVenta(url) {
        $.ajax({
            url: url,
            type: 'GET',
            success: function (result) {
                $('#TotalesVenta').html(result);
            }
        });
    }

    actualizarPrecio() {
        document.getElementById("Total").value = (document.getElementById("precio").value * document.getElementById("Cantidad").value).toFixed(2);
    }

    crearVenta(url, urlReload, urlTotal) {
        var venta = {
            IdPersona: $("#IdPersona").val(),
            Descripcion: $("#Descripcion").val(),
            Cantidad: $("#Cantidad").val(),
            TotalFloat: $("#Total").val().replace('.', ',')
        };

        if ($("#Descripcion").val().trim() === '' || $("#Cantidad").val().trim() === '') {
            alert('Por favor, complete los campos Descripción y Cantidad.');
            return false;
        }

        $.ajax({
            type: "POST",
            url: url,
            data: venta,
            success: function (result) {
                this.obtenerVentas(urlReload);
                this.obtenerTotalVenta(urlTotal);
                this.limpiarInputs(['Descripcion', 'Cantidad', 'Total', 'precio']);
            }.bind(this),
            error: function (xhr, status, error) {
                console.log("Error al crear la venta: " + error);
            }
        });
    }

    crearPersona(url, urlReload) {
        var persona = {
            Nombre: $("#nombrePersona").val(),
            Celular: $("#celularPersona").val(),
        };

        if ($("#nombrePersona").val().trim() === '') {
            alert('Por favor, complete los campos nombre.');
            return false;
        }

        $.ajax({
            type: "POST",
            url: url,
            data: persona,
            success: function (result) {
                $('#miModal').modal('hide');
                this.limpiarInputs(['nombrePersona', 'celularPersona']);
                this.obtenerFormVenta(urlReload);
            }.bind(this),
            error: function (xhr, status, error) {
                console.log("Error al crear la persona: " + error);
            }
        });
    }

    eliminarVenta(idVenta ,url, urlReload, urlTotal) {
        $.ajax({
            type: "POST",
            url: url,
            data: { idVenta },
            success: function (result) {
                this.obtenerVentas(urlReload);
                this.obtenerTotalVenta(urlTotal);
            }.bind(this),
            error: function (xhr, status, error) {
                console.log("Error al crear la persona: " + error);
            }
        });
    }

    limpiarInputs(idList) {
        idList.forEach(function (id) {
            document.getElementById(id).value = '';
        });
    }
}