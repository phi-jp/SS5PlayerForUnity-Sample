using UnityEngine;
using System.Collections;


namespace SSHelper {


    public class SSManager : MonoBehaviour {
        
        public GameObject[] effectViews;
        
        // Use this for initialization
        void Start () {
        }
        
        // Update is called once per frame
        void Update () {
            
        }
        
        // Create Effect
        public SSControl CreateEffect(string path, int index=0) {
            // control
            var controlObject = new GameObject();
            var effectView = this.effectViews [index];
            controlObject.transform.parent = effectView.transform;

            // effect
            var effectControl = (Resources.Load (path) as GameObject).GetComponent<Script_SpriteStudio_LinkPrefab>();
            var effectPrefab = effectControl.LinkPrefab as GameObject;
            var effectObject = Instantiate (effectPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
            effectObject.transform.parent = controlObject.transform;

            // ss control
            var control = controlObject.AddComponent<SSControl> ();
            var root = effectObject.GetComponent<Script_SpriteStudio_PartsRoot>();
            control.SetRoot (root);

            // set name
            controlObject.name = effectControl.name;
                
            return control;
        }
    }

}
