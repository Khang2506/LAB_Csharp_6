var jsFunctions = {};

jsFunctions.caculateSquareRoot = function () {
    const number = prompt("Enter your number!");

    DotNet.invokeMethodAsync("Lab3", "FillNumber", parseInt(number))
        .then(result => {
            var el = document.getElementById("string-result");
            el.innerHTML = result;
        })
}