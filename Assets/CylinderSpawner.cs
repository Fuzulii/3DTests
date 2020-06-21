using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderSpawner : MonoBehaviour
{
    public GameObject cyclinderPrefab;
    public int cyclinderBaseCount;
    Vector3[] _cyclinderPoses;
    Vector3 _cylinderDimensions;
    Vector3[] rowStartPoses;

    List<Vector3> goStartPosList = new List<Vector3>();
    void Start()
    {
        _cylinderDimensions = new Vector3(cyclinderPrefab.transform.localScale.x, cyclinderPrefab.transform.localScale.y, cyclinderPrefab.transform.localScale.z);
        SpawnCylinders();
    }

    void SpawnCylinders()
    {
        Vector3[] rowStartPoses = new Vector3[cyclinderBaseCount];
        if (rowStartPoses.Length % 2 == 0)
        {
            rowStartPoses[0] = new Vector3(-(_cylinderDimensions.x + 0.1f) * rowStartPoses.Length / 2, _cylinderDimensions.y, 0);
        }
        for (int i = 1; i < rowStartPoses.Length; i++)
        {
            rowStartPoses[i] = new Vector3(rowStartPoses[i - 1].x + (_cylinderDimensions.x + 0.1f) / 2f, rowStartPoses[i - 1].y + _cylinderDimensions.y * 2, 0);
        }

        int othersCount = rowStartPoses.Length - 1;

        for (int i = 0; i < rowStartPoses.Length; i++)
        {
            var go = Instantiate(cyclinderPrefab, transform);
            go.SetActive(true);
            go.transform.localPosition = rowStartPoses[i];
            goStartPosList.Add(go.transform.localPosition);

            for (int j = 0; j < othersCount; j++)
            {
                var go2 = Instantiate(cyclinderPrefab, transform);
                go2.SetActive(true);
                go2.transform.localPosition = rowStartPoses[i] + new Vector3((_cylinderDimensions.x + 0.1f) * (j + 1), 0, 0);
                goStartPosList.Add(go2.transform.localPosition);
            }
            othersCount--;
        }
    }

    public void SpawnRandomCylinder()
    {
        int randomIndex = Random.Range(0, goStartPosList.Count);

        var go2 = Instantiate(cyclinderPrefab, transform);
        go2.SetActive(true);
        go2.transform.localPosition = goStartPosList[randomIndex];
    }
}
