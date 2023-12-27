

$(document).ready(function () {
    $('#subscriptionsTable').dataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/subscription/getAllSubscriptions",
            "type": "GET",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }],
        "columns": [
            {
                "data": "reasons", "name": "reasons", "autowidth": true
                , "orderable": false,
                "render": function (data) {
                    
                    return "Test Reason";
                }
            },
            {
                "data": "lastReadingMeter", "name": "lastReadingMeter", "autowidth": true
                ,"orderable": false
            },
            {
                "data": "unitNo", "name": "unitNo", "autowidth": true,
                "orderable": false
            },
            {
                "data": "isThereSanitation", "name": "isThereSanitation", "autowidth": true,
                "render": function (data) {

                    return data !== true ? "نعم" : "لا";
                }
            },
            { "data": "rrealEstateName", "name": "rrealEstateName", "autowidth": true },
            { "data": "mobile", "name": "mobile", "autowidth": true, "orderable": false },
            { "data": "subscriberName", "name": "subscriberName", "autowidth": true ,"orderable": false },
            { "data": "subscriberCode", "name": "subscriberCode", "autowidth": true ,"orderable": false },
            { "data": "id", "name": "id", "autowidth": true, "orderable": false },                      
            {
                "data": null,
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
