
// Set the generated random number as the value of subscription id after the page has loaded
document.addEventListener("DOMContentLoaded", function () {
    var invoiceId = generateRandomNumber();
    document.getElementById('Id').value = invoiceId;
    document.getElementById('invoiceId').value = invoiceId;
});

function generateRandomNumber() {
    var firstPart = 2023;
    var secondPart = Math.floor(Math.random() * 10) + 1;
    var thirdPart = Math.floor(Math.random() * 100) + 1;
    return `${firstPart}-${secondPart}-${thirdPart}`;
}

taxRateInput.addEventListener('blur', function () {

    calculateBill()
});

serviceFeeInput.addEventListener('blur', function () {

    calculateBill()
});

function calculateBill() {
    var url = `/invoice/getTheInvoceTotal`;


    if (taxRateInput.value.trim() != '' && serviceFeeInput.value.trim() != '') {

        var data = {
            SubscriptionNo: document.getElementById("SubscriptionId").value,
            CurrentReadingMeter: parseFloat(document.getElementById("CurrentConsumptionAmount").value),
            ServiceFee: parseFloat(document.getElementById("ServiceFee").value),
            TaxValue: parseFloat(document.getElementById("TaxRate").value)
        };

        console.log("this is ")
        console.log(data)
        $.ajax({
            method: 'POST',
            url: url,
            contentType: 'application/json',
            data: JSON.stringify(data)
            ,
            success: function (response) {
                if (response != null) {
                    console.log(response)
                    setTotalBillPramaters(response)
                }

            }
        })
    }

}
function setTotalBillPramaters(response)
{
    console.log(response)
    var consumptionValueinput = document.getElementById("ConsumptionValue")
    var wastewaterConsumptionValue = document.getElementById("WastewaterConsumptionValue")
    var totalInvoice = document.getElementById("TotalInvoice")
    var totalBill = document.getElementById("TotalBill")
    var taxValue = document.getElementById("TaxValue")

    var consumptionValueinputPublic = document.getElementById("ConsumptionValuePublic")
    var wastewaterConsumptionValuePublic = document.getElementById("WastewaterConsumptionValuePublic")
    var totalInvoicePublic = document.getElementById("TotalInvoicePublic")
    var totalBillPublic = document.getElementById("TotalBillPublic")

    consumptionValueinput.value = response.invoiceConsumptionValue
    wastewaterConsumptionValue.value = response.invoiceWastewaterConsumptionValue
    totalInvoice.value = response.totalInvoice
    totalBill.value = response.invoicesTotalBill
    taxValue.value = response.taxValue
    consumptionValueinputPublic.value = response.invoiceConsumptionValue
    wastewaterConsumptionValuePublic.value = response.invoiceWastewaterConsumptionValue
    totalInvoicePublic.value = response.totalInvoice
    totalBillPublic.value = response.invoicesTotalBill
}

var currentConsumptionAmountinput = document.getElementById('CurrentConsumptionAmount');
var amountConsumption = document.getElementById('AmountConsumption');
var previousConsumptionAmount = document.getElementById('PreviousConsumptionAmount');

var currentConsumptionAmountinputPublic = document.getElementById('CurrentConsumptionAmountPublic');
var amountConsumptionPublic = document.getElementById('AmountConsumptionPublic');
var previousConsumptionAmountPublic = document.getElementById('PreviousConsumptionAmountPublic');

currentConsumptionAmountinputPublic.addEventListener('blur', function () {
    console.log(currentConsumptionAmountinputPublic.value)
    currentConsumptionAmountinput.value = currentConsumptionAmountinputPublic.value
    amountConsumption.value = currentConsumptionAmountinputPublic.value - previousConsumptionAmountPublic.value;
    amountConsumptionPublic.value = currentConsumptionAmountinputPublic.value - previousConsumptionAmountPublic.value;

});

var fromDate = document.getElementById('From');
var toDate = document.getElementById('To');
var year = document.getElementById('Year');

var fromDatePublic = document.getElementById('FromPublic');
var toDatePublic = document.getElementById('ToPublic');

var currentYear = ((new Date().getFullYear()) % 100).toString();
year.value = currentYear;

fromDate.addEventListener('blur', function () {

    
    

    var startDate = new Date(fromDate.value);
  
    const resultDate = new Date(startDate.getFullYear(), startDate.getMonth() + 1, startDate.getDate());
    
    
    toDate.value = resultDate.toISOString().split('T')[0];
    toDatePublic.value = resultDate.toISOString().split('T')[0];
    fromDatePublic.value = fromDate.value

});


var taxRate = document.getElementById('TaxRate');
var serviceFee = document.getElementById('ServiceFee');

taxRate.addEventListener('blur', calculateBill());
serviceFee.addEventListener('blur', calculateBill());





