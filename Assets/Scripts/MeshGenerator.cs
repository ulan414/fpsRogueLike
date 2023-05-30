using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;
    Vector3[] verticies;
    int[] triangles;

    public int xSize = 60;
    public int zSize = 60;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }
    void CreateShape()
    {
        verticies = new Vector3[(xSize + 1) * (zSize + 1)];
        float seed1 = Random.Range(0f, 5f);
        float seed2 = Random.Range(0f, 5f);
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * .1f + seed1, z * .1f + seed2) * 2f;

                if (x == 0 || x == xSize || z == 0 || z == zSize)
                {
                    y = 1f;
                }

                verticies[i] = new Vector3(x, y, z);
                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];
        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }
    }
    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = verticies;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }
}
