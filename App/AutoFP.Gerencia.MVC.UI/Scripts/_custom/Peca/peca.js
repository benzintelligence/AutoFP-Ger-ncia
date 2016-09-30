// Hide and show element
function hideComponent(component) { component.addClass("hidden"); }
function showComponent(component) { component.removeClass("hidden"); }

// Click Piece is Original?
$("#Original").click(function () {
    if ($(this).is(":checked")) {
        hideComponent($("#divPecaParalela"));
        $("#ParalelaLinhaNumero").val(null);
    }
    else showComponent($("#divPecaParalela"));
});

/* Caso estiver selecionado na primeira tentativa de registrar a peça e der algum erro...
.. Mostra/Esconder componente "Peça paralela", caso o backend retorne para a View CREATE novamente. */
if ($("#Original").is(":checked")) hideComponent($("#divPecaParalela"));
else showComponent($("#divPecaParalela"));

// Click Piece position
$("#chkPositionPiece").click(function () {
    if ($(this).is(":checked")) showComponent($("#divPositionPiece"));
    else hideComponent($("#divPositionPiece"));
});

/* Caso estiver selecionado na primeira tentativa de registrar a peça e der algum erro...
.. Mostra Partial "Posição de peça", caso o backend retorne para a View CREATE novamente. */
if ($("#chkPositionPiece").is(":checked")) {
    showComponent($("#divPositionPiece"));
}

// GetMarcaByCategoryPiece
$("#CategoriaPecaId").change(function () {
    var url = "/Marca/MarcasByCategoriaPeca";
    var id = $(this).val();
    var ddlMarcas = $("#MarcaId");
    var messageError = "Não foi possível requisitar as marcas, contacte o administrador";
    var messageComponentInCaseError = "Selecione primeira a categoria";
    if (validateValue(id)) requisition(url, id, ddlMarcas, messageError, 1, messageComponentInCaseError);
});

$("#CategoriaPecaId").val(null);

// Veiculos by Montadora selected
$("#ddlMontadoras").change(function () {
    var url = "/Carro/GetCars";
    var id = $(this).val();
    var ddlVeiculos = $("#ddlCarros");
    var messageError = "Não foi possível requisitar os veículos, contacte o administrador";
    var messageComponentInCaseError = "Selecione um veículo";
    if (validateValue(id)) {
        requisition(url, id, ddlVeiculos, messageError, 2, messageComponentInCaseError);
        $("#ddlModelos").html("<option value='' selected>Selecione um modelo/ano</option>");
    }
});
/* Caso ocorrer algum erro na tentativa de registrar e volte do backend para a View CREATE...
.. Limpa o valor anteriormente selecionado no select/option */
$("#ddlMontadoras").val(null);

// Ano/Modelo by Veiculo selected
$("#ddlCarros").change(function () {
    var url = "/Carro/GetModels";
    var id = $(this).val();
    var ddlModelos = $("#ddlModelos");
    var messageError = "Não foi possível requisitar os modelos, contacte o administrador";
    var messageComponentInCaseError = "Selecione um modelo/ano";
    if (validateValue(id)) requisition(url, id, ddlModelos, messageError, 3, messageComponentInCaseError);
});

// Function's Helper's
function requisition(url, id, component, messageError, idetifyScenario, messageComponentInCaseError) {
    $.ajax({
        url: url,
        method: "POST",
        datatype: "application/json",
        data: { id: id },
        beforeSend: function () {
            component.html("<option value='' selected>Carregando...</option>");
        },
        success: function (data) {
            var listReturn = "";
            switch (idetifyScenario) {
                // Marca -> CategoryPiece
                case 1: listReturn = populateMarksByCategory(data); break;
                    // Montadora -> Veiculos
                case 2: listReturn = populateCars(data); break;
                    // Veiculos -> Modelos/Anos
                case 3: listReturn = populateCarsModels(data); break;
            }
            component.html(listReturn);
        },
        error: function () {
            component.html("<option value='' selected>" + messageComponentInCaseError + "</option>");
            alert(messageError);
        }
    });
}

function validateValue(id) {
    return !(id.trim() === "" || id == 0);
}

function populateMarksByCategory(data) {
    var listMarcas = "<option value='' selected>Selecione a marca</option> ";
    for (var i = 0; i < data.length; i++)
        listMarcas += "<option value='" + data[i].MarcaId + "'>" + data[i].Descricao + "</option>";
    return listMarcas;
}

function populateCars(data) {
    var listCars = "<option value='' selected>Selecione um veículo</option>";
    for (var i = 0; i < data.length; i++)
        listCars += "<option value='" + data[i].VeiculoId + "'>" + data[i].Veiculo + " </option>";
    return listCars;
}

function populateCarsModels(data) {
    var listCarsModels = "<option value='' selected>Selecione um modelo/ano</option>";
    for (var i = 0; i < data.length; i++)
        listCarsModels += "<option value='" + data[i].AnoModeloCarroId + "'>" + data[i].Ano + "</option>";
    return listCarsModels;
}

