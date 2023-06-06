using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlaneGeneration : MonoBehaviour
{
    public NavMeshSurface navMeshSurface;

    public GameObject plane;
    public GameObject player;

    private int radius = 5;
    private int planeOffset = 10;

    private Vector3 startPos = new Vector3(0, 0, 0);

    private int XPlayerMove => (int)(player.transform.position.x - startPos.x);
    private int ZPlayerMove => (int)(player.transform.position.z - startPos.z);

    private int XPlayerLocation => (int)Mathf.Floor(player.transform.position.x / planeOffset) * planeOffset;
    private int ZPlayerLocation => (int)Mathf.Floor(player.transform.position.z / planeOffset) * planeOffset;

    Hashtable tilePlane = new Hashtable();

    float delay = 0.2f;
    int start = 0;
    void Update()
    {
        generateWorld();
        if(delay >= 0)
            delay -= Time.deltaTime;
    }

    private void generateWorld()
    {
        if (startPos == Vector3.zero)
        {
            for (int x = -radius; x < radius; x++)
            {
                for (int z = -radius; z < radius; z++)
                {
                    Vector3 pos = new Vector3((x * planeOffset + XPlayerLocation),
                    0,
                    (z * planeOffset + ZPlayerLocation));

                    if (!tilePlane.Contains(pos))
                    {
                        if (start <100 || delay < 0f)
                        {
                            GameObject tile = Instantiate(plane, pos, Quaternion.identity);
                            tilePlane.Add(pos, tile);
                            navMeshSurface.BuildNavMesh();
                            delay = 0.2f;
                            start++;
                        }
                    }
                }
            }
        }
        if (hasPlayerMoved(XPlayerMove, ZPlayerMove))
        {
            for (int x = -radius; x < radius; x++)
            {
                for (int z = -radius; z < radius; z++)
                {
                    Vector3 pos = new Vector3((x * planeOffset + XPlayerLocation),
                    0,
                    (z * planeOffset + ZPlayerLocation));

                    if (!tilePlane.Contains(pos))
                    {
                        GameObject tile = Instantiate(plane, pos, Quaternion.identity);
                        tilePlane.Add(pos, tile);
                    }
                }
            }
        }
    }

    private bool hasPlayerMoved(int playerX, int playerZ)
    {
        if (Mathf.Abs(XPlayerMove) >= planeOffset || Mathf.Abs(ZPlayerMove) >= planeOffset)
        {
            return true;
        }
        return false;
    }
    public void removeTileFromHash(Vector3 pos)
    {
        tilePlane.Remove(pos);
    }
}