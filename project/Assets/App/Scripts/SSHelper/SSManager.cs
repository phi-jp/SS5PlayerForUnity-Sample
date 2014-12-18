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
        public SSEffect CreateEffect(string path, int index=0) {
            var effectControl = (Resources.Load (path) as GameObject).GetComponent<Script_SpriteStudio_LinkPrefab>();
            var effectPrefab = effectControl.LinkPrefab as GameObject;
            var effectObject = Instantiate (effectPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
            var effectView = this.effectViews [index];
            effectObject.transform.parent = effectView.transform;
            effectObject.AddComponent<SSEffect> ();

            var ssEffect = effectObject.GetComponent<SSEffect> ();
            ssEffect.Stop ();
            
            return ssEffect;
        }
    }

}
