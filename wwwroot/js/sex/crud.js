$(document).ready(() => {
    sex.getAll();
    sex.valForm("#createForm");
    sex.valForm("#editForm");
})

var sex = {
    getAll: () => {
        $.ajax({
            method: "GET",
            url: "../Sex/GetAll/",
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
                                <a href="javascript:void(0)" onclick="sex.editModal(${data.detail.entities[i].id});"><i class="fa-solid icon fa-pen-to-square"></i></a> |
                                <a href="javascript:void(0)" onclick="sex.deleteModal(${data.detail.entities[i].id});"><i class="fa-regular icon fa-trash-can"></i></a>
                            </td>
                        </tr>
                    `);
                        $("#getSex").html(rows);
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
                    maxlength: 50,
                    minlength: 3
                }
            },
            messages: {
                name: {
                    required: `<i class="fa-solid fa-circle-xmark me-1"></i>¡Ingresa un Nombre!`,
                    maxlength: jQuery.validator.format(`<i class="fa-solid fa-circle-xmark me-1"></i>¡El máximo de caracteres es {0}!`),
                    minlength: jQuery.validator.format(`<i class="fa-solid fa-circle-xmark me-1"></i>¡El mínimo de caracteres son {0}!`)
                }
            }
        })
    },
    closeModal: () => {
        $("#createModal, #editModal").modal("hide");
        $("#createName").val("");
        $("#createName-error, #editName-error").empty();
    },
    createModal: () => {
        $("#createModal").modal("show");
    },
    save: () => {
        if ($("#createForm").valid()) {
            var name = $("#createName").val();

            $.ajax({
                method: "POST",
                url: "../sexs/add/",
                type: "JSON",
                data: {
                    name: name
                }
            })
                .done((data) => {
                    if (data.success == 1) {
                        $("#createModal").modal("hide");
                        $("#createName").val("");
                        sexs.getAllSexs();
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
            url: `../Sex/GetById?id=${id}`,
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
            var id = $("#editId").val();
            var name = $("#editName").val();

            $.ajax({
                method: "PATCH",
                url: "../Sex/Update/",
                type: "JSON",
                data: {
                    id: id,
                    name: name
                }
            })
                .done((data) => {
                    if (data.success == 1) {
                        alert(data.detail.message);
                        $("#editModal").modal("hide");
                        sex.getAll();
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
            url: `../Sex/GetById?id=${id}`,
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    $("#deleteId").val(data.detail.entity.id)
                    $("#deleteName").val(data.detail.entity.name)
                    $("#deleteModal").modal("show");
                }
                else {
                    alert(data.detail.message);
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
            url: "../Sex/Delete/",
            type: "JSON",
            data: { id: id }
        })
            .done((data) => {
                if (data.success == 1) {
                    alert(data.detail.message);
                    $("#deleteModal").modal("hide");
                    sexs.getAllSexs();
                } else {
                    alert(data.detail.error);
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    }
}