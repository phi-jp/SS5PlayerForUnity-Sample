using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	public SSHelper.SSManager effectManager;

    private string[] _list;
    private SSHelper.SSControl _curentEffect;

	// Use this for initialization
	void Start () {
        this._list = new string[] {
            "effect001",
            "effect002",
            "effect003",
            "effect004",
            "effect005",
            "effect006",
            "effect007",
            "effect008",
            "effect009",
            "effect010",
            "effect011",
            "effect012",
        };
	}

    void ShowEffect(string name) {
        if (this._curentEffect != null) {
            Destroy(this._curentEffect.gameObject);
            this._curentEffect = null;
        }

        var fullname = System.String.Format("SpriteStudio/effect2/{0}_Control", name);
        this._curentEffect = effectManager.CreateEffect (fullname);
        this._curentEffect.Play (0);

        Debug.Log ("Play " + fullname);
    }

    void OnGUI () {

        // select
        var index = GUILayout.SelectionGrid (-1, this._list, 1, GUILayout.Width (200f));
        if (index != -1) {
            this.ShowEffect(this._list[index]);
        }

        // ボタンを表示する
        /*
        if (GUI.Button (new Rect (20, 20, 100, 50), "Button")) {
        }
        */
    }
	
	static void hoge(Script_SpriteStudio_PartsRoot root) {
		root.FunctionPlayEnd = null;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
