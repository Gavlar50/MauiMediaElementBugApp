namespace MauiMediaElementBugApp
{
    public partial class MainPage : ContentPage
    {
        private IDispatcherTimer _timer;
        private double _playbackSpeed;

        public MainPage()
        {
            InitializeComponent();
            _playbackSpeed = 1.0;

            //TODO replace this with the absolute path to your video location - refer to the repo docs for sample videos to download for each use case
            MyPlayer.Source = "d:\\downloads\\gopro\\test-movie-with-sound.mp4";
            //MyPlayer.Source = "d:\\downloads\\gopro\\test-movie-no-sound.mp4";
        }

        private void MyPlayer_OnLoaded(object sender, EventArgs e)
        {
            _timer = Dispatcher.CreateTimer();
            _timer.Interval = TimeSpan.FromSeconds(2);
            _timer.Tick += Timer_Tick;
            _timer.Start();
            MyPlayer.Play();
        }

        // this simulates something like a cycling app where the playback speed increases relative to the original
        // as the user pedals faster, but the stuttering issue occurs when the video includes an audio track
        private void Timer_Tick(object sender, EventArgs e)
        {
            // note how every time this fires, a movie with sound will briefly stutter while the speed change occurs
            // replace the video with one that excludes an audio track and the speed increase is smooth
            _playbackSpeed += 0.05;
            MyPlayer.Speed = _playbackSpeed < 3 ? +_playbackSpeed : 3;
        }
    }
}
