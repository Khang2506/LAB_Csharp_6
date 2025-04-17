function getDateTime() {
    return new Date();
}

export function ShowAlert(obj) {
    const message = "Name is: " + obj.name + "Age: " + obj.age;
    alert(message);
}
/*function ShowAlert(obj) {
    const message = "Name is: " + obj.name + "Age: " + obj.age;
    alert(message);
}*/

export function emailRegister(message) {
    const result = prompt(message);

    if (result === "" || result == null) {
        return "Vui lòng nhập email!";
    }

    const returnmessage = "Hi" + result.split("@")[0] + "Your email: " + result + "Has been accepted."
    return returnmessage;
}

export function ReturnObject() {
    const Name = prompt("Enter your Name");
    const Age = prompt("Enter your Age");
    // Kiểm tra nếu Age không phải số, trả về null để tránh lỗi
    const ageNumber = parseInt(Age);
    return {
        'Name': Name,
        'Age': ageNumber
    }
}

/*var jsFunctions = {};

jsFunctions.caculateSquareRoot = function () {
    const number = prompt("Enter your number!");

    DotNet.invokeMethodAsync("BlazorWasmJSInteropExamples", "FillNumber", parseInt(number))
        .then(result => {
            var el = document.getElementById("string-result");
            el.innerHTML = result;
        })
}
*/