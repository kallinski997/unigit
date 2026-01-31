using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace UniGit.AIAssistant.Editor
{
    /// <summary>
    /// Template system for quick level generation
    /// </summary>
    public static class LevelTemplates
    {
        /// <summary>
        /// Creates a simple platformer level
        /// </summary>
        public static GameObject CreatePlatformerLevel()
        {
            GameObject level = new GameObject("PlatformerLevel");
            Undo.RegisterCreatedObjectUndo(level, "Create Platformer Level");

            // Ground
            GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            ground.name = "Ground";
            ground.transform.parent = level.transform;
            ground.transform.localScale = new Vector3(20, 1, 5);
            ground.transform.localPosition = new Vector3(0, -0.5f, 0);

            // Platforms
            CreatePlatform("Platform1", level.transform, new Vector3(5, 2, 0), new Vector3(3, 0.5f, 3));
            CreatePlatform("Platform2", level.transform, new Vector3(10, 4, 0), new Vector3(3, 0.5f, 3));
            CreatePlatform("Platform3", level.transform, new Vector3(15, 6, 0), new Vector3(3, 0.5f, 3));

            // Spawn point
            GameObject spawnPoint = new GameObject("SpawnPoint");
            spawnPoint.transform.parent = level.transform;
            spawnPoint.transform.localPosition = new Vector3(-8, 1, 0);

            // Goal
            GameObject goal = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            goal.name = "Goal";
            goal.transform.parent = level.transform;
            goal.transform.localPosition = new Vector3(18, 7, 0);
            goal.transform.localScale = new Vector3(1, 2, 1);

            Selection.activeGameObject = level;
            return level;
        }

        /// <summary>
        /// Creates a simple maze structure
        /// </summary>
        public static GameObject CreateMaze(int width = 10, int height = 10)
        {
            GameObject maze = new GameObject("Maze");
            Undo.RegisterCreatedObjectUndo(maze, "Create Maze");

            // Floor
            GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
            floor.name = "Floor";
            floor.transform.parent = maze.transform;
            floor.transform.localScale = new Vector3(width * 0.1f, 1, height * 0.1f);

            // Outer walls
            CreateMazeWall("NorthWall", maze.transform, new Vector3(0, 1.5f, height / 2), new Vector3(width, 3, 0.5f));
            CreateMazeWall("SouthWall", maze.transform, new Vector3(0, 1.5f, -height / 2), new Vector3(width, 3, 0.5f));
            CreateMazeWall("EastWall", maze.transform, new Vector3(width / 2, 1.5f, 0), new Vector3(0.5f, 3, height));
            CreateMazeWall("WestWall", maze.transform, new Vector3(-width / 2, 1.5f, 0), new Vector3(0.5f, 3, height));

            // Internal walls (simple pattern)
            for (int i = 1; i < width; i += 2)
            {
                CreateMazeWall($"Wall_{i}", maze.transform, 
                    new Vector3(i - width / 2, 1.5f, 0), 
                    new Vector3(0.5f, 3, height * 0.7f));
            }

            Selection.activeGameObject = maze;
            return maze;
        }

        /// <summary>
        /// Creates an arena/battle area
        /// </summary>
        public static GameObject CreateArena(float radius = 10f)
        {
            GameObject arena = new GameObject("Arena");
            Undo.RegisterCreatedObjectUndo(arena, "Create Arena");

            // Floor
            GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            floor.name = "Floor";
            floor.transform.parent = arena.transform;
            floor.transform.localScale = new Vector3(radius * 2, 0.1f, radius * 2);

            // Walls around the perimeter
            int wallCount = 16;
            for (int i = 0; i < wallCount; i++)
            {
                float angle = i * 360f / wallCount * Mathf.Deg2Rad;
                Vector3 position = new Vector3(
                    Mathf.Cos(angle) * radius,
                    1.5f,
                    Mathf.Sin(angle) * radius
                );

                GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                wall.name = $"Wall_{i}";
                wall.transform.parent = arena.transform;
                wall.transform.localPosition = position;
                wall.transform.localScale = new Vector3(1, 3, 0.5f);
                wall.transform.LookAt(arena.transform);
            }

            // Center pillar
            GameObject centerPillar = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            centerPillar.name = "CenterPillar";
            centerPillar.transform.parent = arena.transform;
            centerPillar.transform.localScale = new Vector3(2, 2, 2);
            centerPillar.transform.localPosition = Vector3.up;

            Selection.activeGameObject = arena;
            return arena;
        }

        /// <summary>
        /// Creates a simple race track
        /// </summary>
        public static GameObject CreateRaceTrack()
        {
            GameObject track = new GameObject("RaceTrack");
            Undo.RegisterCreatedObjectUndo(track, "Create Race Track");

            // Track segments
            List<Vector3> waypoints = new List<Vector3>
            {
                new Vector3(0, 0, 0),
                new Vector3(10, 0, 0),
                new Vector3(15, 0, 5),
                new Vector3(15, 0, 15),
                new Vector3(5, 0, 20),
                new Vector3(-5, 0, 20),
                new Vector3(-10, 0, 10),
                new Vector3(-5, 0, 5)
            };

            for (int i = 0; i < waypoints.Count; i++)
            {
                GameObject segment = GameObject.CreatePrimitive(PrimitiveType.Cube);
                segment.name = $"TrackSegment_{i}";
                segment.transform.parent = track.transform;
                segment.transform.localPosition = waypoints[i];
                segment.transform.localScale = new Vector3(5, 0.1f, 5);

                // Waypoint marker
                GameObject marker = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                marker.name = $"Waypoint_{i}";
                marker.transform.parent = track.transform;
                marker.transform.localPosition = waypoints[i] + Vector3.up * 2;
                marker.transform.localScale = Vector3.one * 0.5f;
            }

            Selection.activeGameObject = track;
            return track;
        }

        private static GameObject CreatePlatform(string name, Transform parent, Vector3 position, Vector3 scale)
        {
            GameObject platform = GameObject.CreatePrimitive(PrimitiveType.Cube);
            platform.name = name;
            platform.transform.parent = parent;
            platform.transform.localPosition = position;
            platform.transform.localScale = scale;
            return platform;
        }

        private static GameObject CreateMazeWall(string name, Transform parent, Vector3 position, Vector3 scale)
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
