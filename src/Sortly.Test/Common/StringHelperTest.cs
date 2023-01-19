using Moq;
using NUnit.Framework;
using Sortly.Api.Common.Util;

namespace Sortly.Test.Common
{
    [TestFixture]
    public class StringHelperTest
    {
        /// <summary>
        /// Test that <see cref="StringHelpers.FormatQueryParameterAddition(string, string)"/> returns the appropriate value if
        /// the source string has a ? at the end of it
        /// </summary>
        public void FormatQueryParameterAddition_Question_Mark_At_End() 
        {
        
        }

        /// <summary>
        /// Test that <see cref="StringHelpers.FormatQueryParameterAddition(string, string)"/> returns the appropriate value if
        /// the source string does not have a ? at the end of it
        /// </summary>
        public void FormatQueryParameterAddition_No_Question_Mark_At_End()
        {

        }
    }
}
