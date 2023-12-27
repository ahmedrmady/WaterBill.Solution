
function checkInputLength() {
    var inputElement = document.getElementById("SubscriptionId");
    setSubscriptionToEmpty()
    var inputValue = inputElement.value;
    if (inputValue.length >= 6) {
        // if the id is 10 char
        console.log(inputValue)
        getSubscriptionById(inputValue);
    }



}
function getSubscriptionById(id) {


    var url = `/subscription/getSubscriptionById?id=${id}`;

    $.ajax({
        method: 'GET',
        url: url,
        success: function (response) {
            if (response != null) {
                console.log(response)
                setSubscriptionData(response)

            }

        }
    })

}

function setSubscriptionData(subscription) {

    console.log(subscription)
    var subscriberCode = document.getElementById("SubscriberId");
    var subscriberName = document.getElementById("SubscriberName");
    var previousConsumptionAmount = document.getElementById("PreviousConsumptionAmount");
    var isThereSanitation = document.getElementById("IsThereSanitation");
    var isThereSanitationInput = document.getElementById("isThereSanitationInput");
    var unitNo = document.getElementById("UnitNo");
    var rrealEstateTypeCode = document.getElementById("RrealEstateTypeCode");


    var subscriberCodePublic = document.getElementById("SubscriberIdPublic");
    var subscriberNamePublic = document.getElementById("SubscriberNamePublic");
    var previousConsumptionAmountPublic = document.getElementById("PreviousConsumptionAmountPublic");
    var isThereSanitationPublic = document.getElementById("IsThereSanitationPublic");
    var unitNoPublic = document.getElementById("UnitNoPublic");

    subscriberCode.value = subscription.subscriberCode
    subscriberName.value = subscription.subscriberName
    previousConsumptionAmount.value = subscription.lastReadingMeter
    isThereSanitation.value = subscription.isThereSanitation;
    isThereSanitationInput.value = subscription.isThereSanitation == true ? "نعم" : "لا";
    unitNo.value = subscription.unitNo

    rrealEstateTypeCode.value = subscription.rrealEstateTypesCode

    subscriberCodePublic.value = subscription.subscriberCode
    subscriberNamePublic.value = subscription.subscriberName
    previousConsumptionAmountPublic.value = subscription.lastReadingMeter
    unitNoPublic.value = subscription.unitNo



}
function setSubscriptionToEmpty() {

    var subscriberCode = document.getElementById("SubscriberId");
    var subscriberName = document.getElementById("SubscriberName");
    var previousConsumptionAmount = document.getElementById("PreviousConsumptionAmount");
    var isThereSanitation = document.getElementById("IsThereSanitation");
    var isThereSanitationInput = document.getElementById("isThereSanitationInput");
    var unitNo = document.getElementById("UnitNo");

    subscriberCode.value = ""
    subscriberName.value = ""
    previousConsumptionAmount.value = ""
    isThereSanitation.value = ""
    isThereSanitationInput.value = ""
    unitNo.value = ""

}
var taxRateInput = document.getElementById("TaxRate");
var serviceFeeInput = document.getElementById("ServiceFee");
