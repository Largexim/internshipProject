using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGeneratorLogic : MonoBehaviour
{
    [SerializeField] private GameObject gameController;
    [SerializeField] private GameObject boxPrefab;
    float[] possibleValuesForPosition = { -1.5f, 0f, 1.5f, -1f, 1f};
    

    void Start()
    {
            StartCoroutine(GenerateBox());
    }
    
    IEnumerator GenerateBox()
    {
        while (true)
        {
            float gameSpeed = gameController.GetComponent<GameControllerLogic>().gameSpeed;
            float waitTime = 3/gameSpeed;
            float randomX = possibleValuesForPosition[UnityEngine.Random.Range(0, 3)];
            float randomZ = possibleValuesForPosition[UnityEngine.Random.Range(3, 5)];
            Vector3 pos = new Vector3(randomX, 6f, randomZ); 
            
            yield return new WaitForSeconds(waitTime);
            Instantiate(boxPrefab, pos, Quaternion.identity);
        }
    }
}
