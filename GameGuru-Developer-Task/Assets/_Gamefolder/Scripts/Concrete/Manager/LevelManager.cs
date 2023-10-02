namespace GameGuruDevChallange.Managers
{
    public class LevelManager
    {
        int _baseCounterForSuccess = 4;
        int _levelInterval = 2;
        int _level;
        public int CurrentCountForSuccess => _baseCounterForSuccess + (_level * _levelInterval);

        public void LevelUp()
        {
            _level++;
        }

        public void ResetLevel()
        {
            _level = 0;
        }
    }
}