using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PipBenchmark.Utilities.Data
{
    /// <summary>
    /// Cross-language implementation of a map (dictionary) where all keys and values are strings.
    /// The stored values can be converted to different types using variety of accessor methods.
    /// 
    /// The string map is highly versatile.It can be converted into many formats, stored and 
    /// sent over the wire.
    /// 
    /// This class is widely used in Pip.Services as a basis for variety of classes, such as 
    /// <a href="https://rawgit.com/pip-services3-dotnet/pip-services3-commons-dotnet/master/doc/api/class_pip_services_1_1_commons_1_1_config_1_1_config_params.html">ConfigParams</a>, 
    /// <a href="https://rawgit.com/pip-services3-dotnet/pip-services3-components-dotnet/master/doc/api/class_pip_services_1_1_components_1_1_connect_1_1_connection_params.html">ConnectionParams</a>, 
    /// <a href="https://rawgit.com/pip-services3-dotnet/pip-services3-components-dotnet/master/doc/api/class_pip_services_1_1_components_1_1_auth_1_1_credential_params.html">CredentialParams</a> and others.
    /// </summary>
    /// <example>
    /// <code>
    /// var value1 = StringValueMap.FromString("key1=1;key2=123.456;key3=2018-01-01");
    /// 
    /// value1.GetAsBoolean("key1");   // Result: true
    /// value1.GetAsInteger("key2");   // Result: 123
    /// value1.GetAsFloat("key2");     // Result: 123.456
    /// value1.GetAsDateTime("key3");  // Result: new Date(2018,0,1)
    /// </code>
    /// </example>
    /// See <see cref="StringConverter"/>, <see cref="BooleanConverter"/>, <see cref="IntegerConverter"/>, 
    /// <see cref="LongConverter"/>, <see cref="DoubleConverter"/>, <see cref="FloatConverter"/>, 
    /// <see cref="DateTimeConverter"/>, <see cref="ICloneable"/>
    public class StringValueMap : Dictionary<string, string>
    {
        /// <summary>
        /// Creates a new instance of the map and assigns its value.
        /// </summary>
        public StringValueMap()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }

        /// <summary>
        /// Creates a new instance of the map and assigns its value.
        /// </summary>
        /// <param name="map">(optional) values to initialize this map.</param>
        public StringValueMap(IDictionary<string, string> map)
            : base(StringComparer.OrdinalIgnoreCase)
        {
            Append(map);
        }

        /// <summary>
        /// Creates a new instance of the map and assigns its value.
        /// </summary>
        /// <param name="value">(optional) values to initialize this map.</param>
        public StringValueMap(object value)
            : base(StringComparer.OrdinalIgnoreCase)
        {
            Append(MapConverter.ToMap(value));
        }

        public new string this[string key]
        {
            get { return Get(key); }
            set { Set(key, value); }
        }

        /// <summary>
        /// Gets a map element specified by its key.
        /// </summary>
        /// <param name="key">a key of the element to get.</param>
        /// <returns>the value of the map element.</returns>
        public virtual string Get(string key)
        {
            string value = null;
            base.TryGetValue(key, out value);
            return value;
        }

        /// <summary>
        /// Sets a new value for this array element by its key
        /// </summary>
        /// <param name="key">a key of the element to set.</param>
        /// <param name="value">the new object value.</param>
        public virtual void Set(string key, string value)
        {
            base[key] = value;
        }

        /// <summary>
        /// Appends new elements to this map.
        /// </summary>
        /// <param name="map">a map with elements to be added.</param>
        public void Append(IDictionary<string, object> map)
        {
            if (map == null || map.Count == 0) return;

            foreach (var key in map.Keys)
                SetAsObject(key, StringConverter.ToNullableString(map[key]));
        }

        /// <summary>
        /// Appends new elements to this map.
        /// </summary>
        /// <param name="map">a map with elements to be added.</param>
        public void Append(IDictionary<string, string> map)
        {
            if (map == null || map.Count == 0) return;

            foreach (var key in map.Keys)
                SetAsObject(key, map[key]);
        }

        /// <summary>
        /// Sets a new value to map element specified by its index. When the index is not defined, 
        /// it resets the entire map value.This method has double purpose
        /// because method overrides are not supported in JavaScript.
        /// </summary>
        /// <param name="key">(optional) a key of the element to set</param>
        /// <param name="value">a new element or map value.</param>
        public void SetAsObject(string key, object value)
        {
            Set(key, StringConverter.ToNullableString(value));
        }

        /// <summary>
        /// Converts map element into a string or returns default value if conversion is not possible.
        /// </summary>
        /// <param name="key">a key of element to get.</param>
        /// <param name="defaultValue">the default value</param>
        /// <returns>string value of the element or default value if conversion is not supported.</returns>
        /// See <see cref="StringConverter.ToStringWithDefault(object, string)"/>
        public string GetAsStringWithDefault(string key, string defaultValue)
        {
            var value = Get(key);
            return StringConverter.ToStringWithDefault(value, defaultValue);
        }

        /// <summary>
        /// Gets a string representation of the object. The result is a
        /// semicolon-separated list of key-value pairs as "key1=value1;key2=value2;key=value3"
        /// </summary>
        /// <returns>a string representation of the object.</returns>
        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var key in Keys)
            {
                if (builder.Length > 0)
                    builder.Append(";");

                var value = this[key];
                if (value != null)
                    builder.Append(key + "=" + value);
                else
                    builder.Append(key);
            }
            return builder.ToString();
        }

        /// <summary>
        /// Creates a binary clone of this object.
        /// </summary>
        /// <returns>a clone of this object.</returns>
        public object Clone()
        {
            return new StringValueMap(this);
        }

        /// <summary>
        /// Converts specified value into StringValueMap.
        /// </summary>
        /// <param name="value">value to be converted</param>
        /// <returns>a newly created StringValueMap.</returns>
        public static StringValueMap FromValue(object value)
        {
            return new StringValueMap(value);
        }

        /// <summary>
        /// Creates a new StringValueMap from a list of key-value pairs called tuples.
        /// </summary>
        /// <param name="tuples">a list of values where odd elements are keys and the following
        /// even elements are values</param>
        /// <returns>a newly created StringValueArray.</returns>
        public static StringValueMap FromTuples(params object[] tuples)
        {
            var result = new StringValueMap();

            if (tuples == null || tuples.Length == 0)
                return result;

            for (var i = 0; i < tuples.Length; i += 2)
            {
                if (i + 1 >= tuples.Length) break;

                var name = StringConverter.ToString(tuples[i]);
                var value = StringConverter.ToString(tuples[i + 1]);

                result[name] = value;
            }

            return result;
        }

    }
}