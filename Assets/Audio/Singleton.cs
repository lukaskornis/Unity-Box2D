using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	static T instance;
	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				instance = GameObject.FindObjectOfType<T>();
			}

			if (instance == null)
			{
				var obj = new GameObject(typeof(T).Name);
				instance = obj.AddComponent<T>();
				Object.DontDestroyOnLoad(obj);
			}

			return instance;
		}
	}
}