const AbrirModal = () => {

    $("#Titulo-Modal-Articulo").text("Nuevo Articulo")
    $("#ArticuloID").val(0);
    $("#exampleModal").modal("show");
    $("#Error-Articulo").text("");
    $("#RubroID").val(0);
    $("#SubrubroID").val(0);
    $("#PrecioCosto").val(0);
    $("#Ganancia").val(0);
    $("#PrecioVenta").val(0);
    $("#Error-Ganancia").text("");

}
    

const CompletarTablaArticulo = async () => {

    await VaciarFormulario();

    try {

        $.ajax({
            type: "POST",
            url: '../../Articulos/BuscarArticulos',
            data: {},
            success: async (listadoArticulos) => {
                $("#tbody-Articulos").empty();
                $.each(listadoArticulos, await function (index, articulo) {
                    try {

                        let claseEliminado = '';

                        let botones = '<button type="button" onclick="BuscarArticulo(' + articulo.articuloID + ',' + articulo.rubroID + ')" class="btn btn-outline-dark btn-sm"  style="margin-right:5px; border-radius: 20px!important">' + '<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">' +
                            '<path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>' +
                            '<path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>' +
                            '</svg>' + ' Editar</button>' +
                            '<button type="button" onclick="EliminarArticulo(' + articulo.articuloID + ',1)" class="btn btn-danger btn-sm" style="border-radius: 20px!important">' + '<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash3" viewBox="0 0 16 16">' +
                            '<path d="M6.5 1h3a.5.5 0 0 1 .5.5v1H6v-1a.5.5 0 0 1 .5-.5ZM11 2.5v-1A1.5 1.5 0 0 0 9.5 0h-3A1.5 1.5 0 0 0 5 1.5v1H2.506a.58.58 0 0 0-.01 0H1.5a.5.5 0 0 0 0 1h.538l.853 10.66A2 2 0 0 0 4.885 16h6.23a2 2 0 0 0 1.994-1.84l.853-10.66h.538a.5.5 0 0 0 0-1h-.995a.59.59 0 0 0-.01 0H11Zm1.958 1-.846 10.58a1 1 0 0 1-.997.92h-6.23a1 1 0 0 1-.997-.92L3.042 3.5h9.916Zm-7.487 1a.5.5 0 0 1 .528.47l.5 8.5a.5.5 0 0 1-.998.06L5 5.03a.5.5 0 0 1 .47-.53Zm5.058 0a.5.5 0 0 1 .47.53l-.5 8.5a.5.5 0 1 1-.998-.06l.5-8.5a.5.5 0 0 1 .528-.47ZM8 4.5a.5.5 0 0 1 .5.5v8.5a.5.5 0 0 1-1 0V5a.5.5 0 0 1 .5-.5Z"/>' +
                            '</svg>' + ' Eliminar</button>';

                        if (articulo.eliminado) {
                            claseEliminado = 'table-danger1';
                            botones = '<button type="button" onclick="EliminarArticulo(' + articulo.articuloID + ',0)" class="btn btn-success btn-sm" style="border-radius: 20px!important"> ' + '<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-recycle" viewBox="0 0 16 16">' +
                                '<path d="M9.302 1.256a1.5 1.5 0 0 0-2.604 0l-1.704 2.98a.5.5 0 0 0 .869.497l1.703-2.981a.5.5 0 0 1 .868 0l2.54 4.444-1.256-.337a.5.5 0 1 0-.26.966l2.415.647a.5.5 0 0 0 .613-.353l.647-2.415a.5.5 0 1 0-.966-.259l-.333 1.242-2.532-4.431zM2.973 7.773l-1.255.337a.5.5 0 1 1-.26-.966l2.416-.647a.5.5 0 0 1 .612.353l.647 2.415a.5.5 0 0 1-.966.259l-.333-1.242-2.545 4.454a.5.5 0 0 0 .434.748H5a.5.5 0 0 1 0 1H1.723A1.5 1.5 0 0 1 .421 12.24l2.552-4.467zm10.89 1.463a.5.5 0 1 0-.868.496l1.716 3.004a.5.5 0 0 1-.434.748h-5.57l.647-.646a.5.5 0 1 0-.708-.707l-1.5 1.5a.498.498 0 0 0 0 .707l1.5 1.5a.5.5 0 1 0 .708-.707l-.647-.647h5.57a1.5 1.5 0 0 0 1.302-2.244l-1.716-3.004z"/>' +
                                '</svg>' + ' Activar</button>';
                            /*'<button type="button" onclick="EliminarRubro(' + subrubro.subrubroID + ',0)" class="btn btn-info btn-sm">Activar</button>';*/
                        }

                        $("#tbody-Articulos").append('<tr style="background-color:#ffeba7" class=' + claseEliminado + '>' +
                            '<td>' + articulo.descripcion + '</td>'
                            + '<td>' + articulo.precioCosto + '</td>'
                            + '<td>' + articulo.porcentajeGanancia + '</td>'
                            + '<td>' + articulo.precioVenta + '</td>'

                            + '<td style="text-align:center!important">' + articulo.rubroNombre + '</td>'
                            + '<td>' + articulo.subrubroNombre + '</td>'

                            + '<td class="text-center" style="text-align:right!important">' +
                            botones +
                            '</td>' +
                            '</tr>');

                    } catch (error) {
                        console.log("error en .each", error)
                    }

                });
            },
            error: (data) => {
                console.log("error en listadoArticulos", data)
            }
        });

    } catch (err) {
        console.log("Error en CompletarTablaArticulo",err)
    }
}


