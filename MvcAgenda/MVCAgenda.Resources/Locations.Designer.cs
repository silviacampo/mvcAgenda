﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcAgenda.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Locations {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Locations() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MvcAgenda.Resources.Locations", typeof(Locations).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Address.
        /// </summary>
        public static string locationAddress {
            get {
                return ResourceManager.GetString("locationAddress", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to City.
        /// </summary>
        public static string locationCity {
            get {
                return ResourceManager.GetString("locationCity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Max 20 char.
        /// </summary>
        public static string locationCityMaxLengthMsg {
            get {
                return ResourceManager.GetString("locationCityMaxLengthMsg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to City can&apos;t be empty.
        /// </summary>
        public static string locationCityRequiredMsg {
            get {
                return ResourceManager.GetString("locationCityRequiredMsg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Country.
        /// </summary>
        public static string locationCountry {
            get {
                return ResourceManager.GetString("locationCountry", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Max 20 char.
        /// </summary>
        public static string locationCountryMaxLengthMsg {
            get {
                return ResourceManager.GetString("locationCountryMaxLengthMsg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Country can&apos;t be empty.
        /// </summary>
        public static string locationCountryRequiredMsg {
            get {
                return ResourceManager.GetString("locationCountryRequiredMsg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Description.
        /// </summary>
        public static string locationDescription {
            get {
                return ResourceManager.GetString("locationDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Description can&apos;t be empty.
        /// </summary>
        public static string locationDescriptionRequiredMsg {
            get {
                return ResourceManager.GetString("locationDescriptionRequiredMsg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Postal Code.
        /// </summary>
        public static string locationPostalcode {
            get {
                return ResourceManager.GetString("locationPostalcode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Timezone.
        /// </summary>
        public static string locationTimezone {
            get {
                return ResourceManager.GetString("locationTimezone", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TimeZone can&apos;t be more than 12 or less than -12.
        /// </summary>
        public static string locationTimezoneRangeMsg {
            get {
                return ResourceManager.GetString("locationTimezoneRangeMsg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TimeZone can&apos;t be empty.
        /// </summary>
        public static string locationTimezoneRequiredMsg {
            get {
                return ResourceManager.GetString("locationTimezoneRequiredMsg", resourceCulture);
            }
        }
    }
}
