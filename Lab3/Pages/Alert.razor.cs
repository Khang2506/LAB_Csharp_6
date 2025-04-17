using Lab3.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Lab3.Pages
{
    public partial class Alert
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        private IJSObjectReference _Jsmodule { get; set; }
        private string registerResult;
        private string returnobject;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _Jsmodule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "/js/custom.js");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi import JS: {ex.Message}");
            }
        }

        public async Task ShowAlertInWindows() => await _Jsmodule.InvokeVoidAsync("ShowAlert", new { Name = "Kien", Age = 18});
        public async Task RegisterEmail() => registerResult = await _Jsmodule.InvokeAsync<string>("emailRegister");
        public async Task ReturnObjectAlert()
        {
            try
            {
                var result = await _Jsmodule.InvokeAsync<Users>("ReturnObject");
                if (result != null)
                {
                    returnobject = $"Name: {result.Name}, Age: {result.Age}";
                }
                else
                {
                    returnobject = "Không nhận được dữ liệu!";
                }
            }
            catch (Exception ex)
            {
                returnobject = $"Lỗi: {ex.Message}";
            }
        }

        //public async Task ShowAlertInWindows() => await JSRuntime.InvokeVoidAsync("ShowAlert", new { Name = "Kien", Age = 18});

        //JS gọi phương thức C#
        [JSInvokable] // Attribute khai báo để JS gọi phương thức c#
        public static string FillNumber(int number)
        {
            var result = Math.Sqrt(number);

            return $"Căn bậc 2 của {number} là: {result}";
        }
        private async Task CallJavaScriptFunction()
        {
            await JSRuntime.InvokeVoidAsync("jsFunctions.caculateSquareRoot");
        }
    }
}
