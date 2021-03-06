/************************************************************************************
Copyright : Copyright (c) Facebook Technologies, LLC and its affiliates. All rights reserved.

Your use of this SDK or tool is subject to the Oculus SDK License Agreement, available at
https://developer.oculus.com/licenses/oculussdk/

Unless required by applicable law or agreed to in writing, the Utilities SDK distributed
under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF
ANY KIND, either express or implied. See the License for the specific language governing
permissions and limitations under the License.
************************************************************************************/

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Oculus.Interaction
{
    [Serializable]
    public struct MaterialPropertyVector
    {
        public string name;
        public Vector4 value;
    }

    [Serializable]
    public struct MaterialPropertyColor
    {
        public string name;
        public Color value;
    }

    [Serializable]
    public struct MaterialPropertyFloat
    {
        public string name;
        public float value;
    }

    [ExecuteAlways]
    public class MaterialPropertyBlockEditor : MonoBehaviour
    {
        [SerializeField]
        private List<Renderer> _renderers;

        [SerializeField]
        private List<MaterialPropertyVector> _vectorProperties;

        [SerializeField]
        private List<MaterialPropertyColor> _colorProperties;

        [SerializeField]
        private List<MaterialPropertyFloat> _floatProperties;

        public List<Renderer> Renderers => _renderers;
        public List<MaterialPropertyVector> VectorProperties => _vectorProperties;
        public List<MaterialPropertyColor> ColorProperties => _colorProperties;
        public List<MaterialPropertyFloat> FloatProperties => _floatProperties;

        private MaterialPropertyBlock _materialPropertyBlock = null;

        protected virtual void Awake()
        {
            if (_renderers == null)
            {
                Renderer renderer = GetComponent<Renderer>();
                if (renderer != null)
                {
                    _renderers = new List<Renderer>()
                    {
                        renderer
                    };
                }
            }
            UpdateMaterialPropertyBlock();
        }

        protected virtual void Start()
        {
            UpdateMaterialPropertyBlock();
        }

        public MaterialPropertyBlock MaterialPropertyBlock
        {
            get
            {
                if (_materialPropertyBlock == null)
                {
                    _materialPropertyBlock = new MaterialPropertyBlock();
                }

                return _materialPropertyBlock;
            }
        }

        public void UpdateMaterialPropertyBlock()
        {
            var materialPropertyBlock = MaterialPropertyBlock;

            if (_vectorProperties != null)
            {
                foreach (var property in _vectorProperties)
                {
                    _materialPropertyBlock.SetVector(property.name, property.value);
                }
            }

            if (_colorProperties != null)
            {
                foreach (var property in _colorProperties)
                {
                    _materialPropertyBlock.SetColor(property.name, property.value);
                }
            }

            if (_floatProperties != null)
            {
                foreach (var property in _floatProperties)
                {
                    _materialPropertyBlock.SetFloat(property.name, property.value);
                }
            }

            if (_renderers != null)
            {
                foreach (Renderer renderer in _renderers)
                {
                    renderer.SetPropertyBlock(materialPropertyBlock);
                }
            }
        }

        protected virtual void Update()
        {
            UpdateMaterialPropertyBlock();
        }
    }
}
