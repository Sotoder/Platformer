
namespace Platformer
{
    public class PlayerModel
    {
        public readonly float Speed;
        public readonly float SprintModifier;
        public readonly float Force;
        public readonly float JumpForce;

        public int CurrentCountAirJumps;
        public float AnimationSpeed;
        public IState CurentState;
        public bool IsOnGround;
        public bool IsSprint;

        private int _maxCountAirJumps;
        public int MaxCountAirJumps { get => _maxCountAirJumps; }

        public PlayerModel(PlayerModelConfig playerConfig)
        {
            Speed = playerConfig.Speed;
            SprintModifier = playerConfig.SprintModifier;
            Force = playerConfig.Force;
            JumpForce = playerConfig.JumpForce;
            AnimationSpeed = playerConfig.AnimationSpeed;
            _maxCountAirJumps = playerConfig.CountAirJumps;
            CurrentCountAirJumps = playerConfig.CountAirJumps;
        }
    }
}