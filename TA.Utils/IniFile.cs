using System;
using System.Runtime.InteropServices;
using System.IO;

namespace TA.Utils
{
    #region Class Documentation
    /// <summary>
    /// IniFile 0.2 - Represents an interface for writing and reading an INI file.
    /// </summary>
    /// <remarks>By Rob Loach (http://www.robloach.net)</remarks>
    /// <example>The following is a basic example of the IniFile's use:
    /// <code>
    /// // Create the INI file
    /// IniFile ini = new IniFile("window.ini");
    /// 
    /// // Set the values
    /// ini.Write("Window", "Title","The Title is here!");
    /// ini.Write("Window", "Height", 480);
    /// ini.Write("Window", "Fullscreen", false);
    /// ini.Write("Window", "Speed", 4823.423143);
    /// 
    /// // Get some values from the ini file
    /// int height = ini.GetInt("Window", "Height");
    /// int width = ini.Get("Window", "Width", 640); // get 640 by default
    /// bool fullscreen = ini.GetBoolean("Window", "Fullscreen");
    /// double speed = ini.GetDouble("Window", "Speed", 1.0);
    /// 
    /// // Using the indexer gets and sets strings:
    /// Console.WriteLine("Title: " + ini["Window", "Title"] );
    /// ini["Window", "Author"] = "Rob Loach";
    /// </code>
    /// </example>
    #endregion Class Documentation
    public class IniFile
    {
        #region Private Fields
        /// <summary>
        /// The private field for the filename of the INI file.
        /// </summary>
        private string m_File;
        #endregion Private Fields

        #region Constructors
        /// <summary>
        /// Creates or loads an INI file from the given file path.
        /// </summary>
        /// <param name="filename">The filepath of the INI file.</param>
        public IniFile(string filename)
        {
            if (!System.IO.File.Exists(filename))
                CreateFolder(Path.GetDirectoryName(filename));
            System.IO.FileInfo fileinfo = new System.IO.FileInfo(filename);
            m_File = fileinfo.FullName;
        }
        private void CreateFolder(string foldername) 
        {
            if (System.IO.Directory.Exists(foldername))
                return;
            string folder = Path.GetFileName(foldername);
            string parent_folder = Path.GetDirectoryName(foldername);
            if (!System.IO.Directory.Exists(parent_folder))
                CreateFolder(parent_folder);
            Directory.CreateDirectory(foldername);
        }
        /// <summary>
        /// Creates or loads an INI file from the provided FileInfo.
        /// </summary>
        /// <param name="file">The FileInfo of the desired INI file.</param>
        public IniFile(FileInfo file)
        {
            m_File = file.FullName;
        }
        /// <summary>
        /// Creates or loads an INI file named data.ini .
        /// </summary>
        public IniFile()
            : this("data.ini")
        {
        }
        #endregion Constructors

        #region Properties
        /// <summary>
        /// Gets and sets the file path that's associated with this INI file.
        /// </summary>
        public string File
        {
            get
            {
                return m_File;
            }
            set
            {
                m_File = value;
            }
        }

        #region Indexers
        /// <summary>
        /// Gets and sets the section/key value held within the current INI file as strings.
        /// </summary>
        public string this[string section, string key]
        {
            get
            {
                return GetString(section, key);
            }
            set
            {
                Write(section, key, value);
            }
        }
        /// <summary>
        /// Gets a value held within the INI file as a string.
        /// </summary>
        public string this[string section, string key, string defaultValue]
        {
            get
            {
                return Get(section, key, defaultValue);
            }
        }
        /// <summary>
        /// Gets a value held within the INI file as an integer.
        /// </summary>
        public int this[string section, string key, int defaultValue]
        {
            get
            {
                return Get(section, key, defaultValue);
            }
        }
        /// <summary>
        /// Gets a value held within the INI file as a double.
        /// </summary>
        public double this[string section, string key, double defaultValue]
        {
            get
            {
                return Get(section, key, defaultValue);
            }
        }
        /// <summary>
        /// Gets a value held within the INI file as a boolean.
        /// </summary>
        public bool this[string section, string key, bool defaultValue]
        {
            get
            {
                return Get(section, key, defaultValue);
            }
        }
        #endregion Indexers
        #endregion Properties

        #region Private DLL Imports
        [DllImport("kernel32", EntryPoint = "GetPrivateProfileStringA")]
        private static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, System.Text.StringBuilder lpReturnedString, int nSize, string lpFileName);

