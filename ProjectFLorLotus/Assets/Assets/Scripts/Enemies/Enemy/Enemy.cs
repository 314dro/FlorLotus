using StateMachine;
using UnityEngine;
using Drone;
namespace Enemy
{
    public class Enemy : BaseEnemy
    {
        public PatrolState patrolState;
        public new StateController<Enemy> stateController;

        protected override void Awake()
        {
            stateController = new StateController<Enemy>();

            patrolState = new PatrolState(this, stateController);
        }

        protected override void Start()
        {
            stateController.Initialize(patrolState);
        }

        protected override void Update()
        {
            stateController.currentState.FrameUpdate();
        }

        protected override void FixedUpdate()
        {
            stateController.currentState.PhysicsUpdate();
        }

        protected override void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                stateController.SwitchState(new AttackState(this, stateController, other.gameObject.GetComponent<CommonPlayer>()));
            }
        }

        protected override void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                stateController.SwitchState(new ChaseState(this, stateController, other.gameObject.GetComponent<CommonPlayer>()));
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //FindObjectOfType<AudioManager>().ToggleBattleMusic();
                FindObjectOfType<BattleManager>().AddEnemy(this.gameObject);
                stateController.SwitchState(new ChaseState(this, stateController, other.gameObject.GetComponent<CommonPlayer>()));
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //FindObjectOfType<AudioManager>().ToggleBattleMusic();
                FindObjectOfType<BattleManager>().RemoveEnemy(this.gameObject);
                stateController.SwitchState(patrolState);
            }
        }

        public override void FOVEnterSight(Transform entityInFOV)
        {
            throw new System.NotImplementedException();
        }

        public override void FOVExitSight()
        {
            throw new System.NotImplementedException();
        }
    }
}