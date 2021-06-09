using JadeFramework.Core.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace JadeFramework.TestWeb.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }


    public class TestDI : ITestDI
    {
        public string Write()
        {
            return "12332131";
        }
    }
}
