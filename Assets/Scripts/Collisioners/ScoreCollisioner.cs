using UnityEngine;

namespace Gameplay
{
    public class ScoreCollisioner : ICollisioner
    {
        public void Collide(Collision2D collision)
        {
            var resetable = collision.gameObject.GetComponent<IResetable>();
            if (resetable != null)
            {
                ScoreManager.Inst?.IncreaseScore(1);
                resetable.Reset();
            }
        }
    }
}