using UnityEngine;

namespace Player
{
    public class PlayerObject : MonoBehaviour
    {
        public Vector3 GetPosition() => 
            transform.position;

        public void Move(float horizontalDirection)
        {
            Vector3 position = transform.position;
            
            transform.position = new Vector3(position.x + horizontalDirection,
                                    position.y,
                                    position.z);
        }
    }
}