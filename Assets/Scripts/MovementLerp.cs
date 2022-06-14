using UnityEngine;


namespace LerpTest
{
    public class MovementLerp : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] string buttonName = "";
        [SerializeField] float timeToReach;

        [Header("References")]
        [SerializeField] GameObject objectToReach;

        Vector3 initialPosition;
        Vector3 destinyPosition;
        float wayDone;
        bool move;


        void Awake()
        {
            // Toma como valor inicial la posición actual del objeto y como posición de destino, la que tenga
            // el GameObject objectToReach.
            StabilizeValues();

            wayDone = 0.0f;
            move = false;
        }

        void Update()
        {
            CheckInput();
        }

        void FixedUpdate()
        {
            Movement();   
        }


        #region FUNCIONES PROPIAS

        void CheckInput()
        {
            if (Input.GetButton(buttonName))
            {
                StartLerp();
            }
        }
        void Movement()
        {
            if (move)
            {
                TravelPath();
            }
        }

        void StartLerp()
        {
            move = true;
            StabilizeValues();
        }
        void TravelPath()
        {
            float actualX = Mathf.Lerp(initialPosition.x, destinyPosition.x, wayDone);
            float actualY = Mathf.Lerp(initialPosition.y, destinyPosition.y, wayDone);
            float actualZ = Mathf.Lerp(initialPosition.z, destinyPosition.z, wayDone);


            transform.position = new Vector3(actualX, actualY, actualZ);

            wayDone += Time.deltaTime / timeToReach;

            if (transform.position == destinyPosition)
            {
                StopAndResetLerp();
            }
        }
        void StopAndResetLerp()
        {
            move = false;
            wayDone = 0.0f;
        }

        void StabilizeValues()
        {
            initialPosition = transform.position;
            destinyPosition = objectToReach.transform.position;
        }

        #endregion
    }
}
