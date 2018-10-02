using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class UguiTypewriterAnimation : MonoBehaviour {

	[SerializeField] private Text text ;

	//const float TEXT_SPEED = 0.5f;
	float TEXT_SPEED_STRING = 0.08f;
	const float COMPLETE_LINE_DELAY = 0.3f;

	private UIRechTextTypewriter typewriter = new UIRechTextTypewriter();

	private bool _isEnd = false;

//	private bool isPlayng = false;
	private float _typeSpeed = 0f;  // 表示速度
	private Text _text;
	public Text Text
	{
		get{return _text ?? (_text = GetComponent<Text>()); }
	}

	public float TypewriterSpeed{
		set{ TEXT_SPEED_STRING = value;}
	}

	/// <summary>
	/// 文字表示終了判定
	/// </summary>
	/// <returns></returns>
	public bool IsEnd()
	{
		return _isEnd;
	}

	/// <summary>
	/// 文字数カウント初期化
	/// </summary>
	public void Initialize(string text, bool isType = true)
	{
		_isEnd = string.IsNullOrEmpty(text);
		if (this._isEnd) {
			this.typewriter.rechText = string.Empty;
			Text.text = string.Empty;
			this._typeSpeed = 0f;
			return;
		}

		this.typewriter.rechText = text;

		_typeSpeed = this.typewriter.Length * TEXT_SPEED_STRING;

		if (isType) {
			LineUpdate ();
		} else {
			ShowAllText ();
		}
	}

	/// <summary>
	/// 文字を少しずつ表示
	/// </summary>
	void LineUpdate()
	{
		iTween.ValueTo(this.gameObject, iTween.Hash(
			"from", 0,
			"to", this.typewriter.Length - 1, 
			"time", _typeSpeed, 
			"onupdate", "TextUpdate",
			"oncompletetarget", this.gameObject,
			"oncomplete", "typeEnd"
		));
	}

	public void typeEnd(){
		_isEnd = true;

//		isPlayng = false;
	}

	/// <summary>
	/// 表示文字更新
	/// </summary>
	/// <param name="lineCount">Line count.</param>
	void TextUpdate(int lineCount)
	{
		Text.text = this.typewriter [lineCount];
	}

	public void ShowAllText(){

		if (!_isEnd) {
			iTween.Stop (this.gameObject);
			TextUpdate (this.typewriter.Length - 1 ); // 全部表示

			_isEnd = true;
		}
	}
}
