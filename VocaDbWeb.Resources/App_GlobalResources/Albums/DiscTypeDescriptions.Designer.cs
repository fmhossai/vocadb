﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources
{
	using System;


	/// <summary>
	///   A strongly-typed resource class, for looking up localized strings, etc.
	/// </summary>
	// This class was auto-generated by the StronglyTypedResourceBuilder
	// class via a tool like ResGen or Visual Studio.
	// To add or remove a member, edit your .ResX file then rerun ResGen
	// with the /str option, or rebuild your VS project.
	[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
	[global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
	public class DiscTypeDescriptions
	{
		private static global::System.Resources.ResourceManager resourceMan;

		private static global::System.Globalization.CultureInfo resourceCulture;

		[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal DiscTypeDescriptions()
		{
		}

		/// <summary>
		///   Returns the cached ResourceManager instance used by this class.
		/// </summary>
		[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		public static global::System.Resources.ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(resourceMan, null))
				{
					global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("VocaDb.Web.App_GlobalResources.Albums.DiscTypeDescriptions", typeof(DiscTypeDescriptions).Assembly);
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
		public static global::System.Globalization.CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Album that consists mostly of previously unpublished songs..
		/// </summary>
		public static string Album
		{
			get
			{
				return ResourceManager.GetString("Album", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Collection of previously published songs, gathered from one or more earlier albums. For example, &quot;best of&quot; collections..
		/// </summary>
		public static string Compilation
		{
			get
			{
				return ResourceManager.GetString("Compilation", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Meaning extended play. Contains 3-4 individual tracks. Alternate versions (instrumentals and remixes) are usually not counted..
		/// </summary>
		public static string EP
		{
			get
			{
				return ResourceManager.GetString("EP", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to For albums that don&apos;t fit into anything above..
		/// </summary>
		public static string Other
		{
			get
			{
				return ResourceManager.GetString("Other", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Contains one or two individual tracks. Alternate versions (instrumentals and remixes) are usually not counted..
		/// </summary>
		public static string Single
		{
			get
			{
				return ResourceManager.GetString("Single", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Collaboration between two or more (but usually just two) equal artists, where all artists have roughly the same number of songs..
		/// </summary>
		public static string SplitAlbum
		{
			get
			{
				return ResourceManager.GetString("SplitAlbum", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Disc containing mostly music videos, usually a DVD or blu-ray..
		/// </summary>
		public static string Video
		{
			get
			{
				return ResourceManager.GetString("Video", resourceCulture);
			}
		}
	}
}
