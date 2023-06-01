var student = {
    getStudents: () => {
        $.ajax({
            method: "GET",
            url: "../Student/GetAllDetails/",
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    var rows = "";

                    for (i = 0; i < data.detail.entities.length; i++) {
                        rows = rows.concat(`
                        <tr>
                            <td>
                                ${data.detail.entities[i].name}
                            </td>
                            <td>
                                ${data.detail.entities[i].birthDate.slice(0, 10)}
                            </td>
                            <td>
                                ${data.detail.entities[i].sexName}
                            </td> 
                            <td>
                                ${data.detail.entities[i].groupName}
                            </td>  
                            <td>
					                <a href="javascript:void(0)" onclick="student.editModal(${data.detail.entities[i].id});"><i class="fa-solid icon fa-pen-to-square"></i></a> |
                                    <a href="javascript:void(0)" onclick="student.deleteModal(${data.detail.entities[i].id});"><i class="fa-regular icon fa-trash-can"></i></a>
				            </td>
                        </tr>
                        `)
                        $("#students").html(rows);
                    }
                } else {
                    alert(data.detail.error);
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    }
}