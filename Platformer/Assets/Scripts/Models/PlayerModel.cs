
namespace Platformer
{
    public class PlayerModel
    {
        public float Speed;
        public float Force;
        public float AnimationSpeed;

        public IState CurentState;
        public bool IsOnGround;

        public PlayerModel(PlayerModelConfig playerConfig)
        {
            Speed = playerConfig.Speed;
            Force = playerConfig.Force;
            AnimationSpeed = playerConfig.AnimationSpeed;
        }
    }
}