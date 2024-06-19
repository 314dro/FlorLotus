using Enemy;
using UnityEngine;

namespace TurretEnemy
{
    public class TurretEnemy : BaseEnemy
    {
        [SerializeField]
        private Bullet bullet;

        [SerializeField]
        [Range(0f, 1f)]
        private float shootingPower = 1f;
        public new StateMachine.StateController<TurretEnemy> stateController;

        protected override void Awake()
        {
            stateController = new StateMachine.StateController<TurretEnemy>();
            stateController.Initialize(new PatrolState(this, stateController));
        }

        protected override void Update()
        {
            stateController.currentState.FrameUpdate();
        }

        protected override void FixedUpdate()
        {
            stateController.currentState.PhysicsUpdate();
        }

        public override void FOVEnterSight(Transform entityInFOV)
        {
            if (entityInFOV.CompareTag("Player") && this.stateController.currentState.GetType() == typeof(PatrolState))
            {
                FindObjectOfType<BattleManager>().AddEnemy(this.gameObject);
                //FindObjectOfType<AudioManager>().ToggleBattleMusic();
                this.stateController.SwitchState(new AttackState(this, stateController, entityInFOV));
            }
        }

        public override void FOVExitSight()
        {
            //FindObjectOfType<AudioManager>().ToggleBattleMusic();
            FindObjectOfType<BattleManager>().RemoveEnemy(this.gameObject);
            this.stateController.SwitchState(new PatrolState(this, stateController));
        }

        public void Shoot(Vector3 direction)
        {
            var bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);

            bulletInstance.GetComponent<Rigidbody2D>().velocity = direction.normalized * shootingPower * 10;
        }
    }
}
