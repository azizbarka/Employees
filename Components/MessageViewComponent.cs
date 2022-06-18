using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Components
{
    public class MessageViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(bool? isVisible, string content)
        {
            ViewBag.IsVisible = isVisible;
            ViewBag.Content = content;
            return View();
        }
    }
}
