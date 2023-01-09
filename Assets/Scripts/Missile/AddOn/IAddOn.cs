namespace Pawns.Player
{
    public interface IAddOn
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="missile"></param>
        /// <returns>소모 마나 코스트 양</returns>
        public float ControlMissile(Missile missile);
    }
}