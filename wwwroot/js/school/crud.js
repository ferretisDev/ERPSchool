$(document).ready(() => {
    school.getAll();
    school.getStatesForCreate();
    school.getStatesForUpdate();
    school.valForm("#createForm");
    school.valForm("#editForm");
})

var school = {
    getAll: () => {
        $.ajax({
            method: "GET",
            url: "../School/GetAllDetails/",
            type: "JSON",
            data: {}
        })
            .done((data) => {
                //console.log(data);
                if (data.success == 1) {
                    var rows = "";

                    for (i = 0; i < data.detail.entities.length; i++) {
                        rows = rows.concat(`
                        <tr>
                            <td>
                                ${data.detail.entities[i].name}
                            </td>                      
                            <td>
                                ${data.detail.entities[i].streetName}
                            </td>                            
                            <td>
                                ${data.detail.entities[i].number}
                            </td>          
                            <td>
                                ${data.detail.entities[i].neighborhoodName}
                            </td>
                            <td>
                                <a href="javascript:void(0)" onclick="school.editModal(${data.detail.entities[i].id});"><i class="fa-solid icon fa-pen-to-square"></i></a> |
                                <a href="javascript:void(0)" onclick="school.deleteModal(${data.detail.entities[i].id});"><i class="fa-regular icon fa-trash-can"></i></a>
                            </td>
                        </tr>
                        `)

                        $("#schools").html(rows);
                    }
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    valForm: (selector) => {
        $(selector).validate({
            rules: {
                name: {
                    required: true,
                    minlength: 3,
                    maxlength: 20
                },
                stateFk: {
                    required: true
                },
                townFk: {
                    required: true
                },
                neighbourhoodFk: {
                    required: true
                },
                addressFk: {
                    required: true
                }
            },
            messages: {
                name: {
                    required: `<i class="fa-solid fa-circle-xmark me-1"></i>¡Ingresa un Nombre!`,
                    minlength: jQuery.validator.format(`<i class="fa-solid fa-circle-xmark me-1"></i>¡El mínimo de caracteres es {0}!`),
                    maxlength: jQuery.validator.format(`<i class="fa-solid fa-circle-xmark me-1"></i>¡El maximo de caracteres es {0}!`)
                },
                stateFk: {
                    required: `<i class="fa-solid fa-circle-xmark me-1"></i>¡Selecciona un Estado!`
                },
                townFk: {
                    required: `<i class="fa-solid fa-circle-xmark me-1"></i>¡Selecciona un Municipio!`
                },
                neighbourhoodFk: {
                    required: `<i class="fa-solid fa-circle-xmark me-1"></i>¡Selecciona una Colonia!`
                },
                addressFk: {
                    required: `<i class="fa-solid fa-circle-xmark me-1"></i>¡Selecciona una Calle!`
                }
            }
        });
    },
    createModal: () => {
        $("#createModal").modal("show");
        $("#createTownFk, #createNeighbourhoodFk, #createAddressFk").prop("disabled", true);
    },
    getStatesForCreate: () => {
        $.ajax({
            method: "GET",
            url: "../State/GetAll/",
            type: "JSON",
            data: {}
        })
            .done((data) => {
                //console.log(data);
                if (data.success == 1) {
                    $("#createStateFk").append('<option value="">--Seleccione--</option>');

                    var option = "";

                    for (i = 0; i < data.detail.entities.length; i++) {
                        option = option.concat(`
                         <option value="${data.detail.entities[i].id}">${data.detail.entities[i].name}</option>
                        `)
                    }

                    $("#createStateFk").append(option);
                } else {
                    alert(data.detail.error);
                }

            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    getTownsForCreate: () => {
        $("#createTownFk, #createNeighbourhoodFk, #createAddressFk").empty();
        $("#createNeighbourhoodFk, #createAddressFk").prop("disabled", true);

        if ($("#createStateFk").val() !== "") {
            $("#createTownFk").prop("disabled", false);
            $("#createTownFk").append(`<option value="">--Seleccione--</option>`);
            var stateId = $("#createStateFk").val();
        } else {
            $("#createTownFk").prop("disabled", true);
            $("#createTownFk").empty();
            $("#createNeighbourhoodFk").prop("disabled", true);
            $("#createNeighbourhoodFk").empty();
        }

        $.ajax({
            method: "GET",
            url: `../Town/GetByStateId?stateId=${stateId}`,
            type: "JSON",
            data: {}
        })
            .done((data) => {
                //console.log(data);
                var option = "";

                for (i = 0; i < data.detail.entities.length; i++) {
                    option = option.concat(`
                         <option value="${data.detail.entities[i].id}">${data.detail.entities[i].name}</option>
                        `)
                }

                $("#createTownFk").append(option);
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    getNeighborhoodsForCreate: () => {
        $("#createNeighbourhoodFk").empty();

        if ($("#createTownFk").val() !== "") {
            $("#createNeighbourhoodFk").prop("disabled", false);
            $("#createNeighbourhoodFk").append(`<option value="">--Seleccione--</option>`);
            var townId = $("#createTownFk").val();
        } else {
            $("#createNeighbourhoodFk, #createAddressFk").prop("disabled", true);
            $("#createNeighbourhoodFk, #createAddressFk").empty();
        }

        $.ajax({
            method: "GET",
            url: `../Neighbourhood/GetbyTownId?townId=${townId}`,
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    var option = "";

                    for (i = 0; i < data.detail.entities.length; i++) {
                        option = option.concat(`
                         <option value="${data.detail.entities[i].id}">${data.detail.entities[i].name}</option>
                        `)
                    }

                    $("#createNeighbourhoodFk").append(option);
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    save: () => {
        if ($("#createForm").valid()) {
            var name = $("#createName").val();
            var streetName = $("#createStreetName").val();
            var number = $("#createNumber").val();
            var neighborhoodFk = $("#createNeighbourhoodFk").val();

            $.ajax({
                method: "POST",
                url: "../School/Add/",
                type: "JSON",
                data: {
                    name: name,
                    streetName: streetName,
                    number: number,
                    neighborhoodFk: neighborhoodFk
                }
            })
                .done((data) => {
                    alert(data.detail.message);
                    $("#createModal").modal("hide");
                    school.getAll();
                    school.closeCreateModal();
                })
                .fail((jqHR, textStatus, errorThrow) => {
                    alert(errorThrow);
                })
        }
    },
    closeCreateModal: () => {
        $("#createModal").modal("hide");
        $("#createName, #createStreetName, #createNumber, #createStateFk").val("");
        $("#createTownFk, #createNeighbourhoodFk").empty();
        school.removeInputsError("create");
    },
    removeInputsError: (type) => {
        $(`#${type}Name-error, #${type}StateFk-error, #${type}TownFk-error, #${type}NeighbourhoodFk-error, #${type}AddressFk-error`).remove();
    },
    editModal: (id) => {
        $.ajax({
            method: "GET",
            url: `../School/GetDetailById?id=${id}`,
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    $("#editId").val(data.detail.entity.id);
                    $("#editName").val(data.detail.entity.name);
                    $("#editStreetName").val(data.detail.entity.streetName);
                    $("#editNumber").val(data.detail.entity.number);
                    $("#editStateFk").val(data.detail.entity.statesFk)
                    school.getTownsForUpdate(data.detail.entity.statesFk, data.detail.entity.townFk)
                    school.getNeighborhoodsForUpdate(data.detail.entity.townFk, data.detail.entity.neighborhoodFk)
                    $("#editModal").modal("show");
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    getStatesForUpdate: () => {
        $("#editStateFk").append(`<option value="">--Seleccione--</option>`);

        $.ajax({
            method: "GET",
            url: "../State/GetAll/",
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    var option = "";

                    for (i = 0; i < data.detail.entities.length; i++) {
                        option = option.concat(`
                         <option value="${data.detail.entities[i].id}">${data.detail.entities[i].name}</option>
                        `)
                    }

                    $("#editStateFk").append(option);
                } else {
                    alert(data.detail.error);
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    getTownsForUpdate: (stateId, value) => {
        $("#editTownFk, #editNeighbourhoodFk, #editAddressFk").empty();

        if ($("#editStateFk").val() !== "") {
            $("#editTownFk").append(`<option value="">--Seleccione--</option>`);
            $("#editTownFk").prop("disabled", false);
        } else {
            $("#editTownFk, #editNeighbourhoodFk").prop("disabled", true);
            $("#editTownFk, #editNeighbourhoodFk").empty();
        }

        if (stateId == null || stateId == undefined) {
            var stateId = $("#editStateFk").val();
        }

        $.ajax({
            method: "GET",
            url: `../Town/GetByStateId?stateId=${stateId}`,
            type: "JSON",
            data: {}
        })
            .done((data) => {
                var option = "";

                for (i = 0; i < data.detail.entities.length; i++) {
                    option = option.concat(`
                         <option value="${data.detail.entities[i].id}">${data.detail.entities[i].name}</option>
                        `)
                }
                $("#editTownFk").append(option);

                if (value != null && value != undefined) {
                    $("#editTownFk").val(value);
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    getNeighborhoodsForUpdate: (townId, value) => {
        $("#editNeighbourhoodFk").empty();

        if (townId == null || townId == undefined) {
            var townId = $("#editTownFk").val();
        }

        if (townId !== "") {
            $("#editNeighbourhoodFk").prop("disabled", false);
            $("#editNeighbourhoodFk").append(`<option value="">--Seleccione--</option>`);
        } else {
            $("#editNeighbourhoodFk").prop("disabled", true);
        }

        $.ajax({
            method: "GET",
            url: `../Neighbourhood/GetByTownId?townId=${townId}`,
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    var option = "";

                    for (i = 0; i < data.detail.entities.length; i++) {
                        option = option.concat(`
                         <option value="${data.detail.entities[i].id}">${data.detail.entities[i].name}</option>
                        `)
                    }
                    $("#editNeighbourhoodFk").append(option);

                    if (value != null && value != undefined) {
                        $("#editNeighbourhoodFk").val(value);
                    }
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    closeEditModal: () => {
        $("#editModal").modal("hide");
    },
    update: () => {
        if ($("#editForm").valid()) {
            var id = $("#editId").val();
            var name = $("#editName").val();
            var streetName = $("#editStreetName").val();
            var number = $("#editNumber").val();
            var neighborhoodFk = $("#editNeighbourhoodFk").val();

            $.ajax({
                method: "PATCH",
                url: "../School/Update/",
                type: "JSON",
                data: {
                    id: id,
                    name: name,
                    streetName: streetName,
                    number: number,
                    neighborhoodFk: neighborhoodFk
                }
            })
                .done((data) => {
                    if (data.success == 1) {
                        alert(data.detail.message);
                        $("#editModal").modal("hide");
                        school.getAll();
                    } else {
                        alert(data.detail.error);
                    }
                })
                .fail((jqHR, textStatus, errorThrow) => {
                    alert(errorThrow);
                })
        }
    },
    deleteModal: (id) => {
        $.ajax({
            method: "GET",
            url: `../School/GetById?id=${id}`,
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    $("#deleteId").val(data.detail.entity.id);
                    $("#deleteName").val(data.detail.entity.name);
                    $("#deleteModal").modal("show");
                } else {
                    alert(data.detail.error);
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    delete: () => {
        var id = $("#deleteId").val();

        $.ajax({
            method: "DELETE",
            url: "../School/Delete/",
            type: "JSON",
            data: { id: id }
        })
            .done((data) => {
                if (data.success == 1) {
                    $("#deleteModal").modal("hide");
                    alert(data.detail.message);
                    school.getAll();
                } else {
                    alert(data.detail.error);
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    closeDeleteModal: () => {
        $("#deleteModal").modal("hide");
    }
}