using Eleon.Modding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace DarkCity.Tokenizers
{
    /// <summary>
    /// Abstract class used to tokenize data structures into a token dictionary of strings. These tokens are used to convert a 
    /// </summary>
    public abstract class Tokenizer
    {
        /// <summary>
        /// A dictionary of data that has been processed into tokens. They keys represent tags in a string that will be replaced with the value.
        /// </summary>
        protected Dictionary<string, string> tokens = new Dictionary<string, string>();

        /// <summary>
        /// Updates tokens with the latest data from the data source. The data source must be provided by an inheriting class.
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Processes a string for tokens and replaces them with the token value. Token names must be enclosed in curly braces.
        /// </summary>
        /// <param name="format">The string containing tokens to be replaced.</param>
        /// <returns>A string with the tokens replaced.</returns>
        public virtual string Tokenize(string format)
        {
            if (string.IsNullOrEmpty(format)) return format;

            string result = format;
            foreach (KeyValuePair<string, string> token in this.tokens)
            {
                result = result.Replace('{' + token.Key + '}', token.Value);
            }

            return result;
        }

        /// <summary>
        /// Tokenizes a Vector3. The floating point values use the F0 format.
        /// </summary>
        /// <param name="vector">The Vector3 instance to tokenize.</param>
        /// <param name="prefix">Prefix for token names. If the prefix is "Position" then the tokens "Position", "PositionX", "PositionY", and "PositionZ" will be created.</param>
        protected void TokenizeVector3(Vector3 vector, string prefix)
        {
            this.tokens[prefix] = $"X:{vector.x:F0} Y:{vector.y:F0} Z:{vector.z:F0}";
            this.tokens[prefix + 'X'] = vector.x.ToString("F0");
            this.tokens[prefix + 'Y'] = vector.y.ToString("F0");
            this.tokens[prefix + 'Z'] = vector.z.ToString("F0");
        }

        /// <summary>
        /// Tokenizes a VectorInt3.
        /// </summary>
        /// <param name="vector">The VectorInt3 instance to tokenize.</param>
        /// <param name="prefix">Prefix for token names. If the prefix is "Position" then the tokens "Position", "PositionX", "PositionY", and "PositionZ" will be created.</param>
        protected void TokenizeVectorInt3(VectorInt3 vector, string prefix)
        {
            this.tokens[prefix] = $"X:{vector.x} Y:{vector.y} Z:{vector.z}";
            this.tokens[prefix + 'X'] = vector.x.ToString();
            this.tokens[prefix + 'Y'] = vector.y.ToString();
            this.tokens[prefix + 'Z'] = vector.z.ToString();
        }

        /// <summary>
        /// Tokenizes a Quaternion, which is normally used to express a 3D rotation. The tokens created will use Euler Angles that represent Pitch (P), Yaw (Y), and Roll (R).
        /// </summary>
        /// <param name="quat">The Quaternion to be tokenized.</param>
        /// <param name="prefix">Prefix for token names. If the prefix is "Heading" then the tokens "Heading", "HeadingP", "HeadingY", and "HeadingR" are created.</param>
        protected void TokenizeQuaternion(Quaternion quat, string prefix)
        {
            Vector3 angles = quat.eulerAngles;
            this.tokens[prefix] = $"P:{angles.x:F0} Y:{angles.y:F0} R:{angles.z:F0}";
            this.tokens[prefix + 'P'] = angles.x.ToString("F0");
            this.tokens[prefix + 'Y'] = angles.y.ToString("F0");
            this.tokens[prefix + 'R'] = angles.z.ToString("F0");
        }

        /// <summary>
        /// Tokenizes the data provided by a BinaryReader. The BitConverter is used to translate the binary data into a string representation.
        /// </summary>
        /// <param name="reader">The BinaryReader to tokenize. All data is read from the stream using ReadBytes until no more bytes are available.</param>
        /// <param name="key">The key name of the token.</param>
        protected void TokenizeBinaryReader(BinaryReader reader, string key)
        {
            StringBuilder result = new StringBuilder();
            byte[] data = null;

            do {
                data = reader.ReadBytes(32);
                result.Append(BitConverter.ToString(data));
            } while (data.Length == 32);

            this.tokens[key] = result.ToString();
        }
    }
}
