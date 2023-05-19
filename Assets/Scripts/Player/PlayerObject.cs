using UnityEngine;

namespace Player
{
    public class PlayerObject : MonoBehaviour
    {
        public Vector3 GetPosition() => 
            transform.position;

        public void SetPositionX(float xPosition)
        {
            Vector3 position = transform.position;
            
            transform.position = new Vector3(xPosition,
                                    position.y,
                                    position.z);
        }
    }
}