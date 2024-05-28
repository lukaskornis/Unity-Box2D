using UnityEngine;

public class WaterPour : MonoBehaviour
{
    public GameObject waterPrefab;

     void Update()
     {
          if (Input.GetMouseButton(0))
          {
                var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;
                var water = Instantiate(waterPrefab, mousePos, Quaternion.identity);
          }
     }
}