using System.IO;
using UnityEditor;
using UnityEngine;

public static class ScriptableObjectLibrary
{
	private static readonly string ASSET_EXTENSION  = ".asset";
    private static readonly string ASSETS_PATH      = "Assets";
        

    /// <summary>
    /// 
    /// </summary>
    public static void CreateAsset<T>() where T : ScriptableObject
    {
        T asset = ScriptableObject.CreateInstance<T>();

        string path = AssetDatabase.GetAssetPath(Selection.activeObject);

        if (string.IsNullOrEmpty(path))
        {
            path = ASSETS_PATH;
        }
        else if (!string.IsNullOrEmpty(Path.GetExtension(path)))
        {
            path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), string.Empty);
        }

        if (!string.IsNullOrEmpty(path))
        {
            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/" + ScriptableObjectLibrary.GetTypeNameWithoutNamespace<T>() + ASSET_EXTENSION);

            AssetDatabase.CreateAsset(asset, assetPathAndName);
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
        else
        {
            UnityEngine.Debug.LogError("[CustomAssetUtility] Invalid asset path");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private static string GetTypeNameWithoutNamespace<T>()
    {
        string nameWithNamespace    = typeof(T).ToString();
        string[] parts              = nameWithNamespace.Split('.');

        return (parts.Length > 0 ? parts[parts.Length - 1] : nameWithNamespace);
    }
}

public class LibraryAssetEditor
{
	[MenuItem("Assets/Create/Recipe")]
	public static void CreateAssetCoverStatConfig()
	{
		ScriptableObjectLibrary.CreateAsset<RecipeAsset>();
	}
}
