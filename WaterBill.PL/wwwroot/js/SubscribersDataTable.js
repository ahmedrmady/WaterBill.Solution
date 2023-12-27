

$(document).ready(function () {
    $('#subscribersTable').dataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/subscriber/getSubscribers",
            "type": "GET",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }],
        "columns": [
           
            { "data": "reasons", "name": "reasons", "autowidth": true },
            { "data": "numberOfSubscriptions", "name": "numberOfSubscriptions", "autowidth": true },
            { "data": "mobile", "name": "mobile", "autowidth": true },
            { "data": "area", "name": "area", "autowidth": true },
            { "data": "city", "name": "city", "autowidth": true },
            { "data": "name", "name": "name", "autowidth": true },
            { "data": "id", "name": "id", "autowidth": true }
                
             ,{
                 "data": "serial",
                "name": "serial",
                "render": function (data, type, row, meta) {
                    return meta.row + 1;
                },
                "autowidth": true, 
                 "title": "م", "orderable": false
            }

        ]
    });
    
});
