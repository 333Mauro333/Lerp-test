using UnityEngine;



namespace LerpTest
{
    public class Lerp : MonoBehaviour
    {
        [SerializeField] float destinyXPoint;
        [SerializeField] float endTime;

        float initialPoint;
        float wayDone;
        bool move;


        void Awake()
        {
            initialPoint = transform.position.x;
            wayDone = 0.0f;
            move = false;
        }


        void Update()
        {
            if (Input.GetButton("Move"))
            {
                StartLerp();
            }

            if (move)
            {
                TravelPath();
            }
        }


        void StartLerp()
        {
            move = true;
            initialPoint = transform.position.x;
        }
        void StopAndResetLerp()
        {
            move = false;
            wayDone = 0.0f;
        }
        void TravelPath()
        {
            float newX = Mathf.Lerp(initialPoint, destinyXPoint, wayDone);


            wayDone += Time.deltaTime / endTime;

            transform.position = new Vector3(newX, 0, 0);

            if (initialPoint < destinyXPoint)
            {
                if (transform.position.x >= destinyXPoint)
                {
                    StopAndResetLerp();
                }
            }
            else if (initialPoint > destinyXPoint)
            {
                if (transform.position.x <= destinyXPoint)
                {
                    StopAndResetLerp();
                }
            }
        }
    }
}
