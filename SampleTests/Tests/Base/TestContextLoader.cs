using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTests.Tests.Base
{
    /// <summary>
 /// Wraps <see cref="TestContext"/> abstract class to provide utility methods.
 /// </summary>
    public class TestContextLoader
    {
        private readonly TestContext _testContext;

        public TestContextLoader(TestContext testContext)
        {
            _testContext = testContext;
        }

        /// <summary>
        /// Gets property from TestContext, returning the provided default value if that value is null or empty.
        /// </summary>
        /// <param name="propertyName">Name of property to retrieve.</param>
        /// <param name="defaultValue">Default value to return.</param>
        /// <returns></returns>
        public T GetProperty<T>(string propertyName, T defaultValue) where T : IConvertible
        {
            if (_testContext.Properties.Contains(propertyName) && _testContext.Properties[propertyName] != null)
            {
                return (T)Convert.ChangeType(_testContext.Properties[propertyName], typeof(T));
            }

            Trace.TraceWarning($"The Test Context did not contain a setting for {propertyName}.  Falling back to default value {defaultValue}.");
            return defaultValue;
        }
    }
}