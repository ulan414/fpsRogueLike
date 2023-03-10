// Copyright 2021, Infima Games. All Rights Reserved.

using System.Linq;
using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    [RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
    public class Movement : MovementBehaviour
    {
        #region FIELDS SERIALIZED

        [Header("Audio Clips")]

        [Tooltip("The audio clip that is played while walking.")]
        [SerializeField]
        private AudioClip audioClipWalking;

        [Tooltip("The audio clip that is played while running.")]
        [SerializeField]
        private AudioClip audioClipRunning;

        [Tooltip("The audio clip that is played while sliding.")]
        [SerializeField]
        private AudioClip audioClipSliding;

        [Header("Speeds")]

        [SerializeField]
        private float speedWalking = 5.0f;

        [SerializeField]
        private float jumpForce;

        [Tooltip("How fast the player moves while running."), SerializeField]
        private float speedRunning = 9.0f;

        [SerializeField]
        private bool canJump;

        [SerializeField]
        private float jumpDelay;

        [SerializeField]
        private float ySpeed;

        [SerializeField]
        private float slideTime;

        [SerializeField]
        private float slideSpeed;

        [SerializeField]
        public Transform groundCheckerTransform;
        public Transform groundCheckerTransform2;
        public LayerMask notPlayerMask;
        float lastNotGrounded = 0f;
        #endregion
        public bool isSlidingg = false;
        CapsuleCollider m_Capsule;
        #region PROPERTIES

        //Velocity.
        private Vector3 Velocity
        {
            //Getter.
            get => rigidBody.velocity;
            //Setter.
            set => rigidBody.velocity = value;
        }

        #endregion

        #region FIELDS

        /// <summary>
        /// Attached Rigidbody.
        /// </summary>
        private Rigidbody rigidBody;
        /// <summary>
        /// Attached CapsuleCollider.
        /// </summary>
        private CapsuleCollider capsule;
        /// <summary>
        /// Attached AudioSource.
        /// </summary>
        private AudioSource audioSource;

        /// <summary>
        /// True if the character is currently grounded.
        /// </summary>
        private bool grounded;

        /// <summary>
        /// Player Character.
        /// </summary>
        private CharacterBehaviour playerCharacter;
        /// <summary>
        /// The player character's equipped weapon.
        /// </summary>
        private WeaponBehaviour equippedWeapon;

        /// <summary>
        /// Array of RaycastHits used for ground checking.
        /// </summary>
        private readonly RaycastHit[] groundHits = new RaycastHit[8];
        public Vector3 movement;
        public Vector3 slide_dir_m;
        public float slide_time;

        #endregion

        #region UNITY FUNCTIONS

        /// <summary>
        /// Awake.
        /// </summary>
        protected override void Awake()
        {
            //Get Player Character.
            playerCharacter = ServiceLocator.Current.Get<IGameModeService>().GetPlayerCharacter();
        }

        /// Initializes the FpsController on start.
        protected override void Start()
        {
            m_Capsule = GetComponent<CapsuleCollider>();
            //Rigidbody Setup.
            rigidBody = GetComponent<Rigidbody>();
            rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
            //Cache the CapsuleCollider.
            capsule = GetComponent<CapsuleCollider>();

            //Audio Source Setup.
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = audioClipWalking;
            audioSource.loop = true;

            canJump = true;
            slide_time = slideTime;
        }
        public void SetSlideDir(Vector3 newSlideDir)
        {
            slide_dir_m = newSlideDir;
        }
        public void SetSliding(bool slidinggg)
        {
            isSlidingg = slidinggg;
        }
        /// Checks if the character is on the ground.
        /// 
        /*        private void OnCollisionStay()
                {
                    //Bounds.
                    Bounds bounds = capsule.bounds;
                    //Extents.
                    Vector3 extents = bounds.extents;
                    //Radius.
                    float radius = extents.x - 0.01f;

                    //Cast. This checks whether there is indeed ground, or not.
                    Physics.SphereCastNonAlloc(bounds.center, radius, Vector3.down,
                        groundHits, extents.y - radius * 0.5f, ~0, QueryTriggerInteraction.Ignore);

                    //We can ignore the rest if we don't have any proper hits.
                    if (!groundHits.Any(hit => hit.collider != null && hit.collider != capsule)) 
                        return;



                    //Store RaycastHits.
                    for (var i = 0; i < groundHits.Length; i++)
                        groundHits[i] = new RaycastHit();
                    grounded = true;
                    //Set grounded. Now we know for sure that we're grounded.

                }*/
        private void OnCollisionStay()
        {

        }
        protected override void FixedUpdate()
        {
            //Move.
                MoveCharacter();

            //Unground.
            //grounded = false;
        }

        /// Moves the camera to the character, processes jumping and plays sounds every frame.
        protected override void Update()
        {
            //Get the equipped weapon!
            equippedWeapon = playerCharacter.GetInventory().GetEquipped();
            /*            if ((Physics.Raycast(groundCheckerTransform.position, Vector3.down, 0.1f, notPlayerMask) && Physics.Raycast(groundCheckerTransform2.position, Vector3.down, 0.1f, notPlayerMask))
                            || (Time.time - lastNotGrounded > 2.7f && Velocity.y > -25f && lastNotGrounded != 0f))
                        {
                            grounded = true;
            *//*                Debug.DrawRay(groundCheckerTransform.position, Vector3.down, Color.red);
                            Debug.DrawRay(groundCheckerTransform2.position, Vector3.down, Color.red);*//*
                        }
                        else
                        {
                            if(grounded)
                            lastNotGrounded = Time.time;
                            Debug.Log("Not grounded");
                            grounded = false;
                        }*/
            //Debug.Log(Velocity.y);
            float m_GroundCheckDistance = 0.1f;
            Debug.DrawLine(
    m_Capsule.transform.position + m_Capsule.center + (Vector3.up * 0.1f),
    m_Capsule.transform.position + (Vector3.down * m_GroundCheckDistance),
    Color.red
);

            // 0.1f is a small offset to start the ray from inside the character
            // it is also good to note that the transform position in the sample assets is at the base of the character
            RaycastHit hitInfo;
            bool condition = Physics.SphereCast(
                m_Capsule.transform.position + m_Capsule.center + (Vector3.up * 0.1f),
                m_Capsule.height / 2,
                Vector3.down,
                out hitInfo,
                m_GroundCheckDistance
            );

            if (condition)
            {
                grounded = true;
            }
            else
            {
                grounded = false;
            }
            //Play Sounds!
            PlayFootstepSounds();
            JumpCharacter();
            
            Invoke(nameof(JumpWait), jumpDelay);
        }

        #endregion

        #region METHODS

        public void MoveCharacter()
        {
            #region Calculate Movement Velocity
            if (grounded)
            {
                //Get Movement Input!

                //Running speed calculation.


                if (!isSlidingg)
                {
                    Vector2 frameInput = playerCharacter.GetInputMovement();

                    //Calculate local-space direction by using the player's input.
                    movement = new Vector3(frameInput.x, 0.0f, frameInput.y);
                    slideSpeed = 1f;
                    if (playerCharacter.IsRunning())
                    {
                        movement *= speedRunning;
                    }
                    if (!playerCharacter.IsRunning())
                    {
                        //Multiply by the normal walking speed.
                        movement *= speedWalking;
                    }
                    movement = transform.TransformDirection(movement);
                }
                else
                {
                    slideSpeed = 2.2f;
                    movement = slide_dir_m;
                    slide_time -= Time.deltaTime;
                    if(slide_time <= 0)
                    {
                        isSlidingg = false;
                        slide_time = slideTime;
                    }
                }
                //World space velocity calculation. This allows us to add it to the rigidbody's velocity properly.
                movement = movement * slideSpeed;
                #endregion

                //Update Velocity.

                ySpeed = 0;
                Velocity = new Vector3(movement.x, 0.0f, movement.z);
            }
            else
            {
                ySpeed += Physics.gravity.y * Time.deltaTime;
                Velocity = new Vector3(rigidBody.velocity.x, ySpeed, rigidBody.velocity.z);
            }
        }
        private void JumpCharacter()
        {
            if (Input.GetKeyDown(KeyCode.Space) && grounded && canJump)
            {
                rigidBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
        }
        private void JumpWait()
        {
            canJump = true;
        }

        /// <summary>
        /// Plays Footstep Sounds. This code is slightly old, so may not be great, but it functions alright-y!
        /// </summary>
        private void PlayFootstepSounds()
        {
            //Check if we're moving on the ground. We don't need footsteps in the air.
            if (grounded && rigidBody.velocity.sqrMagnitude > 0.1f)
            {
                if (isSlidingg)
                {
                    audioSource.clip = audioClipSliding;
                }
                else
                {
                    //Select the correct audio clip to play.
                    audioSource.clip = playerCharacter.IsRunning() ? audioClipRunning : audioClipWalking;
                }
                    //Play it!
                    if (!audioSource.isPlaying)
                    {
                        audioSource.Play();
                    }
                
            }
            //Pause it if we're doing something like flying, or not moving!
            else if (audioSource.isPlaying)
                audioSource.Pause();
        }

        #endregion
    }
}