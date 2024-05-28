using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
   // dont destroy on load
   // let only one be in scene
   public string sceneA = "SceneA";
   public string sceneB = "SceneB";
   public string sceneC = "SceneC";
   public string sceneD = "SceneD";
   public string sceneE = "SceneE";
   
   public static SceneChanger Instance { get; private set; }
   
   private void Awake()
   {
       if (Instance == null)
       {
           Instance = this;
           DontDestroyOnLoad(this);
       }
       else
       {
           Destroy(this);
       }
   }

   private void Update()
   {
       if (Input.GetKeyDown(KeyCode.Alpha1))
       {
           OpenScene(sceneA);
       }
       
       if (Input.GetKeyDown(KeyCode.Alpha2))
       {
           OpenScene(sceneB);
       }
       
       if (Input.GetKeyDown(KeyCode.Alpha3))
       {
           OpenScene(sceneC);
       }
       
       if (Input.GetKeyDown(KeyCode.Alpha4))
       {
           OpenScene(sceneD);
       }
       
       if (Input.GetKeyDown(KeyCode.Alpha5))
       {
           OpenScene(sceneE);
       }
   }
   
   
   void OpenScene(string sceneName)
   {
     SceneManager.LoadScene(sceneName);
   }

   private void OnGUI()
   {
        // show button instructions 
        GUI.Label(new Rect(10, 10, 200, 20), "Press 1, 2, 3, 4, or 5 to change scenes");
   }
}
