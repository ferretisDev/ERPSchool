$(document).ready(() => {
    town.getAll();
    town.getAllStates();
    town.valForm("#createForm");
    town.valForm("#editForm");
})

var town = {
    getAll: () => {
        $.ajax({
            method: "GET",
            url: "../Town/GetAllDetails/",
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    var rows = "";

                    for (i = 0; i < data.detail.towns.length; i++) {
                        rows = rows.concat(`
                        <tr>
                            <td>
                                ${data.detail.towns[i].name}
                            </td>                      
                            <td>
                                ${data.detail.towns[i].stateName}
                            </td>
                            <td>
                                <a href="javascript:void(0)" onclick="town.editModal(${data.detail.towns[i].id});"><i class="fa-solid icon fa-pen-to-square"></i></a> |
                                <a href="javascript:void(0)" onclick="town.deleteModal(${data.detail.towns[i].id});"><i class="fa-regular icon fa-trash-can"></i></a>
                            </td>
                        </tr>
                    `)
                        $("#getTowns").html(rows);
                    }
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    getAllStates: () => {
        $.ajax({
            method: "GET",
            url: "../State/GetAll/",
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    for (i = 0; i < data.detail.entities.length; i++) {
                        $("#createStateFk").append(`<option value="${data.detail.entities[i].id}">${data.detail.entities[i].name}</option>`);
                        $("#editStateFk").append(`<option value="${data.detail.entities[i].id}">${data.detail.entities[i].name}</option>`);
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
                }
            },
            messages: {
                name: {
                    required: `<i class="fa-solid fa-circle-xmark me-1"></i>¡Ingresa un Nombre!`,
                    minlength: jQuery.validator.format(`<i class="fa-solid fa-circle-xmark me-1"></i>¡El minimo de caracteres son {0}!`),
                    maxlength: jQuery.validator.format(`<i class="fa-solid fa-circle-xmark me-1"></i>¡El maximo de caracteres es {0}!`)
                },
                stateFk: {
                    required: `<i class="fa-solid fa-circle-xmark me-1"></i>¡Selecciona un Estado!`,
                }
            }
        })
    },
    createModal: () => {
        $("#createModal").modal("show");
    },
    save: () => {
        if ($("#createForm").valid()) {
            var name = $("#createName").val();
            var statesFk = $("#createStateFk").val();

            $.ajax({
                method: "POST",
                url: "../Town/Add/",
                type: "JSON",
                data: {
                    name: name,
                    statesFk: statesFk
                }
            })
                .done((data) => {
                    if (data.success == 1) {
                        alert(data.detail.message);
                        $("#createModal").modal("hide");
                        $("#createName").val("");
                        $("#createStateFk").val("");
                        town.getAll();
                    } else {
                        alert(data.detail.error);
                    }
                })
                .fail((jqHR, textStatus, errorThrow) => {
                    alert(errorThrow);
                })
        }
    },
    closeCreateModal: () => {
        $("#createModal").modal("hide");
        $("#createName, #createStateFk").val("");
        $("#createName-error, #createStateFk-error").remove();

    },
    editModal: (id) => {
        $.ajax({
            method: "GET",
            url: `../Town/GetById?id=${id}`,
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    $("#editId").val(data.detail.entity.id);
                    $("#editName").val(data.detail.entity.name);
                    $("#editStateFk").val(data.detail.entity.statesFk);
                    $("#editModal").modal("show");
                } else {
                    alert(data.detail.error);
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    update: () => {
        if ($("#editForm").valid()) {
            var id = $("#editId").val();
            var name = $("#editName").val();
            var statesFk = $("#editStateFk").val();

            $.ajax({
                method: "PATCH",
                url: "../Town/Update/",
                type: "JSON",
                data: {
                    id: id,
                    name: name,
                    statesFk: statesFk
                }
            })
                .done((data) => {
                    if (data.success == 1) {
                        $("#editModal").modal("hide");
                        town.getAll();
                        alert(data.detail.message);
                    } else {
                        alert(data.detail.error);
                    }
                })
                .fail((jqHR, textStatus, errorThrow) => {
                    alert(errorThrow);
                })
        }
    },
    closeEditModal: () => {
        $("#editModal").modal("hide");
    },
    deleteModal: (id) => {
        $.ajax({
            method: "GET",
            url: `../Town/GetDetailById?id=${id}`,
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    $("#deleteModal").modal("show");
                    $("#deleteId").val(data.detail.town.id);
                    $("#deleteName").val(data.detail.town.name);
                    $("#deleteStateFk").val(data.detail.town.stateName);
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
            url: "../Town/Delete/",
            type: "JSON",
            data: {
                id: id
            }
        })
            .done((data) => {
                if (data.success == 1) {
                    $("#deleteModal").modal("hide");
                    alert(data.detail.message);
                    town.getAll();
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
};