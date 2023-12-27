

$(document).ready(function () {
    $('#invoicesTable').dataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/invoice/getInvoices",
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
                "data": null,
                "name": "k",
                "render": function (data, type, row, meta) {
                    return meta.row + 1;
                },
                "autowidth": true,
                "title": "k", "orderable": false
            },
           
            {
                
                "data": "totalInvoice", "name": "totalInvoice", "autowidth": true, "type": "numeric"
                ,"orderable": true
            },
            {
                "data": "totalBill", "name": "totalBill", "autowidth": true
                , "orderable": false
            },
            {
                "data": "amountConsumption", "name": "amountConsumption", "autowidth": true
                , "orderable": false
            }, {
                "data": "currentConsumptionAmount", "name": "currentConsumptionAmount", "autowidth": true
                , "orderable": false
            },
            {
                "data": "previousConsumptionAmount", "name": "previousConsumptionAmount", "autowidth": true
                , "orderable": false
            },
            
            {
                "render": function (data, type, row) { return '<span>' + row.date.split('T')[0] + '</span>' },
                "name": "date"
            },
            {
                "data": "subscriberName", "name": "subscriberName", "autowidth": true
                , "orderable": false
            },
            {
                "data": "subscriberId", "name": "subscriberId", "autowidth": true
                , "orderable": false
            },
            {
                "data": "subscriptionId", "name": "subscriptionId", "autowidth": true
                , "orderable": false
            },
            {
                "data": "id", "name": "id", "autowidth": true
                , "orderable": false
            },
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
