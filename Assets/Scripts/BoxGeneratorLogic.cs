using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGeneratorLogic : MonoBehaviour
{
    private struct BoxInfo
    {
        public Vector3 pos;
        public float waitTime;
    }
    [SerializeField] private GameObject boxPrefab;

    private List<BoxInfo> LevelBoxRhythm = new List<BoxInfo>()
    {
        new BoxInfo()
        {
            pos = new Vector3(1.5f, 6f, 1),
            waitTime = 2f,
        },
        new BoxInfo()
        {
            pos = new Vector3(0, 6f, -1),
            waitTime = 0.2f,
        },
        new BoxInfo()
        {
            pos = new Vector3(-1.5f, 6f, 1),
            waitTime = 0.3f,
        },
        new BoxInfo()
        {
            pos = new Vector3(1.5f, 6f, -1),
            waitTime = 0.4f,
        }
    };

    void Start()
    {
            StartCoroutine(GenerateBox());
    }
    
    IEnumerator GenerateBox()
    {
        for (int i = 0; i < LevelBoxRhythm.Count; i++)
        {
            yield return new WaitForSeconds(LevelBoxRhythm[i].waitTime);
            Instantiate(boxPrefab, LevelBoxRhythm[i].pos, Quaternion.identity);
        }
    }
}