const GuardarArticulo = async () => {

    let ArticuloID = $("#ArticuloID").val();
    let ArticuloNombre = $("#ArticuloNombre").val();
    let SubrubroID = $("#SubrubroID").val();
    let PrecioCosto = $("#PrecioCosto").val();
    let Ganancia = $("#Ganancia").val();
    let PrecioVenta = $("#PrecioVenta").val();
    //let RubroID = $("#RubroID").val();
    //let rubroNombre2 = document.getElementById("SubRubroNombre").value;

    try {

        if (ArticuloNombre.trim() != "" && ArticuloNombre.trim() != null) {
            //console.log([...SubRubroID, ...SubrubroNombre])
            $.ajax({
                type: "POST",
                url: '../../Articulos/GuardarArticulo',
                data: { ArticuloID: ArticuloID, Descripcion: ArticuloNombre, PrecioVenta: PrecioVenta, PorcentajeGanancia: Ganancia, PrecioCosto: PrecioCosto, SubrubroID: SubrubroID },
                success: await function (resultado) {
                    $("#exampleModal").modal("hide");
                    CompletarTablaArticulo();
                },
                error: (data) => console.log(data)

            });
        } else {
            $("#Error-Articulo").text("Debe Ingresar un Articulo");


        }
        if (Ganancia < 0) {
            $("#Error-Ganancia").text("No es recomendable este margen");

        }

    } catch (err) {
        console.log("Error en GuardarArticulo",err)
    }

}


const VaciarFormulario = () => {

    $("#ArticuloID").val(0);
    $("#ArticuloNombre").val('');
    $("#Error-Articulo").text("");
    $("#SubrubroID").val(0);

    $("#Error-Ganancia").text("");
}

$("#RubroID").change(async ()  => {
    await BuscarSubRubros();
});

const  BuscarSubRubros = () => {
    //Se limpia el contenido del dropdownlist
    $("#SubrubroID").empty();
    $.ajax({
        type: 'POST',
        //Llamado al metodo en el controlador
        url: "../../SubRubros/ComboSubRubro",
        dataType: 'json',
        //Parametros que se envian al metodo del controlador
        data: { id: $("#RubroID").val() },
        //En caso de resultado exitoso
        success: async (subRubros) => {
            try {

                if (subRubros.length == 0) {
                    $("#SubrubroID").append('<option value="' + "0" + '">' + "[SIN SUBRUBROS]" + '</option>');
                }
                 else {
                    $.each(subRubros, await function (i, subRubro) {
                        $("#SubrubroID").append('<option value="' + subRubro.value + '">' +
                            subRubro.text + '</option>');
                    });
                }

            } catch (err) {
                console.log("Error en subRubros al venir del controlador (ComboSubRubro) ",err)
            }
        },
        ////Mensaje de error en caso de fallo
        error: (ex) => {
            console.log("Error en BuscarSubRubros dentro de Articulos",ex)
        }
    });
    return false;
}


const EliminarArticulo = (ArticuloID, elimina) => {

    try {

        $.ajax({
            type: "POST",
            url: '../../Articulos/EliminarArticulo',
            data: { ArticuloID: ArticuloID, Elimina: elimina },
            success: async (articulo) => await CompletarTablaArticulo(),

            error: (data) => console.log(data)

        });

    } catch (err) {
        console.log(err)
    }

}

const CalcularImportes = (origen) => {

    let costo = $("#PrecioCosto").val();
    let ganancia = $("#Ganancia").val();
    let venta = $("#PrecioVenta").val();

    try {

        //SI MODIFICA PRECIO DE COSTO
        if (origen == 1 || origen == 2) {
            //CALCULAR SOLO EL PRECIO DE VENTA
            let precioVenta = parseFloat(ganancia) / 100 * parseFloat(costo) + parseFloat(costo);
            $("#PrecioVenta").val(precioVenta);

        }
        //SI MODIFICA PRECIO DE VENTA
        if (origen == 3) {
            //calcular ganancia
            let costoCalculado = venta * 100 / costo - 100;
            $("#Ganancia").val(costoCalculado);
        }

    } catch (err) {
        console.log(err)
    }
}


const BuscarArticulo = async (articuloID, rubroID) => {

    $("#Titulo-Modal-Articulo").text("Editar Articulo");
    $("#RubroID").val(rubroID);
    $("#ArticuloID").val(articuloID);
     await BuscarSubRubros();

    try {

        $.ajax({
            type: "POST",
            url: '../../Articulos/BuscarArticulo',
            data: { ArticuloID: articuloID },
            success: await function (articulo) {
                $("#ArticuloNombre").val(articulo.descripcion);
                $("#exampleModal").modal("show");
            },
            error: (data) => console.log(data)

        });

    } catch (err) {
        console.log(err)
    }

}