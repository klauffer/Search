﻿using System.Diagnostics;
using Xunit;

namespace Rummage.Tests.TestHelpers
{
    // https://lostechies.com/jimmybogard/2013/06/20/run-tests-explicitly-in-xunit-net/
    public class RunnableInDebugOnlyAttribute : FactAttribute
    {
        public RunnableInDebugOnlyAttribute()
        {
            if (!Debugger.IsAttached)
            {
                Skip = "Only running in interactive mode.";
            }
        }
    }
}
