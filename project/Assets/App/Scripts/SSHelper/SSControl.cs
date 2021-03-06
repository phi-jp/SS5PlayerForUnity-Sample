﻿using UnityEngine;
using System.Collections;

namespace SSHelper {

    public class SSControl : MonoBehaviour {
        
        private Script_SpriteStudio_PartsRoot _root;
        
        public bool autoDestory = true;
        public System.Action<SSControl> onPlayEndCallback;
        public System.Action<SSControl, Library_SpriteStudio.KeyFrame.ValueUser.Data> onUserDataCallback;
        
        void Awake() {
        }

        public void SetRoot(Script_SpriteStudio_PartsRoot root) {
            this._root = root;
        }
        
        public void Play(int n, bool loop = false) {
            this._root.FunctionPlayEnd = this._OnPlayEndCallback;
            this._root.FunctionUserData = this._OnUserDataCallback;
            
            var timesPlay = (loop == true) ? 0 : 1;
            this._root.AnimationPlay (n, timesPlay, timesPlay);
        }
        
        public void Play(string name, bool loop = false) {
            var index = this._root.AnimationGetIndexNo (name);
            this.Play (index, loop);
        }

        public void Stop() {
            this._root.AnimationStop ();
        }

        public void SetTexture(Texture2D texture, bool useCache) {
            var materials = this._root.TableMaterial;
            
            if (useCache) {
                foreach (var material in materials) {
                    material.mainTexture = texture;
                }
            } else {
                var i = 0;
                foreach (var material in materials) {
                    var tempmaterial = new Material (material);
                    tempmaterial.mainTexture = texture;
                    materials [i++] = tempmaterial;
                }
            }
        }

        #region private
        private bool _OnPlayEndCallback(GameObject gameObject) {
            if (this.onPlayEndCallback != null) {
                this.onPlayEndCallback(this);
            }

            if (this.autoDestory == true) {
                this.Stop();
                Destroy (this.gameObject);
            }
            
            return false;
        }
        
        private void _OnUserDataCallback(GameObject gameObject, string PartsName, Library_SpriteStudio.AnimationData AnimationDataParts, int AnimationNo, int FrameNoDecode, int FrameNoKeyData, Library_SpriteStudio.KeyFrame.ValueUser.Data Data, bool FlagWayBack) {
            if (this.onUserDataCallback != null) {
                this.onUserDataCallback(this, Data);
            }
        }
        #endregion
    }   
}
