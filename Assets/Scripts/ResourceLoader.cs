using UnityEngine;

public class ResourceLoader : MonoBehaviour {

    private static ResourceLoader instance;
    public static ResourceLoader Instance {
        get {
            if(instance == null)
                instance = new ResourceLoader();
            return instance;
        }
    }

    /// <summary>
    /// 外部からのインスタンスの作成の禁止
    /// </summary>
    private ResourceLoader() { }


    /// <summary>
    /// pathと親を指定してプレハブをインスタンス化するクラス
    /// </summary>
    /// <returns>The create.</returns>
    /// <param name="path">Path.</param>
    /// <param name="parent">Parent.</param>
    /// <param name="isActive">If set to <c>true</c> is active.</param>
    /// <typeparam name="T">The 1st type parameter.</typeparam>
    public T Create<T>(string path, Transform parent, bool isActive = true){
        GameObject prefab = (GameObject)Resources.Load(path);

        GameObject instanceObject = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        instanceObject.transform.SetParent(parent, false);
        instanceObject.gameObject.SetActive(isActive);
        T component = instanceObject.GetComponent<T>();

        return component;
    }

}
