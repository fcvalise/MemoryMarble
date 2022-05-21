using UnityEngine;

namespace MemoryMarbleAdditional
{
    public class LifeEmitter : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit[] hits;
                hits = Physics.RaycastAll(ray.origin, ray.direction);

                for (int i = 0; i < hits.Length; i++)
                {
                    RaycastHit hit = hits[i];
                    var memorySphere = hit.transform.GetComponent<MemorySphere>();

                    if (memorySphere)
                    {
                        memorySphere.ResetLife();
                    }
                }
            }
        }
    }
}
