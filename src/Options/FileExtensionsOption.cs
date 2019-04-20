﻿namespace DMS.CG.Options
{
	using DMS.CG.Classification;
	using Microsoft.VisualStudio.Text.Editor;
	using Microsoft.VisualStudio.Utilities;
	using System;
	using System.ComponentModel.Composition;

	[Export(typeof(EditorOptionDefinition))]
	public sealed class FileExtensionsOption : EditorOptionDefinition<string>
	{
		public readonly static EditorOptionKey<string> OptionKey = new EditorOptionKey<string>("CG highlighting file extensions");

		[ImportingConstructor]
		public FileExtensionsOption([Import] IContentTypeRegistryService contentTypeRegistry, [Import] IFileExtensionRegistryService fileExtensionRegistry)
		{
			var options = OptionsPagePackage.Options;
			RegisterFileExtensions(fileExtensionRegistry, options.AutoDetectShaderTypeFileExtensions, contentTypeRegistry.GetContentType(ContentTypesGlsl.GlslShader));
			RegisterFileExtensions(fileExtensionRegistry, options.FragmentShaderFileExtensions, contentTypeRegistry.GetContentType(ContentTypesGlsl.FragmentShader));
			RegisterFileExtensions(fileExtensionRegistry, options.VertexShaderFileExtensions, contentTypeRegistry.GetContentType(ContentTypesGlsl.VertexShader));
			RegisterFileExtensions(fileExtensionRegistry, options.GeometryShaderFileExtensions, contentTypeRegistry.GetContentType(ContentTypesGlsl.GeometryShader));
			RegisterFileExtensions(fileExtensionRegistry, options.ComputeShaderFileExtensions, contentTypeRegistry.GetContentType(ContentTypesGlsl.ComputeShader));
			RegisterFileExtensions(fileExtensionRegistry, options.TessControlShaderFileExtensions, contentTypeRegistry.GetContentType(ContentTypesGlsl.TessControlShader));
			RegisterFileExtensions(fileExtensionRegistry, options.TessEvaluationShaderFileExtensions, contentTypeRegistry.GetContentType(ContentTypesGlsl.TessEvaluationShader));
		}

		private static void RegisterFileExtensions(IFileExtensionRegistryService fileExtensionRegistry, string sExtensions, IContentType contentType)
		{
			var extensions = sExtensions.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (var ext in extensions)
			{
				try
				{
					fileExtensionRegistry.AddFileExtension(ext, contentType);
				}
				catch(InvalidOperationException)
				{
					var titel = "CG language integration";
					var message = $"{titel}:Extension {ext} is ignored because it is already registered " +
						$"with a different Visual Studio component. " +
						$"Please remove it from the {titel} options page!";
					VsStatusBar.SetText(message);
				}
			}
		}

		public override EditorOptionKey<string> Key => OptionKey;
	}
}
