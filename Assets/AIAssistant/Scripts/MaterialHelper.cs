using UnityEngine;
using UnityEditor;

namespace UniGit.AIAssistant.Editor
{
    /// <summary>
    /// Helper class for creating and managing materials
    /// </summary>
    public static class MaterialHelper
    {
        /// <summary>
        /// Creates a basic material with the specified color
        /// </summary>
        public static Material CreateBasicMaterial(string name, Color color)
        {
            Material material = new Material(Shader.Find("Standard"));
            material.name = name;
            material.color = color;
            
            // Save material to Assets folder
            string path = $"Assets/{name}.mat";
            AssetDatabase.CreateAsset(material, path);
            AssetDatabase.SaveAssets();
            
            return material;
        }

        /// <summary>
        /// Creates a PBR material with metallic and smoothness
        /// </summary>
        public static Material CreatePBRMaterial(string name, Color albedo, float metallic = 0f, float smoothness = 0.5f)
        {
            Material material = new Material(Shader.Find("Standard"));
            material.name = name;
            material.color = albedo;
            material.SetFloat("_Metallic", metallic);
            material.SetFloat("_Glossiness", smoothness);
            
            string path = $"Assets/{name}.mat";
            AssetDatabase.CreateAsset(material, path);
            AssetDatabase.SaveAssets();
            
            return material;
        }

        /// <summary>
        /// Creates an emissive material
        /// </summary>
        public static Material CreateEmissiveMaterial(string name, Color emissionColor, float intensity = 1f)
        {
            Material material = new Material(Shader.Find("Standard"));
            material.name = name;
            material.EnableKeyword("_EMISSION");
            material.SetColor("_EmissionColor", emissionColor * intensity);
            
            string path = $"Assets/{name}.mat";
            AssetDatabase.CreateAsset(material, path);
            AssetDatabase.SaveAssets();
            
            return material;
        }

        /// <summary>
        /// Applies a material to selected objects
        /// </summary>
        public static void ApplyMaterialToSelection(Material material)
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                Renderer renderer = obj.GetComponent<Renderer>();
                if (renderer != null)
                {
                    Undo.RecordObject(renderer, "Apply Material");
                    renderer.sharedMaterial = material;
                }
            }
        }

        /// <summary>
        /// Creates a transparent material
        /// </summary>
        public static Material CreateTransparentMaterial(string name, Color color, float alpha = 0.5f)
        {
            Material material = new Material(Shader.Find("Standard"));
            material.name = name;
            
            // Set rendering mode to transparent
            material.SetFloat("_Mode", 3);
            material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            material.SetInt("_ZWrite", 0);
            material.DisableKeyword("_ALPHATEST_ON");
            material.EnableKeyword("_ALPHABLEND_ON");
            material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            material.renderQueue = 3000;
            
            Color finalColor = color;
            finalColor.a = alpha;
            material.color = finalColor;
            
            string path = $"Assets/{name}.mat";
            AssetDatabase.CreateAsset(material, path);
            AssetDatabase.SaveAssets();
            
            return material;
        }
    }
}
