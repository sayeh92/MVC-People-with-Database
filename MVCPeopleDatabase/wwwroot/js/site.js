function ajaxListOfPoeple(actionUrl) {
    $.get(actionUrl, function (response) {
        document.getElementById("result").innerHTML = response;
    });
}


function ajaxpost(actionUrl, inputId) {
    let inputElement = $("#" + inputId);
    var data = {
        [inputElement.attr("name")]: inputElement.val()
        
    }
    $.post(actionUrl, data, function (response) { document.getElementById("result").innerHTML = response; })
}

function ajaxPostcity(actionUrl, inputCity) {
    let inputElement = $("#" + inputCity);
    let data = {
        [inputElement.attr("name")]: inputElement.val()
    }
    console.log("inputElement:", inputElement);
    console.log("data:", data);
    // post : url , data to post , what to do when we get the response back
    $.post(actionUrl + "?cityname=" + data.cityname, function (response) {
        console.log("Ajax response:", response);
        document.getElementById("result").innerHTML = response;
    });
}


