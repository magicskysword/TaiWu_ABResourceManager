using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class BuildEditorScript
{
    [MenuItem("Mod工具/打包Mod资源包")]
    public static void BuildModAssetBundles()
    {
        var outPath = "../Bundle";
        Directory.CreateDirectory(outPath);
        var abPath = Path.Combine(outPath, "asset.ab");
        
        var objects = new List<Object>();
        var objectNames = new List<string>();
        var buildResourceDir = "Assets/BuildResource/";
        foreach (var assetPath in AssetDatabase.GetAllAssetPaths())
        {
            if (assetPath.StartsWith(buildResourceDir))
            {
                objects.Add(AssetDatabase.LoadAssetAtPath<Object>(assetPath));
                var name = assetPath.Substring(buildResourceDir.Length);
                objectNames.Add(name);
                Debug.Log("收集资源：" + name);
            }
        }

        BuildPipeline.BuildAssetBundleExplicitAssetNames(objects.ToArray(), objectNames.ToArray(),
            abPath, BuildAssetBundleOptions.CollectDependencies
                    | BuildAssetBundleOptions.ChunkBasedCompression
                    | BuildAssetBundleOptions.ForceRebuildAssetBundle, 
            BuildTarget.StandaloneWindows64);
        Debug.Log($"打包完成，资源包目录：{Path.GetFullPath(abPath)}");
    }
}
