using EliteLogAgent.Settings;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DW.ELA.UnitTests.UI
{
    public class GeneralSettingsControlTests
    {
        [Test]
        public void ShouldCreateAndDestroySettingsForm()
        {
            using (new GeneralSettingsControl()) { };
        }
    }
}
