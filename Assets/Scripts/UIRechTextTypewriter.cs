using System.Collections.Generic;
using System.Text.RegularExpressions;

public class UIRechTextTypewriter {
	
	/// <summary> タグなしのテキスト </summary>
	public string text { get; private set; }
	/// <summary> タグ情報 </summary>
	private string[] tags;
	/// <summary> タグが入るtextのidx </summary>
	private int[] tagIdx;

	/// <summary> テキストの文字長 </summary>
	public int Length {
		get {
			if (text == null) {
				return 0;
			}
			return text.Length;
		}
	}

	/// <summary> idx時の文字列（rechtext）</summary>
	public string this[ int idx ] {
		get {
			if (text == null || tags == null || tagIdx == null) {
				return null;
			}
			if (idx >= this.Length ) {
				idx = this.Length - 1;
			}
			System.Text.StringBuilder result = new System.Text.StringBuilder();
			result.Capacity = this.rechText.Length;
			int currentTagIdx = 0;
			for (int i = 0; i <= idx; i++) {
				while (tagIdx.Length > currentTagIdx && tagIdx [currentTagIdx].Equals (i)) {
					result.Append( tags[currentTagIdx] );
					currentTagIdx++;
				}
				result.Append( text [i] );
			}
			// タグは全て出力
			for( ; currentTagIdx<tags.Length; currentTagIdx++){
				result.Append( tags[currentTagIdx] );
			}
			return result.ToString();
		}
	}

	private string _rechText;
	/// <summary> 元テキスト（rechtext）</summary>
	public string rechText {
		get {
			return _rechText;
		}
		set{
//			if (_rechText == value) {
//				return;
//			}
			if (string.IsNullOrEmpty( value )) {
				this.text = null;
				this.tags = null;
				this.tagIdx = null;
				return;
			}
			this._rechText = value;
			Regex reg = new Regex(@"(</*[b|i|size|color].*?>)");
			string[] sp = reg.Split (value);
			System.Text.StringBuilder str = new System.Text.StringBuilder();

			str.Capacity = value.Length;

			List<string> tagList = new List<string> ();
			List<int> tagIdxList = new List<int> ();
			for (int i = 0, last = sp.Length; i < last; i++) {
				if (string.IsNullOrEmpty (sp [i])) {
					continue;
				}
				if (reg.IsMatch (sp [i])) {
					tagList.Add (sp [i]);
					tagIdxList.Add (str.Length);
				} else {
					str.Append(sp[i]);
				}
			}

			this.text = str.ToString();
			this.tags = tagList.ToArray ();
			this.tagIdx = tagIdxList.ToArray ();
		}
	}

	public UIRechTextTypewriter(){
	}
	public UIRechTextTypewriter(string input){
		this.rechText = input;
	}


	public static void SampleLogic(){
		string[] testStr = new string[]{
			"あ<color=green>いう<i>えおか</i><color=red>きくけこ</color>さしす</color>せそ",
			"<color=green>いう<i>えおか</i><color=red>きくけこ</color>さしす</color>",
			"あいうえおかきくけこさしすせそ",
			"<color=green><いう><i>えお>>か</i><j>じぇー</j><color=red>きくけこ</color>さしす</color>",
		};
		UIRechTextTypewriter rechTypeWriter = new UIRechTextTypewriter ();

		for (int t = 0; t < testStr.Length; t++) {
			rechTypeWriter.rechText = testStr [t];
			string result = "";
			for (int i = 0; i < rechTypeWriter.Length; i++) {
				result += string.Format ("{0:D2}::{1}\n", i, rechTypeWriter[i]);
			}
			UnityEngine.Debug.Log(result);
		}

	}
}