// Click - AddCar and Function's Helper's
$("#btnAddCar").click(function () {
    if (!validateCarSelected())
        showMessageNotification("Os campos MONTADORA, CARRO e MODELO devem estar selecionados", 5000, $("#notificationAddCar"));
    else {
        var montadora = $("#ddlMontadoras option:selected").text();
        var carro = $("#ddlCarros option:selected").text();
        var modeloText = $("#ddlModelos option:selected").text();
        var modeloValue = $("#ddlModelos").val();

        if (validateHasCar(modeloValue)) {
            showMessageNotification("O carro " + carro + " de " + modeloText + " já está selecionado", 5000, $("#notificationAddCar"));
            return;
        }

        setValue(modeloValue);

        var rowTable = "<tr id='car" + modeloValue + "'>" +
                            "<td class='text-center'>" +
                                "<span class='btn btn-sm btn-danger' onclick='removeCar(" + modeloValue + ")'><i class='glyphicon glyphicon-remove'></i> Remover</span>" +
                            "</td>" +
                            "<td>" + montadora + "</td>" +
                            "<td>" + carro + "</td>" +
                            "<td>" + modeloText + "</td>" +
                        "</tr>";

        $("#tblCars tbody").animate({ opacity: 100 }, 0, function () {
            $(rowTable).appendTo("#tblCars tbody");
        });
        showMessageNotification(carro + " de " + modeloText + "  foi adicionado à listagem", 6000, $("#notificationAddCar"));
    }
});

// Vetor com os ID's dos carros vinculados ao produto sendo registrado
var IdsCarsModelsSelected = [];
// Limpando carros selecionados
$("#hdnCarrosModelosAdded").val(null);

function validateHasCar(modeloValue) {
    for (var i = 0; i < IdsCarsModelsSelected.length; i++) {
        if (IdsCarsModelsSelected[i] === modeloValue) return true;
    }
    return false;
}

function validateCarSelected() {
    var ddlMontadora = $("#ddlMontadoras").val();
    var ddlCarro = $("#ddlCarros").val();
    var ddlModelo = $("#ddlModelos").val();
    return !(ddlModelo === "" || ddlModelo == null ||
             ddlCarro === "" || ddlCarro == null ||
             ddlMontadora === "" || ddlMontadora == null);
}

function showMessageNotification(message, time, component) {
    component.text(message);
    component.removeClass("hidden");
    setTimeout(function () {
        component.addClass("hidden");
    }, time);
}

function setValue(modeloValue) {
    IdsCarsModelsSelected[IdsCarsModelsSelected.length] = modeloValue;
    var hdnArrayValues = $("#hdnCarrosModelosAdded");
    hdnArrayValues.val(IdsCarsModelsSelected);
}

function removeCar(id) {
    var rowTable = "#car" + id;
    for (var i = 0; i < IdsCarsModelsSelected.length; i++) {
        if (IdsCarsModelsSelected[i] == id) {
            IdsCarsModelsSelected.splice(i, 1);
            $(rowTable).animate({ opacity: 0.0 }, 400, function () {
                $(rowTable).remove();
            });
            break;
        }
    }
    showMessageNotification("O carro foi removido com sucesso", 4000, $("#notificationAddCar"));
}

//Click refresh table - list cars
$("#btnCleanCars").click(function () {
    IdsCarsModelsSelected = [];
    $("#hdnCarrosModelosAdded").val(IdsCarsModelsSelected);
    $("#tblCars tbody").animate({ opacity: 0.0 }, 500, function () {
        $("#tblCars tbody").html("");
    });
    showMessageNotification("A listagem foi redefinida com sucesso", 4000, $("#notificationAddCar"));
});

//[-- GALERIA DE IMAGENS --]
$("#btnAddPhoto").click(function () {
    $("#fileUpload").click();
});
//Click refresh table - list photos
$("#fileUpload").change(function () {
    //Get count of selected files
    var countFiles = $(this)[0].files.length;

    var imgPath = $(this)[0].value;
    var extn = imgPath.substring(imgPath.lastIndexOf('.') + 1).toLowerCase();
    var image_holder = $("#image-holder");
    image_holder.empty();

    if (extn == "gif" || extn == "png" || extn == "jpg" || extn == "jpeg") {
        if (typeof (FileReader) != "undefined") {
            for (var i = 0; i < countFiles; i++) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $("<img />", {
                        "src": e.target.result,
                        "class": "thumb-image"
                    }).appendTo(image_holder);
                }
                image_holder.show();
                reader.readAsDataURL($(this)[0].files[i]);
            }
            $("#hdnSelectedPhotos").val("true"); // Há fotos selecionadas!
        }
        else showMessageNotification("Este navegador não tem suporte para carregar o arquivo", 5000, $("#notificationAddPhotos"));
    }
    else showMessageNotification("Selecione apenas imagens", 5000, $("#notificationAddPhotos"));
});

/* Caso ocorrer algum erro na tentativa de registrar e volte do backend para a View CREATE...
.. Limpa validador para verificar se há fotos selecionadas */
$("#hdnSelectedPhotos").val(null);