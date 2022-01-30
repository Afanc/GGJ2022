using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class PlayerController : KinematicObject
    {
		//public Gameplay.ItemManager ItemManager = gameObject.AddCompotent<ItemManager>();
        public int PlayerNumber; 
		public ItemManager ItemManager;
        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;

        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>

		//------------------
		//faut faire ça pour toutes les propriétés !!
        public float maxSpeed1 {get; set;}
        public float maxSpeed2 {get; set;}
        public float jumpTakeOffSpeed1 {get; set;}
        public float jumpTakeOffSpeed2 {get; set;}
        
        public float basemaxSpeed1 {get; set;} 
        public float basemaxSpeed2 {get; set;}
        public float basejumpTakeOffSpeed1 {get; set;}
        public float basejumpTakeOffSpeed2 {get; set;}


        //public Health health {get; set;}
		/// ---------------

        /// <summary>
        /// Initial jump velocity at the start of a jump.
        /// </summary>

        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
        /*internal new*/ public Collider2D collider2d;
        /*internal new*/ public AudioSource audioSource;
        public Health health;
        public bool controlEnabled = true;

        bool jump;
        Vector2 move;
        SpriteRenderer spriteRenderer;
        internal Animator animator;
        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Bounds Bounds => collider2d.bounds;

        void Awake()
        {
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
			ItemManager = GetComponent<ItemManager>();
        }

		protected override void Start()
		{
        this.basemaxSpeed1 = 2f;
        this.basemaxSpeed2 = 2f;
        this.basejumpTakeOffSpeed1 = 2f;
        this.basejumpTakeOffSpeed2 = 2f;
    	this.maxSpeed1 = basemaxSpeed1;
        this.maxSpeed2 = basemaxSpeed2;
        this.jumpTakeOffSpeed1 = basejumpTakeOffSpeed1;
        this.jumpTakeOffSpeed2 = basejumpTakeOffSpeed2;
		}

		public void update_item_properties()
		{
			foreach(Item i in ItemManager.items_container)
			{
                if (i.Is_active == 1)
                {
                    if (this.PlayerNumber == 1)
                    {
                        //string basename = "base"+i.Stat_name2;
                        //var basevalue = this.GetType().GetProperty(basename).GetValue(this, null);
	    			    this.GetType().GetProperty(i.Stat_name1).SetValue(this, i.Stat_value1);
                        //this.GetType().GetProperty(i.Stat_name2).SetValue(this, basevalue);
                    }
                    if (this.PlayerNumber == 2)
                    {
                        //string basename = "base"+i.Stat_name2;
                        //var basevalue = this.GetType().GetProperty(basename).GetValue(this, null);
                        //this.GetType().GetProperty(i.Stat_name1).SetValue(this, i.Stat_value1);
                        this.GetType().GetProperty(i.Stat_name2).SetValue(this, i.Stat_value2);
                    }
                }
                if (i.Is_active == 0)
                {
                    if (this.PlayerNumber == 2)
                    {
                        //string basename = "base"+i.Stat_name1;
                        //var basevalue = this.GetType().GetProperty(basename).GetValue(this, null);
                        this.GetType().GetProperty(i.Stat_name2).SetValue(this, i.Stat_value1);
                        //this.GetType().GetProperty(i.Stat_name1).SetValue(this, basevalue);
                    }
                    if (this.PlayerNumber == 1)
                    {
                        //string basename = "base"+i.Stat_name1;
                        //var basevalue = this.GetType().GetProperty(basename).GetValue(this, null);
                        //this.GetType().GetProperty(i.Stat_name2).SetValue(this, i.Stat_value2);
                        this.GetType().GetProperty(i.Stat_name1).SetValue(this, i.Stat_value2);
                    }
                }
            }
		}

        protected override void Update()
        {
			update_item_properties();
		
            if (controlEnabled)
            {
                move.x = Input.GetAxis("Horizontal");
                if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
                    jumpState = JumpState.PrepareToJump;
                else if (Input.GetButtonUp("Jump"))
                {
                    stopJump = true;
                    Schedule<PlayerStopJump>().player = this;
                }
            }
            else
            {
                move.x = 0;
            }
            UpdateJumpState();
            base.Update();
        }

        void UpdateJumpState()
        {
            jump = false;
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    jump = true;
                    stopJump = false;
                    break;
                case JumpState.Jumping:
                    if (!IsGrounded)
                    {
                        Schedule<PlayerJumped>().player = this;
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        Schedule<PlayerLanded>().player = this;
                        jumpState = JumpState.Landed;
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    break;
            }
        }

        protected override void ComputeVelocity()
        {
            if (jump && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed1 * model.jumpModifier;
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * model.jumpDeceleration;
                }
            }

            if (move.x > 0.01f)
                spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                spriteRenderer.flipX = true;

            animator.SetBool("grounded", IsGrounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed1);

            targetVelocity = move * maxSpeed1;
        }

        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }
    }
}
