
    function checkInputLength() {
        var inputElement = document.getElementById("Id");
    var inputValue = inputElement.value;

    if (inputValue.length === 10) {
        // if the id is 10 char
        console.log(inputValue)
            getSubscriberById(inputValue);
        }
    }
    function getSubscriberById(id) {

        var url = `/Subscriber/GetSubscriberById?id=${id}`;

    $.ajax({
        method: 'GET',
    url: url,
    success: function (response) {
                if (response  !=null)
    {
        console.log(response)
                    setSubscriberData(response)
                    
                }

            }
        })

    }

    function setSubscriberData(subscriber)
    {
        var name = document.getElementById("Name");
    var city = document.getElementById("City");
    var area = document.getElementById("Area");
    var mobile = document.getElementById("Mobile");

    name.value = subscriber.name
    city.value = subscriber.city
    area.value = subscriber.area
    mobile.value = subscriber.mobile


    }
