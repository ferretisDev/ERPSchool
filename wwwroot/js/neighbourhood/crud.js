$(document).ready(() => {
    neighbourhood.getAll();
    neighbourhood.getStates();
    neighbourhood.valForm("#createForm");
    neighbourhood.valForm("#editForm");
});

var neighbourhood = {
    valForm: (selector) => {
        $(selector).validate({
            rules: {
                name: {
                    required: true,
                    maxlength: 50
                },
                stateFk: {
                    required: true
                },
                townFk: {
                    required: true
                }
            },
            messages: {
                name: {
                    required: `<i class="fa-solid fa-circle-xmark me-1"></i>Ingresa un nombre!`,
                    maxlength: jQuery.validator.format(`<i class="fa-solid fa-circle-xmark me-1"></i>El maximo de caracteres es {0}!`)
                },
                stateFk: {
                    required: `<i class="fa-solid fa-circle-xmark me-1"></i>Selecciona un estado!`
                },
                townFk: {
                    required: `<i class="fa-solid fa-circle-xmark me-1"></i>Selecciona un municipio!`
                }
            }
        })
    },
    getStates: () => {
        $.ajax({
            method: "GET",
            url: "../State/getAll/",
            dataType: "JSON",
            data: {}
        })
            .done((data) => {
                for (var i = 0; i <= data.detail.entities.length - 1; i++) {
                    $("#createStateFk").append(`<option value="${data.detail.entities[i].id}">${data.detail.entities[i].name}</option>`);
                    $("#editStateFk").append(`<option value="${data.detail.entities[i].id}">${data.detail.entities[i].name}</option>`);
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    getTowns: (stateId, selector, townVal) => {
        $.ajax({
            method: "GET",
            url: `../Town/GetByStateId?stateid=${stateId}`,
            dataType: "json",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    for (var i = 0; i < data.detail.entities.length; i++) {
                        $(selector).append(`<option value="${data.detail.entities[i].id}">${data.detail.entities[i].name}</option>`);
                    }
                }

                $("#editTownFk").val(townVal);
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    getTownsForCreate: () => {
        $("#createTownFk").empty();

        if ($("#createStateFk").val() !== "") {
            $("#createTownFk").prop("disabled", false);
            $("#createTownFk").append(`<option value="">Seleccione un municipio...</option>`);
        } else {
            $("#createTownFk").prop("disabled", true);
        }

        neighbourhood.getTowns($("#createStateFk").val(), "#createTownFk");
    },
    getTownsForUpdate: () => {
        $("#editTownFk").empty();
        $("#editTownFk").append(`<option value="">Seleccione un municipio...</option>`);
        neighbourhood.getTowns($("#editStateFk").val(), "#editTownFk");
    },
    getAll: () => {
        $.ajax({
            method: "GET",
            url: "../Neighbourhood/GetAllDetails/",
            dataType: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    var rows = "";

                    for (var i = 0; i < data.detail.entities.length; i++) {
                        rows = rows.concat(`
			                <tr>
				                <td>${data.detail.entities[i].name}</td>
				                <td>${data.detail.entities[i].townName}</td>
				                <td>
					                <a href="javascript:void(0)" onclick="neighbourhood.editModal(${data.detail.entities[i].id});"><i class="fa-solid icon fa-pen-to-square"></i></a> |
                                    <a href="javascript:void(0)" onclick="neighbourhood.deleteModal(${data.detail.entities[i].id});"><i class="fa-regular icon fa-trash-can"></i></a>
				                </td>
			                </tr>
	                    `);
                        $("#neighbourhoods").html(rows);
                    }
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    createModal: () => {
        $("#createModal").modal("show");
        $("#createTownFk").prop("disabled", true);
    },
    closeCreateModal: () => {
        $("#createModal").modal("hide");
        $("#createName, #createStateFk").val("");
        $("#createTownFk, #editTownFk").empty();
        $("#createName-error, #createStateFk-error, #createTownFk-error").remove();
    },
    save: () => {
        var name = $("#createName").val();
        var townFk = $("#createTownFk").val();

        if ($("#createForm").valid()) {
            $.ajax({
                method: "POST",
                url: "../Neighbourhood/Add/",
                dataType: "json",
                data: {
                    name: name,
                    townFk: townFk
                }
            })
                .done((data) => {
                    if (data.success == 1) {
                        $("#createName, #createStateFk").val("");
                        $("#createTownFk").empty();
                        $("#createModal").modal("hide");

                        neighbourhood.getAll();
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
    editModal: (id) => {
        $.ajax({
            method: "GET",
            url: `../Neighbourhood/GetDetailById?id=${id}`,
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    $("#editId").val(data.detail.entity.id);
                    $("#editName").val(data.detail.entity.name);
                    $("#editStateFk").val(data.detail.entity.stateFk);
                    $("#editTownFk").val(data.detail.entity.townFk);

                    neighbourhood.getTowns(data.detail.entity.stateFk, "#editTownFk", data.detail.entity.townFk);

                    $("#editModal").modal("show");
                }
            })
    },
    closeEditModal: () => {
        $("#editModal").modal("hide");

        $("#editTownFk").empty();

        $("#editName-error").remove();
        $("#editStateFk-error").remove();
        $("#editTownFk-error").remove();
    },
    update: () => {
        if ($("#editForm").valid()) {
            var id = $("#editId").val();
            var name = $("#editName").val();
            var townFk = $("#editTownFk").val();

            $.ajax({
                method: "PATCH",
                url: "../Neighbourhood/Update/",
                type: "JSON",
                data: {
                    id: id,
                    name: name,
                    townFk: townFk
                }
            })
                .done((data) => {
                    if (data.success == 1) {
                        neighbourhood.getAll();
                        $("#editModal").modal("hide");
                        alert(data.detail.message);
                    }
                })
        }
    },
    deleteModal: (id) => {
        $.ajax({
            method: "GET",
            url: `../Neighbourhood/GetDetailById?id=${id}`,
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    $("#deleteId").val(data.detail.entity.id);
                    $("#deleteName").val(data.detail.entity.name);
                    $("#deleteTownFk").val(data.detail.entity.townName);

                    $("#deleteModal").modal("show");
                }
            })
    },
    closeDeleteModal: () => {
        $("#deleteModal").modal("hide");
    },
    delete: () => {
        var id = $("#deleteId").val();

        $.ajax({
            method: "DELETE",
            url: "../Neighbourhood/Delete/",
            type: "JSON",
            data: {
                id: id
            }
        })
            .done((data) => {
                if (data.success == 1) {
                    $("#deleteModal").modal('hide');
                    alert(data.detail.message);
                    neighbourhood.getAll();
                } else {
                    alert(data.detail.error);
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    }
}