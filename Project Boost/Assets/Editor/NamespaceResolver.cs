using System;
using System.IO;

using UnityEditor;

namespace ProjectBoost.Editor
{
    public sealed class NamespaceResolver : UnityEditor.AssetModificationProcessor 
    {
        public static void OnWillCreateAsset(string metaFilePath)
        {
            if (string.IsNullOrEmpty(EditorSettings.projectGenerationRootNamespace))
                throw new ArgumentException("Root Namespace must be set for the Project.\n\t\tEdit -> Project Settings -> Editor -> Root Namespace");
            
            string fileName = Path.GetFileNameWithoutExtension(metaFilePath);
            string directory = Path.GetDirectoryName(metaFilePath);

            if (!fileName.EndsWith(".cs") || string.IsNullOrEmpty(directory)) return;

            string[] segmentedPath = directory.Split(Path.PathSeparator);
            
            string finalNamespace = EditorSettings.projectGenerationRootNamespace;

            // In case of placing the class at the root of a folder such as (Editor, Scripts, etc...)  
            if (segmentedPath.Length > 2)
            {
                string generatedNamespace = string.Empty;
                
                // Skipping the Assets folder and a single subfolder (i.e. Scripts, Editor, Plugins, etc...)
                for (int i = 2; i < segmentedPath.Length; i++)
                {
                    generatedNamespace +=
                        i == segmentedPath.Length - 1
                            ? segmentedPath[i]
                            : $"{segmentedPath[i]}."; // Don't add '.' at the end of the namespace
                }
                
                finalNamespace = $"{EditorSettings.projectGenerationRootNamespace}.{generatedNamespace}";
            }
            
            string actualFile = Path.Combine(directory, fileName);
            string content = File.ReadAllText(actualFile);
            string newContent = content.Replace("#NAMESPACE#", finalNamespace);

            if (content == newContent) return;
        
            File.WriteAllText(actualFile, newContent);
            AssetDatabase.Refresh();
        }
    }
}