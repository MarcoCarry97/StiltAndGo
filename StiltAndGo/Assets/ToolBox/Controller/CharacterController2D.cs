
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

        new private CircleCollider2D collider;

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
            collider = GetComponent<CircleCollider2D>();
            velocity = Vector3.zero;
        }

        private void Update()
        {
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
            Vector3 gravityVector = Physics2D.gravity*rigidBody.mass;
            if(jump)
            {
                int highJumpMultiplier = highJump ? 4 : 2;
                velocity.y = Mathf.Sqrt(highJumpMultiplier * jumpHeigh * Math.Abs(gravityVector.y));
                if (highJump)
                    velocity.y *= 2;

            }
            velocity.y += gravityVector.y * Time.deltaTime;
        }

        private void AdjustPosition()
        {
            List<Collider2D> colliders= Physics2D.OverlapCircleAll(transform.position, collider.radius, 0).ToList<Collider2D>();
            foreach(Collider2D hit in colliders)
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
                }
            }
        }

        private void FixedUpdate()
        {
            Vector2 vel = velocity * Time.fixedDeltaTime;
            rigidBody.MovePosition(rigidBody.position + vel);
            AdjustPosition();
        }

    }

}