        [DllImport("kernel32", EntryPoint = "WritePrivateProfileStringA")]
        private static extern int WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);

        [DllImport("kernel32", EntryPoint = "GetPrivateProfileIntA")]
        private static extern int GetPrivateProfileInt(string lpApplicationName, string lpKeyName, int nDefault, string lpFileName);
        #endregion Private DLL Imports

        #region Get
        /// <summary>
        /// Gets a string from the INI file using the default value of "".
        /// </summary>
        /// <param name="section">The section of which the value is held.</param>
        /// <param name="key">The key of the value.</param>
        /// <returns>The value of the key underneth the section header.  If the value doesn't exist, "" is returned.</returns>
        public string Get(string section, string key)
        {
            return Get(section, key, "");
        }


        /// <summary>
        /// Gets a string value from the INI file.
        /// </summary>
        /// <param name="section">The section of which the value is held.</param>
        /// <param name="key">The key of the value.</param>
        /// <param name="defaultValue">The value to be returned if the key doesn't exist.</param>
        /// <returns>The value of the key underneth the section header.  If the value doesn't exist, the provided default value is returned.</returns>
        public string Get(string section, string key, string defaultValue)
        {
            //  Returns a string from your INI file
            System.Text.StringBuilder objResult = new System.Text.StringBuilder(1024);
            int charCount = GetPrivateProfileString(section, key, defaultValue, objResult, objResult.Capacity, m_File);
            if (charCount > 0)
                return objResult.ToString().Substring(0, charCount);
            else
                return defaultValue;
        }
        /// <summary>
        /// Gets an integer from the INI file.
        /// </summary>
        /// <param name="section">The section of which the value is held.</param>
        /// <param name="key">The key of the value.</param>
        /// <param name="defaultValue">The value to be returned if the key doesn't exist.</param>
        /// <returns>The value of the key underneth the section header.  If the value doesn't exist, the provided default value is returned.</returns>
        public int Get(string section, string key, int defaultValue)
        {
            return GetPrivateProfileInt(section, key, defaultValue, m_File);
        }
        /// <summary>
        /// Gets a boolean value from the INI file.
        /// </summary>
        /// <param name="section">The section of which the value is held.</param>
        /// <param name="key">The key of the value.</param>
        /// <param name="defaultValue">The value to be returned if the key doesn't exist.</param>
        /// <returns>The value of the key underneth the section header.  If the value doesn't exist, the provided default value is returned.</returns>
        public bool Get(string section, string key, bool defaultValue)
        {
            string val = Get(section, key, defaultValue.ToString()).ToLower().Trim();
            if (val == "1") return true;
            if (val == "0") return false;
            if (val == bool.FalseString.ToLower()) return false;
            if (val == bool.TrueString.ToLower()) return true;
            return defaultValue;
        }


        /// <summary>
        /// Gets a double value from the INI file.
        /// </summary>
        /// <param name="section">The section of which the value is held.</param>
        /// <param name="key">The key of the value.</param>
        /// <param name="defaultValue">If the value doesn't exist, this value is to be returned.</param>
        /// <returns>The value of the key underneth the section header.  If the value doesn't exist, the provided default value is returned.</returns>
        public double Get(string section, string key, double defaultValue)
        {
            double val;
            if (double.TryParse(Get(section, key, "Failed"), System.Globalization.NumberStyles.Number, System.Globalization.NumberFormatInfo.CurrentInfo, out val))
                return val;
            else
                return defaultValue;
        }
        /// <summary>
        /// Gets a string value from the INI file.
        /// </summary>
        /// <param name="section">The section of which the value is held.</param>
        /// <param name="key">The key of the value.</param>
        /// <returns>The value of the key underneth the section header.</returns>
        public string GetString(string section, string key)
        {
            return Get(section, key);
        }

        /// <summary>
        /// Gets a string value from the INI file.
        /// </summary>
        /// <param name="section">The section of which the value is held.</param>
        /// <param name="key">The key of the value.</param>
        /// <param name="defaultValue">The value to be returned if the key doesn't exist.</param>
        /// <returns>The value of the key underneth the section header.  If the value doesn't exist, the provided default value is returned.</returns>
        public string GetString(string section, string key, string defaultValue)
        {
            return Get(section, key, defaultValue);
        }

        /// <summary>
        /// Gets an integer value from the INI file using the default value of 0.
        /// </summary>
        /// <param name="section">The section of which the value is held.</param>
        /// <param name="key">The key of the value.</param>
        /// <returns>The value of the key underneth the section header.  If the value doesn't exist, 0 is returned.</returns>
        public int GetInt(string section, string key)
        {
            return Get(section, key, 0);
        }

        /// <summary>
        /// Gets an integer value from the INI file.
        /// </summary>
        /// <param name="section">The section of which the value is held.</param>
        /// <param name="key">The key of the value.</param>
        /// <param name="defaultValue">If the value doesn't exist, this value is to be returned.</param>
        /// <returns>The value of the key underneth the section header.  If the value doesn't exist, the provided default value is returned.</returns>
        public int GetInt(string section, string key, int defaultValue)
        {
            return Get(section, key, defaultValue);
        }

        /// <summary>
        /// Gets a double value from the INI file.
        /// </summary>
        /// <param name="section">The section of which the value is held.</param>
        /// <param name="key">The key of the value.</param>
        /// <param name="defaultValue">If the value doesn't exist, this value is to be returned.</param>
        /// <returns>The value of the key underneth the section header.  If the value doesn't exist, the provided default value is returned.</returns>
        public double GetDouble(string section, string key, double defaultValue)
        {
            return Get(section, key, defaultValue);
        }
        /// <summary>
        /// Gets a double value from the INI file.
        /// </summary>
        /// <param name="section">The section of which the value is held.</param>
        /// <param name="key">The key of the value.</param>
        /// <returns>The value of the key underneth the section header.  If the value doesn't exist, 0.0 is returned.</returns>
        public double GetDouble(string section, string key)
        {
            return Get(section, key, 0.0);
        }

        /// <summary>
        /// Gets a boolean from the INI file using the default value of false.
        /// </summary>
        /// <param name="section">The section of which the value is held.</param>
        /// <param name="key">The key of the value.</param>
        /// <returns>The value of the key underneth the section header.  If the value doesn't exist, false is returned.</returns>
        public bool GetBoolean(string section, string key)
        {
            return Get(section, key, false);
        }

        /// <summary>
        /// Gets an boolean value from the INI file.
        /// </summary>
        /// <param name="section">The section of which the value is held.</param>
        /// <param name="key">The key of the value.</param>
        /// <param name="defaultValue">If the value doesn't exist, this value is to be returned.</param>
        /// <returns>The value of the key underneth the section header.  If the value doesn't exist, the provided default value is returned.</returns>
        public bool GetBoolean(string section, string key, bool defaultValue)
        {
            return Get(section, key, defaultValue);
        }
        #endregion Get

        #region Write
        /// <summary>
        /// Writes a string to the INI file.
        /// </summary>
        /// <param name="section">The section to write under.</param>
        /// <param name="key">The key to write in.</param>
        /// <param name="val">The value to write to the key.</param>
        /// <returns>True if the value successfully written, false otherwise.</returns>
        public bool Write(string section, string key, string val)
        {
            return WritePrivateProfileString(section, key, val, m_File) != 0;
        }

        /// <summary>
        /// Writes an integer to the INI file.
        /// </summary>
        /// <param name="section">The section to write under.</param>
        /// <param name="key">The key to write in.</param>
        /// <param name="val">The value to write to the key.</param>
        /// <returns>True if the value successfully written, false otherwise.</returns>
        public bool Write(string section, string key, int val)
        {
            return Write(section, key, val.ToString());
        }

        /// <summary>
        /// Writes a boolean value to the INI file.
        /// </summary>
        /// <param name="section">The section to write under.</param>
        /// <param name="key">The key to write in.</param>
        /// <param name="val">The value to write to the key.</param>
        /// <returns>True if the value successfully written, false otherwise.</returns>
        public bool Write(string section, string key, bool val)
        {
            return Write(section, key, val ? "1" : "0");
        }

        /// <summary>
        /// Writes a double value to the INI file.
        /// </summary>
        /// <param name="section">The section to write under.</param>
        /// <param name="key">The key to write in.</param>
        /// <param name="val">The value to write to the key.</param>
        /// <returns>True if the value successfully written, false otherwise.</returns>
        public bool Write(string section, string key, double val)
        {
            return Write(section, key, val.ToString());
        }
        #endregion Write
    }
}
