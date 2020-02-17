using System.Collections.Generic;
using PipBenchmark.Utilities.Data;

namespace PipBenchmark.Utilities.Config
{
    /// <summary>
    ///Contains a key-value map with configuration parameters.
    /// All values stored as strings and can be serialized as JSON or string forms.
    /// When retrieved the values can be automatically converted on read using GetAsXXX methods.
    /// 
    /// The keys are case-sensitive, so it is recommended to use consistent C-style as: <c>"my_param"</c>
    /// 
    /// Configuration parameters can be broken into sections and subsections using dot notation as:
    /// <c>"section1.subsection1.param1"</c>. Using GetSection method all parameters from specified section
    /// can be extracted from a ConfigMap.
    /// 
    /// The ConfigParams supports serialization from/to plain strings as:
    /// <c>"key1=123;key2=ABC;key3=2016-09-16T00:00:00.00Z"</c>
    /// ConfigParams are used to pass configurations to IConfigurable objects. 
    /// They also serve as a basis for more concrete configurations such as <a href="https://rawgit.com/pip-services3-dotnet/pip-services3-components-dotnet/master/doc/api/class_pip_services_1_1_components_1_1_connect_1_1_connection_params.html">ConnectionParams</a>
    /// or <a href="https://rawgit.com/pip-services3-dotnet/pip-services3-components-dotnet/master/doc/api/class_pip_services_1_1_components_1_1_auth_1_1_credential_params.html">CredentialParams</a>.
    /// </summary>
    /// <example>
    /// <code>
    /// var config = ConfigParams.fromTuples( "section1.key1", "AAA",
    /// "section1.key2", 123,
    /// "section2.key1", true );
    /// 
    /// config.GetAsString("section1.key1"); // Result: AAA
    /// config.GetAsInteger("section1.key1"); // Result: 0
    /// 
    /// var section1 = config.GetSection("section1");
    /// section1.ToString(); // Result: key1=AAA;key2=123
    /// </code>
    /// </example>
    /// See <see cref="IConfigurable"/>, <see cref="StringValueMap"/>
    public class ConfigParams : StringValueMap
    {
        /// <summary>
        /// Creates an instance of ConfigParams.
        /// </summary>
        public ConfigParams()
        { }

        /// <summary>
        /// Creates a new ConfigParams and fills it with values.
        /// </summary>
        /// <param name="content">(optional) an object to be converted into key-value pairs to initialize this config map.</param>
        /// See <see cref="StringValueMap"/>
        public ConfigParams(IDictionary<string, string> content)
            : base(content)
        { }

        /// <summary>
        /// Creates a new ConfigParams object filled with provided key-value pairs called tuples.
        /// Tuples parameters contain a sequence of key1, value1, key2, value2, ... pairs
        /// </summary>
        /// <param name="tuples">the tuples to fill a new ConfigParams object.</param>
        /// <returns>a new ConfigParams object.</returns>
        /// See <see cref="StringValueMap.FromTuples(object[])"/>
        public new static ConfigParams FromTuples(params object[] tuples)
        {
            var map = StringValueMap.FromTuples(tuples);
            return new ConfigParams(map);
        }

    }
}