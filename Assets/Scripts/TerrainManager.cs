using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour {

	public Transform transAvatar;

	public float CONST = 500f;

	private int currentCount = 1;

	private LinkedList<GameObject> LinkedListObjTerrain; 
	public List<GameObject> ListObjTerrain; 

	// Use this for initialization
	void Start () {
		this.LinkedListObjTerrain = new LinkedList<GameObject>();
		foreach(GameObject obj in this.ListObjTerrain){
			this.LinkedListObjTerrain.AddLast(obj);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transAvatar.localPosition.z > CONST * currentCount){

			GameObject currentObj = this.LinkedListObjTerrain.First.Value;
			this.LinkedListObjTerrain.AddLast(Instantiate<GameObject>(currentObj, this.LinkedListObjTerrain.Last.Value.transform.position, currentObj.transform.rotation, currentObj.transform.parent));
			this.LinkedListObjTerrain.Last.Value.transform.position += new Vector3(0f,0f,CONST);
			GameObject firstObj = this.LinkedListObjTerrain.First.Value;
			this.LinkedListObjTerrain.RemoveFirst();
			Destroy(firstObj);
			this.currentCount++;
		}
	}
}
