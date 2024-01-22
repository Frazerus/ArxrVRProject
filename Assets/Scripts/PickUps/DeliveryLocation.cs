using UnityEngine;

namespace PickUps
{
    public class DeliveryLocation : MonoBehaviour
    {
        public PickUpEnum type;
        private Material _originalMat;
        public bool allDeliverable = true;

        void Start()
        {
            _originalMat = GetComponent<Renderer>().material;
            if(allDeliverable)
                AssignAny();
        }
    
        public void LookAt(Material lookAtMaterial)
        {
            GetComponent<Renderer>().material = lookAtMaterial;
        }

        public void DeliverItem()
        {
            GameEventSystem.current.TryDropItem(type);
        }

        public void StopLookAt()
        {
            GetComponent<Renderer>().material = _originalMat;
        }

        private void AssignAny()
        {
            type = PickUpEnum.Any;
        }
    }
}
