using UnityEngine;
using UnityEditor;

namespace UniGit.AIAssistant.Editor
{
    /// <summary>
    /// Helper class for AI-assisted level design operations
    /// </summary>
    public static class LevelDesignHelper
    {
        /// <summary>
        /// Creates a primitive GameObject at the specified position
        /// </summary>
        public static GameObject CreatePrimitive(PrimitiveType type, Vector3 position)
        {
            GameObject obj = GameObject.CreatePrimitive(type);
            obj.transform.position = position;
            obj.name = $"{type}_{System.DateTime.Now.Ticks % 10000}";
            
            Undo.RegisterCreatedObjectUndo(obj, "Create " + type);
            Selection.activeGameObject = obj;
            
            return obj;
        }

        /// <summary>
        /// Creates a grid of objects for level design
        /// </summary>
        public static GameObject[] CreateObjectGrid(int rows, int columns, float spacing, PrimitiveType type = PrimitiveType.Cube)
        {
            GameObject parent = new GameObject($"Grid_{rows}x{columns}");
            Undo.RegisterCreatedObjectUndo(parent, "Create Grid");
            
            GameObject[] objects = new GameObject[rows * columns];
            int index = 0;

            for (int x = 0; x < rows; x++)
            {
                for (int z = 0; z < columns; z++)
                {
                    Vector3 position = new Vector3(x * spacing, 0, z * spacing);
                    GameObject obj = GameObject.CreatePrimitive(type);
                    obj.transform.position = position;
                    obj.transform.parent = parent.transform;
                    obj.name = $"{type}_{x}_{z}";
                    
                    objects[index++] = obj;
                }
            }

            Selection.activeGameObject = parent;
            return objects;
        }

        /// <summary>
        /// Creates a light in the scene
        /// </summary>
        public static Light CreateLight(LightType type, Vector3 position)
        {
            GameObject lightObj = new GameObject($"{type}Light");
            lightObj.transform.position = position;
            
            Light light = lightObj.AddComponent<Light>();
            light.type = type;
            
            if (type == LightType.Directional)
            {
                lightObj.transform.rotation = Quaternion.Euler(50, -30, 0);
            }
            
            Undo.RegisterCreatedObjectUndo(lightObj, "Create Light");
            Selection.activeGameObject = lightObj;
            
            return light;
        }

        /// <summary>
        /// Creates an empty parent object for organization
        /// </summary>
        public static GameObject CreateEmptyParent(string name)
        {
            GameObject parent = new GameObject(name);
            Undo.RegisterCreatedObjectUndo(parent, "Create Parent");
            Selection.activeGameObject = parent;
            return parent;
        }

        /// <summary>
        /// Arranges selected objects in a line
        /// </summary>
        public static void ArrangeInLine(float spacing = 2f)
        {
            GameObject[] selected = Selection.gameObjects;
            if (selected.Length == 0) return;

            for (int i = 0; i < selected.Length; i++)
            {
                Undo.RecordObject(selected[i].transform, "Arrange in Line");
                selected[i].transform.position = new Vector3(i * spacing, 0, 0);
            }
        }

        /// <summary>
        /// Arranges selected objects in a circle
        /// </summary>
        public static void ArrangeInCircle(float radius = 5f)
        {
            GameObject[] selected = Selection.gameObjects;
            if (selected.Length == 0) return;

            float angleStep = 360f / selected.Length;

            for (int i = 0; i < selected.Length; i++)
            {
                Undo.RecordObject(selected[i].transform, "Arrange in Circle");
                float angle = i * angleStep * Mathf.Deg2Rad;
                selected[i].transform.position = new Vector3(
                    Mathf.Cos(angle) * radius,
                    0,
                    Mathf.Sin(angle) * radius
                );
            }
        }

        /// <summary>
        /// Creates a simple room/level layout
        /// </summary>
        public static GameObject CreateBasicRoom(float width = 10f, float depth = 10f, float height = 3f)
        {
            GameObject room = new GameObject("BasicRoom");
            Undo.RegisterCreatedObjectUndo(room, "Create Room");

            // Floor
            GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
            floor.name = "Floor";
            floor.transform.parent = room.transform;
            floor.transform.localScale = new Vector3(width, 0.1f, depth);
            floor.transform.localPosition = Vector3.zero;

            // Walls
            CreateWall("Wall_North", room.transform, new Vector3(0, height / 2, depth / 2), new Vector3(width, height, 0.1f));
            CreateWall("Wall_South", room.transform, new Vector3(0, height / 2, -depth / 2), new Vector3(width, height, 0.1f));
            CreateWall("Wall_East", room.transform, new Vector3(width / 2, height / 2, 0), new Vector3(0.1f, height, depth));
            CreateWall("Wall_West", room.transform, new Vector3(-width / 2, height / 2, 0), new Vector3(0.1f, height, depth));

            Selection.activeGameObject = room;
            return room;
        }

        private static GameObject CreateWall(string name, Transform parent, Vector3 position, Vector3 scale)
        {
            GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wall.name = name;
            wall.transform.parent = parent;
            wall.transform.localPosition = position;
            wall.transform.localScale = scale;
            return wall;
        }
    }
}
