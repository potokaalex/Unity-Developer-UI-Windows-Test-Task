namespace CodeBase.Project.Services.AudioManagerService
{
    public interface IAudioManager
    {
        public void SetMusicActive(bool isActive);
        public void SetUISoundActive(bool isActive);
    }
}