using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierGenerator : MonoBehaviour
{

    private float width = 6.66f;
    private float height = 10f;
    private float gapSize = 2.5f;

    private float distanceBeetwenPairs = 2.5f;
    private float speed = 2f;

    private bool shouldGenarate = true;

    private List<GameObject> cubes = new List<GameObject>();
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        GeneratePair();
        MoveCubes();
        CheckLastDistance();
        DestroyOffScreenCubes();
    }

    void GeneratePair()
    {
        if (shouldGenarate)
        {
            float downCubeHeight = Random.Range(1f, height - 3f);
            float topCubeHeight = height - gapSize - downCubeHeight;

            GameObject downCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            downCube.transform.localScale = new Vector3(1f, downCubeHeight, 1f);
            downCube.transform.position = new Vector3((width + downCube.transform.localScale.x) / 2, (-height + downCubeHeight) / 2, 0f);

            GameObject topCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            topCube.transform.localScale = new Vector3(1f, topCubeHeight, 1f);
            topCube.transform.position = new Vector3((width + topCube.transform.localScale.x) / 2, (height - topCubeHeight) / 2, 0f);

            cubes.Add(downCube);
            cubes.Add(topCube);

            shouldGenarate = false;
        }
    }

    void MoveCubes()
    {
        for (var i = 0; i < cubes.Count; i++)
        {
            cubes[i].transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    void CheckLastDistance()
    {
        if (cubes.Count > 0)
        {
            GameObject lastCube = cubes[cubes.Count - 1];
            if (lastCube.transform.position.x + lastCube.transform.localScale.x / 2 + distanceBeetwenPairs <= width / 2)
            {
                shouldGenarate = true;
            }
        }
    }

    void DestroyOffScreenCubes()
    {
        if (cubes.Count > 1)
        {
            GameObject firstCube = cubes[0];
            GameObject secondCube = cubes[1];
            if (firstCube.transform.position.x <= (-width - firstCube.transform.localScale.x) / 2)
            {
                cubes.Remove(firstCube);
                cubes.Remove(secondCube);
                Destroy(firstCube);
                Destroy(secondCube);
            }
        }
    }
}
