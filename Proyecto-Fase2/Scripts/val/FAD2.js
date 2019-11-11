$(document).ready(function () {


    $("#myModal").on('hidden.bs.modal', function ()
    {
        creando = false;
        IdEliminados = [];

    });

    var table = $("#tblFAD").DataTable(
            {
                columns: [
                      { title: "N" },
                      { title: "No Factura" },
                      { title: "Precio lote" },
                      { title: "Cantidad lote" },
                      { title: "Fecha de entrada" },
                      { title: "" },
                      { title: "Estado" },
                      { title: "" }
                ]
            });
    for (var i = 0; i < table.data().length; i++)
    {
       
        var fecha = table.cell(i, 4).data();
     
        if (fecha.includes('00:00:00'))
            fecha = fecha.replace('00:00:00', '');


        if (fecha.includes('0:00:00', ''))
            fecha = fecha.replace('0:00:00', '');
        
     

        var date = fecha.split('/', 3);

        if (date[2] != undefined)
            fecha = date[2] + "-" + date[1] + "-" + date[0]
        else
            fecha = "";

        fecha = fecha.replace(' ', '');
        
        table.cell(i, 4).data(fecha); 
    }

    $('#IntegrarP').click(function ()
    {
        $('#cargador').html('<div class="loader"></div>');
        var id = $(this).data('id');
        $("#cargador").load("/Proveedor/Integrar/" + id);
        
    });


    $('#cargador').on('keyup', '#NFactura', function () {

        var NFactura = $('#NFactura').val();
        document.getElementById('GuardarP').style.visibility = "hidden";

        $.ajax(
            {
                url:"/EntradaProducto/KeyUpNFactura",
                method:"post",
                data:'{Factura: '+JSON.stringify(NFactura)+'}',
                contentType:"application/json",
                success:function(mensaje)
                {
                    if (CreandoPL == true) {

                        if (mensaje=="false") 
                        {
                            document.getElementById('s1').style.visibility = "visible";
                            document.getElementById('GuardarP').style.visibility = "hidden";                          
                        }
                        else {
                            document.getElementById('s1').style.visibility = "hidden";
                            document.getElementById('GuardarP').style.visibility = "visible";
                        }
                    }


                    if (editando == true)
                    {
                        if (mensaje=="false" && NFactura != NFacturaOriginal) {
                            document.getElementById('s1').style.visibility = "visible";
                            document.getElementById('GuardarP').style.visibility = "hidden";
                        }
                        else
                        {
                            document.getElementById('s1').style.visibility = "hidden";
                            document.getElementById('GuardarP').style.visibility = "visible";
                        }
                    }


                }
            }
            )

        
        
        


    });


    function llenarLista(id)
    {
        $.ajax
     (
         {
             url: "/EntradaProducto/GetProductos",
             method: "post",
             data: '{Proveedores: ' + JSON.stringify(id) + '}',
             contentType: "application/json",
             success: function (lista) {
                 if (lista != null) {
                     $("#ListaProductos").html('');

                     for (var i = 0; i < lista.length; i++) {
                         $('#ListaProductos').append('<option value="' + lista[i].Value + '">' + lista[i].Text + '</option>');
                     }

                 }
             }

         }

     )
    }

    var NFacturaOriginal;
    var CreandoPL = false;
    $("#crear").click(function ()
    {

        var id = $(this).data('id');
        llenarLista(id);
        $('#cargador').html('<div class="loader"></div>');
        localStorage.setItem('Id_Proveedor', id);
        CreandoPL = true;
        editando = false;
        $("#cargador").load("/EntradaProducto/CrearFAD");

    });

    var editando = false;
    $('#tblFAD').on('click', '.btnEditar', function () {


        $('#cargador').html('<div class="loader"></div>');
        CreandoPL = false;
        var id = $(this).data('id');
        llenarLista($(this).data('proveedor'));
        editando = true;
        $('#cargador').load("/EntradaProducto/EditarFAD/" + id);
        NFacturaOriginal = $('#NFactura').val();
        



    });

    $('#tblFAD').on('click', '.btnVer', function () {


        $('#cargador').html('<div class="loader"></div>'); 
        var id = $(this).data('id');
        $('#cargador').load("/EntradaProducto/VerFad/" + id);
        



    });


    $('#tblFAD').on('click', '.btnCerrar', function ()
    {

        if (confirm('¿Está segura/o que desea cerrar la factura?')) {
            var id = $(this).data('id');
            $.ajax(
                {
                    url: "/EntradaProducto/CerrarF",
                    data: '{id: ' + JSON.stringify(id) + '}',
                    method: "post",
                    contentType: "application/json",
                    success: function (mensaje) {
                        if (mensaje == "2") {
                            alert("No se puede cerrar la factura porque hay detalles incompletos");
                        }
                        else if (mensaje == "1") {
                            for (var i = 0; i < table.data().length; i++) {
                                var Id = table.cell(i, 0);
                                if (id == Id.data()) {
                                    table.cell(i, 5).data('<a href="#myModal" class="btnVer btn-link btn-info" data-toggle="modal" data-id="' + id + '">Ver</a>');
                                    table.cell(i, 6).data('<a  >Cerrarada</a>');
                                    table.cell(i, 7).data('');
                                    break;
                                }

                            }

                        }
                        else {
                            alert(mensaje);
                        }

                    }
                }
                )
        }
    });

    $('#tblFAD').on('click', '.btnEliminar', function () {

        if (confirm('¿Está segura/o que desea eliminar la factura?'))
        {
            var id = $(this).data('id');
            $.ajax(
                {
                    url: "/EntradaProducto/EliminarF",
                    data: '{id: ' + JSON.stringify(id) + '}',
                    method: "post",
                    contentType: "application/json",
                    success: function (mensaje) {
                        if (mensaje == "1") {
                            for (var i = 0; i < table.data().length; i++) {
                                var Id = table.cell(i, 0);
                                if (id == Id.data()) {

                                    table.row(i).remove().draw(false);
                                    break;
                                }
                            }

                        }
                        else {

                            alert(mensaje);
                        }
                    }
                }
                )
        }
    });

    var creando = false;
    var IdCreando;
    $('#cargador').on('click', '#agregarI', function () {
       
            if (creando == false) {

                var cont = document.getElementById("tblPI").rows.length;
                IdCreando = cont;
                id = cont;
                var select = "<select id='ListaProductos1' name='ListaProductos1' class='cProducto' data-id='" + id + "'><option value>Seleccionar Producto</option>" + $("#ListaProductos").html() + "</select>";

                $('#tblPI').append('<tr role="row" class="odd">' +
                                     '<td>' + id + '</td>' +
                                     '<td id="p' + id + '" class="cPro"  data-id=' + id + '> ' + select + '</td>' +
                                     '<td id="cP' + id + '" class="cPrecio" data-id=' + id + '><input type="text" class="inputPrecio"  onkeyup="this.value=NumP(this.value)" data-id="' + id + '"></td>' +
                                     '<td id="cC' + id + '" class="cCantidad" data-id=' + id + '><input type="text" class="inputCantidad" onkeyup="this.value=Num(this.value)" data-id="' + id + '"></td>' +
                                     '<td id="cE' + id + '" class="cBorrar" data-id=' + id + '></td>' +
                                     '</tr>');


                $(".cProducto").select2({
                    dropdownParent: $("#cargador")
                });
                $('#ListaProductos1').focus();
                creando = true;

            }
            else
                alert("Termine de ingresar el detalle para ingresar otro");
        
      

    });

    $('#cargador').on('blur', '#ListaProductos1', function () {

        guardarESP();
    });

    $('#cargador').on('blur', '.inputPrecio', function () {

        guardarESP();
    });

    $('#cargador').on('blur', '.inputCantidad', function () {

        guardarESP();
    });

    function guardarESP() {
        var Id_Producto = $('#ListaProductos1').val();

        if (Id_Producto == "") {
            $("#ListaProductos1").focus();
            return false;
        }
        var Precio = $('.inputPrecio').val();
        if (Precio == "") {
            $('.inputPrecio').focus();
            return false;
        }
        var cantidadI = $('.inputCantidad').val();
        if (cantidadI == "") {
            $('.inputCantidad').focus();
            return false;
        }



        var data =
            {
                Id_Entrada_porProducto: IdCreando,
                Id_Producto: Id_Producto,
                Dinero_E: Precio.replace('.', ','),
                Cantidad_E: cantidadI
            }

        var nProd = $("select[name='ListaProductos1'] option:selected");
        var s;
        var num = $('#precioLote').val();
        var num1 = $('.inputPrecio').val();
        var c1 = $('#cantidadL').val();
        var c2 = cantidadI;

        var s = parseFloat(num) + parseFloat(num1);
        var c = parseInt(c1) + parseInt(c2);

        $('#p' + IdCreando).html(nProd);
        $('#p' + IdCreando).attr("data-prod", data.Id_Producto);
        $('#cP' + IdCreando).html(parseFloat(num1).toFixed(2));
        $('#cC' + IdCreando).html(cantidadI);
        $('#cE' + IdCreando).html('<a href="#" class="btnQuitarIP btn-link btn-info"  data-id="' + data.Id_Entrada_porProducto + '">Quitar</a>');

        $("#precioLote").val(s.toFixed(2));
        $("#cantidadL").val(c);


        creando = false;



    }


    var IdEliminados = [];
    $('#cargador').on('click', '.btnQuitarIP', function () {

        var id = $(this).data('id');
        IdEliminados.push(id);


        $(this).closest('tr').remove();

        totales();

    });

    function totales() {

        var precio_lote = parseFloat(0.00);
        var cantidad_lote = 0;

        $("#tblPI tbody tr").each(function (index) {

            $(this).children("td").each(function (index2) {
                switch (index2) {
                    case 2:
                        {
                            var pi = parseFloat($(this).text()).toFixed(2);
                            precio_lote = parseFloat(precio_lote) + parseFloat(pi);

                            break;
                        }

                    case 3:
                        {
                            var ci = parseInt($(this).text());
                            cantidad_lote += ci;
                            break;
                        }
                }
            });
        });

        $('#precioLote').val(parseFloat(precio_lote).toFixed(2));
        $('#cantidadL').val(cantidad_lote);

    }




    $('#cargador').on('click', '#GuardarP', function () {

        var IdPL = $(this).data('id');
        var productos = [];
        var NFactura = $("#NFactura").val();
        var PrecioL = $('#precioLote').val();
        var cantidadL = $('#cantidadL').val();
        var fecha_Entrada = $('#Fecha').val();


        var Entrada_Producto_Lote =
            {
                Id_Entrada_Producto_Lote: IdPL,
                Id_Proveedor: localStorage.getItem('Id_Proveedor'),
                No_Factura: NFactura,
                Precio_Lote: PrecioL,
                Cantidad_Lote: cantidadL,
                Fecha_Entrada: fecha_Entrada
            }



        if (NFactura == "") {

            alert("Ingrese el número de factura");
            return false;
        }

        if (creando == true)
        {
            alert("Termine de ingresar el detalle o eliminelo una vez ingresado");
            return false;

        }



        $("#tblPI tbody tr").each(function (index) {
            var Id_R;
            if ($(this).data('n') == 1) {
                Id_R = $(this).data('id');
            }
            else {
                Id_R = "";
            }

            var campo1, campo2, campo3;
            $(this).children("td").each(function (index2) {
                switch (index2) {
                    case 1:
                        campo1 = $(this).data('prod');
                        break;
                    case 2:
                        campo2 = $(this).text();
                        break;

                    case 3:
                        campo3 = $(this).text();
                        break;
                }

            })
            var pI =
                {
                    Id_Producto: campo1,
                    Dinero_E: campo2,
                    Cantidad_E: campo3,
                    Id_Entrada_porProducto: Id_R
                }
            productos.push(pI);

        });

        $.ajax
        (
            {
                url: "/EntradaProducto/IngresarP",
                method: "post",
                data: '{_entradaPL: ' + JSON.stringify(Entrada_Producto_Lote) + ', _entradaSLP: ' + JSON.stringify(productos) + ',_ElSLP: ' + JSON.stringify(IdEliminados) + '}',
                contentType: "application/json",
                success: function (mensaje) {
                    if (mensaje != "1") {
                        alert(mensaje);
                    }
                    if (mensaje == "1") {

                        if (CreandoPL == true) {
                            $.ajax
                                (
                                {
                                    url: "/EntradaProducto/GetId",
                                    method: "post",
                                    contentType: "application/json",
                                    success: function (mensaje) {
                                        if (mensaje == "false") {
                                            location.reloa();
                                        }
                                        else {
                                            var editar = '<td ><a href="#myModal" class="btnEditar btn-link btn-info" data-toggle="modal" data-id="' + mensaje + '">Editar</a></td>'
                                            var cerrar = '<td ><a href="#" class="btnCerrar btn-link btn-info"  data-id="' + mensaje + '">Cerrar</a></td>';
                                            var eliminar = '<td ><a href="#" class="btnEliminar btn-link btn-info"  data-id="' + mensaje + '">Eliminar</a></td>';

                                            var data = [[mensaje, Entrada_Producto_Lote.No_Factura, Entrada_Producto_Lote.Precio_Lote, Entrada_Producto_Lote.Cantidad_Lote, Entrada_Producto_Lote.Fecha_Entrada, editar, cerrar, eliminar]];

                                            table.rows.add(data).draw();
                                        }
                                    }
                                }
                                )
                        }
                        if (editando == true) {

                            for (var i = 0; i < table.data().length; i++) {
                                var Id = table.cell(i, 0);
                                if (Entrada_Producto_Lote.Id_Entrada_Producto_Lote == Id.data()) {
                                    table.cell(i, 1).data(Entrada_Producto_Lote.No_Factura);
                                    table.cell(i, 2).data(Entrada_Producto_Lote.Precio_Lote);
                                    table.cell(i, 3).data(Entrada_Producto_Lote.Cantidad_Lote);
                                    table.cell(i, 4).data(Entrada_Producto_Lote.Fecha_Entrada);
                                    break;
                                }

                            }

                        }



                    }

                }
            }

        )

        IdEliminados = [];
    });






    var st = false;
    var IdEditando;
    $('#cargador').on('click', '.cPro', function () {
        if (creando == false && st == false) {

            var select = "<select id='ListaProductos2' name='ListaProductos2' class='ChProducto' data-id='" + $(this).data('id') + "'><option value>Seleccionar Producto</option>" + $("#ListaProductos").html() + "</select>";

            IdEditando = $(this).data('id');
            $('#p' + $(this).data('id')).html(select);

            $(".ChProducto").select2({
                dropdownParent: $("#cargador")
            });
            $('#ListaProductos2').focus();

            st = true;
        }
    });


    $('#cargador').on('change', '#ListaProductos2', function () {

        var Id_Producto = $('#ListaProductos2').val();

        var data =
            {

                Id_Entrada_porProducto: $(this).data('id'),
                Id_Producto: Id_Producto,
                Dinero_E: "",
                Cantidad_E: ""

            }

        cambioI(data);

    });

    $('#cargador').on('click', '.cPrecio', function () {
        if (creando == false && st == false) {

            var num = $('#cP' + $(this).data('id')).html();
            var total = $('#precioLote').val();
            var s = parseFloat(total) - parseFloat(num);
            $('#precioLote').val(s.toFixed(2));



            IdEditando = $(this).data('id');
            var input = '<input type="text" class="iPrecio"  onkeyup="this.value=NumP(this.value)" data-id="' + IdEditando + '"></td>';

            $('#cP' + $(this).data('id')).html(input);
            $('.iPrecio').focus();
            st = true;

        }
    });

    $('#cargador').on('blur', '.iPrecio', function () {

        var dinero = $('.iPrecio').val();
        if (dinero == "")
            dinero = "0";

        var money = parseFloat(dinero);
        money = money.toFixed(2);

        var data =
            {

                Id_Entrada_porProducto: $(this).data('id'),
                Id_Producto: "",
                Dinero_E: money.replace('.', ','),
                Cantidad_E: ""

            }
        cambioI(data);

    });


    $('#cargador').on('click', '.cCantidad', function () {
        if (creando == false && st == false) {

            var total = $('#cantidadL').val();
            var num = $('#cC' + $(this).data('id')).html();
            var s = parseInt(total) - parseInt(num);
            $('#cantidadL').val(s);

            IdEditando = $(this).data('id');
            var input = '<input type="text" class="iCantidad" onkeyup="this.value=Num(this.value)"  data-id="' + IdEditando + '"></td>';

            $('#cC' + $(this).data('id')).html(input);
            $('.iCantidad').focus();
            st = true;

        }
    });
    $('#cargador').on('blur', '.iCantidad', function () {

        var cantidad = $('.iCantidad').val();
        if (cantidad == "")
            cantidad = "0";

        var data =
            {

                Id_Entrada_porProducto: $(this).data('id'),
                Id_Producto: "",
                Dinero_E: "",
                Cantidad_E: cantidad

            }
        cambioI(data);
    });


    function cambioI(data) {


        if (data.Id_Producto != "") {
            var nombreP = $('select[name="ListaProductos2"] option:selected').text();

            $('#p' + IdEditando).html(nombreP);
            $('#p' + IdEditando).data("prod", data.Id_Producto);


        }
        if (data.Dinero_E != "") {
            var total = $('#precioLote').val();

            var dinero = data.Dinero_E.replace(',', '.');
            var s = parseFloat(total) + parseFloat(dinero);

            $('#precioLote').val(s.toFixed(2));

            $('#cP' + IdEditando).html(data.Dinero_E.replace(',', '.'));

        }
        if (data.Cantidad_E != "") {
            var total = $('#cantidadL').val();
            var s = parseInt(total) + parseFloat(data.Cantidad_E);
            $('#cantidadL').val(s);

            $('#cC' + IdEditando).html(data.Cantidad_E);
        }

        st = false;


    }





});

