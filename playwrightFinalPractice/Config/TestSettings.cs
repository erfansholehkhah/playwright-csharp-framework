using System;
using System.Collections.Generic;
using System.Text;

namespace playwrightFinalPractice.Config
{
    public class TestSettings
    {
        public string[] Args { get; set; }
        public float TimeOut { get; set; }
        public bool Headless { get; set; }
         public string? ApplicationApiUrl { get; set; }
        public int SlowMo { get; set; }

        public DriverType DriverType  { get; set; }



    }


    public enum DriverType 
    {
        Chromium,
        Firefox,
        Edge,
        Chrome,
        Webkit
    }
}
