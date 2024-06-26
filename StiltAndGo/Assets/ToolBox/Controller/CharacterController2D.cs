
using UnityEngine;
using System;
using ToolBox.Core;
using System.Linq;
using System.Collections.Generic;

namespace ToolBox.Control.Explorer2D
{


    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public partial class CharacterController2D : MonoBehaviour
    {

        private Vector3 direction;

        private Rigidbody2D rigidBody;

        new private Collider2D collider;

        private bool grounded;

        private Vector3 velocity;

        [SerializeField]
        [Range(0, 20)]
        private float speed;

        [SerializeField]
        [Range(0,20)]
        private float acceleration;

        [SerializeField]
        [Range(0, 10)]
        private float jumpHeigh;

        private bool highJump;

        private bool jump;

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public void Move(Vector3 direction)
        {
            this.direction = direction;
        }

        public void HighJump(bool jump)
        {
            highJump = jump;
        }

        public void Jump(bool jump)
        {
            this.jump = jump;
        }

        private void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            collider = GetComponent<Collider2D>();
            velocity = Vector3.zero;
            grounded = false;
        }

        private void Update()
        {
            print("Velocity: "+velocity);
            print("High jump: " + highJump);
            ComputeVelocityX();
            ComputeVelocityY();
        }

        private void ComputeVelocityX()
        {
            if (direction.x != 0)
            {
                velocity.x = Mathf.MoveTowards(velocity.x, speed * direction.x, acceleration * Time.deltaTime);
            }
            else
            {
                velocity.x = Mathf.MoveTowards(velocity.x, 0, acceleration * Time.deltaTime);
            }
        }

        private void ComputeVelocityY()
        {
            int highJumpMultiplier = highJump ? 4 : 2;
            Vector3 gravityVector = Physics2D.gravity*rigidBody.mass;
            if (jump)
            {
                velocity.y = Mathf.Sqrt(highJumpMultiplier * jumpHeigh * Math.Abs(gravityVector.y));
            }
            if (highJump && grounded)
                velocity.y *= 2;
            velocity.y += gravityVector.y * Time.deltaTime;
        }

        private void AdjustPosition()
        {
            List<Collider2D> colliders;
            if(collider is CircleCollider2D)
            {
                CircleCollider2D circle=collider as CircleCollider2D;
                colliders = Physics2D.OverlapCircleAll(transform.position, circle.radius, 0).ToList<Collider2D>();
            }
            else
            {

                BoxCollider2D box = collider as BoxCollider2D;
                colliders = Physics2D.OverlapCircleAll(transform.position, box.size.x, 0).ToList<Collider2D>();
            }
            foreach (Collider2D hit in colliders)
            {
                if(hit!=collider)
                {
                    ColliderDistance2D distance = hit.Distance(collider);
                    if(distance.isOverlapped)
                    {
                        Vector2 vector = distance.pointA - distance.pointB;
                        Vector2 pos = rigidBody.position + vector;
                        rigidBody.MovePosition(pos);
                    }
                    if (Vector2.Angle(distance.normal, Vector2.up) < 90 && velocity.y < 0)
                    {
                        grounded = true;
                    }
                    else grounded = false;
                }
            }
        }

        public bool IsGrounded()
        {
            return grounded;
        }

        private void FixedUpdate()
        {
            Vector2 vel = velocity * Time.fixedDeltaTime;
            rigidBody.MovePosition(rigidBody.position + vel);
            AdjustPosition();
        }

    }

}

