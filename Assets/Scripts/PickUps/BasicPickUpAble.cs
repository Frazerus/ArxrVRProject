using UnityEngine;

namespace PickUps
{
    public class BasicPickUpAble : MonoBehaviour
    {
        public PickUpEnum type;
        private Material _originalMat;
    
        public void Start()
        {
            _originalMat = GetComponent<Renderer>().material;
        }

        public void LookAt(Material lookAtMaterial)
        {
            GetComponent<Renderer>().material = lookAtMaterial;
        }

        public void PickUp()
        {
            GameEventSystem.current.PickUp(gameObject);
        }

        public void StopLookAt()
        {
            GetComponent<Renderer>().material = _originalMat;
        }

        public override string ToString()
        {
            return type.ToString();
        }
    }
}

