
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovieTest : MonoBehaviour {

	//enum Mode {
	//	Plane,
	//	RawImage
	//};

	////　PlaneとRawImageで切り替える
	//[SerializeField]
	//private Mode mode;
	////　再生する動画
	//[SerializeField]
	//private MovieTexture[] movies;
	////　音声再生コンポーネント
	//private AudioSource audioSource;
	////	再生する音声
	//[SerializeField]
	//private AudioClip[] audioClip;
	////　動画番号
	//private int num;

	//void Start () {
	//	//　最初の動画を設定
	//	num = 0;
	//	if(mode == Mode.Plane) {
	//		GetComponent<MeshRenderer>().material.mainTexture = movies[num];
	//	} else {
	//		GetComponent<RawImage>().texture = movies[num];
	//	}
	//	audioSource = GetComponent<AudioSource>();
	//	audioSource.clip = audioClip[num];
	//	//　動画をループ設定
	//	movies[num].loop = true;
	//}

	//void Update () {
		////　Sキーを押したら動画の再生とポーズを繰り返す
		//if(Input.GetKeyDown("s")) {
		//	if(movies[num].isPlaying) {
		//		movies[num].Pause();
		//		audioSource.Pause();

		//		Debug.Log("pause");
		//	} else {
		//		movies[num].Play();
		//		audioSource.Play();
		//		Debug.Log("start");
		//	}
		//	//　Qキーを押したら動画をストップ
		//} else if(Input.GetKeyDown("q")) {
		//	movies[num].Stop();
		//	audioSource.Stop();
		//	Debug.Log("stop");
		//} else if(Input.GetKeyDown("n")) {
		//	//　動画を切り替える前に今再生している動画を止める
		//	movies[num].Stop();
		//	audioSource.Stop();

		//	//　次の動画を指す
		//	num++;
		//	if(num >= movies.Length) {
		//		num = 0;
		//	}
		//	//　Textureを次のMovieTextureに変える
		//	if(mode == Mode.Plane) {
		//		GetComponent<MeshRenderer>().material.mainTexture = movies[num];
		//	} else {
		//		GetComponent<RawImage>().texture = movies[num];
		//	}
		//	//　動画をループに設定
		//	movies[num].loop = true;
		//	//　再生音声を変更
		//	audioSource.clip = audioClip[num];
		//	Debug.Log("change movie");
		//}
	//}
}