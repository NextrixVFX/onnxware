using UnityEngine;

namespace onnxware.Components.Visual
{
    public static class Renderer
    {
        public static void DrawBoundingBox(Bounds bounds, Camera cam)
        {
            Vector3 center = bounds.center;
            Vector3 size = bounds.size;

            // vertex containing each corner of a box
            Vector3[] vertex = new Vector3[]
            {
                center + new Vector3(-size.x, -size.y, -size.z) * 0.5f, // 0
                center + new Vector3( size.x, -size.y, -size.z) * 0.5f, // 1
                center + new Vector3( size.x, -size.y,  size.z) * 0.5f, // 2
                center + new Vector3(-size.x, -size.y,  size.z) * 0.5f, // 3
                center + new Vector3(-size.x,  size.y, -size.z) * 0.5f, // 4
                center + new Vector3( size.x,  size.y, -size.z) * 0.5f, // 5
                center + new Vector3( size.x,  size.y,  size.z) * 0.5f, // 6
                center + new Vector3(-size.x,  size.y,  size.z) * 0.5f, // 7
            };

            // convert worldspace to screenspace
            Vector3[] screenCoords = new Vector3[8];
            for (int i = 0; i < 8; i++)
            {
                screenCoords[i] = cam.WorldToScreenPoint(vertex[i]);
            }

            // connecting edges of the box
            int[,] edges = new int[,]
            {
                {0, 1}, {1, 2}, {2, 3}, {3, 0}, // bottom face
                {4, 5}, {5, 6}, {6, 7}, {7, 4}, // top face
                {0, 4}, {1, 5}, {2, 6}, {3, 7}  // vertical edges
            };

            // Draw each edge
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                DrawLine(screenCoords[edges[i, 0]], screenCoords[edges[i, 1]]);
            }
        }

        public static void DrawLine(Vector3 start, Vector3 end)
        {
            if (start.z > 0f && end.z > 0f)
            { GL.Vertex3(start.x, start.y, 0f); GL.Vertex3(end.x, end.y, 0f); }
        }
    }
}
