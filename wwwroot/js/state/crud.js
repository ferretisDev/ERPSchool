$(document).ready(() => {
    state.getAll();
    state.valForm("#createForm");
    state.valForm("#editForm");
})

var state = {
    getAll: () => {
        $.ajax({
            method: "GET",
            url: "../State/GetAll/",
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    var rows = "";

                    for (var i = 0; i < data.detail.entities.length; i++) {
                        rows = rows.concat(`
                        <tr>
                            <td>
                                ${data.detail.entities[i].name}
                            </td>
                            <td>
                                <a href="javascript:void(0)" onclick="state.editModal(${data.detail.entities[i].id});"><i class="fa-solid icon fa-pen-to-square"></i></a> |
                                <a href="javascript:void(0)" onclick="state.deleteModal(${data.detail.entities[i].id});"><i class="fa-regular icon fa-trash-can"></i></a>
                            </td>
                        </tr>
                    `);
                        $("#getStates").html(rows);
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
                    maxlength: 50
                }
            },
            messages: {
                name: {
                    required: `<i class="fa-solid fa-circle-xmark me-1"></i>¡Ingresa un Nombre!`,
                    minlength: jQuery.validator.format(`<i class="fa-solid fa-circle-xmark me-1"></i>¡El minimo de caracteres son {0}!`),
                    maxlength: jQuery.validator.format(`<i class="fa-solid fa-circle-xmark me-1"></i>¡El maximo de caracteres es {0}!`)
                }
            }
        })
    },
    closeModal: () => {
        $("#createModal").modal("hide");
        $("#createName").val("");
        $("#createName-error").remove();
    },
    createModal: () => {
        $("#createModal").modal("show");
    },
    save: () => {
        if ($("#createForm").valid()) {
            var name = $("#createName").val();

            $.ajax({
                method: "POST",
                url: "../State/Add",
                type: "JSON",
                data: {
                    name: name
                }
            })
                .done((data) => {
                    if (data.success == 1) {
                        alert(data.detail.message);
                        $("#createModal").modal("hide");
                        $("#createName").val("");
                        state.getAll();
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
            url: `../State/GetById?id=${id}`,
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    $("#editId").val(data.detail.entity.id);
                    $("#editName").val(data.detail.entity.name);
                    $("#editModal").modal('show');
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
            $("#editModal").modal("hide");

            var id = $("#editId").val();
            var name = $("#editName").val();

            $.ajax({
                method: "PATCH",
                url: "../State/Update/",
                type: "JSON",
                data: {
                    id: id,
                    name: name
                }
            })
                .done((data) => {
                    if (data.success == 1) {
                        alert(data.detail.message);
                        state.getAll();
                    }
                })
        }
    },
    deleteModal: (id) => {
        $("#deleteModal").modal('show');

        $.ajax({
            method: "GET",
            url: `../State/getById?id=${id}`,
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    $("#deleteId").val(data.detail.entity.id);
                    $("#deleteName").val(data.detail.entity.name);
                }
                else {
                    alert(data.detail.error);
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    delete: () => {
        $.ajax({
            method: "DELETE",
            url: "../State/Delete/",
            type: "JSON",
            data: {
                id: $("#deleteId").val(),
                name: $("#deleteName").val()
            }
        })
            .done((data) => {
                if (data.success == 1) {
                    $("#deleteModal").modal('hide');
                    alert(data.detail.message);
                    state.getAll();
                } else {
                    alert(data.detail.error);
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    }
}