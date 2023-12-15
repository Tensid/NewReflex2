using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Reflex.Pages
{
    public class IndexModel : PageModel
    {
        public string Version => FileVersionInfo.GetVersionInfo(GetType().Assembly.Location).ProductVersion;
    }
}